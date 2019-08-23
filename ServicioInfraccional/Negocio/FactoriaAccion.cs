using log4net;
using ServicioInfraccional.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ServicioInfraccional.Negocio
{
    /// <summary>
    /// Descripcion: Factoria de acciones que permite la comunicacion con el negocio infraccional.
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
    public class FactoriaAccion
    {
        /// <summary>
        /// Log
        /// </summary>
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Factoria Entidad.
        /// </summary>
        private FactoriaEntidad _factoriaEntidad = new FactoriaEntidad();

        /// <summary>
        /// Constructor factoria accion.
        /// </summary>
        public FactoriaAccion()
        {
            _factoriaEntidad = new FactoriaEntidad();
        }
        
        /// <summary>
        /// Metodo que obtiene las actas de denuncia.
        /// </summary>
        /// <param name="request">Infraccional Request.</param>
        /// <returns></returns>
        public InfraccionalResponse GetPrincipal(InfraccionalRequest request)
        {
            log.Info("Inicio de metodo GetPrincipal");
            InfraccionalResponse respuesta = new InfraccionalResponse();

            log.Info("Llamada a GetEntidad");
            respuesta = GetEntidad(request);
            log.InfoFormat("Respuesta de la entidad: {0}, {1}, {2}", respuesta.CodigoRespuesta, respuesta.Json, respuesta.Mensaje);
            return respuesta;
        }
        
        /// <summary>
        /// Metodo que obtiene la entidad de acta de denuncia.
        /// </summary>
        /// <param name="request">Infraccional Request.</param>
        /// <returns></returns>
        private InfraccionalResponse GetEntidad(InfraccionalRequest request)
        {
            log.Info("Inicio de metodo GetEntidad");
            InfraccionalResponse respuesta = new InfraccionalResponse();

            log.Info("Llamada a los tipos de metodos");
            if (request.Accion == "read") respuesta = _factoriaEntidad.InfraccionalRead(request);
            else if (request.Accion == "create") respuesta = _factoriaEntidad.InfraccionalCreate(request);
            else return Respuesta.RespuestaCRUDInvalido();
            log.InfoFormat("Respuesta de la entidad: {0}, {1}, {2}", respuesta.CodigoRespuesta, respuesta.Json, respuesta.Mensaje);
            return respuesta;
        }
    }
}