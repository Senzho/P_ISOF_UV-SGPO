﻿#pragma checksum "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37E9499682EB5938452585D32A275F88A49B9EDE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using OrozGP.InterfazGrafica.Usuarios;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OrozGP.InterfazGrafica.Usuarios {
    
    
    /// <summary>
    /// PanelUsuarios
    /// </summary>
    public partial class PanelUsuarios : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox campoBusqueda;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tabla;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonEditar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonEliminar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonCredenciales;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonNuevo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OrozGP;component/interfazgrafica/usuarios/panelusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.campoBusqueda = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
            this.campoBusqueda.KeyUp += new System.Windows.Input.KeyEventHandler(this.CampoBusqueda_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tabla = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.botonEditar = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.botonEliminar = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.botonCredenciales = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.botonNuevo = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\InterfazGrafica\Usuarios\PanelUsuarios.xaml"
            this.botonNuevo.Click += new System.Windows.RoutedEventHandler(this.BotonNuevo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

