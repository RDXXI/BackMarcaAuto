using BackTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BackTest.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MarcaAuto> MarcasAutos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MarcaAuto>().HasData(
            //        new MarcaAuto
            //        {
            //            Id = 1,
            //            Nombre = "Toyota",
            //            PaisDeOrigen = "Japón",
            //            Fundacion = new DateTime(1937, 8, 28),
            //            SitioWeb = "https://www.toyota.com",
            //            Activa = true,
            //            FechaCreacion = DateTime.UtcNow
            //        },
            //        new MarcaAuto
            //        {
            //            Id = 2,
            //            Nombre = "Ford",
            //            PaisDeOrigen = "Estados Unidos",
            //            Fundacion = new DateTime(1903, 6, 16),
            //            SitioWeb = "https://www.ford.com",
            //            Activa = true,
            //            FechaCreacion = DateTime.UtcNow
            //        },
            //        new MarcaAuto
            //        {
            //            Id = 3,
            //            Nombre = "Chevrolet",
            //            PaisDeOrigen = "Estados Unidos",
            //            Fundacion = new DateTime(1911, 11, 3),
            //            SitioWeb = "https://www.chevrolet.com",
            //            Activa = true,
            //            FechaCreacion = DateTime.UtcNow
            //        }
            //);
        }
    }
}
