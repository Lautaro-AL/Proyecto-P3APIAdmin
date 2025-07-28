
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsEnvio
{
    public class DTOAltaEnvio
    {
        public int? ClienteId { get; set; }
        public int? EmpleadoId { get; set; }
        [Required]

        public int? Peso { get; set; }
        public int? IDAgenciaEnvio { get; set; }
        public string? DireccionPostal { get; set; }
        public string? Mensaje { get; set; }
        public string? tipoEnvio { get; set; }
        [Required]

        public string? Email { get; set; }

    }
}

