using OrozGP.InterfazGrafica.Catalogos;
using OrozGP.InterfazGrafica.Usuarios;
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

        private void CargarPanelUsuarios()
        {
            this.dockCentral.Children.Clear();
            this.dockCentral.Children.Add(new PanelUsuarios(this));
        }
        private void CargarPanelCategoriasTipo(int tipo)
        {
            this.dockCentral.Children.Clear();
            this.dockCentral.Children.Add(new PanelCategoriasTipo(tipo));
        }

        public VentanaPrincipal()
        {
            InitializeComponent();
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
