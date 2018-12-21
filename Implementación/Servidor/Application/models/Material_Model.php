<?php
class Material_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
		$this->load->model('Moneda_Model');
	}

	public function obtener_materiales($id_categoria)
	{
		$materiales = array();
		$consulta = $this->db->get_where('material', array('idCategoria' => $id_categoria));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$material = array(
				'Id' => $fila->id,
				'Nombre' => $fila->nombre,
				'Proveedor' => $fila->proveedor,
				'Clave' => $fila->clave,
				'Alto' => $fila->alto,
				'Ancho' => $fila->ancho,
				'Grosor' => $fila->grosor,
				'Precio' => $fila->precio,
				'Iva' => $fila->iva,
				'Moneda' => $this->Moneda_Model->obtener_moneda($fila->idMoneda)
			);
			$materiales[$i] = $material;
		}
		return $materiales;
	}
}