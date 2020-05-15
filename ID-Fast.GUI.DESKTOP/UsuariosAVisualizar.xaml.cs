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
using System.Windows.Shapes;

namespace ID_Fast.GUI.DESKTOP
{
    /// <summary>
    /// Lógica de interacción para UsuariosAVisualizar.xaml
    /// </summary>
    public partial class UsuariosAVisualizar : Window
    {
        public UsuariosAVisualizar()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (RdBtnAlumno.IsChecked == false && RdBtnDocente.IsChecked == false)
            {
                MessageBox.Show("Aun no has seleccionado ningun tipo de usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (RdBtnAlumno.IsChecked == true)
                {
                    MainWindow mainWindow= new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    ConsultarDocentes consultarDocentes= new ConsultarDocentes();
                    this.Close();
                    consultarDocentes.Show();
                }
            }
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones menuOperaciones = new MenuOperaciones();
            this.Close();
            menuOperaciones.Show();
        }
    }
}
