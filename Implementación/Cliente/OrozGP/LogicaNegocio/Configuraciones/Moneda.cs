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
        public Moneda(dynamic json)
        {
            this.id = json.Id;
            this.nombre = json.Nombre;
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        public static async Task<IList<Moneda>> ObtenerMonedas()
        {
            IList<Moneda> monedas = new List<Moneda>();
            dynamic json = await ServiciosMoneda.ObtenerMonedas();
            foreach (dynamic moneda in json.Monedas)
            {
                monedas.Add(new Moneda(moneda));
            }
            return monedas;
        }
    }
}
