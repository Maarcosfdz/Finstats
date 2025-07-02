using FinanceApp.Data;
using Finstats.Services; 
using System;
using System.IO;
using System.Windows;

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
            if (Directory.Exists(dbFolder)) //Si existe la carpeta
            {
                string[] dbFiles = Directory.GetFiles(dbFolder, "*db"); //bases de datos das carpetas
                ShowDataBases(dbFiles);
            }
            else //Si no reinicia la app
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        private void DuplicateDatabaseButton_Click(object sender, RoutedEventArgs e)
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

        private void ShowDataBases(string[] dbFiles) 
        {
            DatabaseList.Items.Clear(); 

            foreach (string filePath in dbFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath); 
                DatabaseList.Items.Add(fileName);
            }
        }
        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if (DatabaseList.SelectedItem is string fileName)
            {
                string selectedDatabase = Path.Combine(dbFolder, fileName + ".db");
                _databaseService = new DatabaseService(selectedDatabase); // Inicializa el servicio, nn sei se teño que cerralo ao cerrar, mirar
                DashboardView dashboardView = new DashboardView(selectedDatabase);
                dashboardView.Show();
            }
        }
    }
}
