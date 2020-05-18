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
    /// Lógica de interacción para MenuOperaciones.xaml
    /// </summary>
    public partial class MenuOperaciones : Window
    {
        public MenuOperaciones()
        {
            InitializeComponent();
            LblLicencia.Foreground = new SolidColorBrush(Colors.Black);

        }
        
        private void BtnReguistrar_Click(object sender, RoutedEventArgs e)
        {
            ElejirUsuarioAReguistrar elejirUsuarioAReguistrar = new ElejirUsuarioAReguistrar();
            this.Close();
            elejirUsuarioAReguistrar.Show();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosAVisualizar usuariosAVisualizar= new UsuariosAVisualizar();
            this.Close();
            usuariosAVisualizar.Show();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            IngresoAlSistema ingresoAlSistema = new IngresoAlSistema();
            this.Close();
            ingresoAlSistema.Show();
        }

        private void LblLicencia_MouseMove(object sender, MouseEventArgs e)
        {
            LblLicencia.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void LblLicencia_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LblLicencia.Foreground = new SolidColorBrush(Colors.Red);
            MessageBox.Show("fue presionado");
        }
        
    }
}
