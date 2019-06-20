using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Capstone.Models.ViewModels.Books;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Capstone.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);

        // GET: Books
        public async Task<IActionResult> Index()
        {

            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Book.Include(b => b.BookType).Include(b => b.User).Where(b => b.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.BookType)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            BookUploadPictureViewModel model = new BookUploadPictureViewModel();
            model.Book = new Book();
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View(model);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookUploadPictureViewModel model)
        {
            // Remove user from model validation as it is not submitted in the form.
            // Validation will fail is this is not in here
            ModelState.Remove("UserId");

            
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                model.Book.User = user;
                model.Book.UserId = user.Id;
                await UploadImage(model.ImageFile);
                model.Book.ImagePath = model.ImageFile.FileName;
                _context.Add(model.Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", model.Book.BookTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", model.Book.UserId);
            return View(model);
        }

        private static async Task UploadImage (IFormFile imageFile)
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

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.BookType)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", book.BookTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", book.UserId);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile imageFile, [Bind("BookId,BookTypeId,Title,ImagePath,Author,Quantity,IsOutgrown")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }


            // Remove user from model validation as it is not submitted in the form.
            // Validation will fail is this is not in here
            ModelState.Remove("UserId");


            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    book.User = user;
                    book.UserId = user.Id;
                    _context.Update(book);
                    await UploadImage(imageFile);
                    book.ImagePath = imageFile.FileName;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", book.BookTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", book.UserId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.BookType)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }
    }
}
