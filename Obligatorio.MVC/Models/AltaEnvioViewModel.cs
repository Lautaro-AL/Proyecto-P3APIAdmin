using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOsEnvio;

namespace Obligatorio.MVC.Models
{
    public class AltaEnvioViewModel
    {
        public DTOAltaEnvio Dto { get; set; }
        public List<SelectListItem> TipoDeEnvio { get; set; } = new List<SelectListItem>() {
            new SelectListItem{ Text = "Comun", Value = "comun" },
            new SelectListItem{ Text = "Urgente" , Value= "urgente"}
            };
        public List<SelectListItem> AgenciasaDisponibles { get; set; } = new List<SelectListItem>();

    }
}
