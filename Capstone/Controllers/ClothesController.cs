using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Capstone.Models.ViewModels.Clothing;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Capstone.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClothesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);

        // GET: Clothes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clothes.Include(c => c.ClothesType).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .Include(c => c.ClothesType)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClothesId == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            ClothesUploadPictureViewModel model = new ClothesUploadPictureViewModel();
            model.Clothes = new Clothes();
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClothesUploadPictureViewModel model)
        {
            ModelState.Remove("UserId");

            var user = await  GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                model.Clothes.User = user;
                model.Clothes.UserId = user.Id;
                await UploadImage(model.ImageFile);
                model.Clothes.ImagePath = model.ImageFile.FileName;
                _context.Add(model.Clothes);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description", model.Clothes.ClothesTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", model.Clothes.UserId);
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

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description", clothes.ClothesTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", clothes.UserId);
            return View(clothes);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile imageFile, [Bind("ClothesId,ClothesTypeId,Size,Color,Description,ImagePath,IsOutgrown")] Clothes clothes)
        {
            if (id != clothes.ClothesId)
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
                    clothes.User = user;
                    clothes.UserId = user.Id;
                    _context.Update(clothes);
                    await UploadImage(imageFile);
                    clothes.ImagePath = imageFile.FileName;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.ClothesId))
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
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description", clothes.ClothesTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", clothes.UserId);
            return View(clothes);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .Include(c => c.ClothesType)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClothesId == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await _context.Clothes.FindAsync(id);
            _context.Clothes.Remove(clothes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.ClothesId == id);
        }
    }
}
