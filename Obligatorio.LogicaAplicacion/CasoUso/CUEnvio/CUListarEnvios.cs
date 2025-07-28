using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUEnvio
{
    public class CUListarEnvios : ICUListarEnvios
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAgencia _repoAgencia;
        public CUListarEnvios(IRepositorioEnvio repoEnvio, IRepositorioAgencia repoAgencia)
        {
            _repoEnvio = repoEnvio;
            _repoAgencia = repoAgencia;
        }
        public List<DTOEnvios> ListarEnvios()
        {
            List<Envio> envios = _repoEnvio.FindAll();
            List<DTOEnvios> listaDeEnvios = MapperEnvio.FromListEnviosToListDTOEnvios(envios);

            if (envios is null)
            {
                throw new NoExistenEnviosParaListarException();
            }
            return listaDeEnvios;
        }

        public List<DTOEnvioApi> PorComentarios(string email, string comentario)
        {
            List<Envio> envios = _repoEnvio.FiltrarComentarios(email, comentario);
            List<DTOEnvioApi> listaDeEnvios = MapperEnvio.FromListEnvioToListDTOEnvioApi(envios);

            if (envios.Count == 0)
            {
                throw new NoExistenEnviosParaListarException();
            }
            return listaDeEnvios;
        }

        public List<DTOEnvioApi> PorEmail(string email)
        {
            List<Envio> envios = _repoEnvio.FindAllByEmail(email);
            List<DTOEnvioApi> listaDeEnvios = MapperEnvio.FromListEnvioToListDTOEnvioApi(envios);

            if (envios.Count == 0)
            {
                throw new NoExistenEnviosParaListarException();
            }
            return listaDeEnvios;
        }

        public List<DTOEnvioApi> PorFechas(DTOEnvioXFechas dto)
        {
            List<Envio> envios = _repoEnvio.FiltrarEnvios(dto.F1, dto.F2, dto.Estado);
            List<DTOEnvioApi> listaDeEnvios = MapperEnvio.FromListEnvioToListDTOEnvioApi(envios);

            if (envios is null)
            {
                throw new NoExistenEnviosParaListarException();
            }
            return listaDeEnvios;
        }
    }
}
