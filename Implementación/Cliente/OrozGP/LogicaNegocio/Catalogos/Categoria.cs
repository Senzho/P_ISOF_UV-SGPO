using Newtonsoft.Json.Linq;
using OrozGP.Servicios.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Catalogos
{
    public class Categoria
    {
        private int id;
        private string nombre;

        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public Categoria(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        public bool RegistrarCategoria(int tipo)
        {
            return false;
        }
        public bool EditarCategoria()
        {
            return false;
        }

        public static async Task<IList<Categoria>> ObtenerCategorias(int tipo)
        {
            IList<Categoria> categorias = new List<Categoria>();
            JObject json = await ServiciosCategoria.ObtenerCategorias(tipo);
            foreach (JObject categoria in json.GetValue("Categorias"))
            {
                categorias.Add(new Categoria(categoria));
            }
            return categorias;
        }
    }
}
