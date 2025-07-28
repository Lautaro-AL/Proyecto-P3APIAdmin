using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUUsuario
{
    public class CUObtenerUsuario : ICUObtenerUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUObtenerUsuario(IRepositorioUsuario u)
        {
            _repositorioUsuario = u;
        }
        public DTOUsuario ObtenerUsuario(int id)
        {
            Usuario usuarioEncontrado = _repositorioUsuario.FindById(id);
            if (usuarioEncontrado is null)
            {
                throw new UsuarioNoEncontradoException();
            }
            return MapperUsuario.FromUsuarioToDTOUsuario(usuarioEncontrado);

        }


    }
}
