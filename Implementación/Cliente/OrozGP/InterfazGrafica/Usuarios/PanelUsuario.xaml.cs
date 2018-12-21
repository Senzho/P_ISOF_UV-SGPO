using OrozGP.LogicaNegocio;
using OrozGP.LogicaNegocio.Usuarios;
using OrozGP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class PanelUsuario : UserControl
    {
        private Cargador cargador;
        private Usuario usuario;

        private void CargarUsuario()
        {
            this.campoNombre.Text = this.usuario.Nombre;
            this.campoCorreo.Text = this.usuario.Correo;
            this.campoPuesto.Text = this.usuario.Puesto;
            this.tablaPermisos.ItemsSource = this.usuario.Permisos;
            this.ObtenerPermisos();
        }
        private async Task ObtenerPermisos()
        {
            this.usuario.Permisos = await Permiso.ObtenerPermisos(this.usuario.Id);
            this.CargarPermisos();
        }
        private void CargarPermisos()
        {
            IList<Permiso> permisos;
            if (this.usuario != null)
            {
                permisos = this.usuario.Permisos;
            }
            else
            {
                permisos = new List<Permiso>()
                {
                    new Permiso(0, "Materiales", false, false, false, false),
                    new Permiso(0, "Herrajes", false, false, false, false),
                    new Permiso(0, "Accesorios", false, false, false, false),
                    new Permiso(0, "Usuarios", false, false, false, false),
                    new Permiso(0, "Presupuestos", false, false, false, false)
                };
            }
            this.tablaPermisos.ItemsSource = permisos;
            this.botonGuardar.IsEnabled = true;
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
                valor = DatosUsuario.correoLongitud;
            }
            else if (!this.ValidarCorreo(correo))
            {
                valor = DatosUsuario.correoIncorrecto;
            }
            else if (puesto.Length < 5 || puesto.Length > 100)
            {
                valor = DatosUsuario.puesto;
            }
            else
            {
                valor = DatosUsuario.ok;
            }
            return valor;
        }
        private bool ValidarCorreo(string correo)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(correo, expresion);
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
                case DatosUsuario.correoLongitud:
                    mensaje = "El campo 'Correo' debe tener entre 5 y 100 caractéres";
                    break;
                case DatosUsuario.correoIncorrecto:
                    mensaje = "El campo 'Correo' no es correcto";
                    break;
                //Puesto:
                default:
                    mensaje = "El campo 'Puesto' debe tener entre 5 y 100 caractéres";
                    break;
            }
            ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            ventanaMensaje.ShowDialog();
        }
        private void Regresar()
        {
            this.cargador.Cargar(new PanelUsuarios(this.cargador));
        }
        private async Task Registrar()
        {
            string correo = this.campoCorreo.Text.Trim();
            string correoNoArroba = correo.Replace("@", "");
            Usuario usuarioPeticion = new Usuario(0, this.campoNombre.Text.Trim(), correo, this.campoPuesto.Text.Trim(), correoNoArroba, Encriptacion.Sha256(correoNoArroba))
            {
                Permisos = (IList<Permiso>)this.tablaPermisos.ItemsSource
            };
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
                this.tablaPermisos.ItemsSource = this.usuario.Permisos;
                this.botonEliminar.Content = "Regresar";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Registro", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
        }
        private async Task Editar()
        {
            Usuario usuarioPeticion = new Usuario(this.usuario.Id, this.campoNombre.Text.Trim(), this.campoCorreo.Text.Trim(), this.campoPuesto.Text.Trim(), "", "")
            {
                Permisos = this.usuario.Permisos
            };
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
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Edicion", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
        }

        enum DatosUsuario
        {
            nombre,
            correoLongitud,
            correoIncorrecto,
            puesto,
            ok,
        };

        public PanelUsuario(Cargador cargador, Usuario usuario)
        {
            InitializeComponent();
            this.cargador = cargador;
            this.usuario = usuario;
            if (usuario != null)
            {
                this.CargarUsuario();
            }
            else
            {
                this.CargarPermisos();
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
