using Newtonsoft.Json.Linq;
using OrozGP.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Configuraciones
{
    /// <summary>
    /// Clase de lógica para las monedas.
    /// </summary>
    public class Moneda
    {
        private int id;
        private string nombre;

        /// <summary>
        /// COnstructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador de la moneda (0 para registrar).</param>
        /// <param name="nombre">Nombre de la moneda.</param>
        public Moneda(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Objeto json con los datos de la moneda.</param>
        public Moneda(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
        }

        /// <value>
        /// Establece o regresa el identificador de la moneda.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nombre de la moneda.
        /// </value>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        /// <summary>
        /// Sobreescribe el método ToString.
        /// </summary>
        /// <returns>
        /// EL nombre de la moneda.
        /// </returns>
        public override string ToString()
        {
            return this.nombre;
        }

        /// <summary>
        /// Obtiene la monedas registradas.
        /// </summary>
        /// <returns>
        /// Una lista con las monedas.
        /// </returns>
        public static async Task<IList<Moneda>> ObtenerMonedas()
        {
            IList<Moneda> monedas = new List<Moneda>();
            JObject json = await ServiciosMoneda.ObtenerMonedas();
            foreach (JObject moneda in json.GetValue("Monedas"))
            {
                monedas.Add(new Moneda(moneda));
            }
            return monedas;
        }
    }
}
