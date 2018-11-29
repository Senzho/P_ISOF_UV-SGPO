<?php
class Usuario_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
	}

	public function iniciar_sesion($nombre, $contrasena)
	{

	}
	public function registrar($usuario)
	{
		$resultado = $this->db->insert('usuario', $usuario);
		$id = $this->db->insert_id();
		$respuesta = array('resultado' => $resultado, 'id' => $id);
		return $respuesta;
	}
	public function editar($usuario)
	{
		$this->db->where('idUsuario', $usuario['id']);
		$resultado = $this->db->update('usuario', $usuario);
		$respuesta = array('resultado' => $resultado);
		return $respuesta;
	}
	public function eliminar($id_usuario)
	{

	}
	public function obtener_usuarios()
	{

	}
	public function obtener_usuarios_clave($clave)
	{

	}
	public function obtener_usuario($nombre)
	{

	}
	public function obtener_usuario_presupuesto($id_presupuesto)
	{

	}
	public function obtener_usuario_accion($id_accion)
	{

	}
	public function generar_contrasena($nombre)
	{

	}
}