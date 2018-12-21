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
    public partial class PanelMateriales : UserControl
    {
        private Cargador cargador;
        private int tipo;
        private Categoria categoria;
        private IList<Material> materiales;

        private async Task ObtenerMateriales()
        {
            this.materiales = await Material.ObtenerMateriales(this.categoria.Id);
            this.CargarMateriales();
        }
        private void CargarMateriales()
        {
            this.tabla.ItemsSource = this.materiales;
        }
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

        private enum Seleccion
        {
            editar,
            eliminar,
        };

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

            }
        }
    }
}
