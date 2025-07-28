using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions;
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
    public class CUAltaEnvio : ICUAltaEnvio
    {

        private IRepositorioEnvio _repoEnvio;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;
        private IRepositorioAgencia _repoAgencia;

        public CUAltaEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAud, IRepositorioUsuario repoUsuario, IRepositorioAgencia repoAgencia)
        {
            _repoEnvio = repoEnvio;
            _repoAud = repoAud;
            _repoUsuario = repoUsuario;
            _repoAgencia = repoAgencia;
        }

        public void AltaEnvio(DTOAltaEnvio dto)
        {

            try
            {

                Agencia agenciaEnvio = _repoAgencia.FindById((int)dto.IDAgenciaEnvio);
                if (agenciaEnvio == null)
                {
                    throw new AgenciaNoEncontradaException();
                }

                Usuario cliente = _repoUsuario.FindByEmail(dto.Email);
                if (cliente == null)
                {
                    throw new UsuarioNoEncontradoException();
                }


                Usuario empleado = _repoUsuario.FindById((int)dto.EmpleadoId);
                if (empleado == null)
                {
                    throw new EmpleadoNoEncontradoException();
                }

                Envio envioNuevo = MapperEnvio.FromDTOAltaEnvioToEnvio(dto, agenciaEnvio);

                envioNuevo.Cliente = cliente;
                envioNuevo.ClienteId = cliente.Id;
                envioNuevo.InicioEnvio = DateTime.Now;
                envioNuevo.Empleado = empleado;
                
                envioNuevo.NumTracking = _repoEnvio.GetNumTracking() + GenerarNumeroTrackingUnico();

                int idEnvio = _repoEnvio.Add(envioNuevo);

                Auditoria aud = new Auditoria(dto.EmpleadoId, "Alta", "Envio", idEnvio.ToString(), "Alta de envío correcta");
                _repoAud.Auditar(aud);
            }
            catch (AgenciaNoEncontradaException ex)
            {
                _repoAud.Auditar(new Auditoria(dto.EmpleadoId, "Alta", "Envio", null, ex.Message));
                throw;
            }
            catch (UsuarioNoEncontradoException ex)
            {
                _repoAud.Auditar(new Auditoria(dto.EmpleadoId, "Alta", "Envio", null, ex.Message));
                throw;
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                _repoAud.Auditar(new Auditoria(dto.EmpleadoId, "Alta", "Envio", null, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                _repoAud.Auditar(new Auditoria(dto.EmpleadoId, "Alta", "Envio", null, ex.Message));
                throw;
            }


        }
        public static int GenerarNumeroTrackingUnico()
        {
            return 100000 + (Math.Abs(Guid.NewGuid().GetHashCode()) % 900000);
        }
    }
}