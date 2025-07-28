using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions
{
    public class AgenciaNoEncontradaException : Exception
    {
        public AgenciaNoEncontradaException() : base("No se encontró la agencia indicada.") { }
    }


}
