using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Toys
{
    public class ToyUploadPictureViewModel
    {
        public Toy Toy { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
