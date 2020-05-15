using ID_Fast.BIZ;
using ID_Fast.COMMON.Entidades.ClassIntermedia;
using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
using ID_Fast.COMMON.Interfaces;
using ID_Fast.DAL;
using Microsoft.Win32;
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
    /// Lógica de interacción para ReguistroDocente.xaml
    /// </summary>
    public partial class ReguistroDocente : Window
    {
        IManejadorDocentes manejadorDeDocentes;
        public EDO_SALUD SALUD;
        Docentes docenteEditado;
        public bool EsEditar = false;
        bool Activo;
        public ReguistroDocente(bool EsEdicion,Docentes docentes )
        {
            InitializeComponent();

            EsEditar = EsEdicion;
            manejadorDeDocentes = new ManejadorDeDocentes(new RepositorioGenerico<Docentes>());

            if (!EsEditar)
            {
                LimpiarCajas();
                HabilitarCajas(false);
            }
            else
            {
                docenteEditado = docentes;
                LLenarCampos();
                BtnNuevo.IsEnabled = false;
                BtnRegresar.IsEnabled = false;
            }
        }

        private void LLenarCampos()
        {
            txtApellidos.Text = docenteEditado.Apellidos;
            txtMatricula.Text = docenteEditado.Matricula;
            txtNombre.Text = docenteEditado.Nombre;
            txtArea.Text = docenteEditado.Area;
            txtEspecialidad.Text = docenteEditado.Especialidad;
            if (docenteEditado.EstaActivo)
                EstaActivo.IsChecked = true;
            else
                NoEstaActivo.IsChecked = true;
            Img.Source = ByteToImagen(docenteEditado.Foto);
            SALUD = new EDO_SALUD()
            {
                Alergias = docenteEditado.Alergias,
                Num_Seguro = docenteEditado.Num_Seguro,
                TipoDeSangre = docenteEditado.TipoDeSangre
            };
        }

        private void HabilitarCajas(bool v)
        {
            WrpDatos.IsEnabled = v;
            WrpFoto.IsEnabled = v;
            BtnCancelar.IsEnabled = v;
            BtnNuevo.IsEnabled = !v;
            BtnRegresar.IsEnabled = !v;
            BtnReguistrar.IsEnabled = v;
        }

        private void LimpiarCajas()
        {
            txtApellidos.Clear();
            txtArea.Clear();
            txtEspecialidad.Clear();
            txtMatricula.Clear();
            txtNombre.Clear();
            EstaActivo.IsChecked= false;
            NoEstaActivo.IsChecked= false;
            Img.Source = null;

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajas();
            HabilitarCajas(true);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones menuOperaciones = new MenuOperaciones();
            this.Close();
            menuOperaciones.Show();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajas();
            HabilitarCajas(false);
        }

        private void BtnEstadoSalud_Click(object sender, RoutedEventArgs e)
        {
            AgregarEstadoDeSalud agregarEstadoDeSalud = new AgregarEstadoDeSalud(EsEditar, SALUD);
            agregarEstadoDeSalud.ShowDialog();
            SALUD = agregarEstadoDeSalud.sALUD;
        }

        private void BtnCargarIMg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecciona la fotografia";
            dialog.Filter = "Formato de imagen|*.jpg; *.png";
            if (dialog.ShowDialog().Value)
            {
                Img.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void BtnReguistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellidos.Text) && !string.IsNullOrWhiteSpace(txtArea.Text) && !string.IsNullOrWhiteSpace(txtEspecialidad.Text) && !string.IsNullOrWhiteSpace(txtMatricula.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) && EstaActivo.IsChecked == true || NoEstaActivo.IsChecked == true)
            {

                if (EsEditar)
                {
                    docenteEditado.Apellidos = txtApellidos.Text;
                    docenteEditado.Area = txtArea.Text;
                    docenteEditado.Especialidad = txtEspecialidad.Text;
                    docenteEditado.EstaActivo = Activo;
                    docenteEditado.Foto = ImageToByte(Img.Source);
                    docenteEditado.Matricula = txtMatricula.Text;
                    docenteEditado.Nombre = txtNombre.Text;
                    docenteEditado.Alergias = SALUD.Alergias;
                    docenteEditado.Num_Seguro = SALUD.Num_Seguro;
                    docenteEditado.TipoDeSangre = SALUD.TipoDeSangre;
                    if (manejadorDeDocentes.Update(docenteEditado))
                    {
                        MessageBox.Show("El docente fue modificado correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se modifico el docente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {

                    Docentes docentes = new Docentes()
                    {
                        Apellidos = txtApellidos.Text,
                        Area = txtArea.Text,
                        Especialidad = txtEspecialidad.Text,
                        EstaActivo = Activo,
                        Foto = ImageToByte(Img.Source),
                        Matricula = txtMatricula.Text,
                        Nombre = txtNombre.Text,
                        Alergias = SALUD.Alergias,
                        Num_Seguro = SALUD.Num_Seguro,
                        TipoDeSangre = SALUD.TipoDeSangre
                    };
                    if (manejadorDeDocentes.Create(docentes))
                    {
                        MessageBox.Show("El docente fue agreado correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        LimpiarCajas();
                        HabilitarCajas(false);
                    }
                    else
                    {
                        MessageBox.Show("No se agrego el docente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Faltan datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EstaActivo_Click(object sender, RoutedEventArgs e)
        {
            Activo = true;
        }

        private void NoEstaActivo_Click(object sender, RoutedEventArgs e)
        {
            Activo = false;
        }

        public byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
            else
            {
                return null;
            }
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
    }
}
