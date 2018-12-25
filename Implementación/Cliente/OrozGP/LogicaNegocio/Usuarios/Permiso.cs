using Newtonsoft.Json.Linq;
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
        public Permiso(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.ambito = json.GetValue("Ambito").Value<string>();
            this.consultar = json.GetValue("Consultar").Value<bool>();
            this.crear = json.GetValue("Crear").Value<bool>();
            this.modificar = json.GetValue("Modificar").Value<bool>();
            this.eliminar = json.GetValue("Eliminar").Value<bool>();
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
            JObject json = await ServiciosUsuario.ObtenerPermisos(idUsuario);
            foreach (JObject item in json.GetValue("Permisos"))
            {
                permisos.Add(new Permiso(item));
            }
            return permisos;
        }
    }
}
