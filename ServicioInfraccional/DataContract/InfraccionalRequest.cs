using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioInfraccional.DataContract
{
    /// <summary>
    /// Descripcion: Clase que representa un request de servicio infraccional
    /// </summary>
    [DataContract(Namespace = "http://sag.transversal.cl")]
    public class InfraccionalRequest
    {
        /// <summary>
        /// Representa la accion a realizar, read o create.
        /// </summary>
        [DataMember]
        public string Accion { get; set; }
        /// <summary>
        /// Representa los parametros que recibiran para la accion.
        /// </summary>
        [DataMember]
        public string Json { get; set; }

        [DataMember]
        public string TipoADC { get; set; }
    }
}