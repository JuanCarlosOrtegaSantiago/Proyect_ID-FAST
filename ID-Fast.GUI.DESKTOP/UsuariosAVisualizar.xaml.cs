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

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones menuOperaciones = new MenuOperaciones();
            this.Close();
            menuOperaciones.Show();
        }

        private void BtnProfesor_Click(object sender, RoutedEventArgs e)
        {
            ConsultarDocentes consultarDocentes = new ConsultarDocentes();
            this.Close();
            consultarDocentes.Show();
        }

        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
