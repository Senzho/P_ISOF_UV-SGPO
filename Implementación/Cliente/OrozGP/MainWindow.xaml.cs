using OrozGP.InterfazGrafica;
using OrozGP.LogicaNegocio.Usuarios;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrozGP
{
    /// <summary>
    /// Clase controladora de la ventana de inicio de sesión.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Muestra la ventana principal y se cierra.
        /// </summary>
        /// <param name="usuario">Usuario autenticado.</param>
        private void DesplegarVentanaPrincipal(Usuario usuario)
        {
            VentanaPrincipal principal = new VentanaPrincipal
            {
                Usuario = usuario
            };
            principal.Show();
            App.Current.MainWindow = principal;
            App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.Close();
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
        /// <summary>
        /// Valida la información de inicio de sesión ingresada.
        /// </summary>
        /// <returns>
        /// Un enumerador con el estado de validéz de la información.
        /// </returns>
        private Login ValidarCampos()
        {
            Login valor;
            string nombre = this.campoUsuario.Text.Trim();
            string contraseña = this.campoContrasena.Password.Trim();
            if (nombre.Length < 5 || nombre.Length > 100)
            {
                valor = Login.nombre;
            }else if (contraseña.Length < 5 || contraseña.Length > 100)
            {
                valor = Login.contraseña;
            }
            else
            {
                valor = Login.ok;
            }
            return valor;
        }
        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="mensaje">Texto del mensaje.</param>
        private void MostrarMensajeError(string mensaje)
        {
            VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", mensaje, VentanaMensaje.Botones.ok, this);
            ventanaMensaje.ShowDialog();
        }

        /// <summary>
        /// Constructor principal de la calse.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Función provicional: pruebas del sistema con inicio de sesión automático.
            /*this.campoUsuario.Text = "victor";
            this.campoContrasena.Password = "snape";
            this.IniciarSesion();*/
            //
        }

        enum Login
        {
            nombre,
            contraseña,
            ok,
        };

        /// <summary>
        /// Obtiene un usuario a partir de los datos ingresados, de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        public async Task IniciarSesion()
        {
            string nombre = this.campoUsuario.Text.Trim();
            string contraseña = this.campoContrasena.Password.Trim();
            Usuario usuario = await Usuario.IniciarSesion(nombre, contraseña);
            if (usuario.Id > 0)
            {
                this.DesplegarVentanaPrincipal(usuario);
            }
            else
            {
                this.MostrarMensajeError("Lo sentimos, no podemos encontrar tu cuenta. Por favor, verifica que tus datos sean correctos");
            }
        }

        private void BotonIngresar_Click(object sender, RoutedEventArgs e)
        {
            switch (this.ValidarCampos())
            {
                case Login.nombre:
                    this.MostrarMensajeError("Tu nombre de usuario debe tener entre 5 y 100 caracteres");
                    break;
                case Login.contraseña:
                    this.MostrarMensajeError("Tu contraseña debe tener entre 5 y 100 caracteres");
                    break;
                default:
                    this.IniciarSesion();
                    break;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.campoUsuario.Focus();
        }
    }
}
