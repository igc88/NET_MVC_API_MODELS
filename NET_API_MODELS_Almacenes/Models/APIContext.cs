using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Almacenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Almacenes.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Almacen> almacenes { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Almacen>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Fabricantes");
                entity.Property(e => e.Lugar).IsRequired().HasMaxLength(100).IsUnicode(false);
            });

            modelBuilder.Entity<Caja>(entity => {
                entity.HasKey(e => e.NumReferencia);
                entity.ToTable("Articulos");
                entity.Property(e => e.Contenido).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.HasOne(d => d.Almacen).WithMany(p => p.Articulos);
            });
        }

    }
}
