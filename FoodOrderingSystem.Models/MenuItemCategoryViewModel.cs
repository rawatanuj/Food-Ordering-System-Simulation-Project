using Food_Ordering_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingSystem.Models
{
    public class MenuItemCategoryViewModel
    {
        public MenuItem MenuItems { get; set; }
        public List<Category> Categories { get; set; }
    }
}
