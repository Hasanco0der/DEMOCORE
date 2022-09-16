using DEMOCORE.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Data
{
    public class books
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Des { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Totalpages { get; set; }
        public string Language { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
