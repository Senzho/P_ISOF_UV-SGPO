using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrozGP.Servicios.Usuarios;

namespace OrozGP.LogicaNegocio.Usuarios
{
    class Usuario
    {
        private int id;
        private string nombre;
        private string correo;
        private string puesto;
        private string nombreUsuario;
        private string contraseña;

        public Usuario(int id, string nombre, string correo, string puesto, string nombreUsuario, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.puesto = puesto;
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
        }
        public Usuario(dynamic json)
        {
            this.Id = json.id;
            this.Nombre = json.nombre;
            this.Correo = json.correo;
            this.Puesto = json.puesto;
            this.NombreUsuario = json.nombreUsuario;
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

        public static async Task<Usuario> IniciarSesion(string nombre, string contraseña)
        {
            Usuario usuario = new Usuario();
            dynamic json = await ServiciosUsuario.ObtenerUsuario(nombre, contraseña);
            if (json.exito == true)
            {
                usuario = new Usuario(json.usuario);
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
            dynamic json = await ServiciosUsuario.ObtenerUsuarios();
            foreach (dynamic item in json.usuarios)
            {
                usuarios.Add(new Usuario(item));
            }
            return usuarios;
        }
        public static IList<Usuario> ObtenerUsuarios(string clave)
        {
            IList<Usuario> usuarios = new List<Usuario>();
            return usuarios;
        }
        public bool RegistrarUsuario()
        {
            return false;
        }
        public bool EditarUsuario()
        {
            return false;
        }
        public bool EliminarUsuario()
        {
            return false;
        }
        public bool GenerarCredenciales()
        {
            return false;
        }
    }
}
