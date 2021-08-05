using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Data;
using MusicPortal.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPortal.Controllers
{
    public class AuthenticatiosController : Controller
    {
        private readonly MusicPortalContext _context;

        public AuthenticatiosController(MusicPortalContext context)
        {
            _context = context;
        }

        // GET: Authenticatios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authenticatio.ToListAsync());
        }

        // GET: Authenticatios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authenticatio = await _context.Authenticatio
                .FirstOrDefaultAsync(m => m.id == id);
            if (authenticatio == null)
            {
                return NotFound();
            }

            return View(authenticatio);
        }

        // GET: Authenticatios/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult invalid()
        {
            return View();
        }


        // POST: Authenticatios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UName,UPassword")] Authenticatio authenticatio)
        {
            if (ModelState.IsValid)
            {
                if (authenticatio.UName.Equals("Music@gmail.com") && authenticatio.UPassword.Equals("12345"))
                {
                    return RedirectToAction(nameof(Dashboard));
                }
                else {
                    return RedirectToAction(nameof(invalid));
                }
                
            }
            return View(authenticatio);
        }

        // GET: Authenticatios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authenticatio = await _context.Authenticatio.FindAsync(id);
            if (authenticatio == null)
            {
                return NotFound();
            }
            return View(authenticatio);
        }

        // POST: Authenticatios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UName,UPassword")] Authenticatio authenticatio)
        {
            if (id != authenticatio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authenticatio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthenticatioExists(authenticatio.id))
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
            return View(authenticatio);
        }

        // GET: Authenticatios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authenticatio = await _context.Authenticatio
                .FirstOrDefaultAsync(m => m.id == id);
            if (authenticatio == null)
            {
                return NotFound();
            }

            return View(authenticatio);
        }

        // POST: Authenticatios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authenticatio = await _context.Authenticatio.FindAsync(id);
            _context.Authenticatio.Remove(authenticatio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthenticatioExists(int id)
        {
            return _context.Authenticatio.Any(e => e.id == id);
        }
    }
}
