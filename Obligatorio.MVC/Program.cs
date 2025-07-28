using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasoUso.CUAgencia;
using Obligatorio.LogicaAplicacion.CasoUso.CUEnvio;
using Obligatorio.LogicaAplicacion.CasoUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

            // Registrar el DbContext en el contenedor de servicios 
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString)); //Continuar 8 en delante ef configuration

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Debajo del builder y antes de hacer el build 
            //  builder.Services.AddScoped<, >(); Inyecciones

            //DI - REPOS

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();


            //DI - CASOS USO

            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUListarUsuario, CUListarUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
            builder.Services.AddScoped<ICUActualizarUsuario, CUActualizarUsuario>();
            builder.Services.AddScoped<ICUEliminarUsuario, CUEliminarUsuario>();
            builder.Services.AddScoped<ICUListarAgencias, CUListarAgencias>();
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUListarEnvios, CUListarEnvios>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUComentarEnvio, CUComentarEnvio>();





            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
