using CRUDTaller4.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTaller4.Models.Abstract
{
    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> ObtenerListaPaquetes();
        Task<Paquete> ObtenerPaquetePorId(int id);
        Task GuardarPaquete(Paquete Paquete);
        Task EditarPaquete(Paquete Paquete);
        Task EliminarPaquete(Paquete Paquete);
    }
}
