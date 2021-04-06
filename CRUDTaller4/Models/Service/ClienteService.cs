using CRUDTaller4.Models.Abstract;
using CRUDTaller4.Models.DAL;
using CRUDTaller4.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTaller4.Models.Service
{

    public class ClienteService : IClienteService
    {
        private readonly DbContextCrud _context;

        public ClienteService(DbContextCrud context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> ObtenerClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(m => m.CasilleroId == id);
        }

        public async Task GuardarCliente(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task EditarCliente(Cliente cliente)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task EliminarCliente(Cliente cliente)
        {
            try
            {

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
