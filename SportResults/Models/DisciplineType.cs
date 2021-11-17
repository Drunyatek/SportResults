using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class DisciplineType
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public long StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Discipline> Disciplines { get; set; }
    }
}
