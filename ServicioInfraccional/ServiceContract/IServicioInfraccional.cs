using ServicioInfraccional.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioInfraccional.ServiceContract
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioModuloEspacial" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioInfraccional
    {
        /// <summary>
        /// Metodo que permite obtener fiscalizaciones.
        /// </summary>
        /// <param name="request">Fiscalizacion Request.</param>
        /// <returns></returns>
        [OperationContract]
        InfraccionalResponse GetInfraccional(InfraccionalRequest request);
    }


    

}
