using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.CustomExceptions;
using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.Data;
using Obligatorio.DTOs.DTOs.DTOsEnvio;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTOAltaUsuarioToUsuario(DTOAltaUsuario dto)
        {

            string passHashed = Utilidades.Bcrypt.BcryptPassword.HashPasswordConBcrypt(dto.Password, 12);

            Usuario usuario = new Usuario();
            usuario.Nombre = new VONombreCompleto(dto.Nombre, dto.Apellido);
            usuario.Email = dto.Email;
            usuario.Password = passHashed;
            if (dto.Rol == 1)
            {
                usuario.Rol = "Administrador";
            }
            else if (dto.Rol == 2)
            {
                usuario.Rol = "Funcionario";
            }
            else if (dto.Rol == 3)
            {
                usuario.Rol = "Cliente";
            }
            else
            {
                throw new NoExisteRolException();
            }

            return usuario;
        }

        public static Usuario FromDTOUsuarioToUsuario(DTOUsuario dto)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = new VONombreCompleto(dto.Nombre, dto.Apellido);
            usuario.Email = dto.Email;
            usuario.Rol = dto.Rol;
            usuario.Id = (int)dto.IdLogueado;
            return usuario;
        }


        public static List<DTOUsuario> FromListUsuarioToListDTOUsuario(List<Usuario> usuarios)
        {
            List<DTOUsuario> ret = new List<DTOUsuario>();
            foreach (Usuario u in usuarios)
            {
                DTOUsuario dto = new DTOUsuario();
                dto.Id = u.Id;
                dto.Email = u.Email;
                dto.Nombre = u.Nombre.Nombre;
                dto.Apellido = u.Nombre.Apellido;
                dto.Rol = u.Rol;

                ret.Add(dto);
            }
            return ret;
        }

        public static DTOUsuario FromUsuarioToDTOUsuario(Usuario usuarioEncontrado)
        {
            DTOUsuario dto = new DTOUsuario();
            dto.Id = usuarioEncontrado.Id;
            dto.Email = usuarioEncontrado.Email;
            dto.Nombre = usuarioEncontrado.Nombre.Nombre;
            dto.Apellido = usuarioEncontrado.Nombre.Apellido;
            dto.Rol = usuarioEncontrado.Rol;
            return dto;
        }
    }
}
