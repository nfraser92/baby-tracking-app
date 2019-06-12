using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BookType
    {
        [Required]
        [Display(Name ="Book Category")]
        [Key]
        public int BookTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
