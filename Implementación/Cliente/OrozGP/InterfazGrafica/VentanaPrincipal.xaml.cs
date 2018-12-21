using OrozGP.InterfazGrafica.Catalogos;
using OrozGP.InterfazGrafica.Usuarios;
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
using System.Windows.Shapes;

namespace OrozGP.InterfazGrafica
{
    public partial class VentanaPrincipal : Window
    {
        private Usuario usuario;
        private Cargador cargador;

        private void CargarPanelUsuarios()
        {
            this.cargador.Cargar(new PanelUsuarios(this.cargador));
        }
        private void CargarPanelCategoriasTipo(int tipo)
        {
            this.cargador.Cargar(new PanelCategoriasTipo(tipo, this.cargador));
        }

        public VentanaPrincipal()
        {
            InitializeComponent();
            this.cargador = new Cargador(this, this.dockCentral);
        }

        internal Usuario Usuario {
            get => usuario;
            set => usuario = value;
        }

        private void BotonUsuarios_Click(object sender, RoutedEventArgs e)
        {
            this.CargarPanelUsuarios();
        }

        private void BotonMateriales_Click(object sender, RoutedEventArgs e)
        {
            this.CargarPanelCategoriasTipo(1);
        }
    }
}
