using Infraccional.Negocio.Infraccional.Composite;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using SerializeStrategy.Clases;
using Infraccional.ObjetoTransferencia.Infraccional.Objetos;
using ServicioInfraccional.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.SerializeStrategy.Contexto;
using log4net;
using System.Reflection;
using System.Configuration;

namespace ServicioInfraccional.Negocio
{
    /// <summary>
    /// Descripcion: Factoria de entidad que permite la comunicacion con el negocio infraccional.
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
    /// 1.0 01/08/2017 Mario Huerta Silva : Version Inicial.
    ///
    public class FactoriaEntidad
    {
        /// <summary>
        /// Log
        /// </summary>
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Composite de negocio infraccional.
        /// </summary>
        private InfraccionalComposite _infraccionalComposite;
        /// <summary>
        /// Contexto serializador de JSON.
        /// </summary>
        private ContextSerialize<BaseJsonSerializer> _contextoSerializacion;

        /// <summary>
        /// Constructor de factoria entidad.
        /// </summary>
        public FactoriaEntidad()
        {
            _infraccionalComposite = new InfraccionalComposite();
            _contextoSerializacion = new ContextSerialize<BaseJsonSerializer>();
        }

        /// <summary>
        /// Metodo que permite realizar consulta de actas.
        /// </summary>
        /// <param name="request">Infraccional Request.</param>
        /// <returns></returns>
        public InfraccionalResponse InfraccionalRead(InfraccionalRequest request)
        {
            log.Info("Inicio del metodo InfraccionalRead");
            List<_ActaDenunciaCitacion> Actas = new List<_ActaDenunciaCitacion>();
            List<ActaDenunciaCitacion> actas = new List<ActaDenunciaCitacion>();
            List<ActaDenunciaCitacion> Bitacoras = new List<ActaDenunciaCitacion>();
            List<ActaDenunciaCitacion> bitacoras = new List<ActaDenunciaCitacion>();
            List<Incumplimiento> incumplimientos = new List<Incumplimiento>();

            InfraccionalResponse respuesta = new InfraccionalResponse();
            _ActaDenunciaCitacion actasCitacion = new _ActaDenunciaCitacion();

            List<ADCHito> hitos = new List<ADCHito>();
            _ADCEstado EstadosADC = new _ADCEstado();
            

            // crud mantenedores
            try
            {
                if (!string.IsNullOrEmpty(request.TipoADC))
                {
                    
                    // TIPO ADC = 1 (Traigo todas las Actas)
                    if (request.TipoADC == "1")
                    {
                        log.Info("Tipo ADC =" + request.TipoADC);
                        if (!string.IsNullOrEmpty(request.Json))
                        {

                            var Parametros = _contextoSerializacion.Deserializar<ParametrosADC>(request.Json);

                            if (!string.IsNullOrEmpty(Parametros.NumeroFiscalizacion))
                            {
                                // Obtencion de fiscalizacion desde el sistema de fiscalizacion
                                ActaDenunciaCitacionDetalle fisca = _infraccionalComposite.InfraccionalNegocio.ObtenerADCdetalleSegunFiscalizacion(Parametros.NumeroFiscalizacion).First();

                                actas = _infraccionalComposite.InfraccionalNegocio.ObtenerActasSegunFiscalizacion(Parametros.NumeroFiscalizacion);

                                incumplimientos = _infraccionalComposite.FiscalizacionNegocio.ObtenerIncumplimientos(fisca.idchecklist.ToString());

                                foreach (var _actas in actas)
                                {
                                    actasCitacion = new _ActaDenunciaCitacion()
                                    {

                                        IdADC = _actas.ADC_ID,
                                        NroExpedienteRol = (int)_actas.Rol,
                                        FechaAudiencia = _actas.ADC_FECHA_AUDIENCIA,
                                        FechaDenuncia = _actas.ADC_FECHA_DENUNCIA,
                                        NumeroFiscalizacion = Parametros.NumeroFiscalizacion,
                                        Usuario = new _Usuario()
                                        {
                                            RutUsuario = _actas.usuario.Login,
                                            NombreUsuario = _actas.usuario.Nombre,
                                            //Oficina = _actas.usuario.Oficina 
                                            Oficina = new _Oficina()
                                            {
                                                IdOficina = fisca.idOficina,
                                                NombreOficina = fisca.descOficina
                                            }

                                        },
                                        NegocioFiscalizacion = (_actas.NegocioFiscalizacion != null) ?  new _NegocioFiscalizacion()
                                        {
                                            FiscalizacionPDF = new _NegocioFiscalizacionAdjuntos()
                                            {
                                                //IdNegocioFiscaAdjunto = (_actas.NegocioFiscalizacion.negocioFiscalizacionAdjunto.IdNegocioFiscaAdjunto != null) ? _actas.NegocioFiscalizacion.negocioFiscalizacionAdjunto.IdNegocioFiscaAdjunto : 0,
                                                NombrePDF = (fisca.urlAdc != null) ? ConfigurationManager.AppSettings["UrlDescargaFiscalizacion"] + fisca.urlAdc : null
                                            }
                                        } : null,
                                        Incumplimientos = incumplimientos.Select(x => new _Incumplimiento
                                        {
                                            Identificador = x.Identificador,
                                            Opcion = new _Opcion { Identificador = x.Opcion.Identificador, Descripcion = x.Opcion.Descripcion },
                                            Pregunta = new _Pregunta { Identificador = x.Pregunta.Identificador, Descripcion = x.Pregunta.Descripcion }
                                        }).ToList()
                                    };

                                    Actas.Add(actasCitacion);
                                }

                                 if (Actas.Count > 0)
                                {
                                    respuesta.CodigoRespuesta = "SUCCESS_LIST";
                                    respuesta.Mensaje = "Actas de denuncia exitosas";
                                    string json = _contextoSerializacion.Serializar(Actas);
                                    respuesta.Json = json;
                                }

                                else
                                {
                                    return respuesta = Respuesta.RespuestaPersonalizado("Debe Ingresar Número de Fiscalización!", "ERROR_LIST");
                                }
                            }
                            else
                            {
                                return respuesta = Respuesta.RespuestaPersonalizado("Debe Ingresar Número de Fiscalización!", "ERROR_LIST");
                            }
                        }

                        else
                        {
                            return respuesta = Respuesta.RespuestaPersonalizado("Debe Validar los Vaores en el JSON!", "ERROR_LIST");
                        }

                    }
                    // TIPO ADC = 2 (Traigo las Bitacoras)
                    else if (request.TipoADC == "2")
                    {
                        if (!string.IsNullOrEmpty(request.Json))
                        {
                            var paramBitacora = _contextoSerializacion.Deserializar<ParametrosADC>(request.Json);

                            bitacoras = _infraccionalComposite.InfraccionalNegocio.ObtenerBistacorasSegunFiscalizacion(paramBitacora.NumeroADC);

                            foreach (var _bitacoras in bitacoras)
                            {
                                actasCitacion = new _ActaDenunciaCitacion()
                                {
                                    IdADC = _bitacoras.ADC_ID,
                                    NumeroFiscalizacion = _bitacoras.ADC_NRO_FISCALIZACION,

                                    ActaDenunciaCItacionHistorico = new _ActaDenunciaCItacionHistorico()
                                    {
                                        IdADCHistorico = _bitacoras.ActaDenunciaCItacionHistorico.CodigoResolucion,
                                        NumeroResolucion = _bitacoras.ActaDenunciaCItacionHistorico.NumeroResolucion,
                                        Observacion = _bitacoras.ActaDenunciaCItacionHistorico.ObservacionResolucion,
                                        ADCResolucion = new _ADCResolucion()
                                        {
                                            Fecha = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.Fecha,
                                            FechaSistema = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.FechaSistema,
                                            HoraSistema = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.FechaSistema.Hour.ToString()
                                        }
                                    },
                                    Proceso = new _Proceso()
                                    {
                                        IdProceso = _bitacoras.Proceso.IdProceso,
                                        NombreProceso = _bitacoras.Proceso.NombreProceso
                                    },
                                    Usuario = new _Usuario()
                                    {
                                        RutUsuario = _bitacoras.usuario.Identificador,
                                        NombreUsuario = _bitacoras.usuario.Nombre
                                    }

                                };
                                Bitacoras.Add(_bitacoras);
                            }

                            if (Bitacoras.Count > 0)
                            {
                                respuesta.CodigoRespuesta = "SUCCESS_LIST";
                                respuesta.Mensaje = "Bitacoras exitosas";
                                string json = _contextoSerializacion.Serializar(Bitacoras);
                                respuesta.Json = json;
                            }
                            else
                            {
                                respuesta.CodigoRespuesta = "ERROR_LIST";
                                respuesta.Mensaje = "Error al obtener las Bitacoras.";
                            }

                        }
                        else
                        {
                            return respuesta = Respuesta.RespuestaPersonalizado("Debe Ingresar Valores en el Tipo ADC!", "ERROR_LIST");
                        }
                    }
                    // TIPO ADC = 3 (Traigo los Hitos y detalles)
                    else if (request.TipoADC == "3")
                    {

                        if (!string.IsNullOrEmpty(request.Json))
                        {
                            var Parametros = _contextoSerializacion.Deserializar<ParametrosADC>(request.Json);

                            if (!string.IsNullOrEmpty(Parametros.NumeroADC))
                            {
                                hitos = _infraccionalComposite.InfraccionalNegocio.ObtenerADCdetalleSegunNumeroADC(Parametros.NumeroADC);
                                respuesta.CodigoRespuesta = "SUCCESS_LIST";
                                respuesta.Mensaje = "Lista Hitos Exitosa";
                                string json = _contextoSerializacion.Serializar(hitos);

                                respuesta.Json = json;
                            }

                            else
                            {
                                return respuesta = Respuesta.RespuestaPersonalizado("Debe Ingresar Número de ADC!", "ERROR_LIST");
                            }
                        }
                        else
                        {
                            return respuesta = Respuesta.RespuestaPersonalizado("Debe Validar los Vaores en el JSON!", "ERROR_LIST");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo que permite crear una nueva Acta de Denuncia y Citacion.
        /// </summary>
        /// <param name="request">Infracccional Request.</param>
        /// <returns></returns>
        public InfraccionalResponse InfraccionalCreate(InfraccionalRequest request)
        {
            ActaDenunciaCitacionTO actaDenuncia = null;
            InfraccionalResponse respuesta = new InfraccionalResponse();
            int registro = 0;

            try
            {
                if (!string.IsNullOrEmpty(request.Json))
                {
                    actaDenuncia = _contextoSerializacion.Deserializar<ActaDenunciaCitacionTO>(request.Json);

                    if (actaDenuncia != null)
                    {
                        registro = _infraccionalComposite.InfraccionalNegocio.RegistrarActaDenunciaCitacion(actaDenuncia);

                        if (registro > 0)
                        {
                            respuesta = Respuesta.RespuestaPersonalizado("Acta registrada existoamente", "SUCCESS_INSERT");
                        }
                    }
                }
                else
                {
                    respuesta = Respuesta.RespuestaPersonalizado("Para crear una Acta de Denuncia y Citacion debe enviar la entidad", "ERROR_PARAM");
                }
            }
            catch (Exception ex)
            {
                respuesta = Respuesta.RespuestaPersonalizado("Error al realizar insercion: " + ex.Message, "ERROR_INSERT");
            }

            return respuesta;
        }


    }
}