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
    public class NavigationsController : Controller
    {
        private readonly PortalContext _context;

        public NavigationsController(PortalContext context)
        {
            _context = context;
        }

        // GET: Navigations
        public async Task<IActionResult> Index()
        {
            var portalContext = _context.Navigation.Include(n => n.Language);
            return View(await portalContext.ToListAsync());
        }

        // GET: Navigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigation = await _context.Navigation
                .Include(n => n.Language)
                .FirstOrDefaultAsync(m => m.Nav_Id == id);
            if (navigation == null)
            {
                return NotFound();
            }

            return View(navigation);
        }

        // GET: Navigations/Create
        public IActionResult Create()
        {
            ViewData["lang_id"] = new SelectList(_context.Language, "Lang_Id", "Lang_Id");
            return View();
        }

        // POST: Navigations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nav_Id,nav_Name,nav_Url,nav_Location,isActive,isGroup,lang_id")] Navigation navigation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(navigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["lang_id"] = new SelectList(_context.Language, "Lang_Id", "Lang_Id", navigation.lang_id);
            return View(navigation);
        }

        // GET: Navigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigation = await _context.Navigation.FindAsync(id);
            if (navigation == null)
            {
                return NotFound();
            }
            ViewData["lang_id"] = new SelectList(_context.Language, "Lang_Id", "Lang_Id", navigation.lang_id);
            return View(navigation);
        }

        // POST: Navigations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nav_Id,nav_Name,nav_Url,nav_Location,isActive,isGroup,lang_id")] Navigation navigation)
        {
            if (id != navigation.Nav_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavigationExists(navigation.Nav_Id))
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
            ViewData["lang_id"] = new SelectList(_context.Language, "Lang_Id", "Lang_Id", navigation.lang_id);
            return View(navigation);
        }

        // GET: Navigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigation = await _context.Navigation
                .Include(n => n.Language)
                .FirstOrDefaultAsync(m => m.Nav_Id == id);
            if (navigation == null)
            {
                return NotFound();
            }

            return View(navigation);
        }

        // POST: Navigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var navigation = await _context.Navigation.FindAsync(id);
            _context.Navigation.Remove(navigation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavigationExists(int id)
        {
            return _context.Navigation.Any(e => e.Nav_Id == id);
        }
    }
}
