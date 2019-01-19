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
    /// <summary>
    /// Clase para cargar un elemento gráfico UIElement al panel principal de la ventana principal.
    /// </summary>
    public class Cargador
    {
        private DockPanel panel;
        private VentanaPrincipal principal;

        /// <summary>
        /// Quita cualquier elemento del panel principal y lo reemplaza por otro.
        /// </summary>
        /// <param name="elemento">Elemento a cargar.</param>
        private void BorrarYCargar(UIElement elemento)
        {
            this.panel.Children.Clear();
            this.panel.Children.Add(elemento);
        }

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="principal">Ventana madre.</param>
        /// <param name="panel">Panel principal.</param>
        public Cargador(VentanaPrincipal principal, DockPanel panel)
        {
            this.principal = principal;
            this.panel = panel;
        }

        /// <value>
        /// Establece o regresa el panel principal.
        /// </value>
        public DockPanel Panel {
            get => panel;
            set => panel = value;
        }
        /// <value>
        /// Establece o regresa la ventana madre.
        /// </value>
        public VentanaPrincipal Principal {
            get => principal;
            set => principal = value;
        }

        /// <summary>
        /// Carga una ventna en el panel principal.
        /// </summary>
        /// <param name="ventana">Ventana para cargar.</param>
        public void Cargar(Window ventana)
        {
            this.BorrarYCargar(ventana);
        }
        /// <summary>
        /// Carga un control de usuario al panel principal.
        /// </summary>
        /// <param name="control">Control de usuario para cargar.</param>
        public void Cargar(UserControl control)
        {
            this.BorrarYCargar(control);
        }
    }
}
