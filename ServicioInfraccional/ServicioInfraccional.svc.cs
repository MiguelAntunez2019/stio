using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicioInfraccional.DataContract;
using ServicioInfraccional.Negocio;
using ServicioInfraccional.ServiceContract;

namespace ServicioInfraccional
{
    /// <summary>
    /// Descripcion: Servicio web que despliega las actas del sistema sancionatorio.
    /// </summary>
    /// 
    /// <remarks>
    /// Derechos Reservados para Servicio Agricola y Ganadero, Departamento de Tecnologias de la Informacion,
    /// Unidad Transversal.
    /// </remarks>
    /// 
    /// Control de versiones:
    /// 
    /// 1.0 01/08/2017 Carlos Chacon Ibacache : Version Inicial. 
    ///

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServicioInfraccional : IServicioInfraccional
    {
        /// <summary>
        /// Factoria de Accion.
        /// </summary>
        private FactoriaAccion _factoriaAccion;

        /// <summary>
        /// Constructor de servicio infraccional.
        /// </summary>
        public ServicioInfraccional()
        {
            _factoriaAccion = new FactoriaAccion();
        }

        /// <summary>
        /// Metodo que permite obtener o crear un Acta de Denuncia y Citacion.
        /// </summary>
        /// <param name="request">Infraccional Request.</param>
        /// <returns></returns>
        public InfraccionalResponse GetInfraccional(InfraccionalRequest request)
        {
            InfraccionalResponse respuesta = null;

            try
            {
                respuesta = _factoriaAccion.GetPrincipal(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;        
        }

       
    }
}
