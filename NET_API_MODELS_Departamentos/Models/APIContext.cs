using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Departamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_MODELS_Departamentos.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Departamento>(entity => {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("Fabricantes");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity => {
                entity.HasKey(e => e.DNI);
                entity.ToTable("Articulos");
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados);
            });
        }

    }
}
