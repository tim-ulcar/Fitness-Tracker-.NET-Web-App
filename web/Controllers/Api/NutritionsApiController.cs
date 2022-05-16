using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Filters;

namespace web.Controllers_Api
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class NutritionsApiController : ControllerBase
    {
        private readonly FitnessTrackerContext _context;

        public NutritionsApiController(FitnessTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Nutritions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutrition>>> GetNutritions()
        {
            return await _context.Nutritions.ToListAsync();
        }

        // GET: api/Nutritions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutrition>> GetNutrition(int id)
        {
            var nutrition = await _context.Nutritions.FindAsync(id);

            if (nutrition == null)
            {
                return NotFound();
            }

            return nutrition;
        }

        // PUT: api/Nutritions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutrition(int id, Nutrition nutrition)
        {
            if (id != nutrition.nutritionId)
            {
                return BadRequest();
            }

            _context.Entry(nutrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Nutritions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nutrition>> PostNutrition(Nutrition nutrition)
        {
            _context.Nutritions.Add(nutrition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutrition", new { id = nutrition.nutritionId }, nutrition);
        }

        // DELETE: api/Nutritions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nutrition>> DeleteNutrition(int id)
        {
            var nutrition = await _context.Nutritions.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }

            _context.Nutritions.Remove(nutrition);
            await _context.SaveChangesAsync();

            return nutrition;
        }

        private bool NutritionExists(int id)
        {
            return _context.Nutritions.Any(e => e.nutritionId == id);
        }
    }
}
