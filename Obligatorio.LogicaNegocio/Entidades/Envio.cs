using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Envio
    {



        [Key]
        public int Id { get; set; }

        [Required]
        public int NumTracking { get; set; }

        [ForeignKey("EmpleadoId")]
        public Usuario Empleado { get; set; }
        public int EmpleadoId { get; set; }

        [ForeignKey("ClienteId")]
        public Usuario Cliente { get; set; }
        public int ClienteId { get; set; }
        public int Peso { get; set; }
        public string Estado { get; set; }
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public DateTime? FinalizarEnvio { get; set; }
        public DateTime? InicioEnvio { get; set; }


        public Envio(int numTracking, Usuario empleado, Usuario cliente, int peso, string estado, List<Comentario> comentario, int clienteId, int empleadoId, DateTime? finalizarEnvio)
        {
            NumTracking = numTracking + 1; //numero autogenerado
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = estado;
            Comentarios = comentario;
            ClienteId = clienteId;
            EmpleadoId = empleadoId;
            FinalizarEnvio = finalizarEnvio;
        }

        public Envio()
        {
        }

        public abstract void Finalizar();

    }
}
