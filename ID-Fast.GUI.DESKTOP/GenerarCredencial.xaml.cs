using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using ID_Fast.COMMON.Entidades;
using QRCoder;
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
    /// Lógica de interacción para GenerarCredencial.xaml
    /// </summary>
    public partial class GenerarCredencial : Window
    {
        Alumno _alumno;
        public GenerarCredencial( Alumno alumno)
        {
            InitializeComponent();
            _alumno = alumno;

            lblCarrera.Content = _alumno.Carrera;
            lblMatricula.Content = _alumno.Matricula;
            lblNombre.Content = string.Format("{0} {1}",_alumno.Nombre,_alumno.Apellidos);
            IMGUsuario.Source = ByteToImagen(_alumno.Foto);
            lblFechadeIngreso.Content = _alumno.FechaIngreso.ToShortDateString();
            lblNumSeguro.Content = _alumno.Num_Seguro;

            //QRCodeGenerator qr = new QRCodeGenerator();
            //QRCodeData codeData = qr.CreateQrCode("ES un ejemplo", QRCodeGenerator.ECCLevel.Q);
            //QRCode code = new QRCode(codeData);
            //QrCodeImage.Source = code.GetGraphic(5);

            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(_alumno.Matricula, out qrCode);
            WriteableBitmapRenderer wRenderer = new WriteableBitmapRenderer(new FixedModuleSize(2, QuietZoneModules.Two), Colors.Black, Colors.White);
            WriteableBitmap wBitmap = new WriteableBitmap(60, 60, 60, 60, PixelFormats.Gray8, null);
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
