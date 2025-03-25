using System;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Models;

//revisar porque metin un copypega de manual
namespace FinanceApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        private string _databasePath;

        // Constructor que recibe la ruta de la base de datos
        public AppDbContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        // Configuración de la base de datos (usando la ruta dinámica)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)  // Solo configurar si no está configurado ya
            {
                optionsBuilder.UseSqlite($"Data Source={_databasePath}");
            }
        }

        // Configuración de las relaciones entre las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación muchos a muchos entre Movimiento y Category
            modelBuilder.Entity<Movimiento>()
                .HasMany(m => m.Categories)
                .WithMany(c => c.Movimientos)
                .UsingEntity<Dictionary<string, object>>(
                    "MovimientoCategory",
                    mc => mc.HasOne<Category>().WithMany().HasForeignKey("CategoryName"),
                    mc => mc.HasOne<Movimiento>().WithMany().HasForeignKey("MovimientoId")
                );
        }
    }
}
