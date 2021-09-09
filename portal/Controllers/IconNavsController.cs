using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using portal.Data;
using portal.Models;

namespace portal.Controllers
{
    public class IconNavsController : Controller
    {
        private readonly PortalContext _context;

        public IconNavsController(PortalContext context)
        {
            _context = context;
        }

        // GET: IconNavs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IconNav.ToListAsync());
        }

        // GET: IconNavs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iconNav = await _context.IconNav
                .FirstOrDefaultAsync(m => m.id_IconNav == id);
            if (iconNav == null)
            {
                return NotFound();
            }

            return View(iconNav);
        }

        // GET: IconNavs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IconNavs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_IconNav,nameHint,nameNav,urlNav")] IconNav iconNav)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iconNav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iconNav);
        }

        // GET: IconNavs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iconNav = await _context.IconNav.FindAsync(id);
            if (iconNav == null)
            {
                return NotFound();
            }
            return View(iconNav);
        }

        // POST: IconNavs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_IconNav,nameHint,nameNav,urlNav")] IconNav iconNav)
        {
            if (id != iconNav.id_IconNav)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iconNav);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IconNavExists(iconNav.id_IconNav))
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
            return View(iconNav);
        }

        // GET: IconNavs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iconNav = await _context.IconNav
                .FirstOrDefaultAsync(m => m.id_IconNav == id);
            if (iconNav == null)
            {
                return NotFound();
            }

            return View(iconNav);
        }

        // POST: IconNavs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iconNav = await _context.IconNav.FindAsync(id);
            _context.IconNav.Remove(iconNav);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IconNavExists(int id)
        {
            return _context.IconNav.Any(e => e.id_IconNav == id);
        }
    }
}
