using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    [Table(Name = "SS_NEG_ADC_RESOLUCION")]
    public class ADCResolucion
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "ADR_ID")]
        public int IdResolucion { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        [Column(Name = "ADR_Fecha")]
        public DateTime Fecha { get; set; }

        [Column(Name = "ADR_FECHA_SIS")]
        public DateTime FechaSistema { get; set; }

        public ActaDenunciaCItacionHistorico ActaDenunciaCItacionHistorico { get; set; }

    }
}
