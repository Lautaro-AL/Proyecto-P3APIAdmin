using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ApplicationDbContext _context;

        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Agencia nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> FindAll()
        {
            return _context.Agencias.ToList();
        }

        public Agencia FindById(int id)
        {
            return _context.Agencias.Find(id);
        }

        public int Remove(Agencia a)
        {
            throw new NotImplementedException();
        }

        public int Update(Agencia obj)
        {
            throw new NotImplementedException();
        }
    }
}
