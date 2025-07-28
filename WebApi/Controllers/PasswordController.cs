using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private ICUModificarPasswordCliente _CUModificarPass;

        public PasswordController(ICUModificarPasswordCliente pass)
        {
            _CUModificarPass = pass;
        }


        [HttpPut("Modificar")]
        [Authorize(Roles = "Cliente")]
        public IActionResult ModificarPasword([FromBody] DTOModificarPassword dto)
        {
            if (dto == null)
            {
                return BadRequest("Debe ingresar la contraseña actual y la nueva.");
            }

            try
            {
                dto.Email = EmailUser();
                _CUModificarPass.Ejecutar(dto);
                return Ok("Contraseña actualizada correctamente.");
            }
            catch (PasswordIncorrectaException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error inesperado. Intente más tarde.");
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
