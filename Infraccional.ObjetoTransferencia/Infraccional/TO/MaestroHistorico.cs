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
    [Table(Name = "SS_MAE_HITO")]
    public class MaestroHistorico
    {
        /// </summary>
        /// Tabla HIT_COD_HITO
        [Key]
        [Column(Name = "CodigoHistorico")]
        public int CodigoHistorico { get; set; }

        /// </summary>
        /// Tabla HIT_DES_HITO
        [Column(Name = "DescripcionBitacora")]
        public string DescripcionBitacora { get; set; }

        /// </summary>
        /// Tabla HIT_RESOLUCION
        [Column(Name = "Resolucion")]
        public int Resolucion { get; set; }

        /// </summary>
        /// Tabla HIT_CTL_FRONTERIZO
        [Column(Name = "EstadoFronterizo")]
        public int EstadoFronterizo { get; set; }

        /// </summary>
        /// Tabla HIT_DES_HITO
        [Column(Name = "HIT_PAGO")]
        public int HIT_PAGO { get; set; }

        /// </summary>
        /// Tabla HIT_DES_HITO
        [Column(Name = "HIT_FIN")]
        public int HIT_FIN { get; set; }

        /// </summary>
        /// Tabla HIT_DES_HITO
        [Column(Name = "HIT_HIV_COD")]
        public int HIT_HIV_COD { get; set; }

    }
}
