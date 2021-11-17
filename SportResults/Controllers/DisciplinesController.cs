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
    public class DisciplinesController : ControllerBase
    {
        private readonly SportContext _context;

        public DisciplinesController(SportContext context)
        {
            _context = context;
        }

        // GET: api/Disciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discipline>>> GetDiscipline()
        {
            return await _context.Discipline.Where(x => x.StatusId != 2).ToListAsync();
        }

        // GET: api/Disciplines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discipline>> GetDiscipline(long id)
        {
            var discipline = await _context.Discipline.FindAsync(id);

            if (discipline == null)
            {
                return NotFound();
            }

            return discipline;
        }

        [HttpGet("competitionid={competitionId}")]
        public List<Class.Discipline> GetDisciplines(long competitionId)
        {
            var disciplines = (from _dis in _context.Discipline
                               join _distype in _context.DisciplineType on _dis.DisciplineTypeId equals _distype.Id
                               join _status in _context.Status on _dis.StatusId equals _status.Id
                               where _dis.CompetitionId == competitionId
                               select new Class.Discipline()
                               {
                                   Id = _dis.Id,
                                   CreateDate = _dis.CreateDate,
                                   EditDate = _dis.EditDate,
                                   CompetitionId = _dis.CompetitionId,
                                   StatusId = _dis.StatusId,
                                   Status = _status.Name,
                                   DisciplineTypeId = _dis.DisciplineTypeId,
                                   DisciplineType = _distype.Name,
                                   Result = _dis.Result,
                                   Comments = _dis.Comments
                                }
                               )
                               .AsNoTracking()
                               .ToList();
                
                //_context.Discipline.Where(x => x.CompetitionId == competitionId).ToList();

            return disciplines;
        }

        // PUT: api/Disciplines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipline(long id, Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return BadRequest();
            }

            discipline.EditDate = DateTime.Now;
            _context.Entry(discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(id))
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

        // POST: api/Disciplines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discipline>> PostDiscipline(Discipline discipline)
        {
            discipline.CreateDate = DateTime.Now;
            discipline.EditDate = DateTime.Now;
            discipline.StatusId = 1;

            _context.Discipline.Add(discipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscipline", new { id = discipline.Id }, discipline);
        }

        // DELETE: api/Disciplines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipline(long id)
        {
            var discipline = await _context.Discipline.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }

            discipline.StatusId = 2;
            _context.Discipline.Remove(discipline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineExists(long id)
        {
            return _context.Discipline.Any(e => e.Id == id);
        }
    }
}
