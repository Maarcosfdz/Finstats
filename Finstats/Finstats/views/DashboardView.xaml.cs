using FinanceApp.Models;
using Finstats.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Finstats
{
    public partial class DashboardView : Window
    {
        private string _databasePath;
        public string Nombre { get; private set; }
        public decimal Cantidad { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Categoria { get; private set; }

        private readonly DatabaseService _databaseService;


        public DashboardView(string databasePath)
        {
            InitializeComponent();
            _databasePath = databasePath;
            _databaseService = new DatabaseService(databasePath);
            LoadMovimientos();
        }
        private void AbrirPopup_Click(object sender, RoutedEventArgs e)
        {
            popupGasto.IsOpen = true;
        }

        private void CerrarPopup_Click(object sender, RoutedEventArgs e)
        {
            popupGasto.IsOpen = false;
        }

        //Mirar a partir de aqui 
        private void LoadMovimientos()
        {
            var movimientos = _databaseService.GetMovimientos();
            MovimientosDataGrid.ItemsSource = movimientos;
        }

        private void GuardarGasto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;

                if (!float.TryParse(txtCantidad.Text, out float cantidad))
                {
                    MessageBox.Show("Introduce unha cantidade válida.");
                    return;
                }

                DateTime fecha = dateFecha.SelectedDate ?? DateTime.Now;
                string categoriaTexto = ((ComboBoxItem)cbCategoria.SelectedItem)?.Content.ToString();

                var categorias = new List<Category>
        {
            new Category { Nombre = categoriaTexto, IdentGasto = 1 } // O "IdentGasto" aquí é simbólico
        };

                _databaseService.AddExpense(nombre, cantidad, fecha, categorias);

                popupGasto.IsOpen = false;
                LoadMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gardar o gasto: " + ex.Message);
            }
        }

        // A partir de aquí gpt para rellenar
        private void GuardarIngreso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;

                if (!float.TryParse(txtCantidad.Text, out float cantidad))
                {
                    MessageBox.Show("Introduce unha cantidade válida.");
                    return;
                }

                DateTime fecha = dateFecha.SelectedDate ?? DateTime.Now;
                string categoriaTexto = ((ComboBoxItem)cbCategoria.SelectedItem)?.Content.ToString();

                var categorias = _databaseService.GetCategories();
                cbCategoria.ItemsSource = categorias;
                cbCategoria.SelectedIndex = categorias.Any() ? 0 : -1;

                _databaseService.AddIncome(nombre, cantidad, fecha, categorias);

                popupGasto.IsOpen = false;
                LoadMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gardar o gasto: " + ex.Message);
            }
        }

        private void GuardarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = txtNovaCategoria.Text.Trim();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("O nome da categoría non pode estar baleiro.");
                    return;
                }

                // Comprobar se xa existe
                var existe = _databaseService.GetCategories().Any(c => c.Nombre == nome);
                if (existe)
                {
                    MessageBox.Show("Esa categoría xa existe.");
                    return;
                }

                // Obter o valor do tipo desde o ComboBox
                if (cbTipoCategoria.SelectedItem is ComboBoxItem selectedItem &&
                    int.TryParse(selectedItem.Tag.ToString(), out int tipo))
                {
                    var nova = new Category
                    {
                        Nombre = nome,
                        IdentGasto = tipo
                    };

                    _databaseService.AddCategory(nova);

                    MessageBox.Show("Categoría gardada con éxito.");
                    txtNovaCategoria.Text = "";
                    cbTipoCategoria.SelectedIndex = 0;
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("Selecciona o tipo de categoría.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gardar a categoría: " + ex.Message);
            }
        }
        private void CargarCategorias()
        {
            try
            {
                var categorias = _databaseService.GetCategories();
                cbCategoria.ItemsSource = categorias;
                cbCategoria.SelectedIndex = categorias.Any() ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cargar as categorías: " + ex.Message);
            }
        }
        private void EliminarMovimiento_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.Tag is int id)
            {
                var resultado = MessageBox.Show("Seguro que queres eliminar este movemento?",
                                                "Confirmar eliminación", MessageBoxButton.YesNo);

                if (resultado == MessageBoxResult.Yes)
                {
                    _databaseService.EliminarMovimiento(id);
                    LoadMovimientos();
                }
            }
        }

        private void EliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbCategoria.SelectedItem is Category seleccionada)
                {
                    var resultado = MessageBox.Show($"Seguro que queres eliminar a categoría '{seleccionada.Nombre}'?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButton.YesNo);

                    if (resultado == MessageBoxResult.Yes)
                    {
                        _databaseService.EliminarCategoria(seleccionada.Nombre);
                        MessageBox.Show("Categoría eliminada.");
                        CargarCategorias();
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona unha categoría para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar a categoría: " + ex.Message);
            }
        }

    }
}
