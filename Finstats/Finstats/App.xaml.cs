
using FinanceApp.Data;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Finstats
{
    /// <summary>
    /// Interaction logic for App.xaml  mirar porque nn entendo moi bn pa que se usa esto
    /// </summary>
    // App.xaml.cs
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string ruta = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName, "Data");

            string dbFolder = Path.Combine(ruta, "dataBases");

            string dbOriginal = Path.Combine(ruta, "baseDatosOrixinal.db");

            Directory.CreateDirectory(dbFolder); // non fai falta comprobar se existe, xa o manexa internamente

            // Crear a base de datos orixinal se non existe
            if (!File.Exists(dbOriginal))
            {
                using var context = new AppDbContext(dbOriginal);
                context.Database.EnsureCreated();
            }
        }
    }
}
