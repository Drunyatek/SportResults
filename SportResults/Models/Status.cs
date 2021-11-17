using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class Status
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public string Name { get; set; }

        public ICollection<Competition> Competitions { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
        public ICollection<DisciplineType> DisciplineTypes { get; set; }
    }
}
