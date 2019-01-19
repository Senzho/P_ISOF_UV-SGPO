using Newtonsoft.Json.Linq;
using OrozGP.Servicios.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Catalogos
{
    /// <summary>
    /// Clase de lógica para las categorías.
    /// </summary>
    public class Categoria
    {
        private int id;
        private string nombre;

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador de la categoría (0 para registrar).</param>
        /// <param name="nombre">Nombre de la categoría.</param>
        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Objeto json con los datos de la categoría.</param>
        public Categoria(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
        }

        /// <value>
        /// Establece o regresa el identificador de la categoría.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nombre de la categoría.
        /// </value>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        /// <summary>
        /// Registra una categoría a un tipo de categorías.
        /// </summary>
        /// <param name="tipo">Tipo de la categoría.</param>
        /// <returns>
        /// Un booleano con la confirmación del registro.
        /// </returns>
        public bool RegistrarCategoria(int tipo)
        {
            return false;
        }
        /// <summary>
        /// Actualiza una categoría.
        /// </summary>
        /// <returns>
        /// Un booleano con la confirmación de la actualización.
        /// </returns>
        public bool EditarCategoria()
        {
            return false;
        }

        /// <summary>
        /// Obtiene una lista con las categorías de un tipo.
        /// </summary>
        /// <param name="tipo">Tipo de categorías.</param>
        /// <returns>
        /// Una lista con las categorías.
        /// </returns>
        public static async Task<IList<Categoria>> ObtenerCategorias(int tipo)
        {
            IList<Categoria> categorias = new List<Categoria>();
            JObject json = await ServiciosCategoria.ObtenerCategorias(tipo);
            foreach (JObject categoria in json.GetValue("Categorias"))
            {
                categorias.Add(new Categoria(categoria));
            }
            return categorias;
        }
    }
}
