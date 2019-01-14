using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vbBlog.Areas.Identity.Data;
using vbBlog.Models;

[assembly: HostingStartup(typeof(vbBlog.Areas.Identity.IdentityHostingStartup))]
namespace vbBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<vbBlogContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("vbBlogContextConnection")));

                //services.AddDefaultIdentity<vbBlogUser>()
                services.AddIdentity<vbBlogUser, IdentityRole>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<vbBlogContext>();
            });
        }
    }
}