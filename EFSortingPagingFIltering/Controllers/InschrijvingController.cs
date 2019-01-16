using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSortingPagingFIltering.Data;
using EFSortingPagingFIltering.Models;

namespace EFSortingPagingFIltering.Controllers
{
    public class InschrijvingController : Controller
    {
        private readonly OpleidingContext _context;

        public InschrijvingController(OpleidingContext context)
        {
            _context = context;
        }

        // GET: Inschrijving
        public async Task<IActionResult> Index()
        {
            var opleidingContext = _context.Inschrijvingen.Include(i => i.Cursus).Include(i => i.Student);
            return View(await opleidingContext.ToListAsync());
        }

        // GET: Inschrijving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Cursus)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijving/Create
        public IActionResult Create()
        {
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Naam");
            ViewData["StudentId"] = new SelectList(_context.Studenten, "Id", "Naam");
            return View();
        }

        // POST: Inschrijving/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CursusId,StudentId,Punten")] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Id", inschrijving.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "Id", "Id", inschrijving.StudentId);
            return View(inschrijving);
        }

        // GET: Inschrijving/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Id", inschrijving.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "Id", "Id", inschrijving.StudentId);
            return View(inschrijving);
        }

        // POST: Inschrijving/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CursusId,StudentId,Punten")] Inschrijving inschrijving)
        {
            if (id != inschrijving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.Id))
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
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Id", inschrijving.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "Id", "Id", inschrijving.StudentId);
            return View(inschrijving);
        }

        // GET: Inschrijving/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Cursus)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijvingen.Any(e => e.Id == id);
        }
    }
}
