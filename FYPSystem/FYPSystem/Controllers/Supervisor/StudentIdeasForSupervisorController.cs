using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPSystem.Data;
using FYPSystem.Models;

namespace FYPSystem.Controllers.Supervisor
{
    public class StudentIdeasForSupervisorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentIdeasForSupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentIdeasForSupervisor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentIdeas.Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentIdeasForSupervisor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentIdeas == null)
            {
                return NotFound();
            }

            var studentIdeas = await _context.StudentIdeas
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentIdeas == null)
            {
                return NotFound();
            }

            return View(studentIdeas);
        }

        // GET: StudentIdeasForSupervisor/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: StudentIdeasForSupervisor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StudentName,StudentRollNo,StudentId")] StudentIdeas studentIdeas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentIdeas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentIdeas.StudentId);
            return View(studentIdeas);
        }

        // GET: StudentIdeasForSupervisor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentIdeas == null)
            {
                return NotFound();
            }

            var studentIdeas = await _context.StudentIdeas.FindAsync(id);
            if (studentIdeas == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentIdeas.StudentId);
            return View(studentIdeas);
        }

        // POST: StudentIdeasForSupervisor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StudentName,StudentRollNo,StudentId")] StudentIdeas studentIdeas)
        {
            if (id != studentIdeas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentIdeas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentIdeasExists(studentIdeas.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentIdeas.StudentId);
            return View(studentIdeas);
        }

        // GET: StudentIdeasForSupervisor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentIdeas == null)
            {
                return NotFound();
            }

            var studentIdeas = await _context.StudentIdeas
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentIdeas == null)
            {
                return NotFound();
            }

            return View(studentIdeas);
        }

        // POST: StudentIdeasForSupervisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentIdeas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentIdeas'  is null.");
            }
            var studentIdeas = await _context.StudentIdeas.FindAsync(id);
            if (studentIdeas != null)
            {
                _context.StudentIdeas.Remove(studentIdeas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentIdeasExists(int id)
        {
          return _context.StudentIdeas.Any(e => e.Id == id);
        }
    }
}
