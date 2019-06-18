using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels.Gift_Ideas
{
    public class GiftUploadViewModel
    {
        public GiftIdeas GiftIdeas { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
