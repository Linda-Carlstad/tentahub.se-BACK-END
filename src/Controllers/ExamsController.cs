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
    public class ExamsController : ControllerBase
    {
        private readonly DataContext _context;

        public ExamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            return await _context.Exams.ToListAsync();
        }

        // GET: api/Exams/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Exam>> GetExam(string id)
        {
            var exam =  await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id/{id}")]
        public async Task<IActionResult> PutExam(string id, Exam exam)
        {
            if (id != exam.ID)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            _context.Exams.Add(exam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamExists(exam.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExam", new { id = exam.ID }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteExam(string id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(string id)
        {
            return _context.Exams.Any(e => e.ID == id);
        }


        
        // GET: api/Exams/MAGA55
        [HttpGet("course/{courseNameShort}")]

        public async Task<ActionResult<IEnumerable<Exam>>> GetExamsFromCourse(string courseNameShort) {
            
            
            var queryResult = _context.Exams.FromSqlInterpolated($"SELECT * FROM Exams").Where(res => res.courseNameShort == courseNameShort);
            var exams = await queryResult.ToListAsync();
            return exams;

        }
    }
}
