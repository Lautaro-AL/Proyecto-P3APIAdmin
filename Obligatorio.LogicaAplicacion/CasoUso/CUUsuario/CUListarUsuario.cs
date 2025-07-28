using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUUsuario
{
    public class CUListarUsuario : ICUListarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        public CUListarUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public List<DTOUsuario> ListarUsuarios()
        {
            List<Usuario> usuarios = _repoUsuario.FindAll();
            List<DTOUsuario> listaDeUsuarios = MapperUsuario.FromListUsuarioToListDTOUsuario(usuarios);
            if (usuarios is null)
            {
                throw new NoExistenUsuariosException();
            }
            return listaDeUsuarios;
        }
    }
}
