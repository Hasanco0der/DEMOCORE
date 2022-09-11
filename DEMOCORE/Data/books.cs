using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Data
{
    public class books
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Des { get; set; }
        public string Category { get; set; }
        public int Totalpages { get; set; }
        public string Language { get; set; }
    }
}
