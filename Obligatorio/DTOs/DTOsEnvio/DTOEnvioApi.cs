using Obligatorio.DTOs.DTOs.DTOsAgencia;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsEnvio
{
    public class DTOEnvioApi
    {
        public int? NumTracking { get; set; }
        public string? tipoEnvio { get; set; }
        public int? EnvioID { get; set; }
        public int? ClienteId { get; set; }
        public int? Peso { get; set; }
        public List<DTOSeguimiento> Seguimiento { get; set; }
        public string? Estado { get; set; }
        public DTOAgencia? AgenciaEnvio { get; set; }
        public string? Direccion { get; set; }
        public bool? valorDeEntrega { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }
}
