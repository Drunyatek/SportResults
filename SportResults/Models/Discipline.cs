using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Models
{
    public class discipline
    {
        public long id { get; set; }
        public DateTime createdate { get; set; }
        public DateTime editdate { get; set; }
        public long competitionid { get; set; }
        public long statusid { get; set; }
        public long disciplinetypeid { get; set; }
        public double result { get; set; }
        public string comments { get; set; }

    }
}
