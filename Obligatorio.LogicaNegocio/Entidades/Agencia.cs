using Obligatorio.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int DireccionPostal { get; set; }

        [Required]
        public VOUbicacionAgencia UbicacionAgencia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }


        public Agencia(int direccionPostal, VOUbicacionAgencia ubicacionAgencia, string nombre)
        {
            DireccionPostal = direccionPostal;
            UbicacionAgencia = ubicacionAgencia;
            Nombre = nombre;
        }
        protected Agencia() { }
    }
}
