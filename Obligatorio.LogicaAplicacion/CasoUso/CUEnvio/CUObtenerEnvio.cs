using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions;
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
    public class CUObtenerEnvio : ICUObtenerEnvio
    {
        private IRepositorioEnvio _repoEnv;

        public CUObtenerEnvio(IRepositorioEnvio e)
        {
            _repoEnv = e;
        }

        public DTOEnvios PorID(int id)
        {
            Envio envioEncontrado = _repoEnv.FindById(id);
            if (envioEncontrado is null)
            {
                throw new EnvioNoEncontradoException();
            }
            return MapperEnvio.FromEnvioToDTOEnvios(envioEncontrado);
        }

        public DTOEnvioApi PorNumTracking(int num)
        {
            Envio envioEncontrado = _repoEnv.FindByNumTracking(num);
            if (envioEncontrado is null)
            {
                throw new EnvioNoEncontradoException();
            }
            return MapperEnvio.FromEnvioToDTOEnvioApi(envioEncontrado);
        }
    }
}

