
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasoUso.CUEnvio;
using Obligatorio.LogicaAplicacion.CasoUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Interfaces;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

            // Registrar el DbContext en el contenedor de servicios 
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString)); //Continuar 8 en delante ef configuration

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DI - REPOS

            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();


            //DI - CASOS USO

            builder.Services.AddScoped<ICUListarEnvios, CUListarEnvios>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUModificarPasswordCliente, CUModificarPasswordCliente>();

            //JWT
            //La clave debe ser almacenada en el json, o en el sistema operativo cuando esté  en producción.
            var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
            var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Definir las verificaciones a realizar
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = claveCodificada
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            // Habilitar autenticación y autorización
            //Esto debe ir en el siguiente orden
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
