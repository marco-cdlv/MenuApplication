using System.ComponentModel.DataAnnotations;

namespace MenuApplication.Core.Models
{
    public class MenuDetails
    {
        [Key]
        public int MenuDetailId { get; set; }

        public int PizzaId { get; set; }

        public int MenuId { get; set; }
        
    }
}