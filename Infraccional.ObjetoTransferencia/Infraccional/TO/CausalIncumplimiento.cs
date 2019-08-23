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
    /// Descripcion: Clase que representa un usuario relacionado al acta.
    /// </summary>
    [Table(Name = "SS_MAE_FIS_CAUSAL_INCUMPLIMIENTO")]
    public class CausalIncumplimiento
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "CAU_ID")]
        public int IdCausalIncumplimiento { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        ///  [Key]
        [Column(Name = "CAU_DESCRIPCION")]
        public string NombreCausalIncumplimiento { get; set; }

    }
}
