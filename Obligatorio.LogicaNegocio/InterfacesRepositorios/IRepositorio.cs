using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add(T nuevo);//Retornamos int para tener el id luego de insertado t
        T FindById(int id); // Busca por id
        int Remove(T a); // delete
        List<T> FindAll(); // busca y devuelve lista
        int Update(T obj); // update
    }
}
