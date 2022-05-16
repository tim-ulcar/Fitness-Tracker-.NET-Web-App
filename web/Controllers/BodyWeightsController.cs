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
    public class BodyWeightsController : Controller
    {
        private readonly FitnessTrackerContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public BodyWeightsController(FitnessTrackerContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: BodyWeights
        public async Task<IActionResult> Index()
        {
            return View(await _context.BodyWeights.ToListAsync());
        }

        // GET: BodyWeights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyWeight = await _context.BodyWeights
                .FirstOrDefaultAsync(m => m.bodyWeightId == id);
            if (bodyWeight == null)
            {
                return NotFound();
            }

            return View(bodyWeight);
        }

        // GET: BodyWeights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyWeights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bodyWeightId,time,weight,bodyFat")] BodyWeight bodyWeight)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                bodyWeight.userId = currentUser;
                _context.Add(bodyWeight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyWeight);
        }

        // GET: BodyWeights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyWeight = await _context.BodyWeights.FindAsync(id);
            if (bodyWeight == null)
            {
                return NotFound();
            }
            return View(bodyWeight);
        }

        // POST: BodyWeights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bodyWeightId,userId,time,weight,bodyFat")] BodyWeight bodyWeight)
        {
            if (id != bodyWeight.bodyWeightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyWeight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyWeightExists(bodyWeight.bodyWeightId))
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
            return View(bodyWeight);
        }

        // GET: BodyWeights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyWeight = await _context.BodyWeights
                .FirstOrDefaultAsync(m => m.bodyWeightId == id);
            if (bodyWeight == null)
            {
                return NotFound();
            }

            return View(bodyWeight);
        }

        // POST: BodyWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyWeight = await _context.BodyWeights.FindAsync(id);
            _context.BodyWeights.Remove(bodyWeight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyWeightExists(int id)
        {
            return _context.BodyWeights.Any(e => e.bodyWeightId == id);
        }
    }
}
