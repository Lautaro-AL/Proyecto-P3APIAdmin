using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario
{
    public class DTOModificarPassword
    {
        public string PasswordOriginal { get; set; }
        public string PasswordNueva { get; set; }
        public string? Email { get; set; }

    }
}
