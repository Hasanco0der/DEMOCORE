using DEMOCORE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Helpers
{
    public class MyCustomValditionAttrbuties: ValidationAttribute
    {
        private readonly BookStoreContext _context;

       
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var bookk = _context.books.FirstOrDefault(x => x.Title == value.ToString());
                if (bookk==null)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Is Dublicated");
        }
    }
}
