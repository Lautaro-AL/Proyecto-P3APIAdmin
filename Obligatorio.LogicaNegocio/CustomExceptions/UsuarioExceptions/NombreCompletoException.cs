using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class NombreCompletoException : Exception
    {
        public NombreCompletoException() : base("El nombre completo es obligatorio.") { }
    }
}
