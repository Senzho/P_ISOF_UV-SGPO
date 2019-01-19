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
    /// <summary>
    /// Clase con métodos para acceder a servicios web y retornar objetos json, respecto a los materiales.
    /// </summary>
    public class ServiciosMaterial
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Material_Controller/";

        /// <summary>
        /// Solicita el registro un material y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="material">El material para registrar.</param>
        /// <param name="idCategoria">Identificador de la categoría a la cual registrar el material.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
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
        /// <summary>
        /// Solicita la actualización de un material y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="material">El material para actualizar.</param>
        /// <param name="acabadosAgregar">La lista de acabados para agregar al material.</param>
        /// <param name="acabadosQuitar">La lista de acabados para quitar del material.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
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
        /// <summary>
        /// Solicita la baja de un material y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="idMaterial">Identificador del material para eliminar.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> EliminarMaterial(int idMaterial)
        {
            string url = ServiciosMaterial.rutaBase + "material/idMaterial/" + idMaterial;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita los materiales correspondientes a una categoría.
        /// </summary>
        /// <param name="idCategoria">Identificador de la categoría de materiales.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerMateriales(int idCategoria)
        {
            string url = ServiciosMaterial.rutaBase + "categoria/idCategoria/" + idCategoria;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita los materiales correspondientes a una categoría y relacionados con una palabra clave.
        /// </summary>
        /// <param name="idCategoria">Identificador de la categoría de materiales.</param>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
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
