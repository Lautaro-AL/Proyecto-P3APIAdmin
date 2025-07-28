using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.DTOs.DTOs.DTOsAuth;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _CULogin;

        public AuthController(ICULogin login)
        {
            _CULogin = login;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin dto)
        {
            if (dto == null)
            {
                return BadRequest("Debe proporcionar el email y la contraseña.");
            }

            try
            {
                DTOUsuario u = new DTOUsuario();
                u.Email = dto.Email;
                u.Password = dto.Password;

                DTOUsuario b = _CULogin.VerificarUsuario(u);
                if (b.Rol == "Cliente")
                {
                    var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                    var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                    List<Claim> claims = [
                        new Claim(ClaimTypes.Email, b.Email),
                        new Claim(ClaimTypes.Role, b.Rol)
                    ];
                    var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);
                    var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { Token = jwt });
                }
                else { return StatusCode(403, "Solo los clientes tienen acceso"); }
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ErrorLoginException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error inesperado al intentar iniciar sesión. Intente más tarde.");
            }
        }
    }
}
