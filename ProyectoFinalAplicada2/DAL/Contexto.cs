using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cacaos> Cacaos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Cacao.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Fecha = DateTime.Now, Nombres = "Administrador", NombreUsuario = "Admin", Clave = "Admin", Email = "Admin@outlook.com", FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now, UsuarioIdCreacion = 1 });
        }
    }
}
