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
    /// Descripcion: Clase que representa un acta de denuncia y citacion.
    /// </summary>
    [Table(Name = "SS_NEG_ADC_HITO")]
    public class ActaDenunciaCItacionHistorico
    {
        /// <summary>
        /// Representa el identificador de la acta.
        /// </summary>
        /// ADH_COD
        [Key]
        [Column(Name = "ADH_COD")]
        public int CodigoResolucion { get; set; }
     
        /// ADH_NUM_RESOLUCION
        [Column(Name = "ADH_NUM_RESOLUCION")]
        public string NumeroResolucion { get; set; }
        /// <summary>
        /// Representa la entidad fiscalizadora.
        /// </summary>
        /// ADH_OBSERVACION
        [Column(Name = "ADH_OBSERVACION")]
        public string ObservacionResolucion { get; set; }
        /// ADH_OBSERVACION
        [Column(Name = "ADH_RUT_USUARIO")]
        public string ADH_RUT_USUARIO { get; set; }

        public ADCResolucion  ADCResolucion { get; set; }

        /// <summary>
        /// Representa el Infractor del acta.
        /// </summary>
        // public MaestroHistorico maestroHistorico { get; set; }
        // public Usuario usuario { get; set; }
        //public ActaDenunciaCitacion ADC { get; set; }
    }
}