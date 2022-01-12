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
    public class CompetitionsController : ControllerBase
    {
        private readonly SportContext _context;

        public CompetitionsController(SportContext context)
        {
            _context = context;
        }

        // GET: api/Competitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<competition>>> GetCompetitions()
        {
            return await _context.competitions.Where(x => x.statusid != 2).ToListAsync();
        }

        // GET: api/Competitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class.Competition>> GetCompetition(long id)
        {
            var competition = (from _comp in _context.competitions
                               select new Class.Competition()
                               {
                                   Id = _comp.id,
                                   CreateDate = _comp.createdate,
                                   EditDate = _comp.editdate,
                                   StatusId = _comp.statusid,
                                   Name = _comp.name,
                                   Date = _comp.date,
                                   Comments = _comp.comments,
                                }).AsNoTracking()
                               .FirstOrDefault();

            if (competition != null && competition.StatusId != 2)
            {
                var discController = new DisciplinesController(_context);
                competition.Disciplines = discController.GetDisciplines(competition.Id);

                return competition;
            }

            return NotFound();
        }

        // PUT: api/Competitions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(long id, competition competition)
        {
            if (id != competition.id)
            {
                return BadRequest();
            }

            competition.editdate = DateTime.Now;
            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
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

        // POST: api/Competitions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<competition>> PostCompetition(competition competition)
        {
            competition.createdate = DateTime.Now;
            competition.editdate = DateTime.Now;
            competition.statusid = 1;

            _context.competitions.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetition), new { id = competition.id }, competition);
        }

        // DELETE: api/Competitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(long id)
        {
            var competition = await _context.competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            competition.editdate = DateTime.Now;
            competition.statusid = 2;
            _context.competitions.Update(competition);
            //_context.Competitions.Remove(competition);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(long id)
        {
            return _context.competitions.Any(e => e.id == id);
        }
    }
}
