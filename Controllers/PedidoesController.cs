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
    public class PedidoesController : Controller
    {
        private readonly confeccionesContext _context;

        public PedidoesController(confeccionesContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var confeccionesContext = _context.Pedidos.Include(p => p.CodConfeccionNavigation).Include(p => p.CodMetodoPagoNavigation).Include(p => p.CodUsuarioNavigation);
            return View(await confeccionesContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.CodConfeccionNavigation)
                .Include(p => p.CodMetodoPagoNavigation)
                .Include(p => p.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion");
            ViewData["CodMetodoPago"] = new SelectList(_context.MetodoPagos, "CodMetodoPago", "CodMetodoPago");
            ViewData["CodUsuario"] = new SelectList(_context.Usuarios, "CodUsuario", "CodUsuario");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodPedido,CodUsuario,CodConfeccion,CodMetodoPago,FechaPedido,FechaEntrega,Comentarios")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", pedido.CodConfeccion);
            ViewData["CodMetodoPago"] = new SelectList(_context.MetodoPagos, "CodMetodoPago", "CodMetodoPago", pedido.CodMetodoPago);
            ViewData["CodUsuario"] = new SelectList(_context.Usuarios, "CodUsuario", "CodUsuario", pedido.CodUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", pedido.CodConfeccion);
            ViewData["CodMetodoPago"] = new SelectList(_context.MetodoPagos, "CodMetodoPago", "CodMetodoPago", pedido.CodMetodoPago);
            ViewData["CodUsuario"] = new SelectList(_context.Usuarios, "CodUsuario", "CodUsuario", pedido.CodUsuario);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodPedido,CodUsuario,CodConfeccion,CodMetodoPago,FechaPedido,FechaEntrega,Comentarios")] Pedido pedido)
        {
            if (id != pedido.CodPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.CodPedido))
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
            ViewData["CodConfeccion"] = new SelectList(_context.Confeccions, "CodConfeccion", "CodConfeccion", pedido.CodConfeccion);
            ViewData["CodMetodoPago"] = new SelectList(_context.MetodoPagos, "CodMetodoPago", "CodMetodoPago", pedido.CodMetodoPago);
            ViewData["CodUsuario"] = new SelectList(_context.Usuarios, "CodUsuario", "CodUsuario", pedido.CodUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.CodConfeccionNavigation)
                .Include(p => p.CodMetodoPagoNavigation)
                .Include(p => p.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.CodPedido == id);
        }
    }
}
