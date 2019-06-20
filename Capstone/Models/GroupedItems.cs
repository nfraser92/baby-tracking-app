using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    [NotMapped]
    public class GroupedItems
    {
        [Key]
        public int Id { get; set; }
        public int ItemCount { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Clothes> Clothes { get; set; }

        public IEnumerable<Toy> Toys { get; set; }

    }
}
