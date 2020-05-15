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
    /// Lógica de interacción para ElejirUsuarioAReguistrar.xaml
    /// </summary>
    public partial class ElejirUsuarioAReguistrar : Window
    {
        public ElejirUsuarioAReguistrar()
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
                    Reguistro reguistro = new Reguistro(false,null);
                    this.Close();
                    reguistro.Show();
                }
                else
                {
                    ReguistroDocente reguistroDocente = new ReguistroDocente(false,null);
                    this.Close();
                    reguistroDocente.Show();
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
