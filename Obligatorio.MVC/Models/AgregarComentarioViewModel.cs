using Obligatorio.DTOs.DTOs.DTOsEnvio;

namespace Obligatorio.MVC.Models
{
    public class AgregarComentarioViewModel
    {
        public DTOEnvios DtoEnvio { get; set; }
        public DTOAgregarComentario DtoComentario { get; set; } = new DTOAgregarComentario();
    }
}
