using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackathon.Models;

namespace Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetSetsController : ControllerBase
    {
        private readonly HackatonContext _context;

        public BudgetSetsController(HackatonContext context)
        {
            _context = context;
        }

        // GET: api/BudgetSets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetSet>>> GetBudgetSets()
        {
          if (_context.BudgetSets == null)
          {
              return NotFound();
          }
            return await _context.BudgetSets.ToListAsync();
        }

        // GET: api/BudgetSets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetSet>> GetBudgetSet(int id)
        {
          if (_context.BudgetSets == null)
          {
              return NotFound();
          }
            var budgetSet = await _context.BudgetSets.FindAsync(id);

            if (budgetSet == null)
            {
                return NotFound();
            }

            return budgetSet;
        }

        // PUT: api/BudgetSets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgetSet(int id, BudgetSet budgetSet)
        {
            if (id != budgetSet.Id)
            {
                return BadRequest();
            }

            _context.Entry(budgetSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetSetExists(id))
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

        // POST: api/BudgetSets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BudgetSet>> PostBudgetSet(BudgetSet budgetSet)
        {
          if (_context.BudgetSets == null)
          {
              return Problem("Entity set 'HackatonContext.BudgetSets'  is null.");
          }
            _context.BudgetSets.Add(budgetSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBudgetSet), new { id = budgetSet.Id }, budgetSet);
        }

        // DELETE: api/BudgetSets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetSet(int id)
        {
            if (_context.BudgetSets == null)
            {
                return NotFound();
            }
            var budgetSet = await _context.BudgetSets.FindAsync(id);
            if (budgetSet == null)
            {
                return NotFound();
            }

            _context.BudgetSets.Remove(budgetSet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BudgetSetExists(int id)
        {
            return (_context.BudgetSets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
