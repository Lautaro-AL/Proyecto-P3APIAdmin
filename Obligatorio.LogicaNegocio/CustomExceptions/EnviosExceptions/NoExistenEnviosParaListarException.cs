using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class NoExistenEnviosParaListarException : Exception
    {
        public NoExistenEnviosParaListarException() : base("No se encontraron Envios para listar") { }
    }

}
