using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OrozGP.Util;
using Newtonsoft.Json;
using OrozGP.LogicaNegocio.Usuarios;
using Newtonsoft.Json.Linq;

namespace OrozGP.Servicios.Usuarios
{
    /// <summary>
    /// Clase con métodos para acceder a servicios web y retornar objetos json, respecto a los usuarios.
    /// </summary>
    class ServiciosUsuario
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Usuario_Controller/";

        /// <summary>
        /// Solicita un usuario a partir de un nombre de usuario y contraseña.
        /// </summary>
        /// <param name="nombre">El nombre del usuario.</param>
        /// <param name="contraseña">La contraseña del usuario</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject>  ObtenerUsuario(string nombre, string contraseña)
        {
            //Se vuelve la contraseña a SHA256 antes de enviar.
            string hash = Encriptacion.Sha256(contraseña);
            string url = ServiciosUsuario.rutaBase + "sesion/nombre/"+ nombre + "/sha/" + hash;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita los usuarios registrados.
        /// </summary>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerUsuarios()
        {
            string url = ServiciosUsuario.rutaBase + "usuarios";
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita los usuarios relacionados con una palabra clave.
        /// </summary>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerUsuarios(string clave)
        {
            string url = ServiciosUsuario.rutaBase + "clave/clave/" + clave;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// SOlicita el registro de un usuario y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="usuario">Usuario para registrar.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> RegistrarUsuario(Usuario usuario)
        {
            string url = ServiciosUsuario.rutaBase + "usuario";
            HttpClient cliente = new HttpClient();
            var contenido = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita la actualización de un usuario y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="usuario">Usuario para actualizar.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> EditarUsuario(Usuario usuario)
        {
            string url = ServiciosUsuario.rutaBase + "usuario";
            HttpClient cliente = new HttpClient();
            JArray permisos = new JArray();
            foreach (Permiso permiso in usuario.Permisos)
            {
                JObject jPermiso = new JObject
                {
                    { "Id", permiso.Id },
                    { "Ambito", permiso.Ambito },
                    { "Consultar", permiso.Consultar },
                    { "Crear", permiso.Crear },
                    { "Modificar", permiso.Modificar },
                    { "Eliminar", permiso.Eliminar}
                };
                permisos.Add(jPermiso);
            }
            JObject json = new JObject
            {
                { "Id", usuario.Id },
                { "Nombre", usuario.Nombre},
                { "Correo", usuario.Correo},
                { "Puesto", usuario.Puesto},
                { "Permisos", permisos }
            };
            var contenido = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PutAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita la baja de un usuario y regresa la respuesta del servidor.
        /// </summary>
        /// <param name="id">Identificador del usuario para eliminar.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> EliminarUsuario(int id)
        {
            string url = ServiciosUsuario.rutaBase + "usuario/id/" + id;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
        /// <summary>
        /// Solicita los permisos de un usuario dado.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>
        /// Un objeto json con la respuesta del servidor.
        /// </returns>
        public static async Task<JObject> ObtenerPermisos(int idUsuario){
            string url = ServiciosUsuario.rutaBase + "permisos/idUsuario/" + idUsuario;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JObject.Parse(cadena);
        }
    }
}
