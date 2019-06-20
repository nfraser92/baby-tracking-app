using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Models.ViewModels;
using Capstone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capstone.Models.ViewModels.Search;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> LandingPage()
        {

            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(Index));
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var model = new GroupedItems();

            model.Books = _context.Book
                .Include(b => b.BookType)
                .Include(b => b.User)
                .Where(b => b.UserId == user.Id)
                .OrderByDescending(x => x.Title)
                .Take(4);

            model.Clothes = _context.Clothes
                .Include(c => c.ClothesType)
                .Include(c => c.User)
                .Where(b => b.UserId == user.Id)
                .OrderByDescending(x => x.Description)
                .Take(4);

            model.Toys = _context.Toy
                .Include(t => t.ToyType)
                .Include(t => t.User)
                .Where(b => b.UserId == user.Id)
                .OrderByDescending(x => x.Description)
                .Take(4);

            
            return View(model);
        }

        public async Task<IActionResult> SearchResults(string SearchString)
        {
            //In order to access user specific information, the current user must be identified
            var user = await GetCurrentUserAsync();

            var model = new Search();

            var books = _context.Book.Where(b => b.Title.Contains(SearchString) || (b.Author.Contains(SearchString) || (b.BookType.Description.Contains(SearchString))));

            model.Books = books.ToList();

            var toys = _context.Toy.Where(t => t.Color.Contains(SearchString) || (t.ToyType.Description.Contains(SearchString) || (t.Description.Contains(SearchString))));

            model.Toys = toys.ToList();

            var clothes = _context.Clothes.Where(c => c.Color.Contains(SearchString) || (c.ClothesType.Description.Contains(SearchString)));

            model.Clothing = clothes.ToList();


            //var applicationDbContext = _context.GiftIdeas
            //    .Include(b => b.Book)
            //    .Include(b => b.BookType)
            //    .Include(c => c.Clothes)
            //    .Include(ct => ct.ClothesType)
            //    .Include(t => t.Toy)
            //    .Include(b => b.ToyType)
            //    .Where(x.Book.Author.Contains(SearchString) || (x.Clothes.Description.Contains(SearchString) ||
            //    //      (x.Clothes.Color.Contains(SearchString) || (x.Toy.Color.Contains(SearchString) || (x.Toy.Description.Contains(SearchString)))))));
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
