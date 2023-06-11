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
    public class ConfeccionsController : Controller
    {
        private readonly confeccionesContext _context;

        public ConfeccionsController(confeccionesContext context)
        {
            _context = context;
        }

        // GET: Confeccions
        public async Task<IActionResult> Index()
        {
            var confeccionesContext = _context.Confeccions.Include(c => c.CodEstiloNavigation);
            return View(await confeccionesContext.ToListAsync());
        }

        // GET: Confeccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccion = await _context.Confeccions
                .Include(c => c.CodEstiloNavigation)
                .FirstOrDefaultAsync(m => m.CodConfeccion == id);
            if (confeccion == null)
            {
                return NotFound();
            }

            return View(confeccion);
        }

        // GET: Confeccions/Create
        public IActionResult Create()
        {
            ViewData["CodEstilo"] = new SelectList(_context.Estilos, "CodEstilo", "CodEstilo");
            return View();
        }

        // POST: Confeccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodConfeccion,CodEstilo,Medidas")] Confeccion confeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodEstilo"] = new SelectList(_context.Estilos, "CodEstilo", "CodEstilo", confeccion.CodEstilo);
            return View(confeccion);
        }

        // GET: Confeccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccion = await _context.Confeccions.FindAsync(id);
            if (confeccion == null)
            {
                return NotFound();
            }
            ViewData["CodEstilo"] = new SelectList(_context.Estilos, "CodEstilo", "CodEstilo", confeccion.CodEstilo);
            return View(confeccion);
        }

        // POST: Confeccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodConfeccion,CodEstilo,Medidas")] Confeccion confeccion)
        {
            if (id != confeccion.CodConfeccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfeccionExists(confeccion.CodConfeccion))
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
            ViewData["CodEstilo"] = new SelectList(_context.Estilos, "CodEstilo", "CodEstilo", confeccion.CodEstilo);
            return View(confeccion);
        }

        // GET: Confeccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccion = await _context.Confeccions
                .Include(c => c.CodEstiloNavigation)
                .FirstOrDefaultAsync(m => m.CodConfeccion == id);
            if (confeccion == null)
            {
                return NotFound();
            }

            return View(confeccion);
        }

        // POST: Confeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confeccion = await _context.Confeccions.FindAsync(id);
            _context.Confeccions.Remove(confeccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfeccionExists(int id)
        {
            return _context.Confeccions.Any(e => e.CodConfeccion == id);
        }
    }
}
