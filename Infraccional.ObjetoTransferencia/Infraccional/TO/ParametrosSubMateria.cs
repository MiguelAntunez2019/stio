using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    /// <summary>
    /// Descripcion: Clase que representa parametrizacion para la creación de submateria en procedimiento de almacenado.
    /// </summary>
    public class ParametrosSubMateria
    {
        /// <summary>
        /// Representa el identificador relación submateria y denuncia.
        /// </summary>
        public int P_ASU_ID { get; set; }
        /// <summary>
        /// Representa el identificador de la denuncia.
        /// </summary>
        public int P_ASU_ADC_ID { get; set; }
        /// <summary>
        /// Representa el identificador de la submateria.
        /// </summary>
        public int P_ASU_SUBMATERIA_ID { get; set; }
        /// <summary>
        /// Representa la acción que va a tomar el proceso de guardado.
        /// </summary>
        public string P_ACCION { get; set; }        
    }
}
