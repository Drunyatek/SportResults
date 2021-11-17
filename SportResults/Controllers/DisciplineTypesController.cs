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
        public async Task<ActionResult<IEnumerable<DisciplineType>>> GetDisciplineTypes()
        {
            return await _context.DisciplineType.Where(x => x.StatusId != 2).ToListAsync();
        }

        // GET: api/DisciplineTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineType>> GetDisciplineType(long id)
        {
            var disciplineType = await _context.DisciplineType.FindAsync(id);

            if (disciplineType != null && disciplineType.StatusId != 2)
            {
                return disciplineType;
            }

            return NotFound();
        }

        // PUT: api/DisciplineTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplineType(long id, DisciplineType disciplineType)
        {
            if (id != disciplineType.Id)
            {
                return BadRequest();
            }

            disciplineType.EditDate = DateTime.Now;
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
        public async Task<ActionResult<DisciplineType>> PostDisciplineType(DisciplineType disciplineType)
        {
            disciplineType.CreateDate = DateTime.Now;
            disciplineType.EditDate = DateTime.Now;
            disciplineType.StatusId = 1;

            _context.DisciplineType.Add(disciplineType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplineType", new { id = disciplineType.Id }, disciplineType);
        }

        // DELETE: api/DisciplineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplineType(long id)
        {
            var disciplineType = await _context.DisciplineType.FindAsync(id);
            if (disciplineType == null)
            {
                return NotFound();
            }

            disciplineType.StatusId = 2;
            _context.DisciplineType.Update(disciplineType);
            //_context.DisciplineType.Remove(disciplineType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineTypeExists(long id)
        {
            return _context.DisciplineType.Any(e => e.Id == id);
        }
    }
}
