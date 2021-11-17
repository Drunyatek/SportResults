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
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            return await _context.Competitions.Where(x => x.StatusId != 2).ToListAsync();
        }

        // GET: api/Competitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class.Competition>> GetCompetition(long id)
        {
            var competition = (from _comp in _context.Competitions
                               select new Class.Competition()
                               {
                                   Id = _comp.Id,
                                   CreateDate = _comp.CreateDate,
                                   EditDate = _comp.EditDate,
                                   StatusId = _comp.StatusId,
                                   Name = _comp.Name,
                                   Date = _comp.Date,
                                   Comments = _comp.Comments,
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
        public async Task<IActionResult> PutCompetition(long id, Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

            competition.EditDate = DateTime.Now;
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
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {
            competition.CreateDate = DateTime.Now;
            competition.EditDate = DateTime.Now;
            competition.StatusId = 1;

            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetition), new { id = competition.Id }, competition);
        }

        // DELETE: api/Competitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(long id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            competition.EditDate = DateTime.Now;
            competition.StatusId = 2;
            _context.Competitions.Update(competition);
            //_context.Competitions.Remove(competition);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(long id)
        {
            return _context.Competitions.Any(e => e.Id == id);
        }
    }
}
