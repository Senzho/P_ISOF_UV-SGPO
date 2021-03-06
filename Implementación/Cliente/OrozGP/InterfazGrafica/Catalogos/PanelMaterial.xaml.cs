﻿using OrozGP.LogicaNegocio;
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
    /// <summary>
    /// Clase controladora del control de usuario del panel de material.
    /// </summary>
    public partial class PanelMaterial : UserControl
    {
        private Categoria categoria;
        private int tipo;
        private Cargador cargador;
        private Material material;
        private IList<Acabado> acabados;
        private IList<Acabado> acabadosEditar;
        private IList<Acabado> acabadosAgregar;
        private IList<Acabado> acabadosQuitar;
        private IList<Moneda> monedas;

        /// <summary>
        /// Regresa a la ventana de administración de materiales.
        /// </summary>
        private void Regresar()
        {
            this.cargador.Cargar(new PanelMateriales(this.cargador, this.tipo, this.categoria));
        }
        /// <summary>
        /// Obiene las monedas de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        private async Task ObtenerMonedas()
        {
            this.monedas = await Moneda.ObtenerMonedas();
            this.CargarMonedas();
        }
        /// <summary>
        /// Carga las monedas en los combos de selección de material y acabados.
        /// </summary>
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
                this.botonGuardar.IsEnabled = true;
            }
        }
        /// <summary>
        /// Obitiene los acabados del material de forma síncrona.
        /// </summary>
        /// <param name="idMaterial">Identificador del material.</param>
        /// <returns></returns>
        private async Task ObtenerAcabados(int idMaterial)
        {
            this.acabados = await Acabado.ObtenerAcabados(idMaterial);
            this.material.Acabados = this.acabados;
            this.listaAcabados.ItemsSource = this.acabados;
            this.botonGuardar.IsEnabled = true;
        }
        /// <summary>
        /// Muestra los datos del material.
        /// </summary>
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
            //Obtiene los acabados.
            this.ObtenerAcabados(this.material.Id);
        }
        /// <summary>
        /// Muestra los datos de un acabado seleccionado en el formulario de acabados.
        /// </summary>
        /// <param name="acabado">Acabado a cargar.</param>
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
        /// <summary>
        /// Establece la moneda seleccionada en los combos de selección dependiendo de si se trata de un material o un acabado.
        /// </summary>
        /// <param name="moneda">Moneda seleccionada.</param>
        /// <param name="esMaterial">Identificador para material o acabado.</param>
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
        /// <summary>
        /// Quita los datos cargados del formulario de acabados.
        /// </summary>
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
        /// <summary>
        /// Identifica si un acabado se encuentra en edición.
        /// </summary>
        /// <param name="acabado">Acabado a identificar.</param>
        /// <returns>
        /// Un booleano con la confirmación del estado de edición del acabado.
        /// </returns>
        private bool AcabadoEnEdicion(Acabado acabado)
        {
            bool enEdicion = false;
            if (this.campoNombreAcabado.Text != acabado.Nombre || this.campoPrecioAcabado.Text != acabado.Precio.ToString() || this.campoAnchoAcabado.Text != acabado.Ancho.ToString() || this.campoAltoAcabado.Text != acabado.Alto.ToString() || this.campoGrosorAcabado.Text != acabado.Grosor.ToString())
            {
                enEdicion = true;
            }
            return enEdicion;
        }
        /// <summary>
        /// Identifica si se está registrando un nuevo acabado.
        /// </summary>
        /// <returns>
        /// Un booleano con la confirmación de contenido en el formulario de acabados.
        /// </returns>
        private bool FormularioAcabadoEnEdicion()
        {
            bool enEdicion = false;
            if (this.campoNombreAcabado.Text.Trim() != "" || this.campoPrecioAcabado.Text.Trim() != "" || this.campoAnchoAcabado.Text.Trim() != "" || this.campoAltoAcabado.Text.Trim() != "" || this.campoGrosorAcabado.Text.Trim() != "")
            {
                enEdicion = true;
            }
            return enEdicion;
        }
        /// <summary>
        /// Muestra un mensaja para informar sobre la edición / creación de un acabado.
        /// </summary>
        private void MostrarMensajeEdicion()
        {
            VentanaMensaje ventanaMensaje = new VentanaMensaje(VentanaMensaje.Mensaje.info, "Acabado", "Aún no guardas el nuevo acabado", VentanaMensaje.Botones.ok, this.cargador.Principal);
            ventanaMensaje.ShowDialog();
        }
        /// <summary>
        /// Valida si una cadena de texto corresponde a un número decimal double.
        /// </summary>
        /// <param name="dato">Dato a validar.</param>
        /// <returns>
        /// Un booleano con la confirmación de validéz.
        /// </returns>
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
        /// <summary>
        /// Valida los datos de un material.
        /// </summary>
        /// <returns>
        /// Un enumerador sobre el estado de validéz.
        /// </returns>
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
        /// <summary>
        /// Valida los datos de un acabado.
        /// </summary>
        /// <returns>
        /// Un enumerador con el estado de validez.
        /// </returns>
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
        /// <summary>
        /// Muestra un mensaje de corrección de la información ingresada.
        /// </summary>
        /// <param name="datos">Enumerador con el estado de invalidéz de los datos.</param>
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
        /// <summary>
        /// Agrega un acabado a la lista de acabados.
        /// </summary>
        private void AgregarAcabado()
        {
            Acabado acabado = new Acabado(0, this.campoNombreAcabado.Text.Trim(), Double.Parse(this.campoAnchoAcabado.Text.Trim()), Double.Parse(this.campoAltoAcabado.Text.Trim()), Double.Parse(this.campoGrosorAcabado.Text.Trim()), Double.Parse(this.campoPrecioAcabado.Text.Trim()), this.checkIvaAcabado.IsChecked.Value)
            {
                Moneda = (Moneda)this.comboMonedasAcabado.SelectedItem
            };
            this.acabadosAgregar.Add(acabado);
            this.acabados.Add(acabado);
            this.listaAcabados.Items.Refresh();
            this.LimpiarFormularioAcabado();
        }
        /// <summary>
        /// Actualiza un acabado editado de la lista de acabados.
        /// </summary>
        private void ActualizarAcabado()
        {
            Acabado acabado = (Acabado)this.listaAcabados.SelectedItem;
            if (this.acabados.Contains(acabado))
            {
                this.acabados.Remove(acabado);
            }
            this.acabados.Add(acabado);
            if (this.acabadosEditar.Contains(acabado))
            {
                this.acabadosEditar.Remove(acabado);
            }
            this.acabadosEditar.Add(acabado);
            acabado.Nombre = this.campoNombreAcabado.Text.Trim();
            acabado.Ancho = Double.Parse(this.campoAnchoAcabado.Text.Trim());
            acabado.Alto = Double.Parse(this.campoAltoAcabado.Text.Trim());
            acabado.Grosor = Double.Parse(this.campoGrosorAcabado.Text.Trim());
            acabado.Precio = Double.Parse(this.campoPrecioAcabado.Text.Trim());
            acabado.Iva = this.checkIvaAcabado.IsChecked.Value;
            acabado.Moneda = (Moneda)this.comboMonedasAcabado.SelectedItem;
            this.listaAcabados.Items.Refresh();
        }
        /// <summary>
        /// Registra un material de forma asíncrona.
        /// </summary>
        /// <returns></returns>
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
                this.acabados = this.material.Acabados;
                this.listaAcabados.ItemsSource = this.acabados;
                this.botonEliminar.Content = "Regresar";
                this.LimpiarFormularioAcabado();
                this.VaciarListas();
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Registro", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
        }
        /// <summary>
        /// Actualiza un material de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        private async Task Editar()
        {
            Material materialPeticion = new Material(this.material.Id, this.campoNombre.Text.Trim(), this.campoProveedor.Text.Trim(), this.campoClave.Text.Trim(), Double.Parse(this.campoPrecio.Text.Trim()), this.checkIva.IsChecked.Value)
            {
                Ancho = Double.Parse(this.campoAncho.Text.Trim()),
                Alto = Double.Parse(this.campoAlto.Text.Trim()),
                Grosor = Double.Parse(this.campoGrosor.Text.Trim()),
                Moneda = (Moneda)this.comboMonedas.SelectedItem,
                Acabados = this.acabadosEditar
            };
            Object[] respuesta = await materialPeticion.EditarMaterial(this.acabadosAgregar, this.acabadosQuitar);
            VentanaMensaje.Mensaje tipo;
            string mensaje;
            if ((bool) respuesta[0])
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Material actualizado";
                this.botonEliminar.Content = "Regresar";
                this.VaciarListas();
                this.ActualizarAcabadosEditados((IList<Acabado>) respuesta[1]);
            }
            else
            {
                tipo = VentanaMensaje.Mensaje.exito;
                mensaje = "Lo sentimos, no pudimos actualizar el Material";
            }
            VentanaMensaje vMensaje = new VentanaMensaje(tipo, "Edicion", mensaje, VentanaMensaje.Botones.ok, this.cargador.Principal);
            vMensaje.ShowDialog();
        }
        /// <summary>
        /// Vacía las listas de acabados.
        /// </summary>
        private void VaciarListas()
        {
            this.acabadosAgregar.Clear();
            this.acabadosEditar.Clear();
            this.acabadosQuitar.Clear();
        }
        /// <summary>
        /// Actualiza la lista de acabados después de una actualización de material, reemplazando los acabados nuevos (identificador 0) por los registrados con su respectivo identificador de registro.
        /// </summary>
        /// <param name="acabados">Lista de acabados registrados</param>
        private void ActualizarAcabadosEditados(IList<Acabado> acabados)
        {
            Acabado acabado;
            for (int i = 0; i < this.acabados.Count; i++)
            {
                acabado = this.acabados.ElementAt(i);
                if (acabado.Id == 0)
                {
                    this.acabados.Remove(acabado);
                }
            }
            this.acabados = this.acabados.Concat<Acabado>(acabados).ToList();
            this.listaAcabados.ItemsSource = this.acabados;
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

        /// <summary>
        /// Constructor principal de la clase.
        /// </summary>
        /// <param name="categoria">Categoría del material.</param>
        /// <param name="tipo">Tipo de categoría del material.</param>
        /// <param name="cargador">Instancia del cargador de elementos.</param>
        /// <param name="material">Material (null para registrar).</param>
        public PanelMaterial(Categoria categoria, int tipo, Cargador cargador, Material material)
        {
            InitializeComponent();
            this.categoria = categoria;
            this.tipo = tipo;
            this.cargador = cargador;
            this.material = material;
            this.etiquetaCategoria.Content = categoria.Nombre;
            this.ObtenerMonedas();
            this.acabadosAgregar = new List<Acabado>();
            this.acabadosEditar = new List<Acabado>();
            this.acabadosQuitar = new List<Acabado>();
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
        private void ListaAcabadosItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            Acabado acabado = (Acabado)item.Content;
            Object elementoSeleccionado = this.listaAcabados.SelectedItem;
            if (elementoSeleccionado != null)
            {
                Acabado acabadoSeleccionado = (Acabado)elementoSeleccionado;
                if (this.AcabadoEnEdicion(acabadoSeleccionado))
                {
                    this.MostrarMensajeEdicion();
                }
                else
                {
                    this.CargarAcabado(acabado);
                }
            }
            else
            {
                if (this.FormularioAcabadoEnEdicion())
                {
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
            Object elementoSeleccionado = this.listaAcabados.SelectedItem;
            if (elementoSeleccionado != null)
            {
                Acabado acabado = (Acabado)elementoSeleccionado;
                if (this.AcabadoEnEdicion(acabado))
                {
                    this.MostrarMensajeEdicion();
                }
                else
                {
                    this.LimpiarFormularioAcabado();
                }
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
                Acabado acabado = (Acabado)elemento;
                this.acabados.Remove(acabado);
                if (this.acabadosEditar.Contains(acabado))
                {
                    this.acabadosEditar.Remove(acabado);
                }
                else if (this.acabadosAgregar.Contains(acabado))
                {
                    this.acabadosAgregar.Remove(acabado);
                }
                this.acabadosQuitar.Add(acabado);
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
                    this.Editar();
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
