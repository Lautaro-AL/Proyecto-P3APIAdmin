using Obligatorio.DTOs.DTOs.DTOsAgencia;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUAgencia
{
    public class CUListarAgencias : ICUListarAgencias
    {
        private IRepositorioAgencia _repoAgencia;
        public CUListarAgencias(IRepositorioAgencia repoAgencia)
        {
            _repoAgencia = repoAgencia;
        }

        List<DTOAgencia> ICUListarAgencias.Ejecutar()
        {
            List<Agencia> agencias = _repoAgencia.FindAll();
            List<DTOAgencia> listaDeAgencias = MapperAgencia.FromListAgenciaToListDTOAgencia(agencias);
            return listaDeAgencias;
        }
    }
}
