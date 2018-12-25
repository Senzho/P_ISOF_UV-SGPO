using Newtonsoft.Json.Linq;
using OrozGP.LogicaNegocio.Configuraciones;
using OrozGP.Servicios.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Catalogos
{
    public class Acabado
    {
        private int id;
        private string nombre;
        private double ancho;
        private double alto;
        private double grosor;
        private double precio;
        private bool iva;
        private Moneda moneda;

        public Acabado(int id, string nombre, double ancho, double alto, double grosor, double precio, bool iva)
        {
            this.id = id;
            this.nombre = nombre;
            this.ancho = ancho;
            this.alto = alto;
            this.grosor = grosor;
            this.precio = precio;
            this.iva = iva;
        }
        public Acabado(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
            this.ancho = json.GetValue("Ancho").Value<double>();
            this.alto = json.GetValue("Alto").Value<double>();
            this.grosor = json.GetValue("Grosor").Value<double>();
            this.precio = json.GetValue("Precio").Value<double>();
            this.iva = json.GetValue("Iva").Value<bool>();
            this.moneda = new Moneda(json.GetValue("Moneda").Value<JObject>());
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        public double Ancho {
            get => ancho;
            set => ancho = value;
        }
        public double Alto {
            get => alto;
            set => alto = value;
        }
        public double Grosor {
            get => grosor;
            set => grosor = value;
        }
        public double Precio {
            get => precio;
            set => precio = value;
        }
        public bool Iva {
            get => iva;
            set => iva = value;
        }
        public Moneda Moneda {
            get => moneda;
            set => moneda = value;
        }
        public string IvaEnTexto {
            get => this.iva ? "Sí" : "No";
        }

        public override string ToString()
        {
            return this.nombre;
        }

        public static async Task<IList<Acabado>> ObtenerAcabados(int idMaterial)
        {
            IList<Acabado> acabados = new List<Acabado>();
            JObject json = await ServiciosAcabado.ObtenerAcabados(idMaterial);
            foreach (JObject acabado in json.GetValue("Acabados"))
            {
                acabados.Add(new Acabado(acabado));
            }
            return acabados;
        }
    }
}
