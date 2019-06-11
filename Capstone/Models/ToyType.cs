using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ToyType
    {
        [Required]
        [Key]
        public int ToyTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }

    }
}
