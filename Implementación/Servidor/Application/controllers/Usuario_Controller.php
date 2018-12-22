<?php
require APPPATH . '/libraries/REST_Controller.php';
/*Códigos de error:
	1. Error de validación: los datos recibidos no son válidos.
	2. Error de BD: ocurrió un problema al acceder a la base de datos.
*/
class Usuario_Controller extends REST_Controller
{
	public function __construct()
	{
		parent::__construct();
		$this->load->model('Usuario_Model');
		$this->load->helper('url');
		$this->load->helper('Validacion_Helper');
	}

	public function usuario_post()
	{
		$respuesta;
		$usuario = $this->post();
		$resultado = $this->Usuario_Model->registrar($usuario);
		$respuesta['Exito'] = $resultado['Resultado'];
		if ($respuesta['Exito']){
			$usuario['Id'] = $resultado['Id'];
			$usuario['Permisos'] = $resultado['Permisos'];
			$respuesta['Usuario'] = $usuario;
		}else{
			$respuesta['Error'] = 2;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function usuario_put()
	{
		$respuesta;
		$usuario = $this->put();
		$respuesta['Exito'] = $this->Usuario_Model->editar($usuario);
		if (!$respuesta['Exito']){
			$respuesta['Error'] = 2;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function usuario_delete()
	{
		$respuesta;
		$id = $this->get('id');
		if (validar_dato(1, 10000, $id)){
			$respuesta['Exito'] = $this->Usuario_Model->eliminar($id);
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
	public function sesion_get()
	{
		$respuesta;
		$nombre = $this->get('nombre');
		$sha = $this->get('sha');
		if (validar_dato(3, 100, $nombre) && validar_dato(64, 64, $sha)){
			$resultado = $this->Usuario_Model->iniciar_sesion($nombre, $sha);
			$respuesta['Exito'] = $resultado['Resultado'];
			if ($respuesta['Exito']){
				$respuesta['Usuario'] = $resultado['Usuario'];
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
	public function usuarios_get()
	{
		$respuesta['Usuarios'] = $this->Usuario_Model->obtener_usuarios();
		$this->response($respuesta, 200);
	}
	public function clave_get()
	{
		$clave = $this->get('clave');
		$respuesta;
		$codigo;
		if (validar_dato(1, 100, $clave)){
			$respuesta['Exito'] = True;
			$respuesta['Usuarios'] = $this->Usuario_Model->obtener_usuarios_clave($clave);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function permisos_get()
	{
		$id_usuario = $this->get('idUsuario');
		$respuesta;
		$codigo;
		if (validar_dato(1, 10000, $id_usuario)){
			$respuesta['Exito'] = True;
			$respuesta['Permisos'] = $this->Usuario_Model->obtener_permisos($id_usuario);
		}else{
			$respuesta['Exito'] = False;
			$respuesta['Error'] = 1;
		}
		$codigo = $respuesta['Exito'] ? 200 : 404;
		$this->response($respuesta, $codigo);
	}
	public function contrasena_put()
	{

	}
}