using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vbBlog.Models;

namespace vbBlog
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = this._config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute()
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "identity",
                    areaName: "Identity",
                    template: "Identity/{controller=Home}/{action=Index}/{id?}"
                    );
                routes.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
            CreateRoles(services).Wait();
        }
        private async Task CreateRoles(IServiceProvider services)
        {
            var rolemanager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var roleCheck = await rolemanager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                await rolemanager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}
