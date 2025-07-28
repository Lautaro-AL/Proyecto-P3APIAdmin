using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasoUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAud;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAud)
        {
            _repoUsuario = repoUsuario;
            _repoAud = repoAud;
        }

        public void AltaUsuario(DTOAltaUsuario dto)
        {
            try
            {
                Usuario u = MapperUsuario.FromDTOAltaUsuarioToUsuario(dto);
                u.Validar();
                int idEntidad = _repoUsuario.Add(u);

                Auditoria aud = new Auditoria(dto.LogueadoId, "Alta", "Usuario", idEntidad.ToString(), "Alta Correcta"); //Se puede agregar un jSon serialize, ver en aulas
                _repoAud.Auditar(aud);
            }
            catch (NoExisteRolException e)
            {
                Auditoria aud = new Auditoria(dto.LogueadoId, "Alta", "Usuario", null, e.Message);
                _repoAud.Auditar(aud);
                throw;
            }
            catch (CrearUsuarioException e)
            {
                Auditoria aud = new Auditoria(dto.LogueadoId, "Alta", "Usuario", null, e.Message);
                _repoAud.Auditar(aud);
                throw;
            }
        }
    }
}
