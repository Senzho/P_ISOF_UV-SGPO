<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Acabado_Controller extends REST_Controller
{	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Acabado_Model');
		$this->load->helper('url');
		$this->load->helper('Validacion_Helper');
	}

	public function acabados_get()
	{
		$id_material = $this->get('idMaterial');
		$respuesta;
		$codigo;
		if (validar_dato(1, 10000, $id_material)){
			$respuesta['Exito'] = True;
			$respuesta['Acabados'] = $this->Acabado_Model->obtener_acabados($id_material);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
}