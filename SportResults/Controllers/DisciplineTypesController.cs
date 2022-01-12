using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportResults.Models;

namespace SportResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineTypesController : ControllerBase
    {
        private readonly SportContext _context;

        public DisciplineTypesController(SportContext context)
        {
            _context = context;
        }

        // GET: api/DisciplineTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<disciplinetype>>> GetDisciplineTypes()
        {
            return await _context.disciplinetype.Where(x => x.statusid != 2).ToListAsync();
        }

        // GET: api/DisciplineTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<disciplinetype>> GetDisciplineType(long id)
        {
            var disciplineType = await _context.disciplinetype.FindAsync(id);

            if (disciplineType != null && disciplineType.statusid != 2)
            {
                return disciplineType;
            }

            return NotFound();
        }

        // PUT: api/DisciplineTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplineType(long id, disciplinetype disciplineType)
        {
            if (id != disciplineType.id)
            {
                return BadRequest();
            }

            disciplineType.editdate = DateTime.Now;
            _context.Entry(disciplineType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineTypeExists(id))
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

        // POST: api/DisciplineTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<disciplinetype>> PostDisciplineType(disciplinetype disciplineType)
        {
            disciplineType.createdate = DateTime.Now;
            disciplineType.editdate = DateTime.Now;
            disciplineType.statusid = 1;

            _context.disciplinetype.Add(disciplineType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplineType", new { id = disciplineType.id }, disciplineType);
        }

        // DELETE: api/DisciplineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplineType(long id)
        {
            var disciplineType = await _context.disciplinetype.FindAsync(id);
            if (disciplineType == null)
            {
                return NotFound();
            }

            disciplineType.statusid = 2;
            _context.disciplinetype.Update(disciplineType);
            //_context.DisciplineType.Remove(disciplineType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineTypeExists(long id)
        {
            return _context.disciplinetype.Any(e => e.id == id);
        }
    }
}
