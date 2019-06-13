using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Toy
    {
        [Required]
        [Key]
        public int ToyId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int ToyTypeId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Description { get; set; }

        
        [Display(Name ="Item Image")]
        public string ImagePath { get; set; }

        public ApplicationUser User { get; set; }

        public ToyType ToyType { get; set; }





    }
}
