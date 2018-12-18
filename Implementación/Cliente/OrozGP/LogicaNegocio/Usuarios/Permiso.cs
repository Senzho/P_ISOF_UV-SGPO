using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Usuarios
{
    public class Permiso
    {
        private string nombre;
        private bool consultar;
        private bool crear;
        private bool modificar;
        private bool eliminar;

        public Permiso(string nombre, bool consultar, bool crear, bool modificar, bool eliminar)
        {
            this.nombre = nombre;
            this.consultar = consultar;
            this.crear = crear;
            this.modificar = modificar;
            this.eliminar = eliminar;
        }
        public Permiso(dynamic json)
        {
            this.nombre = json.ambito;
            this.consultar = json.consultar == "1";
            this.crear = json.crear == "1";
            this.modificar = json.modificar == "1";
            this.eliminar = json.eliminar == "1";
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public bool Consultar { get => consultar; set => consultar = value; }
        public bool Crear { get => crear; set => crear = value; }
        public bool Modificar { get => modificar; set => modificar = value; }
        public bool Eliminar { get => eliminar; set => eliminar = value; }
    }
}
