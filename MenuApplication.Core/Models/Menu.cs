using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MenuApplication.Core.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public String Name { get; set; }

        public virtual ICollection<MenuDetails> pizzas { get; set; }
    }
}
