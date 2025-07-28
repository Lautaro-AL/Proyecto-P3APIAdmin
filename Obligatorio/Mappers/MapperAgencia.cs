using Obligatorio.DTOs.DTOs.DTOsAgencia;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperAgencia
    {
        public static List<DTOAgencia> FromListAgenciaToListDTOAgencia(List<Agencia> agencias)
        {
            List<DTOAgencia> ret = new List<DTOAgencia>();
            foreach (Agencia a in agencias)
            {
                DTOAgencia dto = new DTOAgencia();
                dto.Id = a.Id;
                dto.Nombre = a.Nombre;
                dto.DireccionPostal = a.DireccionPostal;
                dto.Latitud = a.UbicacionAgencia.Latitud;
                dto.Longitud = a.UbicacionAgencia.Longitud;

                ret.Add(dto);
            }
            return ret;
        }

        public static DTOAgencia FromAgenciaToDTOAgencia(Agencia agencia)
        {
            if (agencia == null) return null;

            return new DTOAgencia
            {
                Id = agencia.Id,
                DireccionPostal = agencia.DireccionPostal,
                Nombre = agencia.Nombre,
                Latitud = agencia.UbicacionAgencia?.Latitud,
                Longitud = agencia.UbicacionAgencia?.Longitud
            };
        }


    }
}
