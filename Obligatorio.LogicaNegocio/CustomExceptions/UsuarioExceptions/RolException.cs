using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class RolException : Exception
    {
        public RolException() : base("El rol es obligatorio.") { }
    }
}
