﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZAttractionSystem.Data;
using NZAttractionSystem.Models;

namespace NZAttractionSystem.Controllers
{
    [Authorize]
    public class AttractionsController : Controller
    {
        private readonly CustomersDbContext _context;

        public AttractionsController(CustomersDbContext context)
        {
            _context = context;
        }

        // GET: Attractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attraction.ToListAsync());
        }

        // GET: Attractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attraction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attraction == null)
            {
                return NotFound();
            }

            return View(attraction);
        }

        // GET: Attractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Place,Address,Description,Open_Hours")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attraction);
        }

        // GET: Attractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attraction.FindAsync(id);
            if (attraction == null)
            {
                return NotFound();
            }
            return View(attraction);
        }

        // POST: Attractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Place,Address,Description,Open_Hours")] Attraction attraction)
        {
            if (id != attraction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttractionExists(attraction.Id))
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
            return View(attraction);
        }

        // GET: Attractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attraction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attraction == null)
            {
                return NotFound();
            }

            return View(attraction);
        }

        // POST: Attractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attraction = await _context.Attraction.FindAsync(id);
            _context.Attraction.Remove(attraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttractionExists(int id)
        {
            return _context.Attraction.Any(e => e.Id == id);
        }
    }
}
