using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseDeDatos.Entidades.BDContext;

namespace BaseDeDatos.Entidades
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    foreach ( /// Desactiva la eliminacion en cascada de todas las relaciones
        //        var relationship in modelBuilder.Model.GetEntityTypes()
        //        .SelectMany(e => e.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
         
        //}
        public DbSet<Genero> TablaGeneros { get; set; }
        public DbSet<Personaje> TablaPersonajes { get; set; }
        public DbSet<Publico> TablaPublicos { get; set; }
        public DbSet<Serie> TablaSeries { get; set; }
        public DbSet<Usuario> TablaUsuarios { get; set; }
    }
}
