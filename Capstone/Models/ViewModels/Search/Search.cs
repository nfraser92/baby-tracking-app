using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Search
{
    public class Search
    {
        [Key]
        public int Id { get; set; }

        public Toy Toy { get; set; }
        public List<Toy> Toys { get; set; }

        public ToyType ToyType { get; set; }

        public List<ToyType> ToyTypes { get; set; }

        public Book Book { get; set; }
        public BookType BookType {get; set;}

        public List<BookType> BookTypes { get; set; }

        public List<Book> Books { get; set; }

        public Clothes Clothes { get; set; }
        public ClothesType ClothesType { get; set; }

        public List<Clothes> Clothing { get; set; }
    }
}
