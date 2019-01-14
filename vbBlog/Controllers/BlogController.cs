using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vbBlog.Models;

namespace vbBlog.Controllers
{
    public class BlogController:Controller
    {
        private readonly DataContext _ctx;
        public BlogController(DataContext ctx)
        {
            this._ctx = ctx;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ctx.Blog.ToListAsync());
        }
        public ViewResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                this._ctx.Blog.Add(blog);
                await this._ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var blog = await this._ctx.Blog.FirstOrDefaultAsync<Blog>(b => b.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Blog.Update(blog);
                    await this._ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var blog = await this._ctx.Blog.SingleOrDefaultAsync<Blog>(b => b.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BevestigDelete(int id)
        {
            var blog = await this._ctx.Blog.SingleOrDefaultAsync<Blog>(b => b.Id == id);
            this._ctx.Blog.Remove(blog);
            await this._ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BlogExists(int id)
        {
            return this._ctx.Blog.Any(b => b.Id == id);
        }
    }
}
