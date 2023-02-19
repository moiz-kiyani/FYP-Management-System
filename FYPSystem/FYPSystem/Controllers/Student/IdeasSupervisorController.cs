using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPSystem.Data;
using FYPSystem.Models;

namespace FYPSystem.Controllers.Student
{
    public class IdeasSupervisorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeasSupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ideas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ideas.Include(i => i.supervisor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ideas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideas = await _context.Ideas
                .Include(i => i.supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideas == null)
            {
                return NotFound();
            }

            return View(ideas);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            ViewData["SupervisorId"] = new SelectList(_context.supervisor, "Id", "Id");
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Approved,AssignedStatus,SupervisorName,SupervisorShift,CreatedAt,SupervisorId")] Ideas ideas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ideas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupervisorId"] = new SelectList(_context.supervisor, "Id", "Id", ideas.SupervisorId);
            return View(ideas);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ideas == null)
            {
                return NotFound();
            }

            var ideas = await _context.Ideas.FindAsync(id);
            if (ideas == null)
            {
                return NotFound();
            }
            ViewData["SupervisorId"] = new SelectList(_context.supervisor, "Id", "Id", ideas.SupervisorId);
            return View(ideas);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Approved,AssignedStatus,SupervisorName,SupervisorShift,CreatedAt,SupervisorId")] Ideas ideas)
        {
            if (id != ideas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeasExists(ideas.Id))
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
            ViewData["SupervisorId"] = new SelectList(_context.supervisor, "Id", "Id", ideas.SupervisorId);
            return View(ideas);
        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ideas == null)
            {
                return NotFound();
            }

            var ideas = await _context.Ideas
                .Include(i => i.supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideas == null)
            {
                return NotFound();
            }

            return View(ideas);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ideas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ideas'  is null.");
            }
            var ideas = await _context.Ideas.FindAsync(id);
            if (ideas != null)
            {
                _context.Ideas.Remove(ideas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeasExists(int id)
        {
          return _context.Ideas.Any(e => e.Id == id);
        }
    }
}
