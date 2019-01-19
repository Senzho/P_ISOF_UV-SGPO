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
    /// Clase controladora de la ventana personalizada de mensajes.
    /// </summary>
    public partial class VentanaMensaje : Window
    {
        private Mensaje tipo;
        private string titulo;
        private string mensaje;
        private Botones boton;

        /// <summary>
        /// Carga la imágen de un tipo de mensaje.
        /// </summary>
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
        /// <summary>
        /// Muestra los botones de acuerdo al tipo de mensaje.
        /// </summary>
        private void CargarBotones()
        {
            switch (this.boton)
            {
                case Botones.ok:
                    this.botonCancelar.Visibility = Visibility.Collapsed;
                    break;
                case Botones.okCancel:
                    //No esconder ningún botón.
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

        /// <summary>
        /// COnstructor principal de la clase,
        /// </summary>
        /// <param name="tipo">Tipo de mensaje.</param>
        /// <param name="nombre">Título del mensaje.</param>
        /// <param name="mensaje">Mensaje</param>
        /// <param name="boton">Tipo de botones.</param>
        /// <param name="propietario">Ventana propietaria.</param>
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
