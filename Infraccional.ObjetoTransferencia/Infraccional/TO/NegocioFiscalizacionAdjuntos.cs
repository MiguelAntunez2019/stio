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
    [Table(Name = "SS_NEG_FIS_ADJUNTOS")]
    public class NegocioFiscalizacionAdjuntos
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "fia_id")]
        public int IdNegocioFiscaAdjunto { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        ///  [Key]
        [Column(Name = "FIA_ARC_NOMBRE")]
        public string NombrePDF { get; set; }

    }
}
