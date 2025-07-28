using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions
{
    public class YaFinalizoEnvioException : Exception
    {
        public YaFinalizoEnvioException() : base("Ya se finalizo el envio") { }
    }
}