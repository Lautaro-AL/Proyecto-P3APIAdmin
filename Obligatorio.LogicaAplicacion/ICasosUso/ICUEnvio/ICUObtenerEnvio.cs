using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerEnvio
    {
        DTOEnvios PorID(int id);
        DTOEnvioApi PorNumTracking(int num);
    }
}
