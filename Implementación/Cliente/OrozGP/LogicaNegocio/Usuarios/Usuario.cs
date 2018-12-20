using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Usuario(dynamic json)
        {
            this.Id = json.Id;
            this.Nombre = json.Nombre;
            this.Correo = json.Correo;
            this.Puesto = json.Puesto;
            this.NombreUsuario = json.NombreUsuario;
            this.Permisos = new List<Permiso>();
            if (json.GetType().GetProperty("Permisos") != null)
            {
                foreach (dynamic permiso in json.Permisos)
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
            dynamic json = await ServiciosUsuario.ObtenerUsuario(nombre, contraseña);
            if (json.Exito == true)
            {
                usuario = new Usuario(json.Usuario);
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
            foreach (dynamic item in json.Usuarios)
            {
                usuarios.Add(new Usuario(item));
            }
            return usuarios;
        }
        public static async Task<IList<Usuario>> ObtenerUsuarios(string clave)
        {
            IList<Usuario> usuarios = new List<Usuario>();
            dynamic json = await ServiciosUsuario.ObtenerUsuarios(clave);
            if (json.Exito == true)
            {
                foreach (dynamic item in json.Usuarios)
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
            dynamic json = await ServiciosUsuario.RegistrarUsuario(this);
            if (json.Exito == true)
            {
                usuario = new Usuario(json.Usuario);
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
            dynamic json = await ServiciosUsuario.EditarUsuario(this);
            edicion = json.Exito == true;
            return edicion;
        }
        public async Task<bool> EliminarUsuario()
        {
            bool baja;
            dynamic json = await ServiciosUsuario.EliminarUsuario(this.id);
            baja = json.Exito == true;
            return baja;
        }
        public bool GenerarCredenciales()
        {
            return false;
        }
    }
}
