using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrozGP.LogicaNegocio.Catalogos;
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

        public static async Task<JObject> RegistrarMaterial(Material material, int idCategoria)
        {
            string url = ServiciosMaterial.rutaBase + "material/idCategoria/" + idCategoria;
            HttpClient cliente = new HttpClient();
            JObject jMaterial = JObject.Parse(JsonConvert.SerializeObject(material));
            jMaterial.Remove("IvaEnTexto");
            foreach (JObject acabado in jMaterial.GetValue("Acabados"))
            {
                acabado.Remove("IvaEnTexto");
            }
            var contenido = new StringContent(jMaterial.ToString(), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        public static async Task<JObject> EditarMaterial(Material material, IList<Acabado> acabadosAgregar, IList<Acabado> acabadosQuitar)
        {
            string url = ServiciosMaterial.rutaBase + "material";
            HttpClient cliente = new HttpClient();
            JArray acabados = new JArray();
            foreach (Acabado acabado in material.Acabados)
            {
                JObject jAcabado = JObject.Parse(JsonConvert.SerializeObject(acabado));
                jAcabado.Remove("IvaEnTexto");
                jAcabado.Remove("Moneda");
                jAcabado.Add("IdMoneda", acabado.Moneda.Id);
                acabados.Add(jAcabado);
            }
            JArray acabadosNuevos = new JArray();
            foreach (Acabado acabado in acabadosAgregar)
            {
                JObject jAcabado = JObject.Parse(JsonConvert.SerializeObject(acabado));
                jAcabado.Remove("IvaEnTexto");
                acabadosNuevos.Add(jAcabado);
            }
            JArray acabadosEliminar = new JArray();
            foreach (Acabado acabado in acabadosQuitar)
            {
                JObject jAcabado = new JObject
                {
                    { "Id", acabado.Id }
                };
                acabadosEliminar.Add(jAcabado);
            }
            JObject jMaterial = JObject.Parse(JsonConvert.SerializeObject(material));
            jMaterial.Remove("IvaEnTexto");
            jMaterial.Remove("Acabados");
            jMaterial.Remove("Moneda");
            jMaterial.Add("IdMoneda", material.Moneda.Id);
            jMaterial.Add("AcabadosEditar", acabados);
            jMaterial.Add("AcabadosAgregar", acabadosNuevos);
            jMaterial.Add("AcabadosEliminar", acabadosEliminar);
            var contenido = new StringContent(jMaterial.ToString(), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PutAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        public static async Task<JObject> EliminarMaterial(int idMaterial)
        {
            string url = ServiciosMaterial.rutaBase + "material/idMaterial/" + idMaterial;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        public static async Task<JObject> ObtenerMateriales(int idCategoria)
        {
            string url = ServiciosMaterial.rutaBase + "categoria/idCategoria/" + idCategoria;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        public static async Task<JObject> ObtenerMateriales(int idCategoria, string clave)
        {
            string url = ServiciosMaterial.rutaBase + "categoria_clave/idCategoria/" + idCategoria + "/clave/" + clave;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
    }
}
