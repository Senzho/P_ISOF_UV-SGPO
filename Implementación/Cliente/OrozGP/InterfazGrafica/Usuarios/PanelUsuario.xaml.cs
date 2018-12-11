using OrozGP.LogicaNegocio.Usuarios;
using OrozGP.Util;
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
    /// Lógica de interacción para PanelUsuario.xaml
    /// </summary>
    public partial class PanelUsuario : UserControl
    {
        private VentanaPrincipal principal;
        private Usuario usuario;

        private void CargarUsuario()
        {
            this.campoNombre.Text = this.usuario.Nombre;
            this.campoCorreo.Text = this.usuario.Correo;
            this.campoPuesto.Text = this.usuario.Puesto;
        }
        private DatosUsuario ValidarCampos()
        {
            DatosUsuario valor;
            string nombre = this.campoNombre.Text.Trim();
            string correo = this.campoCorreo.Text.Trim();
            string puesto = this.campoPuesto.Text.Trim();
            if (nombre.Length < 5 || nombre.Length > 100)
            {
                valor = DatosUsuario.nombre;
            }
            else if (correo.Length < 5 || correo.Length > 100)
            {
                valor = DatosUsuario.correo;
            }
            else if (puesto.Length < 5 || puesto.Length > 100)
            {
                valor = DatosUsuario.puesto;
            }
            else
            {
                valor = DatosUsuario.ok;
            }
            //Falta validar correo.
            return valor;
        }
        private void MostrarMensajeDatos(DatosUsuario datos)
        {
            VentanaMensaje ventanaMensaje;
            string mensaje;
            switch (datos)
            {
                case DatosUsuario.nombre:
                    mensaje = "El campo 'Nombre' debe tener entre 5 y 100 caractéres";
                    break;
                case DatosUsuario.correo:
                    mensaje = "El campo 'Correo' debe tener entre 5 y 100 caractéres";
                    break;
                //Puesto:
                default:
                    mensaje = "El campo 'Puesto' debe tener entre 5 y 100 caractéres";
                    break;
            }
            ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", mensaje, VentanaMensaje.Botones.ok, this.principal);
            ventanaMensaje.ShowDialog();
        }
        private void Regresar()
        {
            this.principal.dockCentral.Children.Clear();
            this.principal.dockCentral.Children.Add(new PanelUsuarios(this.principal));
        }
        private async Task Registrar()
        {
            string correo = this.campoCorreo.Text.Trim();
            string correoNoArroba = correo.Replace("@", "");
            Usuario usuarioPeticion = new Usuario(0, this.campoNombre.Text.Trim(), correo, this.campoPuesto.Text.Trim(), correoNoArroba, Encriptacion.sha256(correoNoArroba));
            Usuario usuarioRespuesta = await usuarioPeticion.RegistrarUsuario();
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if (usuarioRespuesta.Id == 0)
            {
                tipo = VentanaMensaje.Mensaje.error;
                mensaje = "Lo sentimos, no pudimos registrar el usuario";
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Usuario registrado";
                this.usuario = usuarioRespuesta;
                this.botonEliminar.Content = "Regresar";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Registro", mensaje, VentanaMensaje.Botones.ok, this.principal);
            vMensaje.ShowDialog();
        }
        private async Task Editar()
        {
            Usuario usuarioPeticion = new Usuario(this.usuario.Id, this.campoNombre.Text.Trim(), this.campoCorreo.Text.Trim(), this.campoPuesto.Text.Trim(), "", "");
            bool edicion = await usuarioPeticion.EditarUsuario();
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if (edicion)
            {
                this.usuario = usuarioPeticion;
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Usuario actualizado";
                this.botonEliminar.Content = "Regresar";
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Lo sentimos, no pudimos actualizar el usuario";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Edicion", mensaje, VentanaMensaje.Botones.ok, this.principal);
            vMensaje.ShowDialog();
        }

        enum DatosUsuario
        {
            nombre,
            correo,
            puesto,
            ok,
        };

        public PanelUsuario(VentanaPrincipal principal, Usuario usuario)
        {
            InitializeComponent();
            this.principal = principal;
            this.usuario = usuario;
            if (usuario != null)
            {
                this.CargarUsuario();
            }
            this.campoNombre.Focus();
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Regresar();
        }

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            DatosUsuario datos = this.ValidarCampos();
            if (datos == DatosUsuario.ok)
            {
                if (this.usuario == null)
                {
                    this.Registrar();
                }
                else
                {
                    this.Editar();
                }
            }
            else
            {
                this.MostrarMensajeDatos(datos);
            }
        }

        private void BotonRegresar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Regresar();
        }
    }
}
