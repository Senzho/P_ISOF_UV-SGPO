using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.Servicios.Catalogos
{
    /// <summary>
    /// Clase con métodos para acceder a servicios web y retornar objetos json, respecto a las categorías.
    /// </summary>
    public class ServiciosCategoria
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Categoria_Controller/";

        /// <summary>
        /// Solicita las categorías de un tipo en json.
        /// </summary>
        /// <param name="tipo">Tipo de categoría.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerCategorias(int tipo)
        {
            string url = ServiciosCategoria.rutaBase + "categorias/tipo/" + tipo;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
    }
}
