using ID_Fast.COMMON.Entidades;
using ID_Fast.COMMON.Entidades.ClassIntermedia;
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
    /// Lógica de interacción para AgregarEstadoDeSalud.xaml
    /// </summary>
    public partial class AgregarEstadoDeSalud : Window
    {
        public EDO_SALUD sALUD;
        public AgregarEstadoDeSalud(bool EsEditar, EDO_SALUD eDO_SALUD)
        {
            InitializeComponent();

            if (EsEditar)
            {
                txtAlergias.Text = eDO_SALUD.Alergias;
                txtNumSeguro.Text= eDO_SALUD.Num_Seguro;
                txtTipoDeSangre.Text= eDO_SALUD.TipoDeSangre;
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtAlergias.Text) && !string.IsNullOrWhiteSpace(txtNumSeguro.Text) && !string.IsNullOrWhiteSpace(txtTipoDeSangre.Text))
            {
                sALUD = new EDO_SALUD
                {
                    Alergias = txtAlergias.Text,
                    Num_Seguro = txtNumSeguro.Text,
                    TipoDeSangre=txtTipoDeSangre.Text
                };


                this.Close();

            }

        }
    }
}
