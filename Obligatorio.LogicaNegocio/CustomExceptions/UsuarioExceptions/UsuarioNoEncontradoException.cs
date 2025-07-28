using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException() : base("No se encontro Usuario") { }
    }
}
