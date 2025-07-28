using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;
        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).SingleOrDefault();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public int Remove(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
            return usuario.Id;
        }

        public int Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }

    }
}
