using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comentario
    {
        public Comentario(string mensaje, DateTime fecha, int empleadoId)
        {
            Mensaje = mensaje;
            Fecha = fecha;
            EmpleadoId = empleadoId;
        }

        [Key]
        public int ComentarioId { get; set; }

        [Required]
        [StringLength(200)]
        public string Mensaje { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public int EnvioId { get; set; }

        public Envio Envio { get; set; }
    }

}
