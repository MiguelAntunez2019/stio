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
    /// Descripcion: Clase que representa a un infractor relacionado a un acta de denuncia.
    /// </summary>
    [Table(Name = "SS_NEG_INFRACTOR")]
    public class Infractor
    {
        /// <summary>
        /// Representa el identificador del infractor.
        /// </summary>
        [Key]
        [Column(Name = "IFR_COD")]
        public int Identificador { get; set; }
        /// <summary>
        /// Representa el nombre del infractor.
        /// </summary>
        [Column(Name = "IFR_NOMBRES")]
        public string Nombre { get; set; }
        /// <summary>
        /// Representa el apellido paterno del infractor.
        /// </summary>
        [Column(Name = "IFR_APELLIDO_PAT")]
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Representa el apellido materno del infractor.
        /// </summary>
        [Column(Name = "IFR_APELLIDO_MAT")]
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Representa el tipo de identificacion.
        /// </summary>
        [Column(Name = "IFR_TIPO_ID")]
        public int TipoIdentificacion { get; set; }       
        /// <summary>
        /// Representa el tipo de persona del infractor.
        /// </summary>
        [Column(Name = "IFR_TIPO_PERSONA")]
        public int TipoPersona { get; set; }
        /// <summary>
        /// Representa la direccion del infractor.
        /// </summary>
        [Column(Name = "IFR_DOMICILIO")]
        public string Direccion { get; set; }
        /// <summary>
        /// Representa al genero del infractor.
        /// </summary>
        [Column(Name = "IFR_GENERO")]
        public string Genero { get; set; }
        /// <summary>
        /// Comuna del infractor.
        /// </summary>
        [Column(Name = "IFR_COD_COMUNA")]
        public string Comuna { get; set; }
        /// <summary>
        /// Pais del infractor.
        /// </summary>
        [Column(Name = "IFR_COD_PAIS")]
        public string Pais { get; set; }
        /// <summary>
        /// Representa la identificacion del infractor.
        /// </summary>
        [Column(Name = "IFR_IDENTIFICACION")]
        public string Identificacion { get; set; }
        /// <summary>
        /// Representa el correo electronico del infractor.
        /// </summary>
        [Column(Name = "IFR_EMAIL")]
        public string Email { get; set; }
        /// <summary>
        /// Representa la dirección postal del infractor.
        /// </summary>
        [Column(Name = "IFR_DIR_POSTAL")]
        public string Postal { get; set; }
        /// <summary>
        /// Representa el rut del representante legal del infractor.
        /// </summary>
        [Column(Name = "IFR_REP_LEG_RUT")]
        public string RutRepresentanteLegal { get; set; }
        /// <summary>
        /// Representante el nombre del representante legal del infractor.
        /// </summary>
        [Column(Name = "IFR_REP_LEG_NOM")]
        public string NombreRepresentanteLegal { get; set; }
        /// <summary>
        /// Representa a la actividad del infractor.
        /// </summary>
        [Column(Name = "IFR_COD_ACTIVIDAD")]
        public int Actividad { get; set; }
        /// <summary>
        /// Representa telefono del infractor.
        /// </summary>
        [Column(Name = "IFR_FONO")]        
        public string Fono { get; set; }        
    }
}
