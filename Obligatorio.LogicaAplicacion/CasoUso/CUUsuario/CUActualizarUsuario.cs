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
    public class CUActualizarUsuario : ICUActualizarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;

        public CUActualizarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAud)
        {
            _repoUsuario = repoUsuario;
            _repoAud = repoAud;
        }

        public void ActualizarUsuario(DTOUsuario dto)
        {
            try
            {
                Usuario u = _repoUsuario.FindById((int)dto.Id);
                u.Nombre = new LogicaNegocio.VO.VONombreCompleto(dto.Nombre, dto.Apellido);
                u.Email = dto.Email;
                u.Rol = dto.Rol;
                u.Validar();
                int repo = _repoUsuario.Update(u);



                Auditoria aud = new Auditoria(dto.IdLogueado, "UPDATE", "Usuario", repo.ToString(), "Actualización correcta");
                _repoAud.Auditar(aud);
            }
            catch (UsuarioNoEncontradoException e)
            {
                Auditoria aud = new Auditoria(dto.IdLogueado, "UPDATE", "Usuario", null, e.Message);
                _repoAud.Auditar(aud);
                throw e;
            }
        }
    }
}
