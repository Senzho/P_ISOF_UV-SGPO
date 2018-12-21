using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.Servicios.Catalogos
{
    public class ServiciosMaterial
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Material_Controller/";

        public static async Task<dynamic> ObtenerMateriales(int idCategoria)
        {
            string url = ServiciosMaterial.rutaBase + "categoria/idCategoria/" + idCategoria;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
    }
}
