using Obligatorio.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUAltaEnvio
    {
        void AltaEnvio(DTOAltaEnvio dto);
    }
}
