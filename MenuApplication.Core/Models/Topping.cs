using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MenuApplication.Core.Models
{
    public class Topping
    {
        [Key]
        public int ToppingId { get; set; }


        [Column(TypeName = "nvarchar(250)")]
        public String Name { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<PizzaDetails> PizzaDetails { get; set; }
    }
}

