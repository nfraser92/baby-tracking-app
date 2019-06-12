﻿using System;
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
    public class ToysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Toy.Include(t => t.ToyType).Include(t => t.User);
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

        // GET: Toys/Create
        public IActionResult Create()
        {
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToyId,ToyTypeId,UserId,Color,Description,ImagePath")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToyTypeId"] = new SelectList(_context.ToyType, "ToyTypeId", "Description", toy.ToyTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", toy.UserId);
            return View(toy);
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
        public async Task<IActionResult> Edit(int id, [Bind("ToyId,ToyTypeId,UserId,Color,Description,ImagePath")] Toy toy)
        {
            if (id != toy.ToyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toy);
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
