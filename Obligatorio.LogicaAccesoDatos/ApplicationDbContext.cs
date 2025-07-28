using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comun> Comun { get; set; }
        public DbSet<Urgente> Urgente { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Envio>().HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>().HasOne(e => e.Empleado).WithMany().HasForeignKey(e => e.EmpleadoId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>().HasDiscriminator<string>("TipoDeEnvio").HasValue<Comun>("Comun").HasValue<Urgente>("Urgente"); //herencia

            modelBuilder.Entity<Comun>().HasOne(c => c.AgenciaEnvio).WithMany().HasForeignKey(c => c.AgenciaEnvioID);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique(); //email unique

            modelBuilder.Entity<Comentario>()
                .Property(c => c.ComentarioId)
                .ValueGeneratedOnAdd();

        }



    }
}
