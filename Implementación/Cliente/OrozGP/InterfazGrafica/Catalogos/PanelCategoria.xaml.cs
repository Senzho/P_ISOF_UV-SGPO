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
    /// Clase controladora del control de usuario de categoría.
    /// </summary>
    public partial class PanelCategoria : UserControl
    {
        private Categoria categoria;
        private ISeleccionCategoria seleccion;

        /// <summary>
        /// Establece el nombre de la categoría para la vista.
        /// </summary>
        private void CargarCategoria()
        {
            this.botonCategoria.Content = this.categoria.Nombre;
        }

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="categoria">Categoría.</param>
        /// <param name="seleccion">Interfaz de selección de categoría.</param>
        public PanelCategoria(Categoria categoria, ISeleccionCategoria seleccion)
        {
            InitializeComponent();
            this.categoria = categoria;
            this.seleccion = seleccion;
            this.CargarCategoria();
        }
        
        private void BotonCategoria_Click(object sender, RoutedEventArgs e)
        {
            this.seleccion.CategoriaSeleccionada(this.categoria);
        }
    }
}
