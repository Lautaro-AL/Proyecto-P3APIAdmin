using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.VO
{
    [ComplexType]
    public record VONombreCompleto
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public VONombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;


        }
    }

}