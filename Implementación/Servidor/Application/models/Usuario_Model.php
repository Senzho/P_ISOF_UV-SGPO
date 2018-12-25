<?php
class Usuario_Model extends CI_Model
{
	private function registrar_permisos($id_usuario, $permisos)
	{
		$resultado = True;
		$resultados;
		for($i = 0; $i < count($permisos); $i ++){
			$permiso = $permisos[$i];
			$permiso['IdUsuario'] = $id_usuario;
			$resultados[$i] = $this->db->insert('permiso', $permiso);
			$permiso['Id'] = $this->db->insert_id();
			$permisos[$i] = $permiso;
			if (!$resultados[$i]){
				$resultado = False;
			}
		}
		return $permisos;
	}
	private function editar_permisos($permisos)
	{
		for($i = 0; $i < count($permisos); $i ++){
			$permiso = $permisos[$i];
			$this->db->where('id', $permiso['Id']);
			$this->db->update('permiso', $permiso);
		}
	}

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
			$usuario = array('Id' => $fila->id, 'Nombre' => $fila->nombre, 'Correo' => $fila->correo, 'Puesto' => $fila->puesto, 'NombreUsuario' => $fila->nombreUsuario, 'Permisos' => $this->obtener_permisos($fila->id));
			$respuesta['Resultado'] = True;
			$respuesta['Usuario'] = $usuario;
		}else{
			$respuesta['Resultado'] = False;
		}
		return $respuesta;
	}
	public function registrar($usuario)
	{
		$usuario['activo'] = True;
		$permisos = $usuario['Permisos'];
		unset($usuario['Permisos']);
		$resultado = $this->db->insert('usuario', $usuario);
		$id = $this->db->insert_id();
		if ($resultado){
			$permisos = $this->registrar_permisos($id, $permisos);
		}
		$respuesta = array('Resultado' => $resultado, 'Id' => $id, 'Permisos' => $permisos);
		return $respuesta;
	}
	public function editar($usuario)
	{
		$this->db->where('id', $usuario['Id']);
		$permisos = $usuario['Permisos'];
		unset($usuario['Permisos']);
		$resultado = $this->db->update('usuario', $usuario);
		if ($resultado){
			$this->editar_permisos($permisos);
		}
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
				'Id' => $fila->id,
				'Nombre' => $fila->nombre,
				'Correo' => $fila->correo,
				'Puesto' => $fila->puesto,
				'NombreUsuario' => $fila->nombreUsuario
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
				'Id' => $fila->id,
				'Nombre' => $fila->nombre,
				'Correo' => $fila->correo,
				'Puesto' => $fila->puesto,
				'NombreUsuario' => $fila->nombreUsuario
			);
			$usuarios[$i] = $usuario;
		}
		return $usuarios;
	}
	public function obtener_permisos($id_usuario)
	{
		$permisos = array();
		$consulta = $this->db->get_where('permiso', array('idUsuario' => $id_usuario));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$permiso = array('Id' => $fila->id ,'Ambito' => $fila->ambito, 'Consultar' => $fila->consultar == '1' ? True : False, 'Crear' => $fila->crear == '1' ? True : False, 'Modificar' => $fila->modificar == '1' ? True : False, 'Eliminar' => $fila->eliminar == '1' ? True : False);
			$permisos[$i] = $permiso;
		}
		return $permisos;
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