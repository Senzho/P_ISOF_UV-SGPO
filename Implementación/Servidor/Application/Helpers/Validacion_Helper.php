<?php
function validar_dato($min, $max, $dato)
{
	$valido = False;
	$tipo = gettype($dato);
	if ($tipo === 'string'){
		$len = strlen($dato);
		$valido = $len <= $max && $len >= $min;
	}else if ($tipo === 'integer' || $tipo === 'double'){
		$valido = $dato <= $max && $dato >= $min;
	}
	return $valido;
}