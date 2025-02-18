using Finstats.BaseDatos;
using System.Configuration;
using System.Data;
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
            Instalar_ruta.InstalarRuta(); // Inicializar el directorio al inicio de la aplicación
        }
    }
}
