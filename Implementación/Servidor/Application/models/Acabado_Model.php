<?php
class Acabado_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
		$this->load->model('Moneda_Model');
	}

	public function obtener_acabados($id_material)
	{
		$acabados = array();
		$consulta = $this->db->get_where('acabado', array('idMaterial' => $id_material));
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$acabado = array(
				'Id' => $fila->id,
				'Nombre' => $fila->nombre,
				'Alto' => $fila->alto,
				'Ancho' => $fila->ancho,
				'Grosor' => $fila->grosor,
				'Precio' => $fila->precio,
				'Iva' => $fila->iva,
				'Moneda' => $this->Moneda_Model->obtener_moneda($fila->idMoneda)
			);
			$acabados[$i] = $acabado;
		}
		return $acabados;
	}
}