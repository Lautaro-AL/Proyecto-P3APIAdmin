using Obligatorio.DTOs.DTOs.DTOsUsuario;
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
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;

        public CULogin(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAud)
        {
            _repoUsuario = repoUsuario;
            _repoAud = repoAud;
        }
        public DTOUsuario VerificarUsuario(DTOUsuario dto)
        {
            Usuario u = _repoUsuario.FindByEmail(dto.Email);
            if (u == null)
            {
                throw new ErrorLoginException();
            }

            bool PasswordCoincide = Utilidades.Bcrypt.BcryptPassword.VerifyPasswordConBcrypt(dto.Password, u.Password);
            try
            {
                if (PasswordCoincide && u is not null)
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = u.Id;
                    ret.Rol = u.Rol;
                    ret.Nombre = u.Nombre.Nombre;
                    ret.Apellido = u.Nombre.Apellido;
                    ret.Email = u.Email;
                    Auditoria nuevaAud = new Auditoria(u.Id, "Login", "Usuario", null, "Inicio de Sesion correcto");
                    _repoAud.Auditar(nuevaAud);
                    return ret;
                }
                else
                {
                    throw new ErrorLoginException();
                }
            }
            catch (ErrorLoginException e)
            {
                Auditoria nuevaAud = new Auditoria(u.Id, "Login", "Usuario", null, e.Message);
                _repoAud.Auditar(nuevaAud);
                throw e;

            }
        }
    }
}
