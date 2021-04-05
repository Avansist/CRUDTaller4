using CRUDTaller4.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTaller4.Models.Abstract
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerClientes();
    }
}
