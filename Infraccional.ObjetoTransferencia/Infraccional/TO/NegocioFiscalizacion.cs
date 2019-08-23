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
    [Table(Name = "ss_neg_fiscalizacion")]
    public class NegocioFiscalizacion
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "fis_id")]
        public int IdNegocioFisca { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        public NegocioFiscalizacionAdjuntos negocioFiscalizacionAdjunto { get; set; }
    }
}
