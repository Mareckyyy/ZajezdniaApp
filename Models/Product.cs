using System.ComponentModel.DataAnnotations;

namespace Wyjazdy.Models
{
    public class Przedmiot
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa tramwaju")]
        [StringLength(35, ErrorMessage = "Maksymalna długość nazwy to 35 znaków.")]
        [UniqueProduct]
        public string? NazwaTramwaju { get; set; }


    }

    /*public class Tramwaj
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa Tramwaju")]
        [StringLength(35, ErrorMessage = "Maksymalna długość nazwy to 35 znaków.")]
        [UniqueProduct] // Note: You may need to adjust this attribute or create a new one if the uniqueness still applies
        public string? NazwaTramwaju { get; set; }

        [Display(Name = "Numer Boczny")]
        public string? NumerBoczny { get; set; }
    }*/
}
