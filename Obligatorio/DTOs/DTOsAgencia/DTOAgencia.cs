using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsAgencia
{
    public class DTOAgencia
    {
        public int? Id { get; set; }
        public int? DireccionPostal { get; set; }
        public string? Longitud { get; set; }
        public string? Latitud { get; set; }
        public string? Nombre { get; set; }

    }
}
