using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Capstone.Models.ViewModels.Gift_Ideas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Capstone.Controllers
{
    public class GiftIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GiftIdeasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);


        // GET: GiftIdeas
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.GiftIdeas.Include(g => g.BookType).Include(g => g.ToyType).Include(g => g.ClothesType).Where(c => c.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GiftIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftIdeas = await _context.GiftIdeas
                .Include(g => g.BookType)
                .Include(g => g.ToyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftIdeas == null)
            {
                return NotFound();
            }

            return View(giftIdeas);
        }

        // GET: GiftIdeas/Create
        public IActionResult CreateBook()
        {
            GiftUploadViewModel model = new GiftUploadViewModel();
            model.GiftIdeas = new GiftIdeas();
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description");
            return View(model);
        }

        // POST: GiftIdeas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(GiftUploadViewModel model)
        {
            ModelState.Remove("UserId");

            var user = await GetCurrentUserAsync();

            //If you want to check errors in model state use the code below:
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                model.GiftIdeas.Book.User = user;
                model.GiftIdeas.Book.UserId = user.Id;
                await UploadImage(model.ImageFile);
                model.GiftIdeas.Book.ImagePath = model.ImageFile.FileName;
                _context.Add(model.GiftIdeas.Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", model.GiftIdeas.BookTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", model.GiftIdeas.Book.UserId);
            return View(model);
        }

        private static async Task UploadImage(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                Path.GetTempFileName();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                // var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                    // validate file, then move to CDN or public folder
                }
            }
        }

        // GET: GiftIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftIdeas = await _context.GiftIdeas.FindAsync(id);
            if (giftIdeas == null)
            {
                return NotFound();
            }
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", giftIdeas.BookTypeId);
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", giftIdeas.ToyTypeId);
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description");
            return View(giftIdeas);
        }

        // POST: GiftIdeas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile imageFile, [Bind("Id,ClothesTypeId,BookTypeId,ToyTypeId,Size,Description,ImagePath")] GiftIdeas giftIdeas)
        {
            if (id != giftIdeas.Id)
            {
                return NotFound();
            }

            ModelState.Remove("UserId");


            var user = await GetCurrentUserAsync();


            if (ModelState.IsValid)
            {
                try
                {
                    giftIdeas.User = user;
                    giftIdeas.UserId = user.Id;
                    _context.Update(giftIdeas);
                    await UploadImage(imageFile);
                    giftIdeas.ImagePath = imageFile.FileName;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftIdeasExists(giftIdeas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", giftIdeas.BookTypeId);
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", giftIdeas.ToyTypeId);
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description");
            return View(giftIdeas);
        }

        // GET: GiftIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftIdeas = await _context.GiftIdeas
                .Include(g => g.BookType)
                .Include(g => g.ToyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftIdeas == null)
            {
                return NotFound();
            }

            return View(giftIdeas);
        }

        // POST: GiftIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftIdeas = await _context.GiftIdeas.FindAsync(id);
            _context.GiftIdeas.Remove(giftIdeas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftIdeasExists(int id)
        {
            return _context.GiftIdeas.Any(e => e.Id == id);
        }
    }
}
