using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioInfraccional.DataContract
{
    /// <summary>
    /// Descripcion: Clase que representa una respuesta del servicio infraccional.
    /// </summary>
    [DataContract(Namespace = "http://sag.transversal.cl")]
    public class InfraccionalResponse
    {
        /// <summary>
        /// Representa el mensaje de la respuesta.
        /// </summary>
        [DataMember]
        public string Mensaje { get; set; }
        /// <summary>
        /// Representa la informacion en formato JSON.
        /// </summary>
        [DataMember]
        public string Json { get; set; }
        /// <summary>
        /// Representa el codigo de respuesta.
        /// </summary>
        [DataMember]
        public string CodigoRespuesta { get; set; }

    }
}