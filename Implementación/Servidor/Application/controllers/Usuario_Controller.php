<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Usuario_Controller extends REST_Controller
{
	private function validar_recepcion($datos, $u_c = False)
	{
		$nombre = isset($datos['nombre']) ? $datos['nombre'] : '';
		$correo = isset($datos['correo']) ? $datos['correo'] : '';
		$puesto = isset($datos['puesto']) ? $datos['puesto'] : '';
		$usuario;
		$contrasena;
		$entradas = array($nombre, $correo);
		if ($u_c){
			$usuario = isset($datos['usuario']) ? $datos['usuario'] : '';
			$contrasena = isset($datos['contrasena']) ? $datos['contrasena'] : '';
			$entradas[2] = $usuario;
			$entradas[3] = $contrasena;
		}
		$valida = True;
		for ($i = 0; $i < count($entradas); $i ++){
			if (!$this->validar_dato(10, 100, $entradas[$i])){
				$valida = False;
				break;
			}
		}
		if (!$this->validar_dato(5, 100, $puesto)){
			$valida = False;
		}
		return $valida;
	}
	private function validar_dato($min, $max, $dato)
	{
		$valido = False;
		$tipo = gettype($dato);
		if ($tipo === 'string'){
			$len = strlen($dato);
			$valido = $len <= $max && $len >= $min;
		}else if ($tipo === 'integer' || $tipo === 'double'){
			$valido = $dato <= $max && $dato >= $min;
		}
		return $valido;
	}
	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Usuario_Model');
		$this->load->helper('url');
	}

	public function usuario_post()
	{
		$respuesta;
		$usuario = $this->post();
		//if ($this->validar_recepcion($usuario, True)){
			$resultado = $this->Usuario_Model->registrar($usuario);
			$respuesta['exito'] = $resultado['resultado'];
			if ($respuesta['exito']){
				$usuario['id'] = $resultado['id'];
				$respuesta['usuario'] = $usuario;
			}else{
				$respuesta['error'] = 2;
			}
		/*}else{
			$respuesta['exito'] = False;
			$respuesta['error'] = 1;
		}*/
		$codigo = $respuesta['exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function usuario_put()
	{
		$respuesta;
		$usuario = $this->put();
		if ($this->validar_recepcion($usuario, True)){
			$respuesta['exito'] = $this->Usuario_Model->editar($usuario);
			if (!$respuesta['exito']){
				$respuesta['error'] = 2;
			}
		}else{
			$respuesta['exito'] = False;
			$respuesta['error'] = 1;
		}
		$codigo = $respuesta['exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function usuario_delete()
	{
		$respuesta;
		$id = $this->get('id');
		if ($this->validar_dato(1, 10000, $id)){
			$respuesta['exito'] = $this->Usuario_Model->eliminar($id);
			if (!$respuesta['exito']){
				$respuesta['error'] = 2;
			}
		}else{
			$respuesta['exito'] = False;
			$respuesta['error'] = 1;
		}
		$codigo = $respuesta['exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function sesion_get()
	{
		$respuesta;
		$nombre = $this->get('nombre');
		$sha = $this->get('sha');
		if ($this->validar_dato(3, 100, $nombre) && $this->validar_dato(64, 64, $sha)){
			$resultado = $this->Usuario_Model->iniciar_sesion($nombre, $sha);
			$respuesta['exito'] = $resultado['resultado'];
			if ($respuesta['exito']){
				$respuesta['usuario'] = $resultado['usuario'];
			}else{
				$respuesta['error'] = 2;
			}
		}else{
			$respuesta['exito'] = False;
			$respuesta['error'] = 1;
		}
		$codigo = $respuesta['exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function usuarios_get()
	{
		$respuesta['usuarios'] = $this->Usuario_Model->obtener_usuarios();
		$this->response($respuesta, 200);
	}
	public function clave_get()
	{
		$clave = $this->get('clave');
		$respuesta;
		$codigo;
		if ($this->validar_dato(1, 100, $clave)){
			$respuesta['exito'] = True;
			$respuesta['usuarios'] = $this->Usuario_Model->obtener_usuarios_clave($clave);
		}else{
			$respuesta['exito'] = False;
			$respuesta['error'] = 1;
		}
		$codigo = $respuesta['exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function contrasena_put()
	{

	}
}