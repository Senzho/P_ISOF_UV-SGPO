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

	public function material_post()
	{
		$respuesta;
		$material = $this->post();
		$id_categoria = $this->get('idCategoria');
		if (validar_dato(1, 10000, $id_categoria)){
			$resultado = $this->Material_Model->registrar($material, $id_categoria);
			$respuesta['Exito'] = $resultado['Resultado'];
			if ($respuesta['Exito']){
				$material['Id'] = $resultado['Id'];
				$material['Acabados'] = $resultado['Acabados'];
				$respuesta['Material'] = $material;
			}else{
				$respuesta['Error'] = 2;
			}
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function material_put()
	{
		$respuesta;
		$material = $this->put();
		$resultado = $this->Material_Model->editar($material);
		$respuesta['Exito'] = $resultado['Resultado'];
		if (!$respuesta['Exito']){
			$respuesta['Error'] = 2;
		}else{
			$respuesta['AcabadosAgregados'] = $resultado['Acabados'];
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function material_delete()
	{
		$respuesta;
		$id = $this->get('idMaterial');
		if (validar_dato(1, 10000, $id)){
			$respuesta['Exito'] = $this->Material_Model->eliminar($id);
			if (!$respuesta['Exito']){
				$respuesta['Error'] = 2;
			}
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function categoria_get()
	{
		$id_categoria = $this->get('idCategoria');
		$respuesta;
		$codigo;
		if (validar_dato(1, 10000, $id_categoria)){
			$respuesta['Exito'] = True;
			$respuesta['Materiales'] = $this->Material_Model->obtener_materiales_categoria($id_categoria);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function categoria_clave_get()
	{
		$id_categoria = $this->get('idCategoria');
		$clave = $this->get('clave');
		$respuesta;
		$codigo;
		if (validar_dato(1, 10000, $id_categoria) && validar_dato(1, 100, $clave)){
			$respuesta['Exito'] = True;
			$respuesta['Materiales'] = $this->Material_Model->obtener_materiales_categoria_clave($id_categoria, $clave);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
}