using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class GiftIdeas
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Clothes Type")]
        public ClothesType ClothesType { get; set; }

        [Display(Name = "Toy Type")]
        public ToyType ToyType { get; set; }

        [Display(Name = "Book Type")]
        public BookType BookType { get; set; }

        public int? ClothesTypeId { get; set; }
        public int? BookTypeId { get; set; }
        public int? ToyTypeId { get; set; }

        [StringLength(20, ErrorMessage = "Please shorten the Size to 20 characters")]
        public string Size { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public Toy Toy { get; set; }

        public Book Book { get; set; }

        public Clothes Clothes{ get; set; }
        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Author { get; set; }

    }
}
