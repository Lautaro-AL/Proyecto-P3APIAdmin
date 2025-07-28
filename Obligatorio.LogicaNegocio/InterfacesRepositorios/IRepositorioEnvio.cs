using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        int GetNumTracking();
        Envio FindByNumTracking(int numTracking);
        List<Envio> FindAllByEmail(string email);
        List<Envio> FiltrarEnvios(DateTime f1, DateTime f2, string? estado);
        List<Envio> FiltrarComentarios(string? comentario, string email);
    }
}
