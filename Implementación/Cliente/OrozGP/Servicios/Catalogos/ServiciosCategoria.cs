using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.Servicios.Catalogos
{
    class ServiciosCategoria
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Categoria_Controller/";

        public static async Task<dynamic> ObtenerCategorias(int tipo)
        {
            string url = ServiciosCategoria.rutaBase + "categorias/tipo/" + tipo;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
    }
}
