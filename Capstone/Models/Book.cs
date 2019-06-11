using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Enter Book Category")]
        public int BookTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Display(Name ="Item Image")]
        public string ImagePath { get; set; }
        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        public int Quantity { get; set; }

        public bool IsOutgrown { get; set; }

        public BookType BookType { get; set; }
    }
}
