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
    public partial class PanelCategoria : UserControl
    {
        private Categoria categoria;
        private ISeleccionCategoria seleccion;

        private void CargarCategoria()
        {
            this.botonCategoria.Content = this.categoria.Nombre;
        }

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
