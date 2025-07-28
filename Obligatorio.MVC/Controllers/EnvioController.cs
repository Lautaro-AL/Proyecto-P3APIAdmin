using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOsEnvio;
using Obligatorio.LogicaAplicacion.CasoUso.CUAgencia;
using Obligatorio.LogicaAplicacion.CasoUso.CUEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.MVC.Filtros;
using Obligatorio.MVC.Models;

namespace Obligatorio.MVC.Controllers
{
    public class EnvioController : Controller
    {
        private ICUListarAgencias _CUListarAgencias;
        private ICUAltaEnvio _CUAltaEnvio;
        private ICUListarEnvios _CUListarEnvios;
        private ICUFinalizarEnvio _CUFinalizar;
        private ICUObtenerEnvio _CUObtenerEnvio;
        private ICUComentarEnvio _CUComentarEnvio;


        public EnvioController(ICUListarAgencias cUListarAgencias, ICUAltaEnvio cUAltaEnvio, ICUListarEnvios cuListarEnvios, ICUFinalizarEnvio f, ICUObtenerEnvio o, ICUComentarEnvio cUComentarEnvio)
        {
            _CUListarAgencias = cUListarAgencias;
            _CUAltaEnvio = cUAltaEnvio;
            _CUListarEnvios = cuListarEnvios;
            _CUFinalizar = f;
            _CUObtenerEnvio = o;
            _CUComentarEnvio = cUComentarEnvio;
        }
        [LogueadoAuthorize]
        public IActionResult Index()
        {
            return View(_CUListarEnvios.ListarEnvios());
        }
        [LogueadoAuthorize]
        [HttpGet]
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach (var agencias in _CUListarAgencias.Ejecutar())
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencias.Nombre;
                sItem.Value = agencias.Id.ToString();
                vm.AgenciasaDisponibles.Add(sItem);
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                vm.Dto.EmpleadoId = lid;
                _CUAltaEnvio.AltaEnvio(vm.Dto);
                TempData["Mensaje"] = "Alta correcta";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Create");

            }

            return View(vm);
        }
        [LogueadoAuthorize]
        public IActionResult Finalizar(int id)
        {
            try
            {
                DTOEnvios dto = _CUObtenerEnvio.PorID(id);
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                dto.IdLogueado = lid;
                _CUFinalizar.FinalizarEnvio(dto);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("Index");
        }
        [LogueadoAuthorize]
        public IActionResult Comentar(int id)
        {
            AgregarComentarioViewModel vm = new AgregarComentarioViewModel();
            DTOEnvios dto = _CUObtenerEnvio.PorID(id);
            vm.DtoEnvio = dto;
            return View(vm);

        }

        [HttpPost]
        public IActionResult Comentar(AgregarComentarioViewModel vm)
        {
            try
            {
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                vm.DtoComentario.LogueadoId = lid;
                _CUComentarEnvio.EnviarComentario(vm.DtoComentario);
                TempData["Mensaje"] = "Comentario agregado.";

            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

    }
}
