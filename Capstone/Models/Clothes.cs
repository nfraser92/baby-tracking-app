using System;
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

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name="Is Outgrown")]
        public bool IsOutgrown { get; set; }

        [Display(Name ="Clothes Category")]
        public ClothesType ClothesType { get; set; }

    }
}
