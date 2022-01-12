using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class competition
    {
        public long id { get; set; }
        public DateTime createdate { get; set; }
        public DateTime editdate { get; set; }
        public long statusid { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string comments { get; set; }

        public ICollection<discipline> disciplines { get; set; }
    }
}
