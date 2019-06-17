using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ClothesType
    {
        [Required]
        [Key]
        public int ClothesTypeId { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name ="Category")]
        public string Description { get; set; }

        public virtual ICollection<Clothes> Clothes { get; set; }

        public string UserId { get; set; }

    }
}
