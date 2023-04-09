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
    public class UserIdsController : ControllerBase
    {
        private readonly HackatonContext _context;

        public UserIdsController(HackatonContext context)
        {
            _context = context;
        }

        // GET: api/UserIds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserId>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserIds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserId>> GetUserId(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var userId = await _context.Users.FindAsync(id);

            if (userId == null)
            {
                return NotFound();
            }

            return userId;
        }

        // PUT: api/UserIds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserId(int id, UserId userId)
        {
            if (id != userId.Id)
            {
                return BadRequest();
            }

            _context.Entry(userId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserIdExists(id))
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

        // POST: api/UserIds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserId>> PostUserId(UserId userId)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'HackatonContext.Users'  is null.");
          }
            _context.Users.Add(userId);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserId), new { id = userId.Id }, userId);
        }

        // DELETE: api/UserIds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserId(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userId = await _context.Users.FindAsync(id);
            if (userId == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userId);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserIdExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
