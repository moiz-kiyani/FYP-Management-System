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
    public class SupervisorEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupervisorEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupervisorEvaluations
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Evaluation.ToListAsync());
            
            //if (GetOnlyThoseStudentEvaluationModelsWhereIamSupervisor.Any())
            //{
            //    return View(GetOnlyThoseStudentEvaluationModelsWhereIamSupervisor);
            //}
            //else
            //{
            //    return RedirectToAction("YouHaveToBeSupervisorOfSomeGroupFirst");
            //}

        }

        public IActionResult YouHaveToBeSupervisorOfSomeGroupFirst()
        {
            return View();
        }

        // GET: SupervisorEvaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: SupervisorEvaluations/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: SupervisorEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evaluation evaluation)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        public async Task<IActionResult> Evaluate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Evaluate(int id, Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }


            try
            {
                //evaluation.TotalMarks = evaluation.TotalMarks + evaluation.PosterMarks;
                //evaluation.TotalMarks = evaluation.TotalMarks + evaluation.ProposalMarks;
                evaluation.TotalMarks = evaluation.TotalMarks + evaluation.SupervisorMarks;
                _context.Update(evaluation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(evaluation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        // GET: SupervisorEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        // POST: SupervisorEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        public async Task<IActionResult> RemoveMarks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMarks(int id, Evaluation evaluation)
        {
            //var evaluation = await _context.Evaluations.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            try

            {
                evaluation.TotalMarks -= evaluation.SupervisorMarks;
                evaluation.SupervisorMarks = 0;
                _context.Update(evaluation);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(evaluation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", evaluation.StudentId);
            return View(evaluation);
        }

        // GET: SupervisorEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: SupervisorEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.Evaluation.FindAsync(id);
            _context.Evaluation.Remove(evaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
          return _context.Evaluation.Any(e => e.Id == id);
        }
    }
}
