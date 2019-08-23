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
    public class ActaDenunciaProcedimiento
    {
        /// <summary>
        /// Representa el identificador de la acta.
        /// </summary>        
        public int P_ADC_ID { get; set; }
        /// <summary>
        /// Representa el identificador del sistema.
        /// </summary>        
        public int P_ADC_SISTEMA_ID { get; set; }
        /// <summary>
        /// Representa el tipo de proceso de la acta.
        /// </summary>        
        public int P_ADC_TIPO_PROCESO { get; set; }
        /// <summary>
        /// Representa la entidad fiscalizadora.
        /// </summary>        
        public int P_ADC_COD_ENTIDAD { get; set; }
        /// <summary>
        /// Representa el rol del acta.
        /// </summary>        
        public double P_ADC_ROL { get; set; }
        /// <summary>
        /// Representa el numero del acta.
        /// </summary>        
        public double P_ADC_NUMERO { get; set; }
        /// <summary>
        /// Representa la fecha de la audencia.
        /// </summary>        
        public DateTime P_ADC_FECHA_AUDIENCIA { get; set; }
        /// <summary>
        /// Representa el usuario que inicio el acta.
        /// </summary>        
        public string P_ADC_USUARIO { get; set; }
        /// <summary>
        /// Representa el identificador de la submaterio.
        /// </summary>        
        public int P_ADC_ID_SUBMATERIA { get; set; }
        /// <summary>
        /// Representa el rut del inspecto.
        /// </summary>        
        public int P_ADC_RUT_INSPECTOR { get; set; }
        /// <summary>
        /// Representa la ofocina del usuario.
        /// </summary>        
        public int P_ADC_OFICINA_USUARIO { get; set; }
        /// <summary>
        /// Representa la fecha de ingreso del acta
        /// </summary>        
        public DateTime P_ADC_FECHA_INGRESO { get; set; }
        /// <summary>
        /// Representa la fecha de denuncia.
        /// </summary>        
        public DateTime P_ADC_FECHA_DENUNCIA { get; set; }
        /// <summary>
        /// Represena el numero de la fiscalizacion.
        /// </summary>        
        public string P_ADC_NRO_FISCALIZACION { get; set; }
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
        /// Representa el tipo de persona del infractor.
        /// </summary>
        public int P_ADC_TIPO_PERSONA { get; set; }
        /// <summary>
        /// Representa la direccion del infractor.
        /// </summary>
        public string P_ADC_DOMICILIO { get; set; }
        /// <summary>
        /// Representa la identificacion del infractor.
        /// </summary>
        public string P_ADC_IDENTIFICACION { get; set; }
        /// <summary>
        /// Representa el identificador de la fiscalizacion.
        /// </summary>
        public Nullable<int> P_ADC_FIN_ID { get; set; }
        /// <summary>
        /// Representa el proceso de la fiscalizacion.
        /// </summary>
        public char P_ADC_PROCESO_FIN { get; set; }
        /// <summary>
        /// Representa el rut del sustanciador.
        /// </summary>
        public Nullable<int> P_ADC_RUT_SUSTANCIADOR { get; set; }
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

    }
}
