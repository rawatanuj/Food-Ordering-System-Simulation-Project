﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Ordering_System.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime DateOfLaunch { get; set; }
        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public bool FreeDelivery { get; set; }

    }
}
