<?php
require APPPATH . '/libraries/REST_Controller.php';
class Usuario_Controller extends REST_Controller
{
	private function validar_recepcion($datos, $u_c = False)
	{
		$nombre = isset($datos['nombre']) ? $datos['nombre'] : '';
		$correo = isset($datos['correo']) ? $datos['correo'] : '';
		$puesto = isset($datos['puesto']) ? $datos['puesto'] : '';
		$usuario;
		$contrasena;
		$entradas = array($nombre, $correo, $puesto);
		if ($u_c){
			$usuario = isset($datos['usuario']) ? $datos['usuario'] : '';
			$contrasena = isset($datos['contrasena']) ? $datos['contrasena'] : '';
			$entradas[3] = $usuario;
			$entradas[4] = $contrasena;
		}
		$valida = True;
		for ($i = 0; $i < count($entradas); $i ++){
			if (!$this->validar_dato(10, 100, $entradas[$i])){
				$valida = False;
				break;
			}
		}
		return $valida;
	}
	private function validar_dato($min, $max, $dato)
	{
		$valido;
		$tipo = gettype($dato);
		if ($tipo === 'string'){
			$len = strlen($dato);
			$valido = $len < $max && $len > $min;
		}else if ($tipo === 'integer' || $tipo === 'double'){
			$valido = $dato < $max && $dato > $min;
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
		$usuario = $this->input->post();
		if ($this->validar_recepcion($usuario, True)){
			$resultado = $this->Usuario_Model->registrar($usuario);
			$usuario['id'] = $resultado['id'];
			$respuesta = array('exito' => $resultado['resultado'], 'usuario' => $usuario);
		}else{
			$this->response(array('error' => '1'), 404);
		}
	}
	public function usuario_put()
	{
		$usuario = $this->input->put();
		if ($this->validar_recepcion($usuario)){
			$resultado = $this->Usuario_Model->editar($usuario);
			$respuesta = array('exito' => $resultado['resultado'], 'usuario' => $usuario);
		}else{
			$this->response(array('error' => '1'), 404);
		}
	}
	public function usuario_delete()
	{

	}
	public function sesion_get()
	{

	}
	public function usuarios_get()
	{

	}
	public function clave_get()
	{

	}
	public function contrasena_put()
	{

	}
}