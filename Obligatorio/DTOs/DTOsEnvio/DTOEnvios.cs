using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsEnvio
{
    public class DTOEnvios
    {
        public int? IdLogueado { get; set; }
        public int? EnvioID { get; set; }
        public int? ClienteId { get; set; }
        public int? Peso { get; set; }
        public int? AgenciaEnvio { get; set; }
        public string? DireccionPostal { get; set; }
        public string? Mensaje { get; set; }
        public string? tipoEnvio { get; set; }
        public string? Estado { get; set; }
        public int? NumTracking { get; set; }
        public bool? valorEntrega { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }
}
