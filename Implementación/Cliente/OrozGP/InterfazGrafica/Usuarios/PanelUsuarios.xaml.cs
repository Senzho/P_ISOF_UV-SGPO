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
    public partial class PanelUsuarios : UserControl
    {
        private IList<Usuario> usuarios;
        private VentanaPrincipal principal;

        private enum Seleccion
        {
            editar,
            eliminar,
            generar,
        };

        private async Task ObtenerUsuarios()
        {
            this.usuarios = await Usuario.ObtenerUsuarios();
            this.CargarUsuarios();
        }
        private async Task BuscarUsuarios(string clave)
        {
            IList<Usuario> usuariosBusqueda = await Usuario.ObtenerUsuarios(clave);
            if (usuariosBusqueda == null)
            {
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", "Escribe una palabra clave para buscar", VentanaMensaje.Botones.ok, this.principal);
                ventanaMensaje.ShowDialog();
            }
            else
            {
                this.usuarios = usuariosBusqueda;
                this.CargarUsuarios();
            }
        }
        private void CargarUsuarios()
        {
            this.tabla.ItemsSource = this.usuarios;
        }
        private void CargarPanelUsuario(Usuario usuario)
        {
            this.principal.dockCentral.Children.Clear();
            this.principal.dockCentral.Children.Add(new PanelUsuario(this.principal, usuario));
        }
        private bool ValidarSeleccion(Seleccion seleccion)
        {
            Object elemento = this.tabla.SelectedItem;
            bool valida = elemento != null;
            if (!valida)
            {
                string mensaje = seleccion == Seleccion.editar ? "editar" : (seleccion == Seleccion.eliminar ? "eliminar" : "generar credenciales");
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Elemento no seleccionado", "Debes seleccionar un elemento para " + mensaje + ".", VentanaMensaje.Botones.ok, this.principal);
                ventanaMensaje.ShowDialog();
            }
            return valida;
        }
        private async Task EliminarUsuario(Usuario usuario)
        {
            bool baja = await usuario.EliminarUsuario();
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if (baja)
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Usuario eliminado";
                this.BorrarUsuario(usuario);
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.error;
                mensaje = "Lo sentimos, no pudimos eliminar el usuario";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Baja", mensaje, VentanaMensaje.Botones.ok, this.principal);
            vMensaje.ShowDialog();
            this.botonEliminar.IsEnabled = true;
        }
        private void BorrarUsuario(Usuario usuario)
        {
            this.usuarios.Remove(usuario);
            this.tabla.Items.Refresh();
        }
        private void SolicitarConfirmacionBaja()
        {
            VentanaMensaje vMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.confirmacion, "Baja", "¿Está seguro de eliminar al usuario?", VentanaMensaje.Botones.okCancel, this.principal);
            bool? respuesta = vMensaje.ShowDialog();
            if (respuesta.Value)
            {
                this.botonEliminar.IsEnabled = false;
                Usuario usuario = (Usuario)this.tabla.SelectedItem;
                this.EliminarUsuario(usuario);
            }
        }

        public PanelUsuarios(VentanaPrincipal principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.usuarios = new List<Usuario>();
            this.ObtenerUsuarios();
        }

        private void CampoBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.BuscarUsuarios(this.campoBusqueda.Text);
            }
        }
        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            this.CargarPanelUsuario(null);
        }
        private void BotonEditar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarSeleccion(Seleccion.editar))
            {
                Usuario usuario = (Usuario)this.tabla.SelectedItem;
                this.CargarPanelUsuario(usuario);
            }
        }
        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarSeleccion(Seleccion.eliminar))
            {
                this.SolicitarConfirmacionBaja();
            }
        }
        private void BotonCredenciales_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarSeleccion(Seleccion.generar))
            {
                //Generar credenciales.
            }
        }
    }
}
