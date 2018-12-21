<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Moneda_Controller extends REST_Controller
{	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Moneda_Model');
		$this->load->helper('url');
		$this->load->helper('Validacion_Helper');
	}

	public function monedas_get()
	{
		$respuesta['Exito'] = True;
		$respuesta['Monedas'] = $this->Moneda_Model->obtener_monedas();
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
}