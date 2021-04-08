using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTaller4.Models.Entities
{
    public class Paquete
    {
        public int PaqueteId { get; set; }
        public int Codigo { get; set; }
        public int Peso { get; set; }
        public int CasilleroId { get; set; }
        public int EstadoId { get; set; }
        public int ImagenId { get; set; }
        public int TransportadoraId { get; set; }
        public int TipoMercanciaId { get; set; }
    }
}
