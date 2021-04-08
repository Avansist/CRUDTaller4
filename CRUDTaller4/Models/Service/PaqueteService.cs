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
    public class PaqueteService : IPaqueteService        
    {
        private readonly DbContextCrud _context;
        public PaqueteService(DbContextCrud context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paquete>> ObtenerListaPaquetes()
        {
            return await _context.Paquetes.ToListAsync();
        }

        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _context.Paquetes
                .FirstOrDefaultAsync(m => m.CasilleroId == id);
        }

        public async Task GuardarPaquete(Paquete Paquete)
        {
            try
            {
                _context.Add(Paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task EditarPaquete(Paquete Paquete)
        {
            try
            {
                _context.Update(Paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task EliminarPaquete(Paquete Paquete)
        {
            try
            {

                _context.Remove(Paquete);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
