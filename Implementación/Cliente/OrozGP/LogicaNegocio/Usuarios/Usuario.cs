using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OrozGP.Servicios.Usuarios;

namespace OrozGP.LogicaNegocio.Usuarios
{
    /// <summary>
    /// Clase de lógica para los usuarios.
    /// </summary>
    public class Usuario
    {
        private int id;
        private string nombre;
        private string correo;
        private string puesto;
        private string nombreUsuario;
        private string contraseña;
        private IList<Permiso> permisos;

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador del usuario (0 para crear).</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="correo">Correo del usuario.</param>
        /// <param name="puesto">Nombre del puesto del usuario.</param>
        /// <param name="nombreUsuario">Nombre de usuario del usuario.</param>
        /// <param name="contraseña">Contraseña del usuario.</param>
        public Usuario(int id, string nombre, string correo, string puesto, string nombreUsuario, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.puesto = puesto;
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Objeto json con los datos del usuario.</param>
        public Usuario(JObject json)
        {
            this.Id = json.GetValue("Id").Value<int>();
            this.Nombre = json.GetValue("Nombre").Value<string>();
            this.Correo = json.GetValue("Correo").Value<string>();
            this.Puesto = json.GetValue("Puesto").Value<string>();
            this.NombreUsuario = json.GetValue("NombreUsuario").Value<string>();
            this.Permisos = new List<Permiso>();
            if (json.ContainsKey("Permisos"))
            {
                foreach (JObject permiso in json.GetValue("Permisos"))
                {
                    this.Permisos.Add(new Permiso(permiso));
                }
            }
        }
        /// <summary>
        /// Constructor default de la clase.
        /// </summary>
        public Usuario()
        {
            this.id = 0;
        }

        /// <value>
        /// Establece o regresa el identificador del usuario.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nombre del usuario.
        /// </value>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        /// <value>
        /// Establece o regresa el correo del usuario.
        /// </value>
        public string Correo {
            get => correo;
            set => correo = value;
        }
        /// <value>
        /// Establece o regresa el nombre del puesto del usuario.
        /// </value>
        public string Puesto {
            get => puesto;
            set => puesto = value;
        }
        /// <value>
        /// Establece o regresa el nombre de usuario del usuario.
        /// </value>
        public string NombreUsuario {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }
        /// <value>
        /// Establece o regresa la constraseña del usuario.
        /// </value>
        public string Contraseña {
            get => contraseña;
            set => contraseña = value;
        }
        /// <value>
        /// Establece o regresa la lista de permisos del usuario.
        /// </value>
        public IList<Permiso> Permisos {
            get => permisos;
            set => permisos = value;
        }

        /// <summary>
        /// Obtiene un usuario a partir de un nombre de usuario y una contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de usuario del usuario.</param>
        /// <param name="contraseña">Contraseña del usuario (en SHA256)</param>
        /// <returns>
        /// El usuario asociado.
        /// </returns>
        public static async Task<Usuario> IniciarSesion(string nombre, string contraseña)
        {
            Usuario usuario = new Usuario();
            JObject json = await ServiciosUsuario.ObtenerUsuario(nombre, contraseña);
            if (json.GetValue("Exito").Value<bool>())
            {
                usuario = new Usuario(json.GetValue("Usuario").Value<JObject>());
            }
            return usuario;
        }
        /// <summary>
        /// Genera una contraseña para un usuario dado.
        /// </summary>
        /// <param name="nombre">Nombre de usuario del usuario.</param>
        /// <returns>
        /// Un booleano con la confirmación de la generación.
        /// </returns>
        public static bool GenerarContraseña(string nombre)
        {
            return false;
        }
        /// <summary>
        /// Obtiene los usuarios registrados.
        /// </summary>
        /// <returns>
        /// Una lista con los usuarios.
        /// </returns>
        public static async Task<IList<Usuario>> ObtenerUsuarios()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            JObject json = await ServiciosUsuario.ObtenerUsuarios();
            foreach (JObject item in json.GetValue("Usuarios"))
            {
                usuarios.Add(new Usuario(item));
            }
            return usuarios;
        }
        /// <summary>
        /// Obitne los usuarios relacionados con una palabra clave.
        /// </summary>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns>
        /// Una lista con los usuarios.
        /// </returns>
        public static async Task<IList<Usuario>> ObtenerUsuarios(string clave)
        {
            IList<Usuario> usuarios = new List<Usuario>();
            JObject json = await ServiciosUsuario.ObtenerUsuarios(clave);
            if (json.GetValue("Exito").Value<bool>())
            {
                foreach (JObject item in json.GetValue("Usuarios"))
                {
                    usuarios.Add(new Usuario(item));
                }
            }
            else
            {
                usuarios = null;
            }
            return usuarios;
        }
        /// <summary>
        /// Registra el usuario de la instancia de la clase.
        /// </summary>
        /// <returns>
        /// Un usuario.
        /// </returns>
        public async Task<Usuario> RegistrarUsuario()
        {
            Usuario usuario;
            JObject json = await ServiciosUsuario.RegistrarUsuario(this);
            if (json.GetValue("Exito").Value<bool>())
            {
                usuario = new Usuario(json.GetValue("Usuario").Value<JObject>());
            }
            else
            {
                usuario = new Usuario();
            }
            return usuario;
        }
        /// <summary>
        /// Actualiza el usuario de la instancia de la clase.
        /// </summary>
        /// <returns>
        /// Un booleano con la confirmación de la actualización.
        /// </returns>
        public async Task<bool> EditarUsuario()
        {
            bool edicion;
            JObject json = await ServiciosUsuario.EditarUsuario(this);
            edicion = json.GetValue("Exito").Value<bool>();
            return edicion;
        }
        /// <summary>
        /// Elimina al usuario de la instancia de la clase.
        /// </summary>
        /// <returns>
        /// Un booleano con la confirmación de la baja.
        /// </returns>
        public async Task<bool> EliminarUsuario()
        {
            bool baja;
            JObject json = await ServiciosUsuario.EliminarUsuario(this.id);
            baja = json.GetValue("Exito").Value<bool>();
            return baja;
        }
        /// <summary>
        /// Genera las credenciales del usuario de la instancia de la clase.
        /// </summary>
        /// <returns>
        /// Un booleano con la confirmación de la generación.
        /// </returns>
        public bool GenerarCredenciales()
        {
            return false;
        }
    }
}
