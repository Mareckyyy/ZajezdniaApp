using System.ComponentModel.DataAnnotations;
using Wyjazdy.Data;
namespace Wyjazdy.Models

{
    public class UniqueProductAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Pole nie może być puste");
            }
            var _context = (ApplicationDbContext?)validationContext.GetService(typeof(ApplicationDbContext));
            if (_context.Pojazdy == null)
            {
                return new ValidationResult("Brak kontekstu");
            }
            if(!_context.Pojazdy.Any(p => p.NazwaTramwaju == value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Taki tramwaj już istnieje");
        }
    }
}
