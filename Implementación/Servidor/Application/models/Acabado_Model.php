<?php
class Acabado_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
		$this->load->model('Moneda_Model');
	}

	public function registrar($id_material, $acabados)
	{
		$resultado = True;
		$resultados;
		for($i = 0; $i < count($acabados); $i ++){
			$acabado = $acabados[$i];
			$moneda = $acabado['Moneda'];
			unset($acabado['Moneda']);
			$acabado['idMoneda'] = $moneda['Id'];
			$acabado['IdMaterial'] = $id_material;
			$acabado['Activo'] = True;
			$resultados[$i] = $this->db->insert('acabado', $acabado);
			$acabado['Id'] = $this->db->insert_id();
			$acabado['Moneda'] = $moneda;
			$acabados[$i] = $acabado;
			if (!$resultados[$i]){
				$resultado = False;
			}
		}
		return $acabados;
	}
	public function editar_acabados($acabados)
	{
		for($i = 0; $i < count($acabados); $i ++){
			$acabado = $acabados[$i];
			$this->db->where('id', $acabado['Id']);
			$this->db->update('acabado', $acabado);
		}
	}
	public function eliminar_acabados($acabados)
	{
		for($i = 0; $i < count($acabados); $i ++){
			$acabado = $acabados[$i];
			$this->db->where('id', $acabado['Id']);
			$this->db->update('acabado', array('activo' => False));
		}
	}
	public function obtener_acabados($id_material)
	{
		$acabados = array();
		$consulta = $this->db->get_where('acabado', array('idMaterial' => $id_material, 'Activo' => True));
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
				'Iva' => $fila->iva == '1' ? True : False,
				'Moneda' => $this->Moneda_Model->obtener_moneda($fila->idMoneda)
			);
			$acabados[$i] = $acabado;
		}
		return $acabados;
	}
}