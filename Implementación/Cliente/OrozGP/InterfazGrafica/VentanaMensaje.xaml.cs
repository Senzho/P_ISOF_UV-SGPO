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

namespace OrozGP.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para VentanaMensaje.xaml
    /// </summary>
    public partial class VentanaMensaje : Window
    {
        private Mensaje tipo;
        private string titulo;
        private string mensaje;
        private Botones boton;

        private void CargarTipo()
        {
            BitmapImage imagen;
            switch (this.tipo)
            {
                case Mensaje.info:
                    imagen = new BitmapImage(new Uri("/OrozGP;component/Recursos/Imagenes/issue-opened.png", UriKind.Relative));
                    break;
                case Mensaje.error:
                    imagen = new BitmapImage(new Uri("/OrozGP;component/Recursos/Imagenes/issue-opened-red.png", UriKind.Relative));
                    break;
                case Mensaje.confirmacion:
                    imagen = new BitmapImage(new Uri("/OrozGP;component/Recursos/Imagenes/info.png", UriKind.Relative));
                    break;
                default:
                    imagen = new BitmapImage(new Uri("/OrozGP;component/Recursos/Imagenes/check.png", UriKind.Relative));
                    break;
            }
            this.icono.Source = imagen;
            this.etiquetaTitulo.Content = this.titulo;
            this.bloqueMensaje.Text = this.mensaje;
        }
        private void CargarBotones()
        {
            switch (this.boton)
            {
                case Botones.ok:
                    this.botonCancelar.Visibility = Visibility.Collapsed;
                    break;
                //Cancel:
                default:
                    this.botonAceptar.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public enum Mensaje
        {
            info,
            error,
            exito,
            confirmacion,
        };
        public enum Botones
        {
            okCancel,
            ok,
            cancel,
        };

        public VentanaMensaje(Mensaje tipo, string nombre, string mensaje, Botones boton, Window propietario)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.titulo = nombre;
            this.mensaje = mensaje;
            this.boton = boton;
            this.Owner = propietario;
            this.CargarTipo();
            this.CargarBotones();
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
