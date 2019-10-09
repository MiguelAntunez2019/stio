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
using System.Data.Entity.SqlServer;

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

                                var BDFisca = new fiscalizacionEDM();

                                //Parametros.NumeroFiscalizacion = "1010000138";                              

                                // Con esta consulta trae la información completa desde el sistema de fiscalización
                                var objFisca = BDFisca.Historica.Where(a => a.aftFolio == Parametros.NumeroFiscalizacion).FirstOrDefault();

                                if(objFisca == null)
                                {
                                    respuesta.CodigoRespuesta = "ERROR_LIST";
                                    respuesta.Mensaje = "No se encontró información relacionada al N° de Fiscalización suministrado en el sistema de fiscalización. ["+Parametros.NumeroFiscalizacion+"]";
                                    string json = _contextoSerializacion.Serializar(Actas);
                                    respuesta.Json = json;
                                    return respuesta;
                                }



                                // Con esta consulta trae información de los adjuntos.
                                var fotoADC = BDFisca.FotoFW.Where(a => a.idchecklist == objFisca.idChecklist && a.tipoDocumento == 3).FirstOrDefault();
                              
                                // Obtencion de fiscalizacion desde el sistema de fiscalizacion
                                //ActaDenunciaCitacionDetalle fisca = _infraccionalComposite.InfraccionalNegocio.ObtenerADCdetalleSegunFiscalizacion(Parametros.NumeroFiscalizacion).First();


                                // Si el resultado de la fiscalización es negativo, se debe consultar el ADC
                                if(objFisca.resultadoFiscalizacion == "NO")
                                {
                                    // Obtención de información desde Sancionatorio
                                    actas = _infraccionalComposite.InfraccionalNegocio.ObtenerActasSegunFiscalizacion(objFisca.aftFolio);



                                    incumplimientos = _infraccionalComposite.FiscalizacionNegocio.ObtenerIncumplimientos(objFisca.idChecklist.ToString());

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
                                                    //IdOficina = fisca.idOficina,
                                                    IdOficina = (int)objFisca.idOficina,
                                                    //NombreOficina = fisca.descOficina
                                                    NombreOficina = objFisca.nombreOficina
                                                }

                                            },
                                            NegocioFiscalizacion = (_actas.NegocioFiscalizacion != null) ? new _NegocioFiscalizacion()
                                            {
                                                FiscalizacionPDF = new _NegocioFiscalizacionAdjuntos()
                                                {
                                                    //IdNegocioFiscaAdjunto = (_actas.NegocioFiscalizacion.negocioFiscalizacionAdjunto.IdNegocioFiscaAdjunto != null) ? _actas.NegocioFiscalizacion.negocioFiscalizacionAdjunto.IdNegocioFiscaAdjunto : 0,
                                                    NombrePDF = (fotoADC != null) ? ConfigurationManager.AppSettings["UrlDescargaFiscalizacion"] + fotoADC.nombre : ConfigurationManager.AppSettings["BaseURLFiscalizacion"] + "/Gestion/ADCView?id=" + objFisca.idFiscalizacionDetalle

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
                                }
                                

                                 if (Actas.Count > 0)
                                {
                                    respuesta.CodigoRespuesta = "SUCCESS_LIST";
                                    respuesta.Mensaje = "Actas de denuncia exitosas";
                                    string json = _contextoSerializacion.Serializar(Actas);
                                    respuesta.Json = json;
                                }else if(objFisca.resultadoFiscalizacion == "SI")
                                {
                                    respuesta.CodigoRespuesta = "SUCCESS_LIST";
                                    respuesta.Mensaje = "La fiscalización no cuenta con incumplimientos";
                                    string json = "{}";
                                    respuesta.Json = json;

                                }
                                else
                                {
                                    return respuesta = Respuesta.RespuestaPersonalizado("No existe información de ADC vinculada con el Sistema Infraccional", "ERROR_LIST");
                                }
                            }
                            else
                            {
                                return respuesta = Respuesta.RespuestaPersonalizado("Debe Ingresar Número de Fiscalización!", "ERROR_LIST");
                            }
                        }

                        else
                        {
                            return respuesta = Respuesta.RespuestaPersonalizado("Debe Validar los Valores en el JSON!", "ERROR_LIST");
                        }

                    }
                    // TIPO ADC = 2 (Traigo las Bitacoras)
                    else if (request.TipoADC == "2")
                    {
                        if (!string.IsNullOrEmpty(request.Json))
                        {
                            var paramBitacora = _contextoSerializacion.Deserializar<ParametrosADC>(request.Json);

                            var sancBD = new sancionatorioEDM();

                            var numeroADC = Int32.Parse(paramBitacora.NumeroADC);

                            var bit = sancBD.SS_NEG_ADC_HITO.Where(a => a.ADH_ADC_ID  == numeroADC);



                            var asdf = bit.ToList();

                            bitacoras = _infraccionalComposite.InfraccionalNegocio.ObtenerBistacorasSegunFiscalizacion(paramBitacora.NumeroADC);

                            foreach (var _bitacoras in asdf)
                            {
                                var nuevaActasCitacion = new ActaDenunciaCitacion()
                                {
                                    ADC_ID = _bitacoras.ADH_ADC_ID,
                                    ADC_NRO_FISCALIZACION = _bitacoras.SS_NEG_ADC.ADC_NRO_FISCALIZACION.ToString(),
                                    Sistema = _bitacoras.SS_NEG_ADC.ADC_SISTEMA_ID,
                                    Rol = (double)_bitacoras.SS_NEG_ADC.ADC_ROL,
                                    Numero = 0,
                                    ADC_FECHA_AUDIENCIA = (DateTime)_bitacoras.SS_NEG_ADC.ADC_FECHA_AUDIENCIA,
                                    UsuarioCreador = _bitacoras.SS_NEG_ADC.SS_ADM_USUARIOS.USR_NOMBRE,
                                    Inspector = _bitacoras.SS_NEG_ADC.ADC_RUT_INSPECTOR,
                                    OficinaUsuario = (int)_bitacoras.SS_NEG_ADC.ADC_OFICINA_USUARIO,
                                    FechaIngreso = (DateTime)_bitacoras.SS_NEG_ADC.ADC_FECHA_INGRESO,
                                    ADC_FECHA_DENUNCIA = (DateTime)_bitacoras.SS_NEG_ADC.ADC_FECHA_DENUNCIA,
                                    usuario = new Usuario
                                    {
                                        Identificador = "asdf"
                                    },
                                    ActaDenunciaCItacionHistorico = new ActaDenunciaCItacionHistorico
                                    {
                                        CodigoResolucion = _bitacoras.ADH_COD,
                                        NumeroResolucion = _bitacoras.ADH_NUM_RESOLUCION,
                                        ObservacionResolucion = _bitacoras.ADH_OBSERVACION,
                                        ADH_RUT_USUARIO = _bitacoras.ADH_RUT_USUARIO.ToString(),
                                        ADCResolucion = new ADCResolucion
                                        {
                                            IdResolucion = (_bitacoras.SS_NEG_ADC_RESOLUCION.Count > 0) ? _bitacoras.SS_NEG_ADC_RESOLUCION.First().ADR_ID : 0,
                                            Fecha = (_bitacoras.SS_NEG_ADC_RESOLUCION.Count > 0) ? _bitacoras.SS_NEG_ADC_RESOLUCION.First().ADR_FECHA : new DateTime(),
                                            FechaSistema = (_bitacoras.SS_NEG_ADC_RESOLUCION.Count > 0) ? _bitacoras.SS_NEG_ADC_RESOLUCION.First().ADR_FECHA_SIS : new DateTime(),
                                        },                                        
                                    },
                                    Proceso = new Proceso
                                    {
                                        IdProceso = _bitacoras.SS_NEG_ADC.SS_MAE_PROCESO.PCS_COD_PROCESO,
                                        NombreProceso = _bitacoras.SS_NEG_ADC.SS_MAE_PROCESO.PCS_DES_PROCESO
                                    },
                                    Infractor = new Infractor
                                    {
                                        Identificador = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_COD,
                                        Nombre = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_NOMBRES,
                                        ApellidoPaterno = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_APELLIDO_PAT,
                                        ApellidoMaterno = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_APELLIDO_MAT,
                                        TipoIdentificacion = Int32.Parse(_bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_TIPO_ID),
                                        TipoPersona = Int32.Parse(_bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_TIPO_PERSONA),
                                        Direccion = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_DOMICILIO,
                                        Genero = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_GENERO,
                                        Comuna = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_COD_COMUNA,
                                        Pais = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_COD_PAIS.ToString(),
                                        Identificacion = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_IDENTIFICACION,
                                        Email = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_EMAIL,
                                        Postal = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_DIR_POSTAL,
                                        RutRepresentanteLegal = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_REP_LEG_RUT,
                                        NombreRepresentanteLegal = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_REP_LEG_NOM,
                                        Actividad = (_bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_COD_ACTIVIDAD) ?? 0,
                                        Fono = _bitacoras.SS_NEG_ADC.SS_NEG_INFRACTOR.IFR_FONO
                                    }




                                    //ActaDenunciaCItacionHistorico = new _ActaDenunciaCItacionHistorico()
                                    //{
                                    //    IdADCHistorico = _bitacoras.ActaDenunciaCItacionHistorico.CodigoResolucion,
                                    //    NumeroResolucion = _bitacoras.ActaDenunciaCItacionHistorico.NumeroResolucion,
                                    //    Observacion = _bitacoras.ActaDenunciaCItacionHistorico.ObservacionResolucion,
                                    //    ADCResolucion = new _ADCResolucion()
                                    //    {
                                    //        Fecha = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.Fecha,
                                    //        FechaSistema = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.FechaSistema,
                                    //        HoraSistema = _bitacoras.ActaDenunciaCItacionHistorico.ADCResolucion.FechaSistema.Hour.ToString()
                                    //    }
                                    //},
                                    //Proceso = new _Proceso()
                                    //{
                                    //    IdProceso = _bitacoras.Proceso.IdProceso,
                                    //    NombreProceso = _bitacoras.Proceso.NombreProceso
                                    //},
                                    //Usuario = new _Usuario()
                                    //{
                                    //    RutUsuario = _bitacoras.usuario.Identificador,
                                    //    NombreUsuario = _bitacoras.usuario.Nombre
                                    //}

                                };
                                Bitacoras.Add(nuevaActasCitacion);
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
                            return respuesta = Respuesta.RespuestaPersonalizado("Debe Validar los Valores en el JSON!", "ERROR_LIST");
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
                            respuesta = Respuesta.RespuestaPersonalizado("Acta registrada exitosamente", "SUCCESS_INSERT");
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