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
    class ServiciosUsuario
    {
        private const string rutaBase = "http://localhost/CodeIgniter/index.php/Usuario_Controller/";

        public static async Task<dynamic>  ObtenerUsuario(string nombre, string contraseña)
        {
            string hash = Encriptacion.Sha256(contraseña);
            string url = ServiciosUsuario.rutaBase + "sesion/nombre/"+ nombre + "/sha/" + hash;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> ObtenerUsuarios()
        {
            string url = ServiciosUsuario.rutaBase + "usuarios";
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> ObtenerUsuarios(string clave)
        {
            string url = ServiciosUsuario.rutaBase + "clave/clave/" + clave;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> RegistrarUsuario(Usuario usuario)
        {
            string url = ServiciosUsuario.rutaBase + "usuario";
            HttpClient cliente = new HttpClient();
            var contenido = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> EditarUsuario(Usuario usuario)
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
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> EliminarUsuario(int id)
        {
            string url = ServiciosUsuario.rutaBase + "usuario/id/" + id;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> ObtenerPermisos(int idUsuario){
            string url = ServiciosUsuario.rutaBase + "permisos/idUsuario/" + idUsuario;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
    }
}
