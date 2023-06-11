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
    public class EstiloesController : Controller
    {
        private readonly confeccionesContext _context;

        public EstiloesController(confeccionesContext context)
        {
            _context = context;
        }

        // GET: Estiloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estilos.ToListAsync());
        }

        // GET: Estiloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos
                .FirstOrDefaultAsync(m => m.CodEstilo == id);
            if (estilo == null)
            {
                return NotFound();
            }

            return View(estilo);
        }

        // GET: Estiloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estiloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstilo,DetalleEstilo")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estilo);
        }

        // GET: Estiloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos.FindAsync(id);
            if (estilo == null)
            {
                return NotFound();
            }
            return View(estilo);
        }

        // POST: Estiloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEstilo,DetalleEstilo")] Estilo estilo)
        {
            if (id != estilo.CodEstilo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstiloExists(estilo.CodEstilo))
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
            return View(estilo);
        }

        // GET: Estiloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos
                .FirstOrDefaultAsync(m => m.CodEstilo == id);
            if (estilo == null)
            {
                return NotFound();
            }

            return View(estilo);
        }

        // POST: Estiloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estilo = await _context.Estilos.FindAsync(id);
            _context.Estilos.Remove(estilo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstiloExists(int id)
        {
            return _context.Estilos.Any(e => e.CodEstilo == id);
        }
    }
}
