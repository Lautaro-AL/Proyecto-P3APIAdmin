using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions
{
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException() : base($"No se encontró empleado con ese id") { }
    }
}
