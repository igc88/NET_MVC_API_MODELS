using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Fabricantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Fabricantes.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Fabricante>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Fabricantes");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);                
            });

            modelBuilder.Entity<Articulo>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Articulos");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.HasOne(d => d.Fabricante).WithMany(p => p.Articulos);
            });
        }
        
    }
}
