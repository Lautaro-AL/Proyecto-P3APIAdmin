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
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;

        public CUEliminarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAud)
        {
            _repoUsuario = repoUsuario;
            _repoAud = repoAud;
        }

        public void EliminarUsuario(DTOUsuario dto)
        {
            try
            {
                Usuario usuario = _repoUsuario.FindById((int)dto.Id);
                int repo = _repoUsuario.Remove(usuario);
                Auditoria aud = new Auditoria(dto.IdLogueado, "DELETE", "Usuario", repo.ToString(), "Usuario Eliminado correctamente");
                _repoAud.Auditar(aud);
            }
            catch (DeleteException e)
            {
                Auditoria aud = new Auditoria(dto.IdLogueado, "DELETE", "Usuario", null, e.Message);
                _repoAud.Auditar(aud);
                throw;
            }catch (Exception e)
            {
                Auditoria aud = new Auditoria(dto.IdLogueado, "DELETE", "Usuario", null, e.Message);
                _repoAud.Auditar(aud);
                throw;
            }

        }


    }
}
