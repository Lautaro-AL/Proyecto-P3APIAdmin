using Obligatorio.DTOs.DTOs.DTOsAgencia;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia
{
    public interface ICUListarAgencias
    {
        List<DTOAgencia> Ejecutar();
    }
}
