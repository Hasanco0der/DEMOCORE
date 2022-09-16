using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Models
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }
       
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Des { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int Totalpages { get; set; }
        public string Language { get; set; }
       
        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
