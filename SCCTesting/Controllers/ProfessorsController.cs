using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCTesting.Dtos;
using SCCTesting.Models;
using SCCTesting.Persistence;

namespace SCCTesting.Controllers
{
    [Produces("application/json")]
    [Route("api/Professors")]
    
    public class ProfessorsController : Controller
    {
        private readonly SCCTestingDbContext _context;

        public ProfessorsController(SCCTestingDbContext context)
        {
            _context = context;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<IEnumerable<ProfessorDto>> GetProfessors()
        {
            var professors = await _context.Professors
                .Include(pc => pc.ProfessorTerms)
                    .ThenInclude(t => t.Term)
                .Include(pt => pt.ProfessorTerms)
                    .ThenInclude(ptc => ptc.ProfessorTermCourses)
                        .ThenInclude(c=>c.Course )
                .Include(pt => pt.ProfessorTerms)
                    .ThenInclude(ptc => ptc.ProfessorTermCourses)
                        .ThenInclude(t => t.Tests)
                //            .ThenInclude(s=>s.StudentTests)
                //                .ThenInclude(s=>s.Student)
                .ToListAsync();

            return Mapper.Map<List<Professor>, List<ProfessorDto>>(professors);
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professors
                .Include(pc => pc.ProfessorTerms)
                .ThenInclude(t => t.Term)
                .Include(pt => pt.ProfessorTerms)
                .ThenInclude(ptc => ptc.ProfessorTermCourses)
                .ThenInclude(c => c.Course)
                .Include(pt => pt.ProfessorTerms)
                .ThenInclude(ptc => ptc.ProfessorTermCourses)
                .ThenInclude(t => t.Tests)
            .SingleOrDefaultAsync(m => m.Id == id);


            if (professor == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Professor, ProfessorDto>(professor));
        }

        // PUT: api/Professors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor([FromRoute] int id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professors
        [HttpPost]
        public async Task<IActionResult> PostProfessor([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new { id = professor.Id }, professor);
        }

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professors.SingleOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
    }
}