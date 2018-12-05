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
            VentanaPrincipal principal = new VentanaPrincipal();
            principal.Usuario = usuario;
            principal.Show();
            App.Current.MainWindow = principal;
            App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.Close();
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BotonIngresar_Click(object sender, RoutedEventArgs e)
        {
            this.IniciarSesion();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.campoUsuario.Focus();
        }
        public async Task IniciarSesion()
        {
            string nombre = this.campoUsuario.Text;
            string contraseña = this.campoContrasena.Password;
            Usuario usuario = await Usuario.iniciarSesion(nombre, contraseña);
            if (usuario.Id > 0)
            {
                this.DesplegarVentanaPrincipal(usuario);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado");
            }
        }
    }
}
