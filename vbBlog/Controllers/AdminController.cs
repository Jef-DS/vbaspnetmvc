using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vbBlog.Areas.Identity.Data;
using vbBlog.Models;

namespace vbBlog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController:Controller
    {
        private readonly UserManager<vbBlogUser> userManager;

        public AdminController(UserManager<vbBlogUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ViewResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            IList<vbBlogUser> adminUsers = await userManager.GetUsersInRoleAsync("Admin");
            IList<vbBlogUser> allUsers = await userManager.Users.ToListAsync();
            IList<BlogUserViewModel> users = new List<BlogUserViewModel>();
            foreach(vbBlogUser user in allUsers)
            {
                BlogUserViewModel blogUserVM = new BlogUserViewModel
                {
                    User = user,
                    IsAdmin = adminUsers.Contains(user)
                };
                users.Add(blogUserVM);
            }
            return View(users); 
        }
        public async Task<IActionResult> VoegToeAanAdmin(string id)
        {
            vbBlogUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> VerwijderUitAdmin(string id)
        {
            vbBlogUser user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

    }
}
