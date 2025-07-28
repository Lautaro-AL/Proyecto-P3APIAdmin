using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsEnvio
{
    public class DTOAgregarComentario
    {
        public string Mensaje { get; set; }
        public int EmpleadoId { get; set; }

        public int? LogueadoId { get; set; }
        public int EnvioId { get; set; }

    }
}
