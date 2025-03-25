using System;
using System.IO;
using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Finstats.Services
{
    public class DatabaseService
    {
        // Método para duplicar la base de datos

        /* Facer
         * cambiar o nome dos metodos
         * que se garde solo e co nome predeterminado
         * que se nn existea base de datos orixinal ou a carpeta a cree
         */
        public bool DuplicateDatabase(string sourceDbPath, string destinationDbPath)
        {
            try
            {
                if (File.Exists(sourceDbPath))
                {
                    // Copiar el archivo de la base de datos
                    File.Copy(sourceDbPath, destinationDbPath, overwrite: true);
                    return true;
                }
                else
                {
                    throw new FileNotFoundException("La base de datos original no se encuentra.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al duplicar la base de datos: {ex.Message}");
                return false;
            }
        }

        //pendiente por se teo que añadir unha tabla intermedia e modificr en appdbcntext
        // Agregar un nuevo gasto
        public void AddExpense(string nombre, float cantidad, DateTime fecha, List<Category> categoria)
        {
            var nuevoGasto = new Movimiento
            {
                Nombre = nombre,
                Cant = cantidad,
                Data = fecha,
                Categories = categoria
            };

            // Agregar el gasto al DbContext
            _dbContext.Movimientos.Add(nuevoGasto);
            _dbContext.SaveChanges();
        }
    }
}
