using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeFileManagementSystem.Models;

namespace OfficeFileManagementSystem.Controllers
{
    public class ImportancesController : Controller
    {
        private readonly ApplicationDbSet _context;

        public ImportancesController()
        {
            _context = new ApplicationDbSet();
        }

        // GET: Importances
        public async Task<IActionResult> Index()
        {
              return _context.importances != null ? 
                          View(await _context.importances.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbSet.importances'  is null.");
        }

        // GET: Importances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.importances == null)
            {
                return NotFound();
            }

            var importance = await _context.importances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importance == null)
            {
                return NotFound();
            }

            return View(importance);
        }

        // GET: Importances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Importances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Description,Days_Allowed")] Importance importance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importance);
        }

        // GET: Importances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.importances == null)
            {
                return NotFound();
            }

            var importance = await _context.importances.FindAsync(id);
            if (importance == null)
            {
                return NotFound();
            }
            return View(importance);
        }

        // POST: Importances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Description,Days_Allowed")] Importance importance)
        {
            if (id != importance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportanceExists(importance.Id))
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
            return View(importance);
        }

        // GET: Importances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.importances == null)
            {
                return NotFound();
            }

            var importance = await _context.importances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importance == null)
            {
                return NotFound();
            }

            return View(importance);
        }

        // POST: Importances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.importances == null)
            {
                return Problem("Entity set 'ApplicationDbSet.importances'  is null.");
            }
            var importance = await _context.importances.FindAsync(id);
            if (importance != null)
            {
                _context.importances.Remove(importance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportanceExists(int id)
        {
          return (_context.importances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
