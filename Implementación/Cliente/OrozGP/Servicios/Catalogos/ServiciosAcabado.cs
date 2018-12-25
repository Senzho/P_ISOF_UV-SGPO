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
    public class ServiciosAcabado
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Acabado_Controller/";

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
