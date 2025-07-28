using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsEnvio
{
    public class DTOSeguimiento
    {
        public string Mensaje { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
