using ID_Fast.BIZ;
using ID_Fast.COMMON.Entidades;
using ID_Fast.COMMON.Entidades.ClassIntermedia;
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
    /// Lógica de interacción para Reguistro.xaml
    /// </summary>
    public partial class Reguistro : Window
    {

        bool EstaDadoDeAlta;
        public bool EsEditar=false;
        Alumno alumnoEditado;
        public EDO_SALUD SALUD;

        IManejadorAlumnos manejadorAlumnos;


        public Reguistro(bool EsEdicion, Alumno alumno)
        {
            InitializeComponent();
            EsEditar = EsEdicion;
            manejadorAlumnos = new ManejadorDeAlumnos(new RepositorioGenerico<Alumno>());
            if (!EsEditar)
            {

                LimpiarCajas();
                HabilitarCajas(false);
            }
            else
            {
                alumnoEditado = alumno;
                LLenarCampos();
                BtnNuevo.IsEnabled = false;
                BtnRegresar.IsEnabled = false;
            }

        }

        private void LLenarCampos()
        {
            txtApellidos.Text = alumnoEditado.Apellidos;
            txtCarrera.Text = alumnoEditado.Carrera;
            txtMatricula.Text = alumnoEditado.Matricula;
            txtNombre.Text = alumnoEditado.Nombre;
            txtSemestre.Text = alumnoEditado.Semestre.ToString();
            DateFinSemestre.SelectedDate = alumnoEditado.CicloEscolarFin;
            DateInicioSemestre.SelectedDate = alumnoEditado.CicloEscolarInicio;
            DateF_Ingreso.SelectedDate = alumnoEditado.FechaIngreso;
            if (alumnoEditado.EstaDeAlta)
                EstaDeAlta.IsChecked = true;
            else
                NoEstaDeAlta.IsChecked = true;
            Img.Source = ByteToImagen(alumnoEditado.Foto);
            SALUD = new EDO_SALUD()
            {
                Alergias = alumnoEditado.Alergias,
                Num_Seguro = alumnoEditado.Num_Seguro,
                TipoDeSangre = alumnoEditado.TipoDeSangre
            };

        }

        private void HabilitarCajas(bool v)
        {
            WrpDatos.IsEnabled = v;
            WrpFoto.IsEnabled = v;
            BtnNuevo.IsEnabled = !v;
            BtnRegresar.IsEnabled = !v;
            BtnReguistrar.IsEnabled = v;
            BtnCancelar.IsEnabled = v;
        }

        private void LimpiarCajas()
        {
            txtApellidos.Clear();
            txtCarrera.Clear();
            txtMatricula.Clear();
            txtNombre.Clear();
            txtSemestre.Clear();
            DateFinSemestre.SelectedDate = null;
            DateInicioSemestre.SelectedDate = null;
            DateF_Ingreso.SelectedDate = null;
            EstaDeAlta.IsChecked = false;
            NoEstaDeAlta.IsChecked = false;
            Img.Source = null;
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

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuOperaciones menuOperaciones = new MenuOperaciones();
            this.Close();
            menuOperaciones.Show();
        }

        private void BtnReguistrar_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtApellidos.Text) && !string.IsNullOrWhiteSpace(txtCarrera.Text) && !string.IsNullOrWhiteSpace(txtMatricula.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtSemestre.Text) && DateInicioSemestre.SelectedDate != null && DateFinSemestre.SelectedDate != null && DateF_Ingreso.SelectedDate != null)
            {
                if(EstaDeAlta.IsChecked == true || NoEstaDeAlta.IsChecked == true && Img.Source!= null)
                {
                    try
                    {
                        if (EsEditar)
                        {

                            alumnoEditado.Apellidos = txtApellidos.Text;
                                alumnoEditado.Carrera = txtCarrera.Text;
                                alumnoEditado.CicloEscolarFin = DateFinSemestre.SelectedDate.Value;
                                alumnoEditado.CicloEscolarInicio = DateInicioSemestre.SelectedDate.Value;
                                alumnoEditado.EstaDeAlta = EstaDadoDeAlta;
                                alumnoEditado.FechaIngreso = DateF_Ingreso.SelectedDate.Value;
                                alumnoEditado.Matricula = txtMatricula.Text;
                                alumnoEditado.Nombre = txtNombre.Text;
                                alumnoEditado.Semestre = int.Parse(txtSemestre.Text);
                                alumnoEditado.Foto = ImageToByte(Img.Source);
                                alumnoEditado.Alergias = SALUD.Alergias;
                                alumnoEditado.Num_Seguro = SALUD.Num_Seguro;
                                alumnoEditado.TipoDeSangre = SALUD.TipoDeSangre;
                            
                            if (manejadorAlumnos.Update(alumnoEditado))
                            {
                                MessageBox.Show("El alumno fue Modificado correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se modifico el alumno", "Correcto", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            Alumno alumno = new Alumno()
                            {
                                Apellidos = txtApellidos.Text,
                                Carrera = txtCarrera.Text,
                                CicloEscolarFin = DateFinSemestre.SelectedDate.Value,
                                CicloEscolarInicio = DateInicioSemestre.SelectedDate.Value,
                                EstaDeAlta = EstaDadoDeAlta,
                                FechaIngreso = DateF_Ingreso.SelectedDate.Value,
                                Matricula = txtMatricula.Text,
                                Nombre = txtNombre.Text,
                                Semestre = int.Parse(txtSemestre.Text),
                                Foto = ImageToByte(Img.Source),
                                Alergias = SALUD.Alergias,
                                Num_Seguro = SALUD.Num_Seguro,
                                TipoDeSangre = SALUD.TipoDeSangre
                            };
                            if (manejadorAlumnos.Create(alumno))
                            {
                                MessageBox.Show("El alumno fue agreado correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                LimpiarCajas();
                                HabilitarCajas(false);
                            }
                            else
                            {
                                MessageBox.Show("No se agrego el alumno", "Correcto", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se pudo reguistrar el alumno\nError: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EstaDeAlta_Click(object sender, RoutedEventArgs e)
        {
            EstaDadoDeAlta = true;
        }

        private void NoEstaDeAlta_Click(object sender, RoutedEventArgs e)
        {
            EstaDadoDeAlta = false;
        }

        private void BtnEstadoSalud_Click(object sender, RoutedEventArgs e)
        {
            AgregarEstadoDeSalud agregarEstadoDeSalud = new AgregarEstadoDeSalud(EsEditar,SALUD);
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

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajas();
            HabilitarCajas(true);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (!EsEditar)
            {
                LimpiarCajas();
                HabilitarCajas(false);
            }
            else
            {
                this.Close();
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
