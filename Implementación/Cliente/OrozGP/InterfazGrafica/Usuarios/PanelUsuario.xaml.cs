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

namespace OrozGP.InterfazGrafica.Usuarios
{
    /// <summary>
    /// Lógica de interacción para PanelUsuario.xaml
    /// </summary>
    public partial class PanelUsuario : UserControl
    {
        private VentanaPrincipal principal;
        private Usuario usuario;

        private void CargarUsuario()
        {
            this.campoNombre.Text = this.usuario.Nombre;
            this.campoCorreo.Text = this.usuario.Correo;
            this.campoPuesto.Text = this.usuario.Puesto;
        }
        private DatosUsuario ValidarCampos()
        {
            DatosUsuario valor;
            string nombre = this.campoNombre.Text.Trim();
            string correo = this.campoCorreo.Text.Trim();
            string puesto = this.campoPuesto.Text.Trim();
            if (nombre.Length < 5 || nombre.Length > 100)
            {
                valor = DatosUsuario.nombre;
            }
            else if (correo.Length < 5 || correo.Length > 100)
            {
                valor = DatosUsuario.correo;
            }
            else if (puesto.Length < 5 || puesto.Length > 100)
            {
                valor = DatosUsuario.puesto;
            }
            else
            {
                valor = DatosUsuario.ok;
            }
            //Falta validar correo.
            return valor;
        }
        private void MostrarMensajeDatos(string mensaje)
        {
            MessageBox.Show(mensaje, "Datos no válidos", MessageBoxButton.OK);
        }
        private void Regresar()
        {
            this.principal.dockCentral.Children.Clear();
            this.principal.dockCentral.Children.Add(new PanelUsuarios(this.principal));
        }

        enum DatosUsuario
        {
            nombre,
            correo,
            puesto,
            ok,
        };

        public PanelUsuario(VentanaPrincipal principal, Usuario usuario)
        {
            InitializeComponent();
            this.principal = principal;
            this.usuario = usuario;
            if (usuario != null)
            {
                this.CargarUsuario();
            }
            this.campoNombre.Focus();
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Regresar();
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            switch (this.ValidarCampos())
            {
                case DatosUsuario.nombre:
                    this.MostrarMensajeDatos("El campo 'Nombre' debe tener entre 5 y 100 caractéres");
                    break;
                case DatosUsuario.correo:
                    this.MostrarMensajeDatos("El campo 'Correo' debe tener entre 5 y 100 caractéres");
                    break;
                case DatosUsuario.puesto:
                    this.MostrarMensajeDatos("El campo 'Puesto' debe tener entre 5 y 100 caractéres");
                    break;
                default:
                    //Enviar petición.
                    break;
            }
        }

        private void BotonRegresar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Regresar();
        }
    }
}
