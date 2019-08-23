using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioInfraccional.DataContract
{
    /// <summary>
    /// Descripcion: Clase que representa los filtros para obtener ADC.
    /// </summary>
    public class ParametrosADC
    {
        /// <summary>
        /// Representa el filtro por rut.
        /// </summary>
        public string NumeroADC { get; set; }
        public string NumeroFiscalizacion { get; set; }

    }
}