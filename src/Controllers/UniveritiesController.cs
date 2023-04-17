using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TentaHub.Models;

namespace tenta_hub_backend.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniveritiesController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UniveritiesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Univerities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversities()
        {
            return await _context.Universities.ToListAsync();
        }

        // GET: api/Univerities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(string id)
        {
            var university = await _context.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/Univerities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(string id, University university)
        {
            if (id != university.ID)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/Univerities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
            _context.Universities.Add(university);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniversityExists(university.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUniversity", new { id = university.ID }, university);
        }

        // DELETE: api/Univerities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(string id)
        {
            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityExists(string id)
        {
            return _context.Universities.Any(e => e.ID == id);
        }
    }
}
