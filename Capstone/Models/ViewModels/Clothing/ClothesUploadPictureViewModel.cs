using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Clothing
{
    public class ClothesUploadPictureViewModel
    {
        public Clothes Clothes { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
