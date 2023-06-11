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
    public class TelasController : Controller
    {
        private readonly confeccionesContext _context;

        public TelasController(confeccionesContext context)
        {
            _context = context;
        }

        // GET: Telas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Telas.ToListAsync());
        }

        // GET: Telas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tela = await _context.Telas
                .FirstOrDefaultAsync(m => m.CodTela == id);
            if (tela == null)
            {
                return NotFound();
            }

            return View(tela);
        }

        // GET: Telas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTela,DetalleTela")] Tela tela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tela);
        }

        // GET: Telas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tela = await _context.Telas.FindAsync(id);
            if (tela == null)
            {
                return NotFound();
            }
            return View(tela);
        }

        // POST: Telas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTela,DetalleTela")] Tela tela)
        {
            if (id != tela.CodTela)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelaExists(tela.CodTela))
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
            return View(tela);
        }

        // GET: Telas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tela = await _context.Telas
                .FirstOrDefaultAsync(m => m.CodTela == id);
            if (tela == null)
            {
                return NotFound();
            }

            return View(tela);
        }

        // POST: Telas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tela = await _context.Telas.FindAsync(id);
            _context.Telas.Remove(tela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelaExists(int id)
        {
            return _context.Telas.Any(e => e.CodTela == id);
        }
    }
}
