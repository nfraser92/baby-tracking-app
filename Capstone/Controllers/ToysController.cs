using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Capstone.Models.ViewModels.Toys;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Capstone.Controllers
{
    public class ToysController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToysController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Toy.Include(t => t.ToyType).Include(t => t.User).Where(b => b.UserId == user.Id); ;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Toys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy
                .Include(t => t.ToyType)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ToyId == id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ToyUploadPictureViewModel model = new ToyUploadPictureViewModel();
            model.Toy = new Toy();
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View(model);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToyUploadPictureViewModel model)
        {
            // Remove user from model validation as it is not submitted in the form.
            // Validation will fail is this is not in here
            ModelState.Remove("UserId");


            var user = await GetCurrentUserAsync();
            //If you want to check errors in model state use the code below:
            var errors = ModelState.Values.SelectMany(v => v.Errors);


            if (ModelState.IsValid)
            {
                model.Toy.User = user;
                model.Toy.UserId = user.Id;
                await UploadImage(model.ImageFile);
                model.Toy.ImagePath = model.ImageFile.FileName;
                _context.Add(model.Toy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", model.Toy.ToyTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", model.Toy.UserId);
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

        // GET: Toys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy.FindAsync(id);
            if (toy == null)
            {
                return NotFound();
            }
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", toy.ToyTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", toy.UserId);
            return View(toy);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile imageFile, [Bind("ToyId,ToyTypeId,Color,Description,ImagePath")] Toy toy)
        {
            if (id != toy.ToyId)
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
                    toy.User = user;
                    toy.UserId = user.Id;
                    _context.Update(toy);
                    await UploadImage(imageFile);
                    toy.ImagePath = imageFile.FileName;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToyExists(toy.ToyId))
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
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", toy.ToyTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", toy.UserId);
            return View(toy);
        }

        // GET: Toys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy
                .Include(t => t.ToyType)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ToyId == id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toy = await _context.Toy.FindAsync(id);
            _context.Toy.Remove(toy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToyExists(int id)
        {
            return _context.Toy.Any(e => e.ToyId == id);
        }
    }
}
