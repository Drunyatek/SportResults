using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults.Class
{
    public struct s_request
    {
        public s_body body;
        public struct s_body
        {
            public string ip_id;
            public int KodLica;
            public string ip_nomer;
            public string ip_date;
            public string ispolnitel;
            public string date;

            public string Familiya;
            public string Imya;
            public string Otchestvo;
            public string INN;
            public string Naimenovanie;
            public string DataRozhdeniya;
            public string guid;
        }
    }
}
