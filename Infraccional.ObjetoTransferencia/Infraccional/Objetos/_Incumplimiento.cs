using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.Objetos
{
    /// <summary>
    /// Descripcion: Clase de incumplimiento.
    /// </summary>
    public class _Incumplimiento
    {
        /// <summary>
        /// Representa el identificador del incumplimiento
        /// </summary>
        ///
        public int Identificador { get; set; }
        /// <summary>
        /// Representa la opcion elegida para el incumplimiento.
        /// </summary>
        /// 
        public _Opcion Opcion { get; set; }
        /// <summary>
        /// Representa la pregunta realizada para el incumplimiento.
        /// </summary>
        /// 
        public _Pregunta Pregunta { get; set; }
    }
}
