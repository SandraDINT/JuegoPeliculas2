using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeliculaMVVM vm = new PeliculaMVVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            vm.Avanzar();

        }

        private void imageAtras_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            vm.Retroceder();
        }

        private void buttonCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            vm.CargarDatos();
        }

        private void buttonGuardarDatos_Click(object sender, RoutedEventArgs e)
        {
            vm.ExportarDatos();
        }

        private void buttonExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                textBoxImagen.Text = openFileDialog.FileName;
            }
                
        }

        private void buttonNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            vm.CargarDatos();
        }

        private void checkBoxPista_Checked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Visible;
        }

        private void checkBoxPista_Unchecked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Collapsed;
        }

        private void buttonValidar_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxTituloPelicula.Text == vm.PeliculaActual.Titulo)
            {
                MessageBox.Show("¡Has acertado!");
            }
        }

        private void buttonAddPelicula_Click(object sender, RoutedEventArgs e)
        {
            string titulo = textBoxTituloPelicula.Text;
            string cartel = textBoxImagen.Text;
            string pista = pistaGestionar.Text;
            string nivel = comboBoxNivel.Text;
            string genero = comboBoxGenero.Text;
            Pelicula pelicula = 
                new Pelicula(titulo, pista, cartel, nivel, genero);
            vm.AddPelicula(pelicula);
        }
    }
}
