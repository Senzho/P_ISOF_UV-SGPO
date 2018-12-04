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
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void botonIngresar_Click(object sender, RoutedEventArgs e)
        {
            this.iniciarSesion();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.campoUsuario.Focus();
        }
        public async Task iniciarSesion()
        {
            string nombre = this.campoUsuario.Text;
            string contraseña = this.campoContrasena.Password;
            Usuario usuario = await Usuario.iniciarSesion(nombre, contraseña);
            if (usuario.Id > 0)
            {
                Console.WriteLine("Usuario encontrado");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado");
            }
        }
    }
}
