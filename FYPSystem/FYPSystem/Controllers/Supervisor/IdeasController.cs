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
    public class IdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ideas
        public async Task<IActionResult> Index()
        {
            string email = HttpContext.User.Identity.Name;
            var GetCurrentLoggedInSupervisor = await _context.supervisor.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();

            var applicationDbContext = await _context.Ideas.Include(i => i.supervisor).Where(x => x.SupervisorId == GetCurrentLoggedInSupervisor.Id).ToListAsync();
            if (applicationDbContext.Any())
            {
                return View(applicationDbContext);
            }
            else
            {
                var InitializeWithNull = new List<Ideas>();
                return View(InitializeWithNull);
            }
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
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Ideas ideas)
        {
            string email = HttpContext.User.Identity.Name;
            var supervisor = await _context.supervisor.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();
            ideas.Approved = "Pending";
            ideas.AssignedStatus = "No";
            ideas.CreatedAt = DateTime.Now; 
            ideas.SupervisorId = supervisor.Id;
            ideas.SupervisorName = supervisor.SupervisorName;
            ideas.SupervisorShift = supervisor.Shift;
            ideas.supervisor = supervisor;
            //if (ModelState.IsValid)
            //{
                _context.Add(ideas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["SupervisorId"] = new SelectList(_context.supervisor, "Id", "Id", ideas.SupervisorId);
            return View(ideas);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var ideas = await _context.Ideas.Include(x => x.supervisor).Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(ideas);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ideas ideas)
        {

            _context.Update(ideas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ideas = await _context.Ideas.FindAsync(id);
            _context.Ideas.Remove(ideas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeasExists(int id)
        {
            return _context.Ideas.Any(e => e.Id == id);
        }
    }
}
