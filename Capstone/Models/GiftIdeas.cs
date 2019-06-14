using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class GiftIdeas
    {
        [Key]
        public int Id { get; set; }

        public ClothesType ClothesType { get; set; }

        public ToyType ToyType { get; set; }

        public BookType BookType { get; set; }

        public int? ClothesTypeId { get; set; }
        public int? BookTypeId { get; set; }
        public int? ToyTypeId { get; set; }

        [StringLength(20, ErrorMessage = "Please shorten the Size to 20 characters")]
        public string Size { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
