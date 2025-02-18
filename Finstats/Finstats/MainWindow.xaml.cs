using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finstats.BaseDatos;

// aqui o que se recomenda é que este archivo poña as accions dos botons, te mova pola app pero o que fai cada boton etc estea delegado en outros achivos e o importes co using, usar carpetas para organizar archivos

namespace Finstats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //meter esto se podo noutro numespace ou asi
        private void CrearNuevoArchivo(object sender, RoutedEventArgs e)
        {
            // Llamar al método estático para crear el archivo
            GestorArchivos.CrearArchivo();
        }
    }
}