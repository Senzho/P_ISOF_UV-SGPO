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
    /// Clase con métodos para acceder a servicios web y retornar objetos json, respecto a los acabados.
    /// </summary>
    public class ServiciosAcabado
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Acabado_Controller/";

        /// <summary>
        /// Solicita los acabados de un material en json.
        /// </summary>
        /// <param name="idMaterial">Identificador del material dado.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerAcabados(int idMaterial)
        {
            string url = ServiciosAcabado.rutaBase + "acabados/idMaterial/" + idMaterial;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
    }
}
