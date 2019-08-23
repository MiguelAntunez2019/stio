using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    [Table(Name = "SS_MAE_PROCESO")]
    public class Proceso
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "PCS_COD_PROCESO")]
        public int IdProceso { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        [Column(Name = "PCS_DES_PROCESO")]
        public string NombreProceso { get; set; }
        
    }
}
