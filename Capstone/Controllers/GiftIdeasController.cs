using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class GiftIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiftIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GiftIdeas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GiftIdeas.Include(g => g.BookType).Include(g => g.ToyType);
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
        public IActionResult Create()
        {
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description");
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description");
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description");
            return View();
        }

        // POST: GiftIdeas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClothesTypeId,BookTypeId,ToyTypeId,Size,Description,ImagePath")] GiftIdeas giftIdeas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftIdeas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookTypeId"] = new SelectList(_context.BookType, "BookTypeId", "Description", giftIdeas.BookTypeId);
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", giftIdeas.ToyTypeId);
            ViewData["ClothesTypeId"] = new SelectList(_context.ClothesType, "ClothesTypeId", "Description");
            return View(giftIdeas);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClothesTypeId,BookTypeId,ToyTypeId,Size,Description,ImagePath")] GiftIdeas giftIdeas)
        {
            if (id != giftIdeas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftIdeas);
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
