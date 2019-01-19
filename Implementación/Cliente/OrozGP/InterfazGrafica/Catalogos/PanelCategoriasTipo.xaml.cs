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
    /// Clase controladora del control de usuario del panel de categorías.
    /// </summary>
    public partial class PanelCategoriasTipo : UserControl, ISeleccionCategoria
    {
        private Cargador cargador;
        private int tipo;
        private IList<Categoria> categorias;

        /// <summary>
        /// Obtiene las categorías de su tipo de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        private async Task ObtenerCategorias()
        {
            this.categorias = await Categoria.ObtenerCategorias(this.tipo);
            this.CargarCategorias();
        }
        /// <summary>
        /// Agrega los controles de usuario de categorías al panel de visualización.
        /// </summary>
        private void CargarCategorias()
        {
            foreach (Categoria categoria in this.categorias)
            {
                this.panelCategorias.Children.Add(new PanelCategoria(categoria, this));
            }
        }
        /// <summary>
        /// Muestra el panel del catálogo correspondiente a una categoría.
        /// </summary>
        /// <param name="categoria">Categoría.</param>
        private void CargarPanelCatalogo(Categoria categoria)
        {
            if (this.tipo == 1)
            {
                this.cargador.Cargar(new PanelMateriales(this.cargador, this.tipo, categoria));
            }
        }

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="tipo">Tipo de categorías a mostrar.</param>
        /// <param name="cargador">Instancia del cargardor de elementos.</param>
        public PanelCategoriasTipo(int tipo, Cargador cargador)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.cargador = cargador;
            this.ObtenerCategorias();
        }

        public void CategoriaSeleccionada(Categoria categoria)
        {
            this.CargarPanelCatalogo(categoria);
        }
    }
}
