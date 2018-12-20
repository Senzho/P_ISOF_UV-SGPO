using OrozGP.Servicios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Usuarios
{
    public class Permiso
    {
        private int id;
        private string ambito;
        private bool consultar;
        private bool crear;
        private bool modificar;
        private bool eliminar;

        public Permiso(int id, string ambito, bool consultar, bool crear, bool modificar, bool eliminar)
        {
            this.id = id;
            this.ambito = ambito;
            this.consultar = consultar;
            this.crear = crear;
            this.modificar = modificar;
            this.eliminar = eliminar;
        }
        public Permiso(dynamic json)
        {
            this.id = json.Id;
            this.ambito = json.Ambito;
            this.consultar = json.Consultar == "1";
            this.crear = json.Crear == "1";
            this.modificar = json.Modificar == "1";
            this.eliminar = json.Eliminar == "1";
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Ambito {
            get => ambito;
            set => ambito = value;
        }
        public bool Consultar {
            get => consultar;
            set => consultar = value;
        }
        public bool Crear {
            get => crear;
            set => crear = value;
        }
        public bool Modificar {
            get => modificar;
            set => modificar = value;
        }
        public bool Eliminar {
            get => eliminar;
            set => eliminar = value;
        }

        public static async Task<IList<Permiso>> ObtenerPermisos(int idUsuario)
        {
            IList<Permiso> permisos = new List<Permiso>();
            dynamic json = await ServiciosUsuario.ObtenerPermisos(idUsuario);
            foreach (dynamic item in json.Permisos)
            {
                permisos.Add(new Permiso(item));
            }
            return permisos;
        }
    }
}
