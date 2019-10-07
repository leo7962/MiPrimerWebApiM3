using MiPrimerWebApiM3.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApiM3.Entities
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        //[FirstCapitalLetter]
        [StringLength(10, ErrorMessage = "El campo Name debe tener {1} caracter o menos")]
        public string Name { get; set; }
        //[Range(18, 120)]
        //public int Age { get; set; }
        //[CreditCard]
        //public string CreditCard { get; set; }
        //[Url]
        //public string Url { get; set; }

        public List<Book> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstLetter = Name[0].ToString();

                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayúscula", new string[] { nameof(Name)});
                }
            }
        }
    }
}