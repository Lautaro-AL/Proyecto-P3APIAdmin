using Microsoft.EntityFrameworkCore;
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
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ApplicationDbContext _context;
        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Envio> FindAll()
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Comentarios).OrderByDescending(e => e.InicioEnvio).ToList();
        }
        public List<Envio> FindAllByEmail(string email)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Comentarios).Include(e => (e as Comun).AgenciaEnvio)
                .Where(e => e.Cliente.Email == email).OrderByDescending(e => e.InicioEnvio).ToList();
        }
        public List<Envio> FiltrarEnvios(DateTime f1, DateTime f2, string? estado)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Comentarios).Where(e => e.InicioEnvio >= f1 && e.InicioEnvio <= f2)
                    .Where(e => string.IsNullOrEmpty(estado) || e.Estado.ToLower().Contains(estado.ToLower())).OrderBy(e => e.NumTracking).ToList();
        }
        public List<Envio> FiltrarComentarios(string email, string comentario)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Comentarios)
                .Where(e => e.Cliente.Email == email && e.Comentarios.Any(c => c.Mensaje.Contains(comentario))).OrderByDescending(e => e.InicioEnvio).ToList();
        }
        public Envio FindById(int id)
        {
            return _context.Envios.Find(id);
        }

        public int Remove(Envio e)
        {
            _context.Remove(e);
            _context.SaveChanges();
            return e.Id;
        }

        public int Update(Envio obj)
        {
            _context.Envios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public int GetNumTracking()
        {
            return _context.Envios.OrderByDescending(e => e.NumTracking).Select(e => e.NumTracking).FirstOrDefault();
        }
        public Envio FindByNumTracking(int numTracking)
        {
            return _context.Envios.Include(e => e.Comentarios).Include(e => (e as Comun).AgenciaEnvio).SingleOrDefault(e => e.NumTracking == numTracking);
        }
    }

}

