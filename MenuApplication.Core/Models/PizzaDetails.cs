using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuApplication.Core.Models
{
    public class PizzaDetails
    {
        [Key]
        public int PizzaDetailId { get; set; }
        
        public int PizzaId { get; set; }

        public int ToppingId { get; set; }

        public int TopyngQuantity { get; set; }        
        
    }
}