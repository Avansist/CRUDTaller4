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
using CRUDTaller4.Models.Service;

namespace CRUDTaller4.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _clienteService.ObtenerListaClientes());
        }
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.ObtenerClientePorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasilleroId,Nombre,Correo,Direccion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteTem = await _clienteService.ObtenerClientePorId(cliente.CasilleroId);

                if (clienteTem == null)
                {
                    await _clienteService.GuardarCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.ObtenerClientePorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasilleroId,Nombre,Correo,Direccion")] Cliente cliente)
        {
            if (id != cliente.CasilleroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clienteService.EditarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.ObtenerClientePorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteService.EliminarCliente(cliente);
            return RedirectToAction(nameof(Index));

            //return View(cliente);
        }



        /*
        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.CasilleroId == id);
        }
        */
    }
}
