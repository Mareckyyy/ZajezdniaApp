using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Wyjazdy.Models;

namespace Wyjazdy.Models
{
    
    public class RegistrationViewModel
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public string? TypUzytkownika { get; set; }

        [Required]
        public string? UserName { get; set; }
    }

}