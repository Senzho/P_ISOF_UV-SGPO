<?php
class Moneda_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
	}

	public function obtener_monedas()
	{
		$monedas = array();
		$consulta = $this->db->get('moneda');
		$resultado = $consulta->result();
		for ($i = 0; $i < count($resultado); ++ $i) {
			$fila = $resultado[$i];
			$moneda = array(
				'Id' => $fila->id,
				'Nombre' => $fila->nombre
			);
			$monedas[$i] = $moneda;
		}
		return $monedas;
	}
	public function obtener_moneda($id_moneda)
	{
		$moneda;
		$consulta = $this->db->get_where('moneda', array('id' => $id_moneda));
		if ($consulta->num_rows() === 1){
			$fila = $consulta->row(); 
			$moneda = array('Id' => $fila->id, 'Nombre' => $fila->nombre);
		}else{
			$moneda = array('Id' => 0);
		}
		return $moneda;
	}
}