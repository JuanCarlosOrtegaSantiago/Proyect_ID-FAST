using ID_Fast.BIZ;
using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
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
using System.Windows.Shapes;

namespace ID_Fast.GUI.DESKTOP
{
    /// <summary>
    /// Lógica de interacción para IngresoAlSistema.xaml
    /// </summary>
    public partial class IngresoAlSistema : Window
    {
        IManejadorAdministrativos manejadorAdministrativos;
        public IngresoAlSistema()
        {
            InitializeComponent();

            manejadorAdministrativos = new ManejadorDeAdministrativos(new RepositorioGenerico<Administrativos>());
            DatosAIniciar();
        }

        private void DatosAIniciar()
        {
            if (manejadorAdministrativos.Read.Count < 1)
            {
                Administrativos administrativos = new Administrativos()
                {
                    Contrasenia = "Admin",
                    Correo = "Admin"
                };
                if (!manejadorAdministrativos.Create(administrativos))
                {
                    this.Close();
                }
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtCorreo.Text) && Password.Password != null)
            {

                if (manejadorAdministrativos.BuscarAdmin(txtCorreo.Text, Password.Password))
                {

                    MenuOperaciones mainWindow = new MenuOperaciones();
                    this.Close();
                    mainWindow.Show();
                }
                else
                {

                    MessageBox.Show("No se puede encontra el usuario\nPor favor verifice su correo/contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
