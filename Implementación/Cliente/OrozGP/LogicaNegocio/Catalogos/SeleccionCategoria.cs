using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.LogicaNegocio.Catalogos
{
    /// <summary>
    /// Interfaz para la selección de una categoría en la GUI.
    /// </summary>
    public interface ISeleccionCategoria
    {
        /// <summary>
        /// Debe contener código correspondiente a la acción posterior a la selección de una categoría.
        /// </summary>
        /// <param name="categoria">Categoría seleccionada.</param>
        void CategoriaSeleccionada(Categoria categoria);
    }
}
