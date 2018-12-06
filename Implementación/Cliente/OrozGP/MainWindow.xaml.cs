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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Datos no válidos", MessageBoxButton.OK);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        enum Login
        {
            nombre,
            contraseña,
            ok,
        };
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
