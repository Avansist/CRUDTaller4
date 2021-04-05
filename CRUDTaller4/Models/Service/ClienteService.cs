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
    }
}
