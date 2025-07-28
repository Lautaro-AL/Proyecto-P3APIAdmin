using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.VO
{
    [ComplexType]
    public record VOUbicacionAgencia
    {
        public string Longitud { get; init; }
        public string Latitud { get; init; }

    }
}
