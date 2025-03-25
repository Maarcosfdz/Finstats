using System;
using System.IO;
using System.Windows;
using Finstats.Services; 

namespace Finstats
{
    public partial class MainWindow : Window
    {
        
        private DatabaseService _databaseService;

        // Obtemos o dirtectorio da base de datos de ejemplo e a carpeta cas bases de datos
        static string dbOriginal = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName, "data");
        string dbFolder = Path.Combine(dbOriginal, "dataBases");

        public MainWindow()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(); // Inicializa el servicio
        }

        private void DuplicateDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * cmabiar por se é succes que cambie xa para a pantalla
             */
            try
            {
                int number = 1;
                while (File.Exists(Path.Combine(dbFolder, "dataBase" + number + ".db"))) //basicamente é como nuevo archivo1, 2,3...
                {
                    number++;
                }
                //Crea o archivo
                bool success = _databaseService.DuplicateDatabase(Path.Combine(dbOriginal,"baseDatosOrixinal.db"), Path.Combine(dbFolder, "dataBase" + number + ".db"));

                if (success)
                {
                    MessageBox.Show("Base de datos duplicada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Hubo un error al duplicar la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
