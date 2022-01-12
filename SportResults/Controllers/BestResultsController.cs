using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportResults.Models;
using SportResults.Class;

namespace SportResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestResultsController : ControllerBase
    {
        private readonly SportContext _context;

        public BestResultsController(SportContext context)
        {
            _context = context;
        }

        // GET: BestResultsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BestResults>>> GetBestResults()
        {
            List<BestResults> bestResults = new List<BestResults>();
            var disciplineTypes = _context.disciplinetype.ToList();

            foreach (disciplinetype disciplineType in disciplineTypes)
            {
                BestResults results = new BestResults();
                results.DisciplineTypeName = disciplineType.name;
                results.BestDisciplines = await (from _disc in _context.discipline
                                           where _disc.statusid != 2
                                           && _disc.disciplinetypeid == disciplineType.id
                                           orderby _disc.result descending
                                           select new Class.Discipline()
                                           {
                                               Id = _disc.id,
                                               CreateDate = _disc.createdate,
                                               EditDate = _disc.editdate,
                                               CompetitionId = _disc.competitionid,
                                               StatusId = _disc.statusid,
                                               //Status = _disc.
                                               DisciplineTypeId = _disc.disciplinetypeid,
                                               //DisciplineType = _disc.
                                               Result = _disc.result,
                                               Comments = _disc.comments,
                                           }).AsNoTracking()
                                           .Take(3)
                                           .ToListAsync();
                bestResults.Add(results);
            }

            return bestResults;
        }
    }
}
