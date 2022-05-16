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
    public class BodyWeightsApiController : ControllerBase
    {
        private readonly FitnessTrackerContext _context;

        public BodyWeightsApiController(FitnessTrackerContext context)
        {
            _context = context;
        }

        // GET: api/BodyWeightsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyWeight>>> GetBodyWeights()
        {
            return await _context.BodyWeights.ToListAsync();
        }

        // GET: api/BodyWeightsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyWeight>> GetBodyWeight(int id)
        {
            var bodyWeight = await _context.BodyWeights.FindAsync(id);

            if (bodyWeight == null)
            {
                return NotFound();
            }

            return bodyWeight;
        }

        // PUT: api/BodyWeightsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyWeight(int id, BodyWeight bodyWeight)
        {
            if (id != bodyWeight.bodyWeightId)
            {
                return BadRequest();
            }

            _context.Entry(bodyWeight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyWeightExists(id))
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

        // POST: api/BodyWeightsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BodyWeight>> PostBodyWeight(BodyWeight bodyWeight)
        {
            _context.BodyWeights.Add(bodyWeight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodyWeight", new { id = bodyWeight.bodyWeightId }, bodyWeight);
        }

        // DELETE: api/BodyWeightsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyWeight>> DeleteBodyWeight(int id)
        {
            var bodyWeight = await _context.BodyWeights.FindAsync(id);
            if (bodyWeight == null)
            {
                return NotFound();
            }

            _context.BodyWeights.Remove(bodyWeight);
            await _context.SaveChangesAsync();

            return bodyWeight;
        }

        private bool BodyWeightExists(int id)
        {
            return _context.BodyWeights.Any(e => e.bodyWeightId == id);
        }
    }
}
