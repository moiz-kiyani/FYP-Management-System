using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPSystem.Data;
using FYPSystem.Models;
using FYPSystem.Data.Migrations;

namespace FYPSystem.Controllers.Student
{
    public class StudentIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentIdeas
        public async Task<IActionResult> Index()
        {
            string email = HttpContext.User.Identity.Name;
            var GetCurrentLoggedInStudent= await _context.Student.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();

            var applicationDbContext = await _context.StudentIdeas.Include(i => i.Student).Where(x => x.StudentId == GetCurrentLoggedInStudent.Id).ToListAsync();
            if (applicationDbContext.Any())
            {
                return View(applicationDbContext);
            }
            else
            {
                var InitializeWithNull = new List<StudentIdeas>();
                return View(InitializeWithNull);
            }
        }

        // GET: StudentIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        // GET: StudentIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StudentName,StudentRollNo,StudentId")] StudentIdeas studentIdeas)
        {
            string email = HttpContext.User.Identity.Name;
            var Student = await _context.Student.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();
            
            studentIdeas.StudentId = Student.Id;
            studentIdeas.StudentName = Student.StudentName;
            studentIdeas.StudentRollNo = Student.RollNo;
            studentIdeas.Student = Student;
            //if (ModelState.IsValid)
            //{
            _context.Add(studentIdeas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            ViewData["SupervisorId"] = new SelectList(_context.Student, "Id", "Id", studentIdeas.Student);
            return View(studentIdeas);
        }

        // GET: StudentIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var StudentIdeas = await _context.StudentIdeas.Include(x => x.Student).Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(StudentIdeas);
        }

        // POST: StudentIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StudentName,StudentRollNo,StudentId")] StudentIdeas studentIdeas)
        {
            _context.Update(studentIdeas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

        // GET: StudentIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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

        // POST: StudentIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var StudentIdeas = await _context.StudentIdeas.FindAsync(id);
            _context.StudentIdeas.Remove(StudentIdeas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentIdeasExists(int id)
        {
          return _context.StudentIdeas.Any(e => e.Id == id);
        }
    }
}
