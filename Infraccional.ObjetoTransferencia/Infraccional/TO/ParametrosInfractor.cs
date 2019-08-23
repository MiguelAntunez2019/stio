using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    /// <summary>
    /// Descripcion: Clase que representa un acta de denuncia y citacion en procedimiento de almacenado.
    /// </summary>
    public class ParametrosInfractor
    {
        /// <summary>
        /// Representa el identificador del infractor.
        /// </summary>
        public int P_ADC_COD_INFRACTOR { get; set; }
        /// <summary>
        /// Representa el nombre del infractor.
        /// </summary>
        public string P_ADC_NOMBRES { get; set; }
        /// <summary>
        /// Representa el apellido paterno del infractor.
        /// </summary>        
        public string P_ADC_APELLIDO_PAT { get; set; }
        /// <summary>
        /// Representa el apellido materno del infractor.
        /// </summary>        
        public string P_ADC_APELLIDO_MAT { get; set; }
        /// <summary>
        /// Representa el tipo de identificacion.
        /// </summary>        
        public int P_ADC_TIPO_ID { get; set; }
        /// <summary>
        /// Representa la identificacion del infractor.
        /// </summary>
        public string P_ADC_IDENTIFICACION { get; set; }
        /// <summary>
        /// Representa el tipo de persona del infractor.
        /// </summary>
        public int P_ADC_TIPO_PERSONA { get; set; }
        /// <summary>
        /// Representa la direccion del infractor.
        /// </summary>
        public string P_ADC_DOMICILIO { get; set; }
        /// <summary>
        /// Representa el genero del infractor.
        /// </summary>
        public Nullable<char> P_ADC_GENERO { get; set; }
        /// <summary>
        /// Representa la actividad del infractor.
        /// </summary>
        public Nullable<int> P_ADC_COD_ACTIVIDAD { get; set; }
        /// <summary>
        /// Representa el codigo del pais.
        /// </summary>
        public Nullable<int> P_ADC_COD_PAIS { get; set; }
        /// <summary>
        /// Representa el codigo de comuna.
        /// </summary>
        public string P_ADC_COD_COMUNA { get; set; }
        /// <summary>
        /// Representa el telefono.
        /// </summary>
        public string P_ADC_FONO { get; set; }
        /// <summary>
        /// Representa el correo electronico.
        /// </summary>
        public string P_ADC_EMAIL { get; set; }
        /// <summary>
        /// Representa el direccion postal.
        /// </summary>
        public string P_ADC_DIR_POSTAL { get; set; }
        /// <summary>
        /// Representa el rut del representante legal.
        /// </summary>
        public string P_IFR_REP_LEG_RUT { get; set; }
        /// <summary>
        /// Representa el nombre del representante.
        /// </summary>
        public string P_IFR_REP_LEG_NOM { get; set; }
        /// <summary>
        /// Representa el salida de procedimiento.
        /// </summary>
        public int P_MAX_INFRACTOR { get; set; }
    }
}
