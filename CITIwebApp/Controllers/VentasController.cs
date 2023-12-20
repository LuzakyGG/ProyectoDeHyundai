using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CITIwebApp.Context;
using CITIwebApp.Models;

namespace CITIwebApp.Controllers
{
    public class VentasController : Controller
    {
        private readonly MiContext _context;

        public VentasController(MiContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index(int Buscar)
        {
            if(Buscar==null)
            {
               var miContext = _context.Venta.Include(v => v.Cliente).Include(v => v.Usuario).Include(v => v.Vehiculo);
               return View(await miContext.ToListAsync());
            }
            else if(Buscar==13)
            {
                var miContext = _context.Venta.Include(v => v.Cliente).Include(v => v.Usuario).Include(v => v.Vehiculo);
                return View(await miContext.ToListAsync());
            }
                string b = Buscar.ToString();
                var ventas = from venta in _context.Venta.Include(v => v.Cliente).Include(v => v.Usuario).Include(v => v.Vehiculo) select venta;
                if (!String.IsNullOrEmpty(b))
                {
                    ventas = ventas.Where(v => v.Fecha.Month.ToString().Contains(b));
                }
            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NombreCompleto");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreCompleto");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "Id", "Modelo");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta.UsuarioId = 1;
                venta.Fecha = DateTime.Now;
            
                _context.Add(venta);
                await _context.SaveChangesAsync();
                TempData["VentaRegistrado"] = "Venta Registrada de manera correcta!!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NombreCompleto", venta.ClienteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", venta.UsuarioId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "Id", "Matricula", venta.VehiculoId);
            return View(venta);
        }

       
        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'MiContext.Venta'  is null.");
            }
            var venta = await _context.Venta.FindAsync(id);
            if (venta != null)
            {
                _context.Venta.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return (_context.Venta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
