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
    public class OutgoingFilesController : Controller
    {
        private readonly ApplicationDbSet _context;

        public OutgoingFilesController(ApplicationDbSet context)
        {
            _context = context;
        }

        // GET: OutgoingFiles
        public async Task<IActionResult> Index()
        {
              return _context.outgoingFiles != null ? 
                          View(await _context.outgoingFiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbSet.outgoingFiles'  is null.");
        }

        // GET: OutgoingFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.outgoingFiles == null)
            {
                return NotFound();
            }

            var outgoingFile = await _context.outgoingFiles
                .FirstOrDefaultAsync(m => m.Out_Id == id);
            if (outgoingFile == null)
            {
                return NotFound();
            }

            return View(outgoingFile);
        }

        // GET: OutgoingFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OutgoingFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Out_Id,Emp_Id,Incoming_File_Id,Date_Allowed")] OutgoingFile outgoingFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outgoingFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outgoingFile);
        }

        // GET: OutgoingFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.outgoingFiles == null)
            {
                return NotFound();
            }

            var outgoingFile = await _context.outgoingFiles.FindAsync(id);
            if (outgoingFile == null)
            {
                return NotFound();
            }
            return View(outgoingFile);
        }

        // POST: OutgoingFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Out_Id,Emp_Id,Incoming_File_Id,Date_Allowed")] OutgoingFile outgoingFile)
        {
            if (id != outgoingFile.Out_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outgoingFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutgoingFileExists(outgoingFile.Out_Id))
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
            return View(outgoingFile);
        }

        // GET: OutgoingFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.outgoingFiles == null)
            {
                return NotFound();
            }

            var outgoingFile = await _context.outgoingFiles
                .FirstOrDefaultAsync(m => m.Out_Id == id);
            if (outgoingFile == null)
            {
                return NotFound();
            }

            return View(outgoingFile);
        }

        // POST: OutgoingFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.outgoingFiles == null)
            {
                return Problem("Entity set 'ApplicationDbSet.outgoingFiles'  is null.");
            }
            var outgoingFile = await _context.outgoingFiles.FindAsync(id);
            if (outgoingFile != null)
            {
                _context.outgoingFiles.Remove(outgoingFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutgoingFileExists(int id)
        {
          return (_context.outgoingFiles?.Any(e => e.Out_Id == id)).GetValueOrDefault();
        }
    }
}
