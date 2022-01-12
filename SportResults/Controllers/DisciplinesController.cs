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
        public async Task<ActionResult<IEnumerable<discipline>>> GetDiscipline()
        {
            return await _context.discipline.Where(x => x.statusid != 2).ToListAsync();
        }

        // GET: api/Disciplines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<discipline>> GetDiscipline(long id)
        {
            var discipline = await _context.discipline.FindAsync(id);

            if (discipline == null)
            {
                return NotFound();
            }

            return discipline;
        }

        [HttpGet("competitionid={competitionId}")]
        public List<Class.Discipline> GetDisciplines(long competitionId)
        {
            var disciplines = (from _dis in _context.discipline
                               join _distype in _context.disciplinetype on _dis.disciplinetypeid equals _distype.id
                               join _status in _context.status on _dis.statusid equals _status.id
                               where _dis.competitionid == competitionId
                               select new Class.Discipline()
                               {
                                   Id = _dis.id,
                                   CreateDate = _dis.createdate,
                                   EditDate = _dis.editdate,
                                   CompetitionId = _dis.competitionid,
                                   StatusId = _dis.statusid,
                                   Status = _status.name,
                                   DisciplineTypeId = _dis.disciplinetypeid,
                                   DisciplineType = _distype.name,
                                   Result = _dis.result,
                                   Comments = _dis.comments
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
        public async Task<IActionResult> PutDiscipline(long id, discipline discipline)
        {
            if (id != discipline.id)
            {
                return BadRequest();
            }

            discipline.editdate = DateTime.Now;
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
        public async Task<ActionResult<discipline>> PostDiscipline(discipline discipline)
        {
            discipline.createdate = DateTime.Now;
            discipline.editdate = DateTime.Now;
            discipline.statusid = 1;

            _context.discipline.Add(discipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscipline", new { id = discipline.id }, discipline);
        }

        // DELETE: api/Disciplines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipline(long id)
        {
            var discipline = await _context.discipline.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }

            discipline.statusid = 2;
            _context.discipline.Remove(discipline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineExists(long id)
        {
            return _context.discipline.Any(e => e.id == id);
        }
    }
}
