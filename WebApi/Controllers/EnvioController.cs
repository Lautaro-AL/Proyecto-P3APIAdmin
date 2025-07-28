using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.EnviosExceptions;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {

        private ICUObtenerEnvio _CUObtenerEnvio;
        private ICUListarEnvios _CUListarEnvio;


        public EnvioController(ICUObtenerEnvio o, ICUListarEnvios e)
        {
            _CUObtenerEnvio = o;
            _CUListarEnvio = e;
        }

        [HttpGet("{numTracking}")]
        public IActionResult GetEnvioByNumTracking(int numTracking)
        {
            try
            {
                DTOEnvioApi dto = _CUObtenerEnvio.PorNumTracking(numTracking);
                return Ok(dto);
            }
            catch (EnvioNoEncontradoException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error, intenta mas tarde");
            }
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("MisEnvios")]
        public IActionResult ObtenerEnviosPorUser()
        {

            try
            {
                string email = EmailUser();
                List<DTOEnvioApi> dto = _CUListarEnvio.PorEmail(email);
                return Ok(dto);
            }
            catch (NoExistenEnviosParaListarException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error, intenta mas tarde");
            }


        }

        [Authorize(Roles = "Cliente")]
        [HttpPost("PorFechas")]
        public IActionResult ObtenerEnviosPorFechas([FromBody] DTOEnvioXFechas dto)
        {
            try
            {
                List<DTOEnvioApi> envios = _CUListarEnvio.PorFechas(dto);
                return Ok(envios);
            }
            catch (NoExistenEnviosParaListarException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error, intenta mas tarde");
            }
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("PorComentarios")]
        public IActionResult ObtenerEnviosPorComentarios([FromQuery] string? palabra)
        {
            try
            {
                if (!(string.IsNullOrWhiteSpace(palabra)))
                {
                    string email = EmailUser();
                    List<DTOEnvioApi> envios = _CUListarEnvio.PorComentarios(email, palabra);
                    return Ok(envios);
                }
                else
                {
                    return BadRequest("Escriba una palabra para buscar en los comentarios.");
                }
            }
            catch (NoExistenEnviosParaListarException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error, intenta mas tarde");
            }
        }


        private string EmailUser()
        {
            string email = null;
            // como obtener el email del token
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }



    }


}
