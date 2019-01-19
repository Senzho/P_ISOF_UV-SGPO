using Newtonsoft.Json.Linq;
using OrozGP.Servicios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Usuarios
{
    /// <summary>
    /// Clase de lógica para los permisos de los usuarios.
    /// </summary>
    public class Permiso
    {
        private int id;
        private string ambito;
        private bool consultar;
        private bool crear;
        private bool modificar;
        private bool eliminar;

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <param name="ambito">Nombre del ámbito del permiso (Usuarios, Materiales, Módulos, Presupuestos y Accesorios).</param>
        /// <param name="consultar">Identificador para el permiso de consulta.</param>
        /// <param name="crear">Identificador para el permiso de creación.</param>
        /// <param name="modificar">Identificador para el permiso de modificación.</param>
        /// <param name="eliminar">Identificador para el permiso de eliminar.</param>
        public Permiso(int id, string ambito, bool consultar, bool crear, bool modificar, bool eliminar)
        {
            this.id = id;
            this.ambito = ambito;
            this.consultar = consultar;
            this.crear = crear;
            this.modificar = modificar;
            this.eliminar = eliminar;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Un objeto json con los datos del permiso.</param>
        public Permiso(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.ambito = json.GetValue("Ambito").Value<string>();
            this.consultar = json.GetValue("Consultar").Value<bool>();
            this.crear = json.GetValue("Crear").Value<bool>();
            this.modificar = json.GetValue("Modificar").Value<bool>();
            this.eliminar = json.GetValue("Eliminar").Value<bool>();
        }

        /// <value>
        /// Establece o regresa el identificador del permiso.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nombre del ámbito del permiso (Usuarios, Materiales, Módulos, Presupuestos y Accesorios).
        /// </value>
        public string Ambito {
            get => ambito;
            set => ambito = value;
        }
        /// <value>
        /// Establece o regresa el identificador del permiso de consulta.
        /// </value>
        public bool Consultar {
            get => consultar;
            set => consultar = value;
        }
        /// <value>
        /// Establece o regresa el identificador del permiso de creación.
        /// </value>
        public bool Crear {
            get => crear;
            set => crear = value;
        }
        /// <value>
        /// Establece o regresa el identificador del permiso de modificación.
        /// </value>
        public bool Modificar {
            get => modificar;
            set => modificar = value;
        }
        /// <value>
        /// Establece o regresa el identificador del permiso de eliminación.
        /// </value>
        public bool Eliminar {
            get => eliminar;
            set => eliminar = value;
        }


        /// <summary>
        /// Obtiene los permisos de un usuario dado.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>
        /// Una lista con los permisos.
        /// </returns>
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
