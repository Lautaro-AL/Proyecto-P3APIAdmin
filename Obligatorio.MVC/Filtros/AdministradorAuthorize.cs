using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.MVC.Filtros
{
    public class AdministradorAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.Session.GetString("LogueadoRol");
            if (userRole != "Administrador")
            {
                context.Result = new RedirectToActionResult("AccesoDenegado", "Usuario", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
