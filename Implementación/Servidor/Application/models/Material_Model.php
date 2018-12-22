<?php
class Material_Model extends CI_Model
{
	public function __construct()
	{
		$this->load->database('orozgp');
		$this->load->model('Moneda_Model');
		$this->load->model('Acabado_Model');
	}

	public function registrar($material, $id_categoria)
	{
		$material['idCategoria'] = $id_categoria;
		$moneda = $material['Moneda'];
		unset($material['Moneda']);
		$material['idMoneda'] = $moneda['Id'];
		$acabados = $material['Acabados'];
		unset($material['Acabados']);
		$resultado = $this->db->insert('material', $material);
		$id = $this->db->insert_id();
		if ($resultado){
			$acabados = $this->Acabado_Model->registrar($id, $acabados);
		}
		$respuesta = array('Resultado' => $resultado, 'Id' => $id, 'Acabados' => $acabados);
		return $respuesta;
	}
	public function obtener_materiales_categoria($id_categoria)
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
				'Iva' => $fila->iva == '1' ? True : False,
				'Moneda' => $this->Moneda_Model->obtener_moneda($fila->idMoneda)
			);
			$materiales[$i] = $material;
		}
		return $materiales;
	}
	public function obtener_materiales_categoria_clave($id_categoria, $clave)
	{
		$materiales = array();
		$this->db->like('nombre', $clave);
		$this->db->or_like('proveedor', $clave);
		$this->db->or_like('clave', $clave);
		$this->db->or_like('precio', $clave);
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
				'Iva' => $fila->iva == '1' ? True : False,
				'Moneda' => $this->Moneda_Model->obtener_moneda($fila->idMoneda)
			);
			$materiales[$i] = $material;
		}
		return $materiales;
	}
}