using OrozGP.InterfazGrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrozGP.LogicaNegocio
{
    public class Cargador
    {
        private DockPanel panel;
        private VentanaPrincipal principal;

        private void BorrarYCargar(UIElement elemento)
        {
            this.panel.Children.Clear();
            this.panel.Children.Add(elemento);
        }

        public Cargador(VentanaPrincipal principal, DockPanel panel)
        {
            this.principal = principal;
            this.panel = panel;
        }

        public DockPanel Panel {
            get => panel;
            set => panel = value;
        }
        public VentanaPrincipal Principal {
            get => principal;
            set => principal = value;
        }

        public void Cargar(Window ventana)
        {
            this.BorrarYCargar(ventana);
        }
        public void Cargar(UserControl control)
        {
            this.BorrarYCargar(control);
        }
    }
}
