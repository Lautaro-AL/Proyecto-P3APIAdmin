using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUEnvio
{
    public class CUComentarEnvio : ICUComentarEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repoAud;
        private IRepositorioAgencia _repoAgencia;

        public CUComentarEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAud, IRepositorioAgencia repoAgencia)
        {
            _repoEnvio = repoEnvio;
            _repoAud = repoAud;
            _repoAgencia = repoAgencia;
        }

        public void EnviarComentario(DTOAgregarComentario dto)
        {
            try
            {
                Envio envio = _repoEnvio.FindById(dto.EnvioId);
                Comentario comentarioNuevo = new Comentario(dto.Mensaje, DateTime.Now, dto.EmpleadoId);
                comentarioNuevo.EmpleadoId = (int)dto.LogueadoId;
                comentarioNuevo.EnvioId = dto.EnvioId;

                envio.Comentarios.Add(comentarioNuevo);
                _repoEnvio.Update(envio);
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el comentario al envío.");
            }
        }




    }
}