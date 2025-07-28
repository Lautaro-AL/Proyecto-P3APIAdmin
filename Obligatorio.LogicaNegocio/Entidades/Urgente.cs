using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Urgente : Envio

    {

        public string DireccionPostal { get; set; }
        public bool ValorEntrega { get; set; }
        public Urgente(int numTracking, Usuario empleado, Usuario cliente, int peso, string estado, List<Comentario> comentario, string direccion, bool valor, int clienteId, int empleadoId, DateTime? finalizarEnvio) : base(numTracking, empleado, cliente, peso, estado, comentario, clienteId, empleadoId, finalizarEnvio)
        {
            ValorEntrega = valor;
            DireccionPostal = direccion; //direccion del cliente (NO codigo postal) : ej calle apto etc
        }


        public Urgente() : base()
        {
        }

        public override void Finalizar()
        {
            base.Estado = "Finalizado";
            TimeSpan diferencia = (TimeSpan)(base.FinalizarEnvio - base.InicioEnvio);

            if (diferencia.TotalHours <= 24)
            {
                ValorEntrega = true;
            }
            else
            {
                ValorEntrega = false;
            }
        }
    }
}
