using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
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
using System.Windows.Shapes;

namespace ID_Fast.GUI.DESKTOP
{
    /// <summary>
    /// Lógica de interacción para CredencialesDocentes.xaml
    /// </summary>
    public partial class CredencialesDocentes : Window
    {
        Docentes _docente;
        public CredencialesDocentes(Docentes docentes)
        {
            InitializeComponent();
            _docente = docentes;

            lblArea.Content = _docente.Area;
            lblMatricula.Content = _docente.Matricula;
            lblNombre.Content = string.Format("{0} {1}", _docente.Nombre, _docente.Apellidos);
            IMGUsuario.Source = ByteToImagen(_docente.Foto);
            lblNumSeguro.Content = _docente.Num_Seguro;

            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(string.Format(_docente.Num_Seguro), out qrCode);
            WriteableBitmapRenderer wRenderer = new WriteableBitmapRenderer(new FixedModuleSize(2, QuietZoneModules.Two), Colors.Black, Colors.White);
            WriteableBitmap wBitmap = new WriteableBitmap(50, 50, 50, 50, PixelFormats.Gray8, null);
            wRenderer.Draw(wBitmap, qrCode.Matrix);

            QrCodeImage.Source = null;
            QrCodeImage.Source = wBitmap;
        }

        private ImageSource ByteToImagen(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage bitimg = new BitmapImage();
                MemoryStream las = new MemoryStream(imageData);
                bitimg.BeginInit();
                bitimg.StreamSource = las;
                bitimg.EndInit();
                ImageSource imgSrc = bitimg as ImageSource;
                return imgSrc;
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
