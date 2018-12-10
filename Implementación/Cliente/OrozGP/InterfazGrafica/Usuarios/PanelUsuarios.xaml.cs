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
    /// Lógica de interacción para PanelUsuarios.xaml
    /// </summary>
    public partial class PanelUsuarios : UserControl
    {
        private IList<Usuario> usuarios;
        private VentanaPrincipal principal;

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
            this.principal.dockCentral.Children.Clear();
            this.principal.dockCentral.Children.Add(new PanelUsuario(this.principal, null));
        }
        private void BotonEditar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario)this.tabla.SelectedItem;
            if (usuario != null)
            {
                this.principal.dockCentral.Children.Clear();
                this.principal.dockCentral.Children.Add(new PanelUsuario(this.principal, usuario));
            }
            else
            {
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Elemento no seleccionado", "Debes seleccionar un elemento para editar", VentanaMensaje.Botones.ok, this.principal);
                ventanaMensaje.ShowDialog();
            }
        }
    }
}
