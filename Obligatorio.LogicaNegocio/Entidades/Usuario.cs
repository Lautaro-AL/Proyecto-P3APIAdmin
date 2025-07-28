using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        public VONombreCompleto Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Rol { get; set; }

        public Usuario(VONombreCompleto nombre, string email, string password, string rol, int id)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Rol = rol;
            Id = id;
        }
        public void Validar()
        {
            if (Nombre == null || string.IsNullOrWhiteSpace(Nombre.Nombre) || string.IsNullOrWhiteSpace(Nombre.Apellido))
                throw new NombreCompletoException();

            if (string.IsNullOrWhiteSpace(Email))
                throw new EmailException();

            if (string.IsNullOrWhiteSpace(Rol))
                throw new RolException();

        }

        public Usuario() { }


    }
}
