using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wyjazdy.Models
{
    /* public class OrderFormModel
     {

         //[Required(ErrorMessage = "Pole uwagi jest wymagane.")] //odkomentować jeśli uwagmi mają byc wymagane
         public string? uwagi { get; set; }

         public List<PrzedmiotViewModel> Tramwaje { get; set; }
     }*/

    public class OrderFormModel
    {
        public List<PrzedmiotViewModel> Tramwaje { get; set; }
        public int? SelectedProductId { get; set; } // Nullable int in case no product is selected
        public string uwagi { get; set; }
    }

}
