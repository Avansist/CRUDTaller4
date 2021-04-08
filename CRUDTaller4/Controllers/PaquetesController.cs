using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDTaller4.Models.DAL;
using CRUDTaller4.Models.Entities;
using CRUDTaller4.Models.Abstract;

namespace CRUDTaller4.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        // GET: Paquetes
        public async Task<IActionResult> Index()
        {
            return View(await _paqueteService.ObtenerListaPaquetes());
        }

        // GET: Paquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _paqueteService.ObtenerPaquetePorId(id.Value);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // GET: Paquetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaqueteId,Codigo,Peso,CasilleroId,EstadoId,ImagenId,TransportadoraId,TipoMercanciaId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                var paqueteTem = await _paqueteService.ObtenerPaquetePorId(paquete.PaqueteId);

                if (paqueteTem == null)
                {
                    await _paqueteService.GuardarPaquete(paquete);
                    return RedirectToAction(nameof(Index));
                }               
            }
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _paqueteService.ObtenerPaquetePorId(id.Value);
            if (paquete == null)
            {
                return NotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaqueteId,Codigo,Peso,CasilleroId,EstadoId,ImagenId,TransportadoraId,TipoMercanciaId")] Paquete paquete)
        {
            if (id != paquete.PaqueteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    await _paqueteService.EditarPaquete(paquete);
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _paqueteService.ObtenerPaquetePorId(id.Value);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }
        /*
        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);
            _context.Paquete.Remove(paquete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteExists(int id)
        {
            return _context.Paquete.Any(e => e.PaqueteId == id);
        }
        */
    }
}
