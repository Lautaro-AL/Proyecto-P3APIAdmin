using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperEnvio
    {
        public static Comentario FromDTOAgregarComentarioToComentario(DTOAgregarComentario dto)
        {
            Comentario coment = new Comentario(dto.Mensaje, DateTime.Now, dto.EmpleadoId);
            return coment;
        }

        public static Envio FromDTOAltaEnvioToEnvio(DTOAltaEnvio dto, Agencia agenciaEnvio)
        {
            Envio envio;

            if (dto.tipoEnvio.Equals("comun"))
            {
                envio = new Comun(0, null, null, (int)dto.Peso, "Ingresado en agencia de origen", null, 0, (int)dto.EmpleadoId, agenciaEnvio, null);

            }
            else
            {
                if (dto.DireccionPostal == null)
                {
                    throw new DireccionPostalException();
                }
                envio = new Urgente(0, null, null, (int)dto.Peso, "Ingresado en agencia de origen", null, dto.DireccionPostal, false, 0, (int)dto.EmpleadoId, null);
            }

            return envio;
        }

        public static DTOEnvios FromEnvioToDTOEnvios(Envio envioEncontrado)
        {

            DTOEnvios e = new DTOEnvios();
            e.EnvioID = envioEncontrado.Id;
            e.ClienteId = envioEncontrado.ClienteId;
            e.NumTracking = envioEncontrado.NumTracking;
            e.Peso = envioEncontrado.Peso;
            e.Mensaje = envioEncontrado.Comentarios.LastOrDefault()?.Mensaje;
            e.Estado = envioEncontrado.Estado;
            e.FechaFinalizacion = envioEncontrado.FinalizarEnvio;
            if (envioEncontrado is Comun comun)
            {
                e.tipoEnvio = "Comun";
                e.AgenciaEnvio = comun.AgenciaEnvioID;
            }
            else if (envioEncontrado is Urgente urgente)
            {
                e.tipoEnvio = "Urgente";
                e.DireccionPostal = urgente.DireccionPostal;
                e.valorEntrega = urgente.ValorEntrega;
            }

            return e;

        }

        public static DTOEnvioApi FromEnvioToDTOEnvioApi(Envio envioEncontrado)
        {

            DTOEnvioApi e = new DTOEnvioApi();
            e.EnvioID = envioEncontrado.Id;
            e.ClienteId = envioEncontrado.ClienteId;
            e.NumTracking = envioEncontrado.NumTracking;
            e.Peso = envioEncontrado.Peso;
            e.Seguimiento = envioEncontrado.Comentarios.Select(c => FromComentarioToDTOSeguimiento(c)).ToList();
            e.Estado = envioEncontrado.Estado;
            e.FechaFinalizacion = envioEncontrado.FinalizarEnvio;
            if (envioEncontrado is Comun comun)
            {
                e.tipoEnvio = "Comun";
                e.AgenciaEnvio = MapperAgencia.FromAgenciaToDTOAgencia(comun.AgenciaEnvio); ;
            }
            else if (envioEncontrado is Urgente urgente)
            {
                e.tipoEnvio = "Urgente";
                e.Direccion = urgente.DireccionPostal;
                e.valorDeEntrega = urgente.ValorEntrega;
            }

            return e;

        }
        public static List<DTOEnvioApi> FromListEnvioToListDTOEnvioApi(List<Envio> envios)
        {
            List<DTOEnvioApi> listaDTO = new List<DTOEnvioApi>();

            foreach (var envio in envios)
            {
                var dto = FromEnvioToDTOEnvioApi(envio);
                listaDTO.Add(dto);
            }

            return listaDTO;
        }


        public static List<DTOEnvios> FromListEnviosToListDTOEnvios(List<Envio> envios)
        {
            List<DTOEnvios> ret = new List<DTOEnvios>();
            foreach (Envio e in envios)
            {
                DTOEnvios dto = new DTOEnvios();
                dto.NumTracking = e.NumTracking;
                dto.Mensaje = e.Comentarios.LastOrDefault()?.Mensaje;
                dto.ClienteId = e.ClienteId;
                dto.Peso = e.Peso;
                dto.Estado = e.Estado;
                dto.EnvioID = e.Id;
                dto.FechaFinalizacion = e.FinalizarEnvio;
                if (e is Comun comun)
                {
                    dto.tipoEnvio = "Comun";
                    dto.AgenciaEnvio = comun.AgenciaEnvioID;
                }
                else if (e is Urgente urgente)
                {
                    dto.tipoEnvio = "Urgente";
                    dto.DireccionPostal = urgente.DireccionPostal;
                    dto.valorEntrega = urgente.ValorEntrega;
                }


                ret.Add(dto);
            }
            return ret;
        }

        public static DTOSeguimiento FromComentarioToDTOSeguimiento(Comentario c)
        {
            DTOSeguimiento dto = new DTOSeguimiento();

            dto.Mensaje = c.Mensaje;
            dto.EmpleadoId = c.EmpleadoId;
            dto.Fecha = c.Fecha;


            return dto;
        }

    }
}

