<?php
class Usuario_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
	}

	public function iniciar_sesion($nombre, $contrasena)
	{
		$respuesta;
		$consulta = $this->db->get_where('usuario', array('nombreUsuario' => $nombre, 'contraseña' => $contrasena));
		if ($consulta->num_rows() === 1){
			$fila = $consulta->row();
			$usuario = array('id' => $fila->id, 'nombre' => $fila->nombre, 'correo' => $fila->correo, 'puesto' => $fila->puesto, 'nombreUsuario' => $fila->nombreUsuario);
			$respuesta['resultado'] = True;
			$respuesta['usuario'] = $usuario;
		}else{
			$respuesta['resultado'] = False;
		}
		return $respuesta;
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
		$this->db->where('id', $usuario['id']);
		$resultado = $this->db->update('usuario', $usuario);
		return $resultado;
	}
	public function eliminar($id_usuario)
	{
		$this->db->where('id', $id_usuario);
		$resultado = $this->db->update('usuario', array('activo' => False));
		return $resultado;
	}
	public function obtener_usuarios()
	{
		$usuarios = array();
		$consulta = $this->db->get_where('usuario', array('activo' => True));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$usuario = array(
				'id' => $fila->id,
				'nombre' => $fila->nombre,
				'correo' => $fila->correo,
				'puesto' => $fila->puesto,
				'nombreUsuario' => $fila->nombreUsuario
			);
			$usuarios[$i] = $usuario;
		}
		return $usuarios;
	}
	public function obtener_usuarios_clave($clave)
	{
		$usuarios = array();
		$this->db->like('nombre', $clave);
		$this->db->or_like('correo', $clave);
		$this->db->or_like('puesto', $clave);
		$consulta = $this->db->get_where('usuario', array('activo' => True));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$usuario = array(
				'id' => $fila->id,
				'nombre' => $fila->nombre,
				'correo' => $fila->correo,
				'puesto' => $fila->puesto,
				'nombreUsuario' => $fila->nombreUsuario
			);
			$usuarios[$i] = $usuario;
		}
		return $usuarios;
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