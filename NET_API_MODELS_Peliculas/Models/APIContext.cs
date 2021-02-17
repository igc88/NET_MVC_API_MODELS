using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Peliculas.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Pelicula> Fabricantes { get; set; }
        public DbSet<Sala> Articulos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pelicula>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Fabricantes");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Articulos");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.HasOne(d => d.Pelicula).WithMany(p => p.Salas);
            });
        }

    }
}
