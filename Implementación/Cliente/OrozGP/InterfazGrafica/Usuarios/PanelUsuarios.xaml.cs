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

        private async Task ObtenerUsuarios()
        {
            this.usuarios = await Usuario.ObtenerUsuarios();
            this.CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            this.tabla.ItemsSource = this.usuarios;
        }

        public PanelUsuarios()
        {
            InitializeComponent();
            this.usuarios = new List<Usuario>();
            this.ObtenerUsuarios();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
