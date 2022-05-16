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
    public class ExercisesPerformedApiController : ControllerBase
    {
        private readonly FitnessTrackerContext _context;

        public ExercisesPerformedApiController(FitnessTrackerContext context)
        {
            _context = context;
        }

        // GET: api/ExercisesPerformedApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercisePerformed>>> GetExercisesPerformed()
        {
            return await _context.ExercisesPerformed.ToListAsync();
        }

        // GET: api/ExercisesPerformedApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercisePerformed>> GetExercisePerformed(int id)
        {
            var exercisePerformed = await _context.ExercisesPerformed.FindAsync(id);

            if (exercisePerformed == null)
            {
                return NotFound();
            }

            return exercisePerformed;
        }

        // PUT: api/ExercisesPerformedApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercisePerformed(int id, ExercisePerformed exercisePerformed)
        {
            if (id != exercisePerformed.exercisePerformedId)
            {
                return BadRequest();
            }

            _context.Entry(exercisePerformed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercisePerformedExists(id))
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

        // POST: api/ExercisesPerformedApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExercisePerformed>> PostExercisePerformed(ExercisePerformed exercisePerformed)
        {
            _context.ExercisesPerformed.Add(exercisePerformed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercisePerformed", new { id = exercisePerformed.exercisePerformedId }, exercisePerformed);
        }

        // DELETE: api/ExercisesPerformedApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExercisePerformed>> DeleteExercisePerformed(int id)
        {
            var exercisePerformed = await _context.ExercisesPerformed.FindAsync(id);
            if (exercisePerformed == null)
            {
                return NotFound();
            }

            _context.ExercisesPerformed.Remove(exercisePerformed);
            await _context.SaveChangesAsync();

            return exercisePerformed;
        }

        private bool ExercisePerformedExists(int id)
        {
            return _context.ExercisesPerformed.Any(e => e.exercisePerformedId == id);
        }
    }
}
