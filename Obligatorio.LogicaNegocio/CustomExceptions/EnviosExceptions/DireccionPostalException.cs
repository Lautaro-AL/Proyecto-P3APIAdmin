using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions
{
    public class DireccionPostalException : Exception
    {
        public DireccionPostalException() : base("La direccion no puede ser vacia") { }

    }
}
