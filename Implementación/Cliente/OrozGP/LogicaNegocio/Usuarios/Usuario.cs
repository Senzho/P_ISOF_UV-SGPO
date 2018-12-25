using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OrozGP.Servicios.Usuarios;

namespace OrozGP.LogicaNegocio.Usuarios
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string correo;
        private string puesto;
        private string nombreUsuario;
        private string contraseña;
        private IList<Permiso> permisos;

        public Usuario(int id, string nombre, string correo, string puesto, string nombreUsuario, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.puesto = puesto;
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
        }
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
        public Usuario()
        {
            this.id = 0;
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        public string Correo {
            get => correo;
            set => correo = value;
        }
        public string Puesto {
            get => puesto;
            set => puesto = value;
        }
        public string NombreUsuario {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }
        public string Contraseña {
            get => contraseña;
            set => contraseña = value;
        }
        public IList<Permiso> Permisos {
            get => permisos;
            set => permisos = value;
        }

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
        public static bool GenerarContraseña(string nombre)
        {
            return false;
        }
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
        public async Task<bool> EditarUsuario()
        {
            bool edicion;
            JObject json = await ServiciosUsuario.EditarUsuario(this);
            edicion = json.GetValue("Exito").Value<bool>();
            return edicion;
        }
        public async Task<bool> EliminarUsuario()
        {
            bool baja;
            JObject json = await ServiciosUsuario.EliminarUsuario(this.id);
            baja = json.GetValue("Exito").Value<bool>();
            return baja;
        }
        public bool GenerarCredenciales()
        {
            return false;
        }
    }
}
