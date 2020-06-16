using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial_Aplicada_1.BLL;
using Parcial_Aplicada_1.Entidades;

namespace Parcial_Aplicada_1.UI
{
    /// <summary>
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        private Articulos Articulos = new Articulos();
        public rArticulos ()
        {
            InitializeComponent();
            this.DataContext = Articulos;
        }
        private void Limpiar()
        {
            this.Articulos = new Articulos();
            this.DataContext = Articulos;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool Validado = true;
            if (ArticulosIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Validado;
        }

       
        
       
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var articulos = ArticulosBLL.Buscar(Utilidades.ToInt(ArticulosIdTextBox.Text));
            if (articulos != null)
                this.Articulos = articulos;
            else
                this.Articulos = new Articulos();

            this.DataContext = this.Articulos;
        }

        private void NuevoButton_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }
        private void EliminarButton_Click_1(object sender, RoutedEventArgs e)
        {
            {
                if (ArticulosBLL.Eliminar(Utilidades.ToInt(ArticulosIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = ArticulosBLL.Guardar(Articulos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int a = int.Parse(ExistenciaTextBox.Text);
                int b = int.Parse(CostoTextBox.Text);
                ValorInventarioTextBox.Text = add(a, b).ToString();
            }
            catch
            {

            }
        }
        public double add(double a, double b)
        {
            double c = a * b;
            return c;
        }
        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(ExistenciaTextBox.Text);
                double b = Convert.ToDouble(CostoTextBox.Text);
                ValorInventarioTextBox.Text = "$ " + add(a, b).ToString();
            }
            catch
            {

            }

        }

       
        

        
    }
}
