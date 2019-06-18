using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Search
{
    [NotMapped]
    public class Search
    {
        [Key]
        public int Id { get; set; }
        public List<Toy> Toys { get; set; }

        public List<ToyType> ToyTypes { get; set; }

        public List<BookType> BookTypes { get; set; }

        public List<Book> Books { get; set; }

        public List<Clothes> Clothing { get; set; }
    }
}
