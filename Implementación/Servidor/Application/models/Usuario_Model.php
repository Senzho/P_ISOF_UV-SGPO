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
		$consulta = $this->db->get_where('usuario', array('nombre' => $nombre, 'contrasena' => $contrasena));
		if ($consulta->num_rows() === 1){
			$fila = $consulta->row();
			$usuario = array('nombre' => $fila->nombre, 'correo' => $fila->correo, 'puesto' => $fila->puesto);
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
		$this->db->where('idUsuario', $usuario['id']);
		$resultado = $this->db->update('usuario', $usuario);
		return $resultado;
	}
	public function eliminar($id_usuario)
	{
		$this->db->where('idUsuario', $id_usuario);
		$resultado = $this->db->update('usuario', array('activo' => False));
		return $resultado;
	}
	public function obtener_usuarios()
	{
		$usuarios;
		$consulta = $this->db->get('usuario');
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$row = $resultado[$i];
			$usuario = array(
				'nombre' => $row->nombre,
				'correo' => $row->correo,
				'puesto' => $row->puesto
			);
			$usuarios[$i] = $usuario;
		}
		return $usuarios;
	}
	public function obtener_usuarios_clave($clave)
	{
		$usuarios;
		$this->db->like('nombre', $clave);
		$this->db->like('correo', $clave);
		$this->db->like('puesto', $clave);
		$consulta = $this->db->get('usuario');
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$row = $resultado[$i];
			$usuario = array(
				'nombre' => $row->nombre,
				'correo' => $row->correo,
				'puesto' => $row->puesto
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