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
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbSet _context;

        public AssignmentsController(ApplicationDbSet context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
              return _context.assignments != null ? 
                          View(await _context.assignments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbSet.assignments'  is null.");
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.assignments
                .FirstOrDefaultAsync(m => m.Assignment_Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Assignment_Id,Employee_Id,Date_Allowed,Incoming_File_Id")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Assignment_Id,Employee_Id,Date_Allowed,Incoming_File_Id")] Assignment assignment)
        {
            if (id != assignment.Assignment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Assignment_Id))
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
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.assignments
                .FirstOrDefaultAsync(m => m.Assignment_Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.assignments == null)
            {
                return Problem("Entity set 'ApplicationDbSet.assignments'  is null.");
            }
            var assignment = await _context.assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.assignments.Remove(assignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
          return (_context.assignments?.Any(e => e.Assignment_Id == id)).GetValueOrDefault();
        }
    }
}
