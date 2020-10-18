using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Ordering_System.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
