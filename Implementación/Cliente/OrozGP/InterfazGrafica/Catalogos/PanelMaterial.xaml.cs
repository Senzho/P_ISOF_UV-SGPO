using OrozGP.LogicaNegocio;
using OrozGP.LogicaNegocio.Catalogos;
using OrozGP.LogicaNegocio.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrozGP.InterfazGrafica.Catalogos
{
    public partial class PanelMaterial : UserControl
    {
        private Categoria categoria;
        private int tipo;
        private Cargador cargador;
        private Material material;
        private IList<Acabado> acabados;
        private IList<Moneda> monedas;

        private void Regresar()
        {
            this.cargador.Cargar(new PanelMateriales(this.cargador, this.tipo, this.categoria));
        }
        private async Task ObtenerMonedas()
        {
            this.monedas = await Moneda.ObtenerMonedas();
            this.CargarMonedas();
        }
        private void CargarMonedas()
        {
            this.comboMonedas.ItemsSource = this.monedas;
            this.comboMonedasAcabado.ItemsSource = this.monedas;
            if (this.material != null)
            {
                this.EstablecerMonedaSeleccionada(this.material.Moneda, true);
                this.EstablecerMonedaSeleccionada(this.monedas.First(), false);
            }
            else
            {
                this.EstablecerMonedaSeleccionada(this.monedas.First(), true);
                this.EstablecerMonedaSeleccionada(this.monedas.First(), false);
            }
        }
        private async Task ObtenerAcabados(int idMaterial)
        {
            this.acabados = await Acabado.ObtenerAcabados(idMaterial);
            this.listaAcabados.ItemsSource = this.acabados;
        }
        private void CargarMaterial()
        {
            this.campoNombre.Text = this.material.Nombre;
            this.campoClave.Text = this.material.Clave;
            this.campoProveedor.Text = this.material.Proveedor;
            this.campoPrecio.Text = this.material.Precio.ToString();
            this.checkIva.IsChecked = this.material.Iva;
            this.campoAncho.Text = this.material.Ancho.ToString();
            this.campoAlto.Text = this.material.Alto.ToString();
            this.campoGrosor.Text = this.material.Grosor.ToString();
            this.ObtenerAcabados(this.material.Id);
        }
        private void CargarAcabado(Acabado acabado)
        {
            this.campoNombreAcabado.Text = acabado.Nombre;
            this.campoPrecioAcabado.Text = acabado.Precio.ToString();
            this.checkIvaAcabado.IsChecked = acabado.Iva;
            this.campoAnchoAcabado.Text = acabado.Ancho.ToString();
            this.campoAltoAcabado.Text = acabado.Alto.ToString();
            this.campoGrosorAcabado.Text = acabado.Grosor.ToString();
            this.EstablecerMonedaSeleccionada(acabado.Moneda, false);
        }
        private void EstablecerMonedaSeleccionada(Moneda moneda, bool esMaterial)
        {
            Moneda monedaSeleccion = null;
            foreach (Moneda monedaLista in this.monedas)
            {
                if (monedaLista.Id == moneda.Id)
                {
                    monedaSeleccion = monedaLista;
                    break;
                }
            }
            if (esMaterial)
            {
                this.comboMonedas.SelectedItem = monedaSeleccion;
            }
            else
            {
                this.comboMonedasAcabado.SelectedItem = monedaSeleccion;
            }
        }
        private void LimpiarFormularioAcabado()
        {
            this.listaAcabados.SelectedItem = null;
            this.campoNombreAcabado.Text = "";
            this.campoPrecioAcabado.Text = "";
            this.campoAnchoAcabado.Text = "";
            this.campoAltoAcabado.Text = "";
            this.campoGrosorAcabado.Text = "";
            this.checkIvaAcabado.IsChecked = false;
        }
        private bool FormularioAcabadoEnEdicion()
        {
            bool enEdicion = false;
            if (this.campoNombreAcabado.Text.Trim() != "" || this.campoPrecioAcabado.Text.Trim() != "" || this.campoAnchoAcabado.Text.Trim() != "" || this.campoAltoAcabado.Text.Trim() != "" || this.campoGrosorAcabado.Text.Trim() != "")
            {
                enEdicion = true;
            }
            return enEdicion;
        }
        private void MostrarMensajeEdicion()
        {
            VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Acabado", "Aún no guardas el nuevo acabado", VentanaMensaje.Botones.ok, this.cargador.Principal);
            ventanaMensaje.ShowDialog();
        }
        private bool ValidarDouble(string dato)
        {
            bool valido;
            try
            {
                Double.Parse(dato);
                valido = true;
            }
            catch (FormatException)
            {
                valido = false;
            }
            return valido;
        }
        private DatosMaterial ValidarDatosMaterial()
        {
            DatosMaterial datos;
            string precio = this.campoPrecio.Text.Trim();
            string ancho = this.campoAncho.Text.Trim();
            string alto = this.campoAlto.Text.Trim();
            string grosor = this.campoGrosor.Text.Trim();
            if (this.campoNombre.Text.Trim() == "")
            {
                datos = DatosMaterial.nombre;
            }
            else if (precio == "")
            {
                datos = DatosMaterial.precio;
            }
            else if (!this.ValidarDouble(precio))
            {
                datos = DatosMaterial.precioIncorrecto;
            }
            else if (ancho == "")
            {
                datos = DatosMaterial.ancho;
            }
            else if (!this.ValidarDouble(ancho))
            {
                datos = DatosMaterial.anchoIncorrecto;
            }
            else if (alto == "")
            {
                datos = DatosMaterial.alto;
            }
            else if (!this.ValidarDouble(alto))
            {
                datos = DatosMaterial.altoIncorrecto;
            }
            else if (grosor == "")
            {
                datos = DatosMaterial.grosor;
            }
            else if (!this.ValidarDouble(grosor))
            {
                datos = DatosMaterial.grosorIncorrecto;
            }
            else if (this.campoClave.Text.Trim() == "")
            {
                datos = DatosMaterial.clave;
            }
            else if (this.campoProveedor.Text.Trim() == "")
            {
                datos = DatosMaterial.proveedor;
            }
            else
            {
                datos = DatosMaterial.ok;
            }
            return datos;
        }
        private DatosMaterial ValidarDatosAcabado()
        {
            DatosMaterial datos;
            string precio = this.campoPrecioAcabado.Text.Trim();
            string ancho = this.campoAnchoAcabado.Text.Trim();
            string alto = this.campoAltoAcabado.Text.Trim();
            string grosor = this.campoGrosorAcabado.Text.Trim();
            if (this.campoNombreAcabado.Text.Trim() == "")
            {
                datos = DatosMaterial.nombre;
            }
            else if (precio == "")
            {
                datos = DatosMaterial.precio;
            }
            else if (!this.ValidarDouble(precio))
            {
                datos = DatosMaterial.precioIncorrecto;
            }
            else if (ancho == "")
            {
                datos = DatosMaterial.ancho;
            }
            else if (!this.ValidarDouble(ancho))
            {
                datos = DatosMaterial.anchoIncorrecto;
            }
            else if (alto == "")
            {
                datos = DatosMaterial.alto;
            }
            else if (!this.ValidarDouble(alto))
            {
                datos = DatosMaterial.altoIncorrecto;
            }
            else if (grosor == "")
            {
                datos = DatosMaterial.grosor;
            }
            else if (!this.ValidarDouble(grosor))
            {
                datos = DatosMaterial.grosorIncorrecto;
            }
            else
            {
                datos = DatosMaterial.ok;
            }
            return datos;
        }
        private void MostrarMensajeDatos(DatosMaterial datos)
        {
            string mensaje;
            switch (datos)
            {
                case DatosMaterial.nombre:
                    mensaje = "El campo 'Nombre' debe tener entre 5 y 100 caractéres";
                    break;
                case DatosMaterial.clave:
                    mensaje = "El campo 'Clave' debe tener entre 5 y 100 caractéres";
                    break;
                case DatosMaterial.proveedor:
                    mensaje = "El campo 'Proveedor' debe tener entre 5 y 100 caractéres";
                    break;
                case DatosMaterial.precio:
                    mensaje = "El campo 'Precio' es requerido";
                    break;
                case DatosMaterial.precioIncorrecto:
                    mensaje = "El campo 'Precio' no es correcto";
                    break;
                case DatosMaterial.ancho:
                    mensaje = "El campo 'Ancho' es requerido";
                    break;
                case DatosMaterial.anchoIncorrecto:
                    mensaje = "El campo 'Ancho' no es correcto";
                    break;
                case DatosMaterial.alto:
                    mensaje = "El campo 'Alto' es requerido";
                    break;
                case DatosMaterial.altoIncorrecto:
                    mensaje = "El campo 'Alto' no es correcto";
                    break;
                case DatosMaterial.grosor:
                    mensaje = "El campo 'Grosor' es requerido";
                    break;
                //Grosor incorrecto:
                default:
                    mensaje = "El campo 'Grosor' no es correcto";
                    break;
            }
            VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Datos no válidos", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            ventanaMensaje.ShowDialog();
        }
        private void AgregarAcabado()
        {
            Acabado acabado = new Acabado(0, this.campoNombreAcabado.Text.Trim(), Double.Parse(this.campoAnchoAcabado.Text.Trim()), Double.Parse(this.campoAltoAcabado.Text.Trim()), Double.Parse(this.campoGrosorAcabado.Text.Trim()), Double.Parse(this.campoPrecioAcabado.Text.Trim()), this.checkIvaAcabado.IsChecked.Value)
            {
                Moneda = (Moneda)this.comboMonedasAcabado.SelectedItem
            };
            this.acabados.Add(acabado);
            this.listaAcabados.Items.Refresh();
            this.LimpiarFormularioAcabado();
        }
        private void ActualizarAcabado()
        {
            Acabado acabado = (Acabado)this.listaAcabados.SelectedItem;
            acabado.Nombre = this.campoNombreAcabado.Text.Trim();
            acabado.Ancho = Double.Parse(this.campoAnchoAcabado.Text.Trim());
            acabado.Alto = Double.Parse(this.campoAltoAcabado.Text.Trim());
            acabado.Grosor = Double.Parse(this.campoGrosorAcabado.Text.Trim());
            acabado.Precio = Double.Parse(this.campoPrecioAcabado.Text.Trim());
            acabado.Iva = this.checkIvaAcabado.IsChecked.Value;
            acabado.Moneda = (Moneda)this.comboMonedasAcabado.SelectedItem;
            this.listaAcabados.Items.Refresh();
        }
        private async Task Registrar()
        {
            Material materialPeticion = new Material(0, this.campoNombre.Text.Trim(), this.campoProveedor.Text.Trim(), this.campoClave.Text.Trim(), Double.Parse(this.campoPrecio.Text.Trim()), this.checkIva.IsChecked.Value)
            {
                Ancho = Double.Parse(this.campoAncho.Text.Trim()),
                Alto = Double.Parse(this.campoAlto.Text.Trim()),
                Grosor = Double.Parse(this.campoGrosor.Text.Trim()),
                Moneda = (Moneda)this.comboMonedas.SelectedItem,
                Acabados = this.acabados
            };
            Material materialRespuesta = await materialPeticion.RegistrarMaterial(this.categoria.Id);
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if (materialRespuesta.Id == 0)
            {
                tipo = VentanaMensaje.Mensaje.error;
                mensaje = "Lo sentimos, no pudimos registrar el material";
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Material registrado";
                this.material = materialRespuesta;
                this.listaAcabados.ItemsSource = this.material.Acabados;
                this.botonEliminar.Content = "Regresar";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Registro", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
        }

        private enum DatosMaterial
        {
            nombre,
            clave,
            proveedor,
            precio,
            precioIncorrecto,
            ancho,
            anchoIncorrecto,
            alto,
            altoIncorrecto,
            grosor,
            grosorIncorrecto,
            ok
        }

        public PanelMaterial(Categoria categoria, int tipo, Cargador cargador, Material material)
        {
            InitializeComponent();
            this.categoria = categoria;
            this.tipo = tipo;
            this.cargador = cargador;
            this.material = material;
            this.etiquetaCategoria.Content = categoria.Nombre;
            this.ObtenerMonedas();
            if (this.material != null)
            {
                this.CargarMaterial();
            }
            else
            {
                this.acabados = new List<Acabado>();
                this.listaAcabados.ItemsSource = this.acabados;
            }
        }

        private void BotonRegresar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Regresar();
        }
        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Regresar();
        }
        private void ListaAcabados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Acabado acabado = (Acabado)this.listaAcabados.SelectedItem;
            if (acabado != null)
            {
                if (this.FormularioAcabadoEnEdicion())
                {
                    this.listaAcabados.SelectedItem = null;
                    this.MostrarMensajeEdicion();
                }
                else
                {
                    this.CargarAcabado(acabado);
                }
            }
        }
        private void BotonNuevoAcabado_Click(object sender, RoutedEventArgs e)
        {
            if (this.listaAcabados.SelectedItem != null)
            {
                this.LimpiarFormularioAcabado();
            }
            else
            {
                if (this.FormularioAcabadoEnEdicion())
                {
                    this.MostrarMensajeEdicion();
                }
            }
        }
        private void BotonNuevoAgregarAcabado_Click(object sender, RoutedEventArgs e)
        {
            DatosMaterial datos = this.ValidarDatosAcabado();
            if (datos == DatosMaterial.ok)
            {
                if (this.listaAcabados.SelectedItem != null)
                {
                    this.ActualizarAcabado();
                }
                else
                {
                    this.AgregarAcabado();
                }
            }
            else
            {
                this.MostrarMensajeDatos(datos);
            }
        }
        private void BotonQuitarAcabado_Click(object sender, RoutedEventArgs e)
        {
            Object elemento = this.listaAcabados.SelectedItem;
            if (elemento != null)
            {
                this.acabados.Remove((Acabado)elemento);
                this.LimpiarFormularioAcabado();
                this.listaAcabados.Items.Refresh();
            }
            else
            {
                VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Elemento no seleccionado", "Debes seleccionar un acabado para quitar", VentanaMensaje.Botones.ok, this.cargador.Principal);
                ventanaMensaje.ShowDialog();
            }
        }
        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            DatosMaterial datos = this.ValidarDatosMaterial();
            if (datos == DatosMaterial.ok)
            {
                if (this.material != null)
                {
                    //Editar.
                }
                else
                {
                    this.Registrar();
                }
            }
            else
            {
                this.MostrarMensajeDatos(datos);
            }
        }
    }
}
