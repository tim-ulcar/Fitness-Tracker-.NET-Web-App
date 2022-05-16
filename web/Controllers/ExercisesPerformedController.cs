using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace web.Controllers
{
    [Authorize]
    public class ExercisesPerformedController : Controller
    {
        private readonly FitnessTrackerContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ExercisesPerformedController(FitnessTrackerContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: ExercisesPerformed
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExercisesPerformed.ToListAsync());
        }

        // GET: ExercisesPerformed/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisePerformed = await _context.ExercisesPerformed
                .FirstOrDefaultAsync(m => m.exercisePerformedId == id);
            if (exercisePerformed == null)
            {
                return NotFound();
            }

            return View(exercisePerformed);
        }

        // GET: ExercisesPerformed/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExercisesPerformed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("exercisePerformedId,exerciseName,time,weight,sets,reps")] ExercisePerformed exercisePerformed)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            
            if (ModelState.IsValid)
            {
                exercisePerformed.userId = currentUser;
                _context.Add(exercisePerformed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercisePerformed);
        }

        // GET: ExercisesPerformed/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisePerformed = await _context.ExercisesPerformed.FindAsync(id);
            if (exercisePerformed == null)
            {
                return NotFound();
            }
            return View(exercisePerformed);
        }

        // POST: ExercisesPerformed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("exercisePerformedId,userId,exerciseName,time,weight,sets,reps")] ExercisePerformed exercisePerformed)
        {
            if (id != exercisePerformed.exercisePerformedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercisePerformed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercisePerformedExists(exercisePerformed.exercisePerformedId))
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
            return View(exercisePerformed);
        }

        // GET: ExercisesPerformed/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisePerformed = await _context.ExercisesPerformed
                .FirstOrDefaultAsync(m => m.exercisePerformedId == id);
            if (exercisePerformed == null)
            {
                return NotFound();
            }

            return View(exercisePerformed);
        }

        // POST: ExercisesPerformed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercisePerformed = await _context.ExercisesPerformed.FindAsync(id);
            _context.ExercisesPerformed.Remove(exercisePerformed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercisePerformedExists(int id)
        {
            return _context.ExercisesPerformed.Any(e => e.exercisePerformedId == id);
        }
    }
}
