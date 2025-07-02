using System;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Models;

namespace FinanceApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        private readonly string _databasePath;

        // Constructor que recibe a ruta da base de datos
        public AppDbContext(string databasePath)
        {
            _databasePath = databasePath;

            // Crea a base de datos e as táboas se non existen
            Database.EnsureCreated();
        }

        // Configuración da conexión a SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={_databasePath}");
            }
        }

        // Configuración das relacións  REVISAR
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave primaria e propiedades obrigatorias
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Nombre);

            modelBuilder.Entity<Category>()
                .Property(c => c.Nombre)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.IdentGasto)
                .IsRequired();

            modelBuilder.Entity<Movimiento>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd(); // Auto-incremento

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Nombre)
                .IsRequired();

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Cant)
                .IsRequired();

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Data)
                .IsRequired();

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.IdentGasto)
                .IsRequired();

            // Relación moitos a moitos sen cascada
            modelBuilder.Entity<Movimiento>()
                .HasMany(m => m.Categories)
                .WithMany(c => c.Movimientos)
                .UsingEntity<Dictionary<string, object>>(
                    "MovimientoCategory",
                    j => j
                        .HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("CategoryNombre")
                        .HasPrincipalKey(c => c.Nombre)
                        .OnDelete(DeleteBehavior.Cascade), // Elimina só da táboa intermedia

                    j => j
                        .HasOne<Movimiento>()
                        .WithMany()
                        .HasForeignKey("MovimientoId")
                        .OnDelete(DeleteBehavior.Cascade), // Elimina só da táboa intermedia

                    j =>
                    {
                        j.HasKey("MovimientoId", "CategoryNombre");
                    });
        }

    }
}
