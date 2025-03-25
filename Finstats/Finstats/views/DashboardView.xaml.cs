using System;
using System.Windows;

namespace Finstats
{
    public partial class DashboardView : Window
    {
        private string _databasePath;
        public string Nombre { get; private set; }
        public decimal Cantidad { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Categoria { get; private set; }

        public DashboardView(string databasePath)
        {
            InitializeComponent();
            _databasePath = databasePath;
        }
        private void AbrirPopup_Click(object sender, RoutedEventArgs e)
        {
            popupGasto.IsOpen = true;
        }

        private void CerrarPopup_Click(object sender, RoutedEventArgs e)
        {
            popupGasto.IsOpen = false;
        }
    }
}
