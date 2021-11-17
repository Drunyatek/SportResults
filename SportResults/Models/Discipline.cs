using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class Discipline
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public long CompetitionId { get; set; }
        public long StatusId { get; set; }
        public long DisciplineTypeId { get; set; }
        public double Result { get; set; }
        public string Comments { get; set; }

    }
}
