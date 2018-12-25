using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.Servicios
{
    public class ServiciosMoneda
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Moneda_Controller/";

        public static async Task<JObject> ObtenerMonedas()
        {
            string url = ServiciosMoneda.rutaBase + "monedas";
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
    }
}
