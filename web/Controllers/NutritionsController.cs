using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Identity;

namespace web.Controllers
{
    [Authorize]
    public class NutritionsController : Controller
    {
        private readonly FitnessTrackerContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public NutritionsController(FitnessTrackerContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: Nutritions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nutritions.ToListAsync());
        }

        // GET: Nutritions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutritions
                .FirstOrDefaultAsync(m => m.nutritionId == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // GET: Nutritions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nutritions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nutritionId,time,calories,protein,carbohydrates,fat")] Nutrition nutrition)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                nutrition.userId = currentUser;
                _context.Add(nutrition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutrition);
        }

        // GET: Nutritions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutritions.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }
            return View(nutrition);
        }

        // POST: Nutritions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nutritionId,userId,time,calories,protein,carbohydrates,fat")] Nutrition nutrition)
        {
            if (id != nutrition.nutritionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutrition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionExists(nutrition.nutritionId))
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
            return View(nutrition);
        }

        // GET: Nutritions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutritions
                .FirstOrDefaultAsync(m => m.nutritionId == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // POST: Nutritions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutrition = await _context.Nutritions.FindAsync(id);
            _context.Nutritions.Remove(nutrition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutritionExists(int id)
        {
            return _context.Nutritions.Any(e => e.nutritionId == id);
        }
    }
}
