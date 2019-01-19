using OrozGP.LogicaNegocio;
using OrozGP.LogicaNegocio.Catalogos;
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

namespace OrozGP.InterfazGrafica.Catalogos
{
    /// <summary>
    /// Clase controladora para el control de usuario del panel de materiales.
    /// </summary>
    public partial class PanelMateriales : UserControl
    {
        private Cargador cargador;
        private int tipo;
        private Categoria categoria;
        private IList<Material> materiales;

        /// <summary>
        /// Obtiene los materiales de una categoría de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        private async Task ObtenerMateriales()
        {
            this.materiales = await Material.ObtenerMateriales(this.categoria.Id);
            this.CargarMateriales();
        }
        /// <summary>
        /// Establece la fuente de datos para la tabla.
        /// </summary>
        private void CargarMateriales()
        {
            this.tabla.ItemsSource = this.materiales;
        }
        /// <summary>
        /// Verifica la selección de un elemento de la tabla.
        /// </summary>
        /// <param name="seleccion">Enumerador con el tipo de acción a realizar.</param>
        /// <returns>
        /// Un booleano con la confirmación de selección.
        /// </returns>
        private bool ValidarSeleccion(Seleccion seleccion)
        {
            Object elemento = this.tabla.SelectedItem;
            bool valida = elemento != null;
            if (!valida)
            {
                string mensaje = seleccion == Seleccion.editar ? "editar" : "eliminar";
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Elemento no seleccionado", "Debes seleccionar un elemento para " + mensaje + ".", VentanaMensaje.Botones.ok, this.cargador.Principal);
                ventanaMensaje.ShowDialog();
            }
            return valida;
        }
        /// <summary>
        /// Obtiene los materiales relacionados con una palabra clave de forma asíncrona.
        /// </summary>
        /// <param name="clave">Palabra clave para la búsqueda (campo de búsqueda).</param>
        /// <returns></returns>
        private async Task BuscarMateriales(string clave)
        {
            IList<Material> materialesBusqueda = await Material.ObtenerMateriales(this.categoria.Id, clave);
            if (materialesBusqueda == null)
            {
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", "Escribe una palabra clave para buscar", VentanaMensaje.Botones.ok, this.cargador.Principal);
                ventanaMensaje.ShowDialog();
            }
            else
            {
                this.materiales = materialesBusqueda;
                this.CargarMateriales();
            }
        }
        /// <summary>
        /// Solicita la confirmación para la baja de un material seleccionado.
        /// </summary>
        private void SolicitarConfirmacionBaja()
        {
            VentanaMensaje vMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.confirmacion, "Baja", "¿Está seguro de eliminar el material?", VentanaMensaje.Botones.okCancel, this.cargador.Principal);
            bool? respuesta = vMensaje.ShowDialog();
            if (respuesta.Value)
            {
                this.botonEliminar.IsEnabled = false;
                Material material = (Material)this.tabla.SelectedItem;
                this.EliminarMaterial(material);
            }
        }
        /// <summary>
        /// Elimina un material de forma asíncrona.
        /// </summary>
        /// <param name="material">Material para eliminar.</param>
        /// <returns></returns>
        private async Task EliminarMaterial(Material material)
        {
            bool baja = await material.EliminarMaterial();
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if (baja)
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Material eliminado";
                this.BorrarMaterial(material);
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.error;
                mensaje = "Lo sentimos, no pudimos eliminar el material";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Baja", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
            this.botonEliminar.IsEnabled = true;
        }
        /// <summary>
        /// Borra un material de la fuente de datos de la tabla y refresca.
        /// </summary>
        /// <param name="material">Material para borrar.</param>
        private void BorrarMaterial(Material material)
        {
            this.materiales.Remove(material);
            this.tabla.Items.Refresh();
        }

        private enum Seleccion
        {
            editar,
            eliminar,
        };

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="cargador">Instancia del cargador de elementos.</param>
        /// <param name="tipo">Tipo de categoría de materiales.</param>
        /// <param name="categoria">Categoría de materiales.</param>
        public PanelMateriales(Cargador cargador, int tipo, Categoria categoria)
        {
            InitializeComponent();
            this.cargador = cargador;
            this.tipo = tipo;
            this.categoria = categoria;
            this.etiquetaCategoria.Content = categoria.Nombre;
            this.ObtenerMateriales();
        }

        private void BotonRegresar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.cargador.Cargar(new PanelCategoriasTipo(this.tipo, this.cargador));
        }
        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            this.cargador.Cargar(new PanelMaterial(this.categoria, this.tipo, this.cargador, null));
        }
        private void BotonEditar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarSeleccion(Seleccion.editar))
            {
                Material material = (Material)this.tabla.SelectedItem;
                this.cargador.Cargar(new PanelMaterial(this.categoria, this.tipo, this.cargador, material));
            }
        }
        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarSeleccion(Seleccion.eliminar))
            {
                this.SolicitarConfirmacionBaja();
            }
        }
        private void CampoBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.BuscarMateriales(this.campoBusqueda.Text.Trim());
            }
        }
    }
}
