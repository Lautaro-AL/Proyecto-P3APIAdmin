using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class ErrorLoginException : Exception
    {
        public ErrorLoginException() : base("Error. Verifique si las Credenciales son correctas") { }
    }
}
