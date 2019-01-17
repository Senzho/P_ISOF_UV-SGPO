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
    public class Material
    {
        private int id;
        private string nombre;
        private string proveedor;
        private string clave;
        private double ancho;
        private double alto;
        private double grosor;
        private double precio;
        private bool iva;
        private Moneda moneda;
        private IList<Acabado> acabados;

        public Material()
        {
            this.id = 0;
        }
        public Material(int id, string nombre, string proveedor, string clave, double precio, bool iva)
        {
            this.id = id;
            this.nombre = nombre;
            this.proveedor = proveedor;
            this.clave = clave;
            this.precio = precio;
            this.iva = iva;
        }
        public Material(JObject json)
        {
            this.id = json.GetValue("Id").Value<int>();
            this.nombre = json.GetValue("Nombre").Value<string>();
            this.proveedor = json.GetValue("Proveedor").Value<string>();
            this.clave = json.GetValue("Clave").Value<string>();
            this.ancho = json.GetValue("Ancho").Value<double>();
            this.alto = json.GetValue("Alto").Value<double>();
            this.grosor = json.GetValue("Grosor").Value<double>();
            this.precio = json.GetValue("Precio").Value<double>();
            this.iva = json.GetValue("Iva").Value<bool>();
            this.moneda = new Moneda(json.GetValue("Moneda").Value<JObject>());
            this.acabados = new List<Acabado>();
            if (json.ContainsKey("Acabados"))
            {
                foreach (JObject acabado in json.GetValue("Acabados"))
                {
                    this.acabados.Add(new Acabado(acabado));
                }
            }
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        public string Proveedor {
            get => proveedor;
            set => proveedor = value;
        }
        public string Clave {
            get => clave;
            set => clave = value;
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
        public IList<Acabado> Acabados {
            get => acabados;
            set => acabados = value;
        }
        public Moneda Moneda {
            get => moneda;
            set => moneda = value;
        }
        public string IvaEnTexto {
            get => this.iva ? "Sí" : "No";
        }

        public async Task<Material> RegistrarMaterial(int idCategoria)
        {
            Material material;
            JObject json = await ServiciosMaterial.RegistrarMaterial(this, idCategoria);
            if (json.GetValue("Exito").Value<bool>())
            {
                material = new Material(json.GetValue("Material").Value<JObject>());
            }
            else
            {
                material = new Material();
            }
            return material;
        }
        public async Task<Object[]> EditarMaterial(IList<Acabado> acabadosAgregar, IList<Acabado> acabadosQuitar)
        {
            Object[] respuesta = new object[2];
            bool edicion;
            JObject json = await ServiciosMaterial.EditarMaterial(this, acabadosAgregar, acabadosQuitar);
            edicion = json.GetValue("Exito").Value<bool>();
            respuesta[0] = edicion;
            IList<Acabado> acabados = new List<Acabado>();
            foreach (JObject acabado in json.GetValue("AcabadosAgregados"))
            {
                acabados.Add(new Acabado(acabado));
            }
            respuesta[1] = acabados;
            return respuesta;
        }
        public async Task<bool> EliminarMaterial()
        {
            bool baja;
            JObject json = await ServiciosMaterial.EliminarMaterial(this.id);
            baja = json.GetValue("Exito").Value<bool>();
            return baja;
        }
        
        public static async Task<IList<Material>> ObtenerMateriales(int idCategoria)
        {
            IList<Material> materiales = new List<Material>();
            JObject json = await ServiciosMaterial.ObtenerMateriales(idCategoria);
            foreach (JObject material in json.GetValue("Materiales"))
            {
                materiales.Add(new Material(material));
            }
            return materiales;
        }
        public static async Task<IList<Material>> ObtenerMateriales(int idCategoria, string clave)
        {
            IList<Material> materiales = new List<Material>();
            JObject json = await ServiciosMaterial.ObtenerMateriales(idCategoria, clave);
            if (json.GetValue("Exito").Value<bool>())
            {
                foreach (JObject material in json.GetValue("Materiales"))
                {
                    materiales.Add(new Material(material));
                }
            }
            else
            {
                materiales = null;
            }
            return materiales;
        }
        public static async Task<IList<Material>> ObtenerMateriales(string clave)
        {
            IList<Material> materiales = new List<Material>();
            return materiales;
        }
        public static async Task<IList<Material>> ObtenerMateriales(bool incluirAcabados)
        {
            IList<Material> materiales = new List<Material>();
            return materiales;
        }
    }
}
