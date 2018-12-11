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
        public static async Task<dynamic>  ObtenerUsuario(string nombre, string contraseña)
        {
            string hash = Encriptacion.sha256(contraseña);
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/sesion/nombre/"+ nombre + "/sha/" + hash;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> ObtenerUsuarios()
        {
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/usuarios";
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> ObtenerUsuarios(string clave)
        {
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/clave/clave/" + clave;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> RegistrarUsuario(Usuario usuario)
        {
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/usuario";
            HttpClient cliente = new HttpClient();
            var contenido = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> EditarUsuario(Usuario usuario)
        {
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/usuario";
            HttpClient cliente = new HttpClient();
            JObject json = new JObject
            {
                { "id", usuario.Id },
                { "nombre", usuario.Nombre},
                { "correo", usuario.Correo},
                { "puesto", usuario.Puesto},
            };
            var contenido = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PutAsync(url, contenido);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
        public static async Task<dynamic> EliminarUsuario(int id)
        {
            string url = "http://localhost/CodeIgniter/index.php/Usuario_Controller/usuario/id/" + id;
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);
            string cadena = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(cadena);
        }
    }
}
