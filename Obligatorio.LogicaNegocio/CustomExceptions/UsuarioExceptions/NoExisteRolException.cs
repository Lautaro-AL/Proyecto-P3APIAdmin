using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class NoExisteRolException : Exception
    {
        public NoExisteRolException() : base("No se le asigno ningun Rol") { }

    }
}
