using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Confecciones.Data;
using Confecciones.Models;

namespace Confecciones.Controllers
{
    public class ConfeccionTelasController : Controller
    {
        private readonly confeccionesContext _context;

        public ConfeccionTelasController(confeccionesContext context)
        {
            _context = context;
        }

        // GET: ConfeccionTelas
        public async Task<IActionResult> Index()
        {
            var confeccionesContext = _context.ConfeccionTelas.Include(c => c.CodConfeccionNavigation).Include(c => c.CodTelaNavigation);
            return View(await confeccionesContext.ToListAsync());
        }

        // GET: ConfeccionTelas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccionTela = await _context.ConfeccionTelas
                .Include(c => c.CodConfeccionNavigation)
                .Include(c => c.CodTelaNavigation)
                .FirstOrDefaultAsync(m => m.CodTela == id);
            if (confeccionTela == null)
            {
                return NotFound();
            }

            return View(confeccionTela);
        }

        // GET: ConfeccionTelas/Create
        public IActionResult Create()
        {
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion");
            ViewData["CodTela"] = new SelectList(_context.Telas, "CodTela", "CodTela");
            return View();
        }

        // POST: ConfeccionTelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTela,CodConfeccion")] ConfeccionTela confeccionTela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confeccionTela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", confeccionTela.CodConfeccion);
            ViewData["CodTela"] = new SelectList(_context.Telas, "CodTela", "CodTela", confeccionTela.CodTela);
            return View(confeccionTela);
        }

        // GET: ConfeccionTelas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccionTela = await _context.ConfeccionTelas.FindAsync(id);
            if (confeccionTela == null)
            {
                return NotFound();
            }
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", confeccionTela.CodConfeccion);
            ViewData["CodTela"] = new SelectList(_context.Telas, "CodTela", "CodTela", confeccionTela.CodTela);
            return View(confeccionTela);
        }

        // POST: ConfeccionTelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTela,CodConfeccion")] ConfeccionTela confeccionTela)
        {
            if (id != confeccionTela.CodTela)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confeccionTela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfeccionTelaExists(confeccionTela.CodTela))
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
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", confeccionTela.CodConfeccion);
            ViewData["CodTela"] = new SelectList(_context.Telas, "CodTela", "CodTela", confeccionTela.CodTela);
            return View(confeccionTela);
        }

        // GET: ConfeccionTelas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccionTela = await _context.ConfeccionTelas
                .Include(c => c.CodConfeccionNavigation)
                .Include(c => c.CodTelaNavigation)
                .FirstOrDefaultAsync(m => m.CodTela == id);
            if (confeccionTela == null)
            {
                return NotFound();
            }

            return View(confeccionTela);
        }

        // POST: ConfeccionTelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confeccionTela = await _context.ConfeccionTelas.FindAsync(id);
            _context.ConfeccionTelas.Remove(confeccionTela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfeccionTelaExists(int id)
        {
            return _context.ConfeccionTelas.Any(e => e.CodTela == id);
        }
    }
}
