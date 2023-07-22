using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeFileManagementSystem.Models;

namespace OfficeFileManagementSystem.Controllers
{
    public class IncomingFilesController : Controller
    {
        private readonly ApplicationDbSet _context;

        public IncomingFilesController()
        {
            _context = new ApplicationDbSet();
            
        }


        // GET: IncomingFiles
        public async Task<IActionResult> Index()
        {
            ViewBag.Impt = await _context.importances.ToListAsync();   
            return _context.incomingFiles != null ? View(await _context.incomingFiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbSet.incomingFiles'  is null.");
        }

        // GET: IncomingFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.incomingFiles == null)
            {
                return NotFound();
            }

            

            var incomingFile = await _context.incomingFiles
                .FirstOrDefaultAsync(m => m.Incoming_File_Id == id);
            
            if (incomingFile == null)
            {
                return NotFound();
            }
            var importance = await _context.importances.FirstOrDefaultAsync(m => m.Id == incomingFile.Importance_ID);
            ViewBag.impt = importance.Type.ToString();
            return View(incomingFile);
        }

        // GET: IncomingFiles/Create
        public IActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in _context.importances) {
                SelectListItem listitem = new SelectListItem
                {
                    Text=item.Type,
                    Value=item.Id.ToString(),
                };

            list.Add(listitem); 
            }
            ViewBag.dropdown=list;
            return View();
        }

        // POST: IncomingFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Incoming_File_Id,FileName,Date_Allowed,FileType,Importance_ID")] IncomingFile incomingFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(incomingFile);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e) { 
                            Console.WriteLine(e.ToString());    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incomingFile);
        }

        // GET: IncomingFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.incomingFiles == null)
            {
                return NotFound();
            }

            var incomingFile = await _context.incomingFiles.FindAsync(id);
            if (incomingFile == null)
            {
                return NotFound();
            }
            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var i in _context.importances) { 
                SelectListItem selectListItem = new SelectListItem { 
                        Value = i.Id.ToString(),
                        Text =  i.Type
                };
                
                List.Add(selectListItem);
                       
            }
            ViewBag.List = List;
            
            
            return View(incomingFile);
        }

        // POST: IncomingFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Incoming_File_Id,FileName,Date_Allowed,FileType,Importance_ID")] IncomingFile incomingFile)
        {
            if (id != incomingFile.Incoming_File_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomingFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomingFileExists(incomingFile.Incoming_File_Id))
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
            return View(incomingFile);
        }

        // GET: IncomingFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.incomingFiles == null)
            {
                return NotFound();
            }

            var incomingFile = await _context.incomingFiles
                .FirstOrDefaultAsync(m => m.Incoming_File_Id == id);
            if (incomingFile == null)
            {
                return NotFound();
            }

            return View(incomingFile);
        }

        // POST: IncomingFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.incomingFiles == null)
            {
                return Problem("Entity set 'ApplicationDbSet.incomingFiles'  is null.");
            }
            var incomingFile = await _context.incomingFiles.FindAsync(id);
            if (incomingFile != null)
            {
                _context.incomingFiles.Remove(incomingFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomingFileExists(int id)
        {
          return (_context.incomingFiles?.Any(e => e.Incoming_File_Id == id)).GetValueOrDefault();
        }
    }
}
