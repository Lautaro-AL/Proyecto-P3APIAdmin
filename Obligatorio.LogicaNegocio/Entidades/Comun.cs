using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comun : Envio
    {

        public Agencia AgenciaEnvio { get; set; }
        public int AgenciaEnvioID { get; set; }

        public Comun(int numTracking, Usuario empleado, Usuario cliente, int peso, string estado, List<Comentario> comentario, int clienteId, int empleadoId, Agencia agencias, DateTime? finalizarEnvio) : base(numTracking, empleado, cliente, peso, estado, comentario, clienteId, empleadoId, finalizarEnvio)
        {
            AgenciaEnvio = agencias;
        }
        public Comun() : base() { }

        public override void Finalizar()
        {
            base.Estado = "Finalizado";
        }
    }
}
