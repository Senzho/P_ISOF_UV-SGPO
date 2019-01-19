using Newtonsoft.Json.Linq;
using OrozGP.LogicaNegocio.Configuraciones;
using OrozGP.Servicios.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Catalogos
{
    /// <summary>
    /// Clase de logica para los acabados.
    /// </summary>
    public class Acabado
    {
        private int id;
        private string nombre;
        private double ancho;
        private double alto;
        private double grosor;
        private double precio;
        private bool iva;
        private Moneda moneda;

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador del acabado (0 para registrar).</param>
        /// <param name="nombre">Nombre del acabado.</param>
        /// <param name="ancho">Ancho del acabado.</param>
        /// <param name="alto">Alto del acabado.</param>
        /// <param name="grosor">Grosor del acabado.</param>
        /// <param name="precio">Precio del acabado.</param>
        /// <param name="iva">Indicador para la inclusión del iva en el precio.</param>
        public Acabado(int id, string nombre, double ancho, double alto, double grosor, double precio, bool iva)
        {
            this.id = id;
            this.nombre = nombre;
            this.ancho = ancho;
            this.alto = alto;
            this.grosor = grosor;
            this.precio = precio;
            this.iva = iva;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Objeto json con los datos de un acabado.</param>
        public Acabado(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
            this.ancho = json.GetValue("Ancho").Value<double>();
            this.alto = json.GetValue("Alto").Value<double>();
            this.grosor = json.GetValue("Grosor").Value<double>();
            this.precio = json.GetValue("Precio").Value<double>();
            this.iva = json.GetValue("Iva").Value<bool>();
            this.moneda = new Moneda(json.GetValue("Moneda").Value<JObject>());
        }

        /// <value>
        /// Establece o regresa el identificador del acabado.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nNombre del acabado.
        /// </value>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        /// <value>
        /// Establece o regresa el ancho del acabado.
        /// </value>
        public double Ancho {
            get => ancho;
            set => ancho = value;
        }
        /// <value>
        /// Establece o regresa el alto del acabado.
        /// </value>
        public double Alto {
            get => alto;
            set => alto = value;
        }
        /// <value>
        /// Establece o regresa el grosor del acabado.
        /// </value>
        public double Grosor {
            get => grosor;
            set => grosor = value;
        }
        /// <value>
        /// Establece o regresa el precio del acabado.
        /// </value>
        public double Precio {
            get => precio;
            set => precio = value;
        }
        /// <value>
        /// Establece o regresa el identificador para la inclusión del iva en el precio.
        /// </value>
        public bool Iva {
            get => iva;
            set => iva = value;
        }
        /// <value>
        /// Establece o regresa la moneda asociada al precio del acabado.
        /// </value>
        public Moneda Moneda {
            get => moneda;
            set => moneda = value;
        }
        /// <value>
        /// Regresa el valor en texto para la inclusión del iva en el precio (para binding).
        /// </value>
        public string IvaEnTexto {
            get => this.iva ? "Sí" : "No";
        }

        /// <summary>
        /// Sobreescribe el método ToString.
        /// </summary>
        /// <returns>
        /// EL nombre del acabado.
        /// </returns>
        public override string ToString()
        {
            return this.nombre;
        }

        /// <summary>
        /// Obtiene una lista con los acabados de un material dado.
        /// </summary>
        /// <param name="idMaterial">Identificador del material.</param>
        /// <returns>
        /// Una lista con los acabados.
        /// </returns>
        public static async Task<IList<Acabado>> ObtenerAcabados(int idMaterial)
        {
            IList<Acabado> acabados = new List<Acabado>();
            JObject json = await ServiciosAcabado.ObtenerAcabados(idMaterial);
            foreach (JObject acabado in json.GetValue("Acabados"))
            {
                acabados.Add(new Acabado(acabado));
            }
            return acabados;
        }
    }
}
