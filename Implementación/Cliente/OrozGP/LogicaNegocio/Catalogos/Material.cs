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
    /// <summary>
    /// Clase de lógica para los materiales.
    /// </summary>
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

        /// <summary>
        /// Constructor default de la clase.
        /// </summary>
        public Material()
        {
            this.id = 0;
        }
        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="id">Identificador del material (0 para registrar).</param>
        /// <param name="nombre">Nombre del material.</param>
        /// <param name="proveedor">Nombre del proveedor del material.</param>
        /// <param name="clave">Clave de búsqueda del material.</param>
        /// <param name="precio">Precio del material.</param>
        /// <param name="iva">Identificador para la inclusión del iva en el precio.</param>
        public Material(int id, string nombre, string proveedor, string clave, double precio, bool iva)
        {
            this.id = id;
            this.nombre = nombre;
            this.proveedor = proveedor;
            this.clave = clave;
            this.precio = precio;
            this.iva = iva;
        }
        /// <summary>
        /// Constructor json de la clase.
        /// </summary>
        /// <param name="json">Un objeto json con los datos del material.</param>
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

        /// <value>
        /// Establece o regresa el identificador del material.
        /// </value>
        public int Id {
            get => id;
            set => id = value;
        }
        /// <value>
        /// Establece o regresa el nombre del material.
        /// </value>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        /// <value>
        /// Establece o regresa el nombre del proveedor del material.
        /// </value>
        public string Proveedor {
            get => proveedor;
            set => proveedor = value;
        }
        /// <value>
        /// Establece o regresa la clave de búsqueda del material.
        /// </value>
        public string Clave {
            get => clave;
            set => clave = value;
        }
        /// <value>
        /// Establece o regresa el ancho del material.
        /// </value>
        public double Ancho {
            get => ancho;
            set => ancho = value;
        }
        /// <value>
        /// Establece o regresa el alto del material.
        /// </value>
        public double Alto {
            get => alto;
            set => alto = value;
        }
        /// <value>
        /// Establece o regresa el grosor del material.
        /// </value>
        public double Grosor {
            get => grosor;
            set => grosor = value;
        }
        /// <value>
        /// Establece o regresa el precio del material.
        /// </value>
        public double Precio {
            get => precio;
            set => precio = value;
        }
        /// <value>
        /// Establece o regresa el identificador para la inclusión del iva en el precio.
        /// </value>
        public bool Iva {
            get => iva;
            set => iva = value;
        }
        /// <value>
        /// Establece o regresa la lista de los acabados del material.
        /// </value>
        public IList<Acabado> Acabados {
            get => acabados;
            set => acabados = value;
        }
        /// <value>
        /// Establece o regresa la moneda asociada al precio del material.
        /// </value>
        public Moneda Moneda {
            get => moneda;
            set => moneda = value;
        }
        /// <value>
        /// Regresa el valor en texto para la inclusión del iva en el precio (para binding).
        /// </value>
        public string IvaEnTexto {
            get => this.iva ? "Sí" : "No";
        }

        /// <summary>
        /// Registra el material de la instancia de la clase a una categoría.
        /// </summary>
        /// <param name="idCategoria">Identificador de la categoría.</param>
        /// <returns>
        /// Un material con su identificador de registro.
        /// </returns>
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
        /// <summary>
        /// Actualiza el material de la instancia de la clase.
        /// </summary>
        /// <param name="acabadosAgregar">La lista de los acabados a agregar al material.</param>
        /// <param name="acabadosQuitar">La lista de los acabados a eliminar del material.</param>
        /// <returns>
        /// Un arreglo de objetos: [0]booleano con la confirmación de la actualización, [1]lista de acabados registrados en la actualización.
        /// </returns>
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
        /// <summary>
        /// Elimina el material de la instancia de la clase.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EliminarMaterial()
        {
            bool baja;
            JObject json = await ServiciosMaterial.EliminarMaterial(this.id);
            baja = json.GetValue("Exito").Value<bool>();
            return baja;
        }
        /// <summary>
        /// Obtiene los materiales de una categoría.
        /// </summary>
        /// <param name="idCategoria">Identificador de la categoría.</param>
        /// <returns>
        /// Una lista con los materiales de la categoría.
        /// </returns>
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
        /// <summary>
        /// Obtiene los materiales de una categoría y relacionados con una palabra clave.
        /// </summary>
        /// <param name="idCategoria">Identificador de la categoría.</param>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns>
        /// Una lista con los materiales.
        /// </returns>
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
        /// <summary>
        /// Obtiene los mateirales relacionados con una palabra clave.
        /// </summary>
        /// <param name="clave">Palabra clave para la búsqueda.</param>
        /// <returns>
        /// Una lista con los materiales.
        /// </returns>
        public static async Task<IList<Material>> ObtenerMateriales(string clave)
        {
            IList<Material> materiales = new List<Material>();
            return materiales;
        }
        /// <summary>
        /// Obtiene los materiales registrados.
        /// </summary>
        /// <param name="incluirAcabados">Establece si se deben regresar los acabados de cada material o no.</param>
        /// <returns>
        /// Una lista con los materiales.
        /// </returns>
        public static async Task<IList<Material>> ObtenerMateriales(bool incluirAcabados)
        {
            IList<Material> materiales = new List<Material>();
            return materiales;
        }
    }
}
