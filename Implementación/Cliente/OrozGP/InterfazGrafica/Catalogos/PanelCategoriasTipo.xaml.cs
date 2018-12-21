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
    public partial class PanelCategoriasTipo : UserControl, ISeleccionCategoria
    {
        private Cargador cargador;
        private int tipo;
        private IList<Categoria> categorias;

        private async Task ObtenerCategorias()
        {
            this.categorias = await Categoria.ObtenerCategorias(this.tipo);
            this.CargarCategorias();
        }
        private void CargarCategorias()
        {
            foreach (Categoria categoria in this.categorias)
            {
                this.panelCategorias.Children.Add(new PanelCategoria(categoria, this));
            }
        }
        private void CargarPanelCatalogo(Categoria categoria)
        {
            if (this.tipo == 1)
            {
                this.cargador.Cargar(new PanelMateriales(this.cargador, this.tipo, categoria));
            }
        }

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
