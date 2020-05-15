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
    /// Lógica de interacción para ConsultarDocentes.xaml
    /// </summary>
    public partial class ConsultarDocentes : Window
    {
        IManejadorDocentes manejadorDocentes;
        public ConsultarDocentes()
        {
            InitializeComponent();
            manejadorDocentes=new ManejadorDeDocentes(new RepositorioGenerico<Docentes>());

            ActualizarLista();
        }

        private void ActualizarLista()
        {
            ListDocentes.ItemsSource = null;
            ListDocentes.ItemsSource = manejadorDocentes.Read;

        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones ingresoAlSistema = new MenuOperaciones();
            this.Close();
            ingresoAlSistema.Show();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Docentes docentes = ListDocentes.SelectedItem as Docentes;
            if (MessageBox.Show("Esta seguro de eliminar a " + docentes.Nombre, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Stop, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                if (manejadorDocentes.Delete(docentes.id))
                {
                    MessageBox.Show("El docente fue eliminado", "Corecto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    ActualizarLista();
                }

            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Docentes docentes = ListDocentes.SelectedItem as Docentes;
            if (docentes != null)
            {
                ReguistroDocente reguistro = new ReguistroDocente(true, docentes);
                reguistro.ShowDialog();
                ActualizarLista();
            }
        }
    }
}
