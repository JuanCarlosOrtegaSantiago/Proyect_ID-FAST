using ID_Fast.BIZ;
using ID_Fast.COMMON.Entidades;
using ID_Fast.COMMON.Interfaces;
using ID_Fast.DAL;
using System;
using System.Collections.Generic;
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

namespace ID_Fast.GUI.DESKTOP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorAlumnos manejadorAlumnos;
        public MainWindow()
        {
            InitializeComponent();
            manejadorAlumnos = new ManejadorDeAlumnos(new RepositorioGenerico<Alumno>());
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            ListALumnos.ItemsSource = null;
            ListALumnos.ItemsSource = manejadorAlumnos.Read;
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones ingresoAlSistema = new MenuOperaciones();
            this.Close();
            ingresoAlSistema.Show();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = ListALumnos.SelectedItem as Alumno;
            if (MessageBox.Show("Esta seguro de eliminar a " + alumno.Nombre, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Stop, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                if (manejadorAlumnos.Delete(alumno.id))
                {
                    MessageBox.Show("El Alumno fue eliminado", "Corecto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    ActualizarLista();
                }

            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = ListALumnos.SelectedItem as Alumno;
            Reguistro reguistro = new Reguistro(true, alumno);
            reguistro.ShowDialog();
            ActualizarLista();

        }

        private void GenerarCredencial_Click(object sender, RoutedEventArgs e)
        {
            if (ListALumnos.SelectedItem != null)
            {
                GenerarCredencial generarCredencial = new GenerarCredencial(ListALumnos.SelectedItem as Alumno);
                generarCredencial.ShowDialog();
            }
        }
    }

    
}
