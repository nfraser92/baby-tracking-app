﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Clothes
    {
        [Required]
        [Key]
        public int ClothesId { get; set; }

        [Required]
        public int ClothesTypeId { get; set; }

        [Required]
        [StringLength(15)]
        public string Size { get; set; }
        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        public string ImagePath { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public bool IsOutgrown { get; set; }

        public ClothesType ClothesType { get; set; }

    }
}