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


        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones menuOperaciones = new MenuOperaciones();
            this.Close();
            menuOperaciones.Show();
        }

        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            Reguistro reguistro = new Reguistro(false, null);
            this.Close();
            reguistro.Show();
        }

        private void BtnProfesor_Click(object sender, RoutedEventArgs e)
        {
            ReguistroDocente reguistroDocente = new ReguistroDocente(false, null);
            this.Close();
            reguistroDocente.Show();
        }
    }
}
