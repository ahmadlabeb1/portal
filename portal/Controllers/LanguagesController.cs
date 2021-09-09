using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using portal.Data;
using portal.Models;
using portal.ModelView;

namespace portal.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly PortalContext _context;

        public LanguagesController(PortalContext context)
        {
            _context = context;
        }

        // GET: Languages
        public IActionResult Index()
        {

            var data = _context.Language.Join(
                _context.IconNav,
                l => l.Lang_Id,
                i => i.lang_Id,
                (l, i) => new allData
                {
                   language=new Language
                   {
                       Lang_Id=l.Lang_Id,
                       Lang_key=l.Lang_key,
                       Lang_name=l.Lang_name
                   },
                   IconNav=new IconNav { 
                       id_IconNav=i.id_IconNav,
                       nameHint=i.nameHint,
                       nameNav=i.nameNav,
                       urlNav=i.urlNav
                   }
                }).ToList();
            
            return View(data);
        }
        public JsonResult Icon()
        {
            var data = _context.Language.Join(
                _context.IconNav,
                l => l.Lang_Id,
                i => i.lang_Id,
                (l, i) => new allData
                {
                    language = new Language
                    {
                        Lang_Id = l.Lang_Id,
                        Lang_key = l.Lang_key,
                        Lang_name = l.Lang_name
                    },
                    IconNav = new IconNav
                    {
                        id_IconNav = i.id_IconNav,
                        nameHint = i.nameHint,
                        nameNav = i.nameNav,
                        urlNav = i.urlNav,
                        lang_Id=i.lang_Id
                    }
                }).ToList();
            //var data = _context.IconNav.Select(a => new
            //{
            //    a.language.Lang_Id,
            //    a.language.Lang_key,
            //    a.language.Lang_name,
            //    a.nameHint,
            //    a.nameNav,
            //    a.urlNav

            //}).Where(a => a.Lang_key.Contains("ar"));
            return Json(data);
        }
        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.Lang_Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lang_Id,Lang_name,Lang_key")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lang_Id,Lang_name,Lang_key")] Language language)
        {
            if (id != language.Lang_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.Lang_Id))
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
            return View(language);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.Lang_Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var language = await _context.Language.FindAsync(id);
            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
            return _context.Language.Any(e => e.Lang_Id == id);
        }
    }
}
