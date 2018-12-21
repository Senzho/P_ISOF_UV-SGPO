<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Material_Controller extends REST_Controller
{	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Material_Model');
		$this->load->helper('url');
		$this->load->helper('Validacion_Helper');
	}

	public function categoria_get()
	{
		$id_categoria = $this->get('idCategoria');
		$respuesta;
		$codigo;
		if (validar_dato(1, 10000, $id_categoria)){
			$respuesta['Exito'] = True;
			$respuesta['Materiales'] = $this->Material_Model->obtener_materiales($id_categoria);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
}