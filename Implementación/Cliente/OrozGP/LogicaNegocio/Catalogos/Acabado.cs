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
        public Acabado(dynamic json)
        {
            this.id = json.Id;
            this.nombre = json.Nombre;
            this.ancho = json.Ancho;
            this.alto = json.Alto;
            this.grosor = json.Grosor;
            this.precio = json.Precio;
            this.iva = json.Iva == true;
            this.moneda = new Moneda(json.Moneda);
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

        public override string ToString()
        {
            return this.nombre;
        }

        public static async Task<IList<Acabado>> ObtenerAcabados(int idMaterial)
        {
            IList<Acabado> acabados = new List<Acabado>();
            dynamic json = await ServiciosAcabado.ObtenerAcabados(idMaterial);
            foreach (dynamic acabado in json.Acabados)
            {
                acabados.Add(new Acabado(acabado));
            }
            return acabados;
        }
    }
}
