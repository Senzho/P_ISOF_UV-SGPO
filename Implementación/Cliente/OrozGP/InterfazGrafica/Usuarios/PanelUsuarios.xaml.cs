using OrozGP.LogicaNegocio;
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
    /// Clase controladora del control de usuario del panel de usuarios.
    /// </summary>
    public partial class PanelUsuarios : UserControl
    {
        private IList<Usuario> usuarios;
        private Cargador cargador;

        private enum Seleccion
        {
            editar,
            eliminar,
            generar,
        };

        /// <summary>
        /// Obtiene los usarios de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        private async Task ObtenerUsuarios()
        {
            this.usuarios = await Usuario.ObtenerUsuarios();
            this.CargarUsuarios();
        }
        /// <summary>
        /// Obtiene los usuarios relacionados con una palabra clave de forma asíncrona.
        /// </summary>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns></returns>
        private async Task BuscarUsuarios(string clave)
        {
            IList<Usuario> usuariosBusqueda = await Usuario.ObtenerUsuarios(clave);
            if (usuariosBusqueda == null)
            {
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", "Escribe una palabra clave para buscar", VentanaMensaje.Botones.ok, this.cargador.Principal);
                ventanaMensaje.ShowDialog();
            }
            else
            {
                this.usuarios = usuariosBusqueda;
                this.CargarUsuarios();
            }
        }
        /// <summary>
        /// Establece la fuente de datos para la tabla.
        /// </summary>
        private void CargarUsuarios()
        {
            this.tabla.ItemsSource = this.usuarios;
        }
        /// <summary>
        /// Muestra el control de usuario del panel de usuario.
        /// </summary>
        /// <param name="usuario">Usuario a editar.</param>
        private void CargarPanelUsuario(Usuario usuario)
        {
            this.cargador.Cargar(new PanelUsuario(this.cargador, usuario));
        }
        /// <summary>
        /// Verifica la selección de un elemento de la tabla.
        /// </summary>
        /// <param name="seleccion">Tipo de acción de selección.</param>
        /// <returns>
        /// Un booleano con la confirmación de selección.
        /// </returns>
        private bool ValidarSeleccion(Seleccion seleccion)
        {
            Object elemento = this.tabla.SelectedItem;
            bool valida = elemento != null;
            if (!valida)
            {
                string mensaje = seleccion == Seleccion.editar ? "editar" : (seleccion == Seleccion.eliminar ? "eliminar" : "generar credenciales");
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Elemento no seleccionado", "Debes seleccionar un elemento para " + mensaje + ".", VentanaMensaje.Botones.ok, this.cargador.Principal);
                ventanaMensaje.ShowDialog();
            }
            return valida;
        }
        /// <summary>
        /// Elimina un usuario de forma asíncrona.
        /// </summary>
        /// <param name="usuario">Usuario a eliminar.</param>
        /// <returns></returns>
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
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Baja", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
            this.botonEliminar.IsEnabled = true;
        }
        /// <summary>
        /// Borra a un usuario de la fuente de datos de la tabla y refresca.
        /// </summary>
        /// <param name="usuario">Usuario a borrar.</param>
        private void BorrarUsuario(Usuario usuario)
        {
            this.usuarios.Remove(usuario);
            this.tabla.Items.Refresh();
        }
        /// <summary>
        /// Solicita la confirmacón de la baja de un usuario.
        /// </summary>
        private void SolicitarConfirmacionBaja()
        {
            VentanaMensaje vMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.confirmacion, "Baja", "¿Está seguro de eliminar al usuario?", VentanaMensaje.Botones.okCancel, this.cargador.Principal);
            bool? respuesta = vMensaje.ShowDialog();
            if (respuesta.Value)
            {
                this.botonEliminar.IsEnabled = false;
                Usuario usuario = (Usuario)this.tabla.SelectedItem;
                this.EliminarUsuario(usuario);
            }
        }

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="cargador">Instancia del cargador.</param>
        public PanelUsuarios(Cargador cargador)
        {
            InitializeComponent();
            this.cargador = cargador;
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
