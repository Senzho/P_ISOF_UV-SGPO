<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Categoria_Controller extends REST_Controller
{	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Categoria_Model');
		$this->load->helper('url');
		$this->load->helper('Validacion_Helper');
	}

	public function categoria_post()
	{
		
	}
	public function categoria_put()
	{
		
	}
	public function categorias_get()
	{
		$tipo = $this->get('tipo');
		$respuesta;
		$codigo;
		if (validar_dato(1, 4, $tipo)){
			$respuesta['Exito'] = True;
			$respuesta['Categorias'] = $this->Categoria_Model->obtener_categorias($tipo);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
}