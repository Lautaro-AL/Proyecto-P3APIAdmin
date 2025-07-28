using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUUsuario
{
    public class CUModificarPasswordCliente : ICUModificarPasswordCliente
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;

        public CUModificarPasswordCliente(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAud)
        {
            _repoUsuario = repoUsuario;
            _repoAud = repoAud;
        }
        public void Ejecutar(DTOModificarPassword dto)
        {
            Usuario u = _repoUsuario.FindByEmail(dto.Email);

            bool passCorrecta = Utilidades.Bcrypt.BcryptPassword.VerifyPasswordConBcrypt(dto.PasswordOriginal, u.Password);
            if (!passCorrecta)
            {
                throw new PasswordIncorrectaException();
            }
            string nuevopass = Utilidades.Bcrypt.BcryptPassword.HashPasswordConBcrypt(dto.PasswordNueva, 12);

            u.Password = nuevopass;
            _repoUsuario.Update(u);
        }
    }
}
