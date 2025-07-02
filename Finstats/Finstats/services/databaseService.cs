using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Windows;

namespace Finstats.Services
{
    public class DatabaseService
    {
        // Método para duplicar la base de datos

        /* Facer
         * cambiar o nome dos metodos
         * que se garde solo e co nome predeterminado
         */

        private readonly AppDbContext _dbContext;

        // Recibe la ruta de la base de datos
        public DatabaseService(string dbPath)
        {
            _dbContext = new AppDbContext(dbPath);
        }
        public void DuplicateDatabase(string dbFolder)
        {
            /*
             * cambiar por se é succes que cambie xa para a pantalla
             */
            try
            {
                int number = 1;
                string newDbPath;

                // Buscar un nome dispoñible tipo dataBase1.db, dataBase2.db...
                do
                {
                    newDbPath = Path.Combine(dbFolder, $"dataBase{number}.db");
                    number++;
                } while (File.Exists(newDbPath));

                // Nun futuro añadir para poder personalizar o nome da base de datos

                // Crear a nova base de datos
                using var context = new AppDbContext(newDbPath);
                context.Database.EnsureCreated();


                if (File.Exists(newDbPath))
                {
                    MessageBox.Show("Base de datos duplicada correctamente.");

                    // AbrirNovaPantallaConContexto(context);
                }
                else
                {
                    MessageBox.Show("Non se puido crear a nova base de datos.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Agregar un nuevo gasto

        public void AddExpense(string nombre, float cantidad, DateTime fecha, List<Category> categoria)
        {
            var nuevoGasto = new Movimiento
            {
                Nombre = nombre,
                Cant = cantidad,
                Data = fecha,
                Categories = categoria,
                IdentGasto = 1
            };

            // Agregar el gasto al DbContext
            _dbContext.Movimientos.Add(nuevoGasto);
            _dbContext.SaveChanges();
        }

        public void AddIncome(string nombre, float cantidad, DateTime fecha, List<Category> categoria)
        {
            var nuevoIngreso = new Movimiento
            {
                Nombre = nombre,
                Cant = cantidad,
                Data = fecha,
                Categories = categoria,
                IdentGasto = 0
            };

            // Agregar el gasto al DbContext
            _dbContext.Movimientos.Add(nuevoIngreso);
            _dbContext.SaveChanges();
        }
        public List<Movimiento> GetMovimientos()
        {
            return _dbContext.Movimientos
                             .Include(m => m.Categories)
                             .ToList();
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        //REDVISAR GPT
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public bool CategoriaExiste(string nombre)
        {
            return _dbContext.Categories.Any(c => c.Nombre == nombre);
        }

        public void EliminarMovimiento(int id)
        {
            var movimiento = _dbContext.Movimientos
                .Include(m => m.Categories)
                .FirstOrDefault(m => m.Id == id);

            if (movimiento != null)
            {
                movimiento.Categories.Clear(); // elimina relacións
                _dbContext.Movimientos.Remove(movimiento);
                _dbContext.SaveChanges();
            }
        }
        public void EliminarCategoria(string nome)
        {
            var categoria = _dbContext.Categories
                .Include(c => c.Movimientos)
                .FirstOrDefault(c => c.Nombre == nome);

            if (categoria != null)
            {
                categoria.Movimientos.Clear(); // elimina relacións moitos a moitos
                _dbContext.Categories.Remove(categoria);
                _dbContext.SaveChanges();
            }
        }


    }
}
