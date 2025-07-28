using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
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
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repoAud;

        public CUFinalizarEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAud)
        {
            _repoEnvio = repoEnvio;
            _repoAud = repoAud;
        }

        public void FinalizarEnvio(DTOEnvios dto)
        {
            try
            {
                Envio e = _repoEnvio.FindById((int)dto.EnvioID);

                if (e.FinalizarEnvio is null)
                {
                    e.FinalizarEnvio = DateTime.Now;
                    e.Finalizar();
                    int repo = _repoEnvio.Update(e);
                    Auditoria aud = new Auditoria(dto.IdLogueado, "FINALIZAR", "Envio", repo.ToString(), "Finalizacion correcta");
                    _repoAud.Auditar(aud);
                }
                else
                {
                throw new YaFinalizoEnvioException();

                }
            }
            catch (EnvioNoEncontradoException e)
            {
                Auditoria aud = new Auditoria(dto.IdLogueado, "FINALIZAR", "Envio", null, e.Message);
                _repoAud.Auditar(aud);
                throw e;
            }
            catch (YaFinalizoEnvioException e)
            {
                Auditoria aud = new Auditoria(dto.IdLogueado, "FINALIZAR", "Envio", null, e.Message);
                _repoAud.Auditar(aud);
                throw e;
            }
        }
    }
}
