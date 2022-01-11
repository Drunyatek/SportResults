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
            var disciplineTypes = _context.DisciplineType.ToList();

            foreach (DisciplineType disciplineType in disciplineTypes)
            {
                BestResults results = new BestResults();
                results.DisciplineTypeName = disciplineType.Name;
                results.BestDisciplines = await (from _disc in _context.Discipline
                                           where _disc.StatusId != 2
                                           && _disc.DisciplineTypeId == disciplineType.Id
                                           orderby _disc.Result descending
                                           select new Class.Discipline()
                                           {
                                               Id = _disc.Id,
                                               CreateDate = _disc.CreateDate,
                                               EditDate = _disc.EditDate,
                                               CompetitionId = _disc.CompetitionId,
                                               StatusId = _disc.StatusId,
                                               //Status = _disc.
                                               DisciplineTypeId = _disc.DisciplineTypeId,
                                               //DisciplineType = _disc.
                                               Result = _disc.Result,
                                               Comments = _disc.Comments,
                                           }).AsNoTracking()
                                           .Take(3)
                                           .ToListAsync();
                bestResults.Add(results);
            }

            return bestResults;
        }
    }
}
