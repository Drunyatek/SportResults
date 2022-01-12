using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class status
    {
        public long id { get; set; }
        public DateTime createdate { get; set; }
        public DateTime editdate { get; set; }
        public string name { get; set; }

        public ICollection<competition> competitions { get; set; }
        public ICollection<discipline> disciplines { get; set; }
        public ICollection<disciplinetype> disciplinetypes { get; set; }
    }
}
