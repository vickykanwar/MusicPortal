﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Data;
using MusicPortal.Models;

namespace MusicPortal.Controllers
{
    public class MusicsController : Controller
    {
        private readonly MusicPortalContext _context;

        public MusicsController(MusicPortalContext context)
        {
            _context = context;
        }

        // GET: Musics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Music.ToListAsync());
        }

        public async Task<IActionResult> viewaAll()
        {
            return View(await _context.Music.ToListAsync());
        }
        // GET: Musics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: Musics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Mtitle,MName,Mdate,MLink")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Musics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Mtitle,MName,Mdate,MLink")] Music music)
        {
            if (id != music.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.id))
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
            return View(music);
        }

        // GET: Musics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var music = await _context.Music.FindAsync(id);
            _context.Music.Remove(music);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.id == id);
        }
    }
}
