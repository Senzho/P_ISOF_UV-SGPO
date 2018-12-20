<?php
class Categoria_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
	}

	public function obtener_categorias($tipo)
	{
		$categorias = array();
		$consulta = $this->db->get_where('categoria', array('tipo' => $tipo));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$categoria = array(
				'Id' => $fila->id,
				'Nombre' => $fila->nombre
			);
			$categorias[$i] = $categoria;
		}
		return $categorias;
	}
}