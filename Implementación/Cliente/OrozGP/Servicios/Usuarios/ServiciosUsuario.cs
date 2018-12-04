﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OrozGP.Util;
using Newtonsoft.Json;

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
    }
}
