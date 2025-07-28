using Obligatorio.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUListarEnvios
    {
        List<DTOEnvios> ListarEnvios();
        List<DTOEnvioApi> PorEmail(string email);
        List<DTOEnvioApi> PorFechas(DTOEnvioXFechas dto);
        List<DTOEnvioApi> PorComentarios(string email, string comentario);


    }
}
