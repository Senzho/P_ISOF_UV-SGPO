using Newtonsoft.Json.Linq;
using OrozGP.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Configuraciones
{
    public class Moneda
    {
        private int id;
        private string nombre;

        public Moneda(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public Moneda(JObject json)
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

        public override string ToString()
        {
            return this.nombre;
        }

        public static async Task<IList<Moneda>> ObtenerMonedas()
        {
            IList<Moneda> monedas = new List<Moneda>();
            JObject json = await ServiciosMoneda.ObtenerMonedas();
            foreach (JObject moneda in json.GetValue("Monedas"))
            {
                monedas.Add(new Moneda(moneda));
            }
            return monedas;
        }
    }
}
