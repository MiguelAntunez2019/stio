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
    [Table(Name = "SS_NEG_ADC")]
    public class ActaDenunciaCitacion
    {
        /// <summary>
        /// Representa el identificador de la acta.
        /// </summary>
        [Key]
        [Column(Name = "ADC_ID")]
        public int ADC_ID { get; set; }
        /// <summary>
        /// Representa el identificador del sistema.
        /// </summary>
        [Column(Name = "ADC_SISTEMA_ID")]
        public int Sistema { get; set; }     
        /// <summary>
        /// Representa la entidad fiscalizadora.
        /// </summary>
        [Column(Name = "ADC_COD_ENTIDAD")]
        public int EntidadFiscalizadora { get; set; }
        /// <summary>
        /// Representa el rol del acta.
        /// </summary>
        [Column(Name = "ADC_ROL")]
        public double Rol { get; set; }
        /// <summary>
        /// Representa el numero del acta.
        /// </summary>
        [Column(Name = "ADC_NUMERO")]
        public double Numero { get; set; }
        /// <summary>
        /// Representa la fecha de la audencia.
        /// </summary>
        [Column(Name = "ADC_FECHA_AUDIENCIA")]
        public DateTime ADC_FECHA_AUDIENCIA { get; set; }
        /// <summary>
        /// Representa el usuario que inicio el acta.
        /// </summary>
        [Column(Name = "ADC_USUARIO_CREADOR")]
        public string UsuarioCreador { get; set; }
               /// <summary>
        /// Representa el rut del inspecto.
        /// </summary>
        [Column(Name = "ADC_RUT_INSPECTOR")]
        public int Inspector { get; set; }
            /// <summary>
        /// Representa la ofocina del usuario.
        /// </summary>
        [Column(Name = "ADC_OFICINA_USUARIO")]
        public int OficinaUsuario { get; set; }
        /// <summary>
        /// Representa la fecha de ingreso del acta
        /// </summary>
        [Column(Name = "ADC_FECHA_INGRESO")]
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Representa la fecha de denuncia.
        /// </summary>
        [Column(Name = "ADC_FECHA_DENUNCIA")]
        public DateTime ADC_FECHA_DENUNCIA { get; set; }
        /// <summary>
        /// Represena el numero de la fiscalizacion.
        /// </summary>
        [Column(Name = "ADC_NRO_FISCALIZACION")]
        public string ADC_NRO_FISCALIZACION { get; set; }
        /// <summary>
        /// Representa la lista de incumplimientos asociadas a una fiscalizacion.
        /// </summary>
        public List<Incumplimiento> Incumplimientos { get; set; }

        public Usuario usuario { get; set;  }

        public ActaDenunciaCItacionHistorico ActaDenunciaCItacionHistorico { get; set;  }
        public NegocioFiscalizacion NegocioFiscalizacion { get; set; }

        public CausalIncumplimiento CausaIncumplimiento { get; set; }

        public Proceso Proceso { get; set; }
        /// <summary>
        /// Representa el Infractor del acta.
        /// </summary>
       public Infractor Infractor { get; set; }


    }
}
