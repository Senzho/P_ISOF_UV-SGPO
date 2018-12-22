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
        public Material(dynamic json)
        {
            this.id = json.Id;
            this.nombre = json.Nombre;
            this.proveedor = json.Proveedor;
            this.clave = json.Clave;
            this.ancho = json.Ancho;
            this.alto = json.Alto;
            this.grosor = json.Grosor;
            this.precio = json.Precio;
            this.iva = json.Iva == true;
            this.moneda = new Moneda(json.Moneda);
            this.acabados = new List<Acabado>();
            try
            {
                foreach (dynamic acabado in json.Acabados)
                {
                    this.acabados.Add(new Acabado(acabado));
                }
            }
            catch (NullReferenceException) { }
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

        public async Task<Material> RegistrarMaterial(int idCategoria)
        {
            Material material;
            dynamic json = await ServiciosMaterial.RegistrarMaterial(this, idCategoria);
            if (json.Exito == true)
            {
                material = new Material(json.Material);
            }
            else
            {
                material = new Material();
            }
            return material;
        }
        public async Task<bool> EditarMaterial(IList<Acabado> acabadosQuitar)
        {
            bool edicion;
            dynamic json = await ServiciosMaterial.EditarMaterial(this, acabadosQuitar);
            edicion = json.Exito == true;
            return edicion;
        }
        public async Task<bool> EliminarMaterial()
        {
            bool baja;
            dynamic json = await ServiciosMaterial.EliminarMaterial(this.id);
            baja = json.Exito == true;
            return baja;
        }
        
        public static async Task<IList<Material>> ObtenerMateriales(int idCategoria)
        {
            IList<Material> materiales = new List<Material>();
            dynamic json = await ServiciosMaterial.ObtenerMateriales(idCategoria);
            foreach (dynamic material in json.Materiales)
            {
                materiales.Add(new Material(material));
            }
            return materiales;
        }
        public static async Task<IList<Material>> ObtenerMateriales(int idCategoria, string clave)
        {
            IList<Material> materiales = new List<Material>();
            dynamic json = await ServiciosMaterial.ObtenerMateriales(idCategoria, clave);
            if (json.Exito == true)
            {
                foreach (dynamic material in json.Materiales)
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
