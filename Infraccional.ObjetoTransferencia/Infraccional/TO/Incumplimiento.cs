using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    /// <summary>
    /// Descripcion: Clase que representa el incumplimiento asociada a una fiscalizacion.
    /// </summary>
    /// 
    [Serializable]
    [Table(Name = "IncumplimientoHis")]
    public class Incumplimiento
    {
        /// <summary>
        /// Representa el identificador del incumplimiento
        /// </summary>
        ///
        [Key]
        [Column(Name = "idIncumplimientoHis")]
        public int Identificador { get; set; }
        /// <summary>
        /// Representa la opcion elegida para el incumplimiento.
        /// </summary>
        /// 
        public Opcion Opcion { get; set; }
        /// <summary>
        /// Representa la pregunta realizada para el incumplimiento.
        /// </summary>
        /// 
        public Pregunta Pregunta { get; set; }
    }
}
