using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Books
{
    public class EditBookViewModel
    {
        public Book Book { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
