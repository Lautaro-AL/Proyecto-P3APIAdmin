using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using NuGet.Configuration;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.CasoUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.MVC.Filtros;

namespace Obligatorio.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUAltaUsuario _cuAltaUsuario;
        private ICULogin _cuLogin;
        private ICUListarUsuario _cuListarUsuario;
        private ICUObtenerUsuario _cuObtenerUsuario;
        private ICUActualizarUsuario _CUActualizarUsuario;
        private ICUEliminarUsuario _CUEliminarUsuario;

        public UsuarioController(ICUAltaUsuario cuAltaUsuario, ICULogin cuLogin, ICUListarUsuario cuListarUsuario, ICUActualizarUsuario cUActualizarUsuario, ICUObtenerUsuario cuObtenerUsuario, ICUEliminarUsuario cuEliminarUsuario)
        {
            _cuAltaUsuario = cuAltaUsuario;
            _cuLogin = cuLogin;
            _cuListarUsuario = cuListarUsuario;
            _CUActualizarUsuario = cUActualizarUsuario;
            _cuObtenerUsuario = cuObtenerUsuario;
            _CUEliminarUsuario = cuEliminarUsuario;
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [LogueadoAuthorize]
        [AdministradorAuthorize]

        public IActionResult Index()
        {
            return View(_cuListarUsuario.ListarUsuarios());
        }
        [AdministradorAuthorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                DTOUsuario dtoEdit = _cuObtenerUsuario.ObtenerUsuario(id);
                return View(dtoEdit);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e;
            }
            return RedirectToAction("AccesoDenegado");

        }
        [HttpPost]
        public IActionResult Create(DTOAltaUsuario dto)
        {
            try
            {
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                dto.LogueadoId = lid;
                _cuAltaUsuario.AltaUsuario(dto);
                ViewBag.Mensaje = "Alta correcta";
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e;
            }
            return View(dto);

        }

        [HttpPost]
        public IActionResult Login(DTOUsuario dto)
        {
            try
            {
                DTOUsuario usuarioVerificado = _cuLogin.VerificarUsuario(dto);
                HttpContext.Session.SetInt32("LogueadoId", (int)usuarioVerificado.Id);
                HttpContext.Session.SetString("LogueadoRol", usuarioVerificado.Rol);
                HttpContext.Session.SetString("LogueadoNombreCompleto", usuarioVerificado.Nombre + " " + usuarioVerificado.Apellido);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {

                ViewBag.Mensaje = e.Message;
            }

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Edit(DTOUsuario dtoEdit)
        {
            try
            {
                dtoEdit.IdLogueado = HttpContext.Session.GetInt32("LogueadoId");
                _CUActualizarUsuario.ActualizarUsuario(dtoEdit);
                ViewBag.Mensaje = "Usuario editado correctamente";
            }
            catch (Exception e)
            {

                ViewBag.error = e.Message;
            }
            return View();
        }

        public IActionResult Delete(DTOUsuario dto)
        {
            try
            {
                dto.IdLogueado = HttpContext.Session.GetInt32("LogueadoId");
                _CUEliminarUsuario.EliminarUsuario(dto);
                TempData["Mensaje"] = "Usuario eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return View(dto);
            }
        }
    }
}

