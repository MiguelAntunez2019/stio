using Infraccional.Negocio.Infraccional.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using Clientes.AccesoDatos.AccesoDatos;
using System.Transactions;
using Infraccional.Negocio.Clases;
using System.Reflection;
using log4net;
using Infraccional.ObjetoTransferencia.Infraccional.Objetos;
using SerializeStrategy.Clases;
using Util.SerializeStrategy.Contexto;

namespace Infraccional.Negocio.Infraccional.Negocio.Clases
{
    /// <summary>
    /// Descripcion: Clase de negocio que contiene reglas asociadas al negocio infraccional.
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
    [Export(typeof(IInfraccional))]
    class InfraccionalNegocio : IInfraccional
    {
        /// <summary>
        /// Log
        /// </summary>
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Acceso generico.
        /// </summary>
        private AccesoGenerico _daoGenerico;
        /// <summary>
        /// Acceso DUMMY.
        /// </summary>
        private DatosDummy _daoDUMMY;
        /// <summary>
        /// Acceso fiscalización.
        /// </summary>
        private AccesoGenerico _daoFisca;
        /// <summary>
        /// Nombre de la conexion a sancionatorio.
        /// </summary>
        private readonly string CONEXION_SANCIONATORIO = "sancionatorio";
        /// <summary>
        /// Nombre de la conexion a fiscalización.
        /// </summary>
        private readonly string CONEXION_FISCALIZACION = "fiscalizacion";
        /// <summary>
        /// Procedimiento que permite almacenar una Acta de denuncia y citacion.
        /// </summary>
        private readonly string _procedimientoCrearADC = "SP_SS_ACTUALIZAR_ADC";        
        /// <summary>
        /// Procedimiento que permite generar un nuevo rol.
        /// </summary>
        private readonly string _procedimientoTraerRol = "SP_SS_TRAER_ULTIMO_ROL";        
        /// <summary>
        /// Procedimiento que permite generar un ADC.
        /// </summary>
        private readonly string _procedimientoTraerADC = "SP_SS_TRAER_ADC";
        /// <summary>
        /// Procedimiento que permite almacenar o Actualizar un Infractor.
        /// </summary>
        private readonly string _procedimientoCrearInfractor = "SP_SS_ACTUALIZAR_INFRACTOR";
        /// <summary>
        /// Procedimiento que permite almacenar una sub materia.
        /// </summary>
        private readonly string _procedimientoCrearSUBMATERIA = "SP_SS_ACTUALIZAR_ADC_SUBMATERIA"; 

        /// <summary>
        /// Constructor de negocio infraccional.
        /// </summary>
        public InfraccionalNegocio()
        {
            _daoGenerico = new AccesoGenerico(CONEXION_SANCIONATORIO);
            _daoFisca = new AccesoGenerico(CONEXION_FISCALIZACION);
        }

        // Obtener el folio de fiscalizacion desde fiscalizacion
                

        public List<ActaDenunciaCitacion> ObtenerActasSegunFiscalizacion(string NroFiscalizacion)
        {
            log.InfoFormat("Metodo ObtenerActasSegunFiscalizacion, Parametro: {0}", NroFiscalizacion);

            // Obtencion de fiscalizacion desde el sistema de fiscalizacion
            //ActaDenunciaCitacionDetalle fisca = ObtenerADCdetalleSegunFiscalizacion(idFiscalizacion).First();



            List<ActaDenunciaCitacion> actas = new List<ActaDenunciaCitacion>();
            List<Incumplimiento> incumplimientos = new List<Incumplimiento>();
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };

            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, opciones))
            {
                try
                {
                    log.Info("Inicia busqueda de actas");
                    string QueryFiscalizacion = string.Format(@"select 
		                                                             ADC.ADC_ID
	                                                               , ADC.ADC_NRO_FISCALIZACION 
	                                                               , ADC.ADC_NRO_FISCALIZACION 
	                                                               , ADC.ADC_FECHA_DENUNCIA 
	                                                               , ADC.ADC_FECHA_AUDIENCIA 
	                                                                , ADC.ADC_ROL  AS Rol
                                                                    , SNFIS.fis_id
                                                                    , SNFISA.fia_id  as IdNegocioFiscaAdjunto
                                                                    , SNFISA.FIA_ARC_NOMBRE  as NombrePDF                                                                    
                                                                    , USU.USR_RUT as Identificador
                                                                    , USR_NOMBRE as Nombre
                                                                    , OFI.ID_OFICINA as IdOficina
                                                                    , OFI.NOMBRE_OFICINA as NombreOficina 
                                                                    from  [SS_NEG_ADC] AS ADC
                                                                    INNER JOIN [SS_ADM_USUARIOS] AS USU ON ADC.ADC_RUT_INSPECTOR = USU.USR_RUT
                                                                    INNER JOIN [SS_MAE_OFICINA] AS OFI ON USU.USR_COD_OFICINA = OFI.ID_OFICINA
                                                                    LEFT JOIN ss_neg_fiscalizacion AS SNFIS  ON ADC.ADC_NRO_FISCALIZACION = SNFIS.FIS_NUMERO
                                                                    LEFT JOIN SS_NEG_FIS_ADJUNTOS AS SNFISA ON SNFIS.FIS_ID = SNFISA.FIA_FIS_ID
                                                                    WHERE( ADC.ADC_NRO_FISCALIZACION = CASE '{0}' WHEN  ' ' THEN ADC.ADC_NRO_FISCALIZACION ELSE '{0}' END)", NroFiscalizacion);

                    actas = _daoGenerico.ObtenerActasSegunIdFiscalizacion(QueryFiscalizacion);
                    trans.Complete();
                    log.Info("Busqueda completada");

                }
                catch (Exception ex)
                {
                    log.InfoFormat("Error en la busqueda: {0}", ex.Message);
                    trans.Dispose();
                    throw ex;
                }
            }

            return actas;
        }

        public List<ADCResolucion> ObtenerADCResolucion(string IdentificadorADC)
        {
            log.InfoFormat("Metodo ObtenerADCResolucion, Parametro: {0}", IdentificadorADC);
            List<ADCResolucion> ADCResolucion = new List<ADCResolucion>();
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, opciones))
            {
                try
                {
                    log.Info("Inicio de busqueda resoluciones.");
                    string QueryBitacoras = string.Format(@" SELECT  		                                                             
		                                                              SNAR.ADR_ID
		                                                            , SNAR.ADR_FECHA_SIS

		                                                            , ADH.ADH_COD    as CodigoResolucion
		                                                            , ADH.ADH_NUM_RESOLUCION as NumeroResolucion
		                                                            , ADH.ADH_OBSERVACION as ObservacionResolucion
                                                                    , ADH.ADH_RUT_USUARIO
	
                                                            FROM [SS_NEG_ADC] AS ADC
                                                            INNER JOIN SS_MAE_PROCESO        AS SMP ON ADC.ADC_TIPO_PROCESO = SMP.PCS_COD_PROCESO
                                                            INNER JOIN SS_ADM_USUARIOS       AS U    ON  ADC.ADC_RUT_SUSTANCIADOR = U.USR_RUT
                                                            INNER JOIN SS_NEG_ADC_RESOLUCION AS SNAR ON U.USR_RUT  = SNAR.ADR_USR_RUT_ACC
                                                            INNER JOIN SS_NEG_ADC_HITO       AS ADH ON ADH.ADH_COD = SNAR.ADR_ADH_COD
                                                            WHERE( ADC.ADC_ID= CASE '{0}' WHEN  ' ' THEN ADC.ADC_ID ELSE '{0}' END)", IdentificadorADC);


                    ADCResolucion = _daoGenerico.ObtenereResolucionADC(QueryBitacoras);
                    trans.Complete();
                    log.Info("Busqueda finalizada.");
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Error al realizar busqueda {0}", ex.Message);
                    trans.Dispose();
                    throw ex;
                }
            }

            return ADCResolucion;
        }

        public List<ActaDenunciaCitacion> ObtenerBistacorasSegunFiscalizacion(string IdentificadorFiscalizacion)
        {

            List<ActaDenunciaCitacion> bitacoras = new List<ActaDenunciaCitacion>();
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, opciones))
            {
                try
                {
                    string QueryBitacoras = string.Format(@"Select A.ADC_ID
				                                                 , A.ADC_NRO_FISCALIZACION 
                                                                , A.ADC_ROL  AS Rol
				                                                 , AH.ADH_COD      as CodigoResolucion  
				                                                 , AH.ADH_NUM_RESOLUCION   as NumeroResolucion
				                                                 , AH.ADH_OBSERVACION as ObservacionResolucion
				                                                 , RE.ADR_ID 
				                                                 , RE.ADR_Fecha as Fecha
				                                                 , RE.ADR_FECHA_SIS as FechaSistema
				                                                 , PRO.PCS_COD_PROCESO as IdProceso
				                                                 , PRO.PCS_DES_PROCESO as NombreProceso
				                                                 , U.USR_RUT as Identificador
				                                                 , U.USR_NOMBRE
	                                                          FROM SS_NEG_ADC A
	                                                          INNER JOIN SS_NEG_ADC_HITO        AS  AH  ON  A.ADC_ID    = AH.ADH_ADC_ID 
	                                                          LEFT JOIN SS_NEG_ADC_RESOLUCION  AS  RE  ON  AH.ADH_COD  = RE.ADR_ADH_COD
                                                              LEFT JOIN SS_MAE_PROCESO         AS PRO  ON  A.ADC_TIPO_PROCESO =    PRO.PCS_COD_PROCESO 
	                                                          LEFT JOIN SS_ADM_USUARIOS        AS  U   ON  A.ADC_USUARIO_CREADOR = U.USR_RUT
                                               
                                                             WHERE( A.ADC_NUMERO= CASE '{0}' WHEN  ' ' THEN A.ADC_NUMERO ELSE '{0}' END)", IdentificadorFiscalizacion);


                    bitacoras = _daoGenerico.ObtenerBitacorasSegunADC(QueryBitacoras);
                    trans.Complete();
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    throw ex;
                }
            }

            return bitacoras;
        }        

        /// <summary>
        /// Metodo que permite registrar actas de denuncia y citacion.
        /// </summary>
        /// <param name="actaDenuncia">Acta de Denuncia y Citación</param>
        /// <returns></returns>
        public int RegistrarActaDenunciaCitacion(ActaDenunciaCitacionTO actaDenuncia)
        {
            int registro = 0;
            ActaDenunciaCitacion actaDenunciaCitacion = null;
            try
            {
                Mapeo map = new Mapeo();
                actaDenunciaCitacion = new ActaDenunciaCitacion();
                
                actaDenunciaCitacion.ADC_FECHA_AUDIENCIA = actaDenuncia.FechaAudiencia;
                actaDenunciaCitacion.ADC_FECHA_DENUNCIA = actaDenuncia.FechaDenuncia;
                actaDenunciaCitacion.FechaIngreso = actaDenuncia.FechaIngreso;
                actaDenunciaCitacion.ADC_NRO_FISCALIZACION = actaDenuncia.NumeroFiscalizacion;  
                actaDenunciaCitacion.Sistema = 7;
                actaDenunciaCitacion.EntidadFiscalizadora = 1;
                //actaDenunciaCitacion.Infractor = actaDenuncia.Infractor;
                //actaDenunciaCitacion.SubMateria = actaDenuncia.SubMateria;
                actaDenunciaCitacion.Numero = actaDenuncia.Numero;

                Usuario usuario = _daoGenerico.Obtener<Usuario>("WHERE USR_EMAIL = '" + actaDenuncia.EmailUsuario + "'");

                if (usuario != null)
                {
                    actaDenunciaCitacion.UsuarioCreador = usuario.Identificador;
                    actaDenunciaCitacion.usuario = usuario;
                }
                else
                {
                    throw new Exception("El usuario con email " + actaDenuncia.EmailUsuario + " no existe en el sistema sancionatorio como inspector fiscalizador");
                    //registro = 0;
                }



                try
                {

                    if (usuario != null && usuario.Oficina > 0)
                        actaDenunciaCitacion.OficinaUsuario = usuario.Oficina;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener información del usuario fiscalizado", ex);
                }

                Usuario inspector = _daoGenerico.Obtener<Usuario>("WHERE USR_EMAIL = '" + actaDenuncia.EmailInspector + "'");

                if (inspector != null)
                {
                    actaDenunciaCitacion.Inspector = Int32.Parse(inspector.Identificador);
                }
                else
                {
                    registro = 0;
                }                

                string regionSancionatorio = map.ObtenerValueRegion(actaDenuncia.Region);
                            
                var rol = _daoGenerico.Ejecutar(new { P_ID_REGION = regionSancionatorio, P_ID_TIPO = 1 }, _procedimientoTraerRol);
                
                if (rol != null)
                {
                    var rolfinal = Convert.ToInt64(rol);
                    var v_Cont = rolfinal.ToString().Substring(4);
                    v_Cont = (Int32.Parse(v_Cont) + 1).ToString();
                    var rolConvertido = DateTime.Now.ToString("yy") + regionSancionatorio + v_Cont;
                    actaDenunciaCitacion.Rol = Convert.ToInt64(rolConvertido);                    
                }                

                int cuenta = _daoGenerico.ObtenerLista<Infractor>("WHERE IFR_IDENTIFICACION = '" + actaDenuncia.Infractor.Identificacion + "'").Count();

                Infractor x = null;
                var infractor = x;

                if (cuenta > 0)
                {
                    infractor = _daoGenerico.ObtenerLista<Infractor>("WHERE IFR_IDENTIFICACION = '" + actaDenuncia.Infractor.Identificacion + "'").First();
                }
                else
                {
                    ParametrosInfractor infraProcedimiento = new ParametrosInfractor()
                    {
                        P_ADC_COD_INFRACTOR = 0,
                        P_ADC_NOMBRES = actaDenuncia.Infractor.Nombre,
                        P_ADC_APELLIDO_PAT = actaDenuncia.Infractor.ApellidoPaterno,
                        P_ADC_APELLIDO_MAT = actaDenuncia.Infractor.ApellidoMaterno,
                        P_ADC_TIPO_ID = actaDenuncia.Infractor.TipoIdentificacion,
                        P_ADC_IDENTIFICACION = actaDenuncia.Infractor.Identificacion,
                        P_ADC_TIPO_PERSONA = actaDenuncia.Infractor.TipoPersona,
                        P_ADC_DOMICILIO = actaDenuncia.Infractor.Direccion,
                        P_ADC_GENERO = (actaDenuncia.Infractor.Genero != null) ? Convert.ToChar(actaDenuncia.Infractor.Genero) : '0',
                        P_ADC_COD_ACTIVIDAD = actaDenuncia.Infractor.Actividad,
                        P_ADC_COD_PAIS = (actaDenuncia.Infractor.Pais != null) ? Convert.ToChar(actaDenuncia.Infractor.Pais) : '0',
                        P_ADC_COD_COMUNA = actaDenuncia.Infractor.Comuna,
                        P_ADC_FONO = (actaDenuncia.Infractor.Fono != null) ? actaDenuncia.Infractor.Fono.ToString() : "",
                        P_ADC_EMAIL = actaDenuncia.Infractor.Email,
                        P_ADC_DIR_POSTAL = actaDenuncia.Infractor.Postal,
                        P_IFR_REP_LEG_RUT = actaDenuncia.Infractor.RutRepresentanteLegal,
                        P_IFR_REP_LEG_NOM = actaDenuncia.Infractor.NombreRepresentanteLegal,
                        P_MAX_INFRACTOR = 0
                    };
                    _daoGenerico.AgregarRegistro(infraProcedimiento, _procedimientoCrearInfractor);
                    infractor = _daoGenerico.ObtenerLista<Infractor>("WHERE IFR_IDENTIFICACION = '" + actaDenuncia.Infractor.Identificacion + "'").First();
                }

                if (infractor != null)
                {
                    actaDenunciaCitacion.Infractor = infractor;
                }
                else
                {
                    actaDenunciaCitacion.Infractor = actaDenuncia.Infractor;
                }

                //// Revisión comuna y pais del infractor.
                string pa = infractor.Pais;
                string co = infractor.Comuna;
                                
                List<ActaDenunciaCitacionDetalle> ADCdetalle = new List<ActaDenunciaCitacionDetalle>();

                try
                {
                    ADCdetalle = ObtenerADCdetalleSegunFiscalizacion(actaDenunciaCitacion.ADC_NRO_FISCALIZACION);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener detalle del ADC desde fiscalización", ex);
                }
               

                

                string sub = ADCdetalle[0].ID_SUB_MATERIA.ToString();
                var submateria = Convert.ToInt32(map.ObtenerValueSubMateria(sub));
                pa = "45";
                co = ADCdetalle[0].idComuna.ToString();
                string folio = ADCdetalle[0].folio;
                co = map.ObtenerValueComuna(co);
                
                if (string.IsNullOrEmpty(co))
                {
                    co = "130101";
                }

                ActaDenunciaProcedimiento actaProcedimiento = new ActaDenunciaProcedimiento()
                {
                    //ADC
                    P_ADC_ID = 0,
                    P_ADC_SISTEMA_ID = actaDenunciaCitacion.Sistema,
                    P_ADC_TIPO_PROCESO = 1,
                    P_ADC_COD_ENTIDAD = actaDenunciaCitacion.EntidadFiscalizadora,
                    P_ADC_ROL = actaDenunciaCitacion.Rol,
                    P_ADC_NUMERO = actaDenunciaCitacion.Numero,
                    P_ADC_FECHA_AUDIENCIA = actaDenunciaCitacion.ADC_FECHA_AUDIENCIA,
                    P_ADC_USUARIO = actaDenunciaCitacion.usuario.Identificador,
                    P_ADC_ID_SUBMATERIA = submateria,
                    P_ADC_FIN_ID = null,
                    P_ADC_PROCESO_FIN = '1',
                    P_ADC_RUT_INSPECTOR = actaDenunciaCitacion.Inspector,
                    P_ADC_RUT_SUSTANCIADOR = null,
                    P_ADC_OFICINA_USUARIO = actaDenunciaCitacion.OficinaUsuario,
                    P_ADC_FECHA_INGRESO = actaDenunciaCitacion.FechaIngreso,
                    P_ADC_FECHA_DENUNCIA = actaDenunciaCitacion.ADC_FECHA_DENUNCIA,
                    P_ADC_NRO_FISCALIZACION = folio,///actaDenunciaCitacion.ADC_NRO_FISCALIZACION,

                // Infractor

                P_ADC_COD_INFRACTOR = actaDenunciaCitacion.Infractor.Identificador,
                    P_ADC_NOMBRES = actaDenunciaCitacion.Infractor.Nombre,
                    P_ADC_APELLIDO_PAT = actaDenunciaCitacion.Infractor.ApellidoPaterno,
                    P_ADC_APELLIDO_MAT = actaDenunciaCitacion.Infractor.ApellidoMaterno,
                    P_ADC_TIPO_ID = actaDenunciaCitacion.Infractor.TipoIdentificacion,
                    P_ADC_IDENTIFICACION = actaDenunciaCitacion.Infractor.Identificacion,
                    P_ADC_TIPO_PERSONA = actaDenunciaCitacion.Infractor.TipoPersona,
                    P_ADC_DOMICILIO = actaDenunciaCitacion.Infractor.Direccion,
                    P_ADC_GENERO = ' ',
                    P_ADC_COD_ACTIVIDAD = null,
                    P_ADC_COD_PAIS = Convert.ToInt32(pa),
                    P_ADC_COD_COMUNA = co,
                    P_ADC_FONO = null,
                    //P_ADC_EMAIL = actaDenunciaCitacion.Infractor.Email,
                    P_ADC_DIR_POSTAL = null,
                    P_IFR_REP_LEG_RUT = ADCdetalle[0].rutRepresentante,
                    P_IFR_REP_LEG_NOM = ADCdetalle[0].nombreRepresentante
                };

                _daoGenerico.AgregarRegistro(actaProcedimiento, _procedimientoCrearADC);
                registro = 1;
                
                ActaDenunciaCitacion adcNuevo = new ActaDenunciaCitacion();
                adcNuevo = _daoGenerico.Obtener<ActaDenunciaCitacion>("WHERE ADC_ROL = '" + actaDenunciaCitacion.Rol + "'");

                ParametrosSubMateria subNueva = new ParametrosSubMateria()
                {
                    P_ASU_ID = 0,
                    P_ASU_ADC_ID = adcNuevo.ADC_ID,
                    P_ASU_SUBMATERIA_ID = submateria,
                    P_ACCION = "I"
                };

                _daoGenerico.AgregarRegistro(subNueva, _procedimientoCrearSUBMATERIA);
            }
            catch (Exception ex)
            {
                registro = 0;
                throw ex;
            }

            return registro;
        }

        public List<ActaDenunciaCitacionDetalle> ObtenerADCdetalleSegunFiscalizacion(string IdentificadorFiscalizacion)
        {
            List<ActaDenunciaCitacionDetalle> detalle = new List<ActaDenunciaCitacionDetalle>();            
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, opciones))
            {
                try
                {
                    string QueryDetalle = string.Format(@"SELECT Convert(varchar(30),A.folio) as folio,
                                                                REG.ID_REGION, 
                                                                REG.REGION_NOMBRE, 
                                                                F.idComuna, 
                                                                COM.COMUNA_NOMBRE, 
                                                                C.ID_SUB_MATERIA, 
                                                                C.NOMBRE_SUB_MATERIA,
                                                                D.ID_MATERIA, 
                                                                D.NOMBRE_MATERIA, 
                                                                E.NOMBRE_AMBITO, 
                                                                E.ID_AMBITO,
                                                                F.idFiscalizacion,
					                                            F.idchecklist,
                                                                EH.rutRepresentante as rutRepresentante ,
		                                                        EH.nombreRepresentante as nombreRepresentante,
					                                            OFi.DESCRIPCION_OFICINA as descOficina,
					                                            OFI.ID_OFICINA as idOficina,
					                                            FO.nombre as urlAdc													 
                                                        FROM ActaFiscalizacion A 
                                                       LEFT JOIN  FiscalizacionDetalle B ON A.id_checklist = B.idChecklist
                                                        LEFT JOIN SUB_MATERIA C ON B.idSubmateria = C.ID_SUB_MATERIA
                                                        LEFT JOIN MATERIA D ON C.ID_MATERIA = D.ID_MATERIA
                                                        LEFT JOIN AMBITO E ON D.ID_AMBITO = E.ID_AMBITO
                                                        LEFT JOIN CheckList F ON A.id_checklist = F.idchecklist
                                                        LEFT JOIN EntidadHist EH ON A.id_checklist = EH.idCheckList
                                                        LEFT JOIN Historica H ON H.aftFolio = A.folio             			
	                                                    LEFT JOIN FISCALIZADOR FIS ON FIS.idFiscalizador = B.idFiscalizador
	
	                                                    LEFT JOIN OFICINA OFI ON OFI.ID_OFICINA = FIS.oficina_sectorial
	                                                    LEFT JOIN COMUNA COM ON COM.ID_COMUNA = OFI.ID_COMUNA -- Comuna
	                                                    LEFT JOIN PROVINCIA PROV ON PROV.ID_PROVINCIA = COM.ID_COMUNA_PROVINCIA -- Provincia
	                                                    LEFT JOIN REGION REG ON REG.ID_REGION = PROV.PROVINCIA_ID_REGION -- Provincia		

	                                                    LEFT JOIN FotoFW FO ON FO.idchecklist = F.idchecklist AND FO.tipoDocumento = 3
                                                        WHERE F.idFiscalizacion = '" + IdentificadorFiscalizacion + "'");
                    //detalle = _daoFisca.ObtenerDetalleFisca(QueryDetalle);
                    detalle = _daoFisca.ObtenerDetalleFisca<ActaDenunciaCitacionDetalle>(QueryDetalle);
                    trans.Complete();
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    throw ex;
                }
            }
            return detalle;
        }


        public List<ADCHito> ObtenerADCdetalleSegunNumeroADC(string FolioADC)
        {
            log.InfoFormat("Metodo ObtenerADCHitos, Parametro: {0}", FolioADC);
            List<ADCHito> Hitos = new List<ADCHito>();
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, opciones))
            {
                try
                {
                    log.Info("Inicio de busqueda Hitos.");
                    string QueryHitos = string.Format(@"select a.ADC_NRO_FISCALIZACION
                                                            ,a.ADC_ID
                                                            ,isnull(convert(bigint,a.ADC_NRO_FISCALIZACION),0) FolioFiscalizacion
                                                            ,convert(int,a.ADC_NUMERO) FolioADC
                                                            ,a.ADC_FECHA_CREACION
                                                            ,a.ADC_FECHA_AUDIENCIA
                                                            ,b.ADH_COD_HITO
                                                            ,c.HIT_DES_HITO
                                                            ,b.ADH_FECHA_HITO
                                                             from [sancionatorio].[dbo].[SS_NEG_ADC] a
                                                            inner join [sancionatorio].[dbo].SS_NEG_ADC_HITO b on a.ADC_ID = b.ADH_ADC_ID
                                                            inner join [sancionatorio].[dbo].[SS_MAE_HITO] c on b.ADH_COD_HITO = c.HIT_COD_HITO
                                                            where (a.ADC_NUMERO =CASE '{0}' WHEN  ' ' THEN a.ADC_ID ELSE '{0}' END)", FolioADC);


                    Hitos = _daoGenerico.ObtenereHitosADC(QueryHitos);
                    var Idfisca = ObtenerFiscaliaciondetalleSegunNumeroADC(FolioADC).FirstOrDefault();

                   if(Idfisca != null)
                    Hitos[0].IdFiscalizacion = Idfisca.idFiscalizacion;

                    trans.Complete();
                    log.Info("Busqueda finalizada.");
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Error al realizar busqueda {0}", ex.Message);
                    trans.Dispose();
                    throw ex;
                }
            }

            return Hitos;
        }

        public List<ActaDenunciaCitacionDetalle> ObtenerFiscaliaciondetalleSegunNumeroADC(string FolioADC)
        {
            List<ActaDenunciaCitacionDetalle> detalle = new List<ActaDenunciaCitacionDetalle>();
            TransactionOptions opciones = new TransactionOptions()
            {
                Timeout = new TimeSpan(0, 5, 0)
            };
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Suppress, opciones))
            {
                try
                {
                    string QueryDetalle = string.Format(@"SELECT Convert(varchar(30),A.folio) as folio,
                                                                REG.ID_REGION, 
                                                                REG.REGION_NOMBRE, 
                                                                F.idComuna, 
                                                                COM.COMUNA_NOMBRE, 
                                                                C.ID_SUB_MATERIA, 
                                                                C.NOMBRE_SUB_MATERIA,
                                                                D.ID_MATERIA, 
                                                                D.NOMBRE_MATERIA, 
                                                                E.NOMBRE_AMBITO, 
                                                                E.ID_AMBITO,
                                                                F.idFiscalizacion,
					                                            F.idchecklist,
                                                                EH.rutRepresentante as rutRepresentante ,
		                                                        EH.nombreRepresentante as nombreRepresentante,
					                                            OFi.DESCRIPCION_OFICINA as descOficina,
					                                            OFI.ID_OFICINA as idOficina,
					                                            FO.nombre as urlAdc									 
                                                        FROM [SKV_SAG].[DBO].ActaFiscalizacion A 
                                                        INNER JOIN [SKV_SAG].[DBO].FiscalizacionDetalle B ON A.id_checklist = B.idChecklist
                                                        INNER JOIN [SKV_SAG].[DBO].SUB_MATERIA C ON B.idSubmateria = C.ID_SUB_MATERIA
                                                        INNER JOIN [SKV_SAG].[DBO].MATERIA D ON C.ID_MATERIA = D.ID_MATERIA
                                                        INNER JOIN [SKV_SAG].[DBO].AMBITO E ON D.ID_AMBITO = E.ID_AMBITO
                                                        INNER JOIN [SKV_SAG].[DBO].CheckList F ON A.id_checklist = F.idchecklist
                                                        INNER JOIN [SKV_SAG].[DBO].EntidadHist EH ON A.id_checklist = EH.idCheckList
                                                        INNER JOIN [SKV_SAG].[DBO].Historica H ON H.aftFolio = A.folio             			
			                                            INNER JOIN [SKV_SAG].[DBO].FISCALIZADOR FIS ON FIS.idFiscalizador = B.idFiscalizador

			                                            INNER JOIN [SKV_SAG].[DBO].OFICINA OFI ON OFI.ID_OFICINA = FIS.oficina_sectorial
			                                            INNER JOIN [SKV_SAG].[DBO].COMUNA COM ON COM.ID_COMUNA = OFI.ID_COMUNA -- Comuna
			                                            INNER JOIN [SKV_SAG].[DBO].PROVINCIA PROV ON PROV.ID_PROVINCIA = COM.ID_COMUNA_PROVINCIA -- Provincia
			                                            INNER JOIN [SKV_SAG].[DBO].REGION REG ON REG.ID_REGION = PROV.PROVINCIA_ID_REGION -- Provincia		

			                                            LEFT JOIN [SKV_SAG].[DBO].FotoFW FO ON FO.idchecklist = F.idchecklist AND FO.tipoDocumento = 3
                                                       WHERE h.adcFolio = '" + FolioADC + "'");
                    //detalle = _daoFisca.ObtenerDetalleFisca(QueryDetalle);
                    detalle = _daoFisca.ObtenerDetalleFisca<ActaDenunciaCitacionDetalle>(QueryDetalle);
                    trans.Complete();
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    throw ex;
                }
            }
            return detalle;
        }

        public string DUMMYObtenerADCdetalleSegunNumeroADC(string FolioADC)
        {
            string lista= "";
            log.InfoFormat("Metodo DUMMY ObtenerADCHitos, Parametro: {0}", FolioADC);
            
            try
            {

                var listObj = new List<ADCHito>();

                var obj = new ADCHito
                {
                    IdFiscalizacion = 23,
                    IdADC = 32222,
                    FolioFiscalizacion = 1,
                    FolioADC = 111111,
                    FechaCreacionADC = DateTime.Now,
                    FechaAudiencia = DateTime.Now
                };

                obj.Estados = new List<_ADCEstado>();
                obj.Estados.Add(new _ADCEstado { IdEstadoSancionatorio = 1, EstadoSancionatorio = "estado 1", FechaActualizacion = DateTime.Now, Orden = 1 });
                obj.Estados.Add(new _ADCEstado { IdEstadoSancionatorio = 33, EstadoSancionatorio = "estado 2", FechaActualizacion = DateTime.Now, Orden = 2 });
                obj.Estados.Add(new _ADCEstado { IdEstadoSancionatorio = 323, EstadoSancionatorio = "estado 3", FechaActualizacion = DateTime.Now, Orden = 3 });


                listObj.Add(obj);

                var _contextoSerializacion = new ContextSerialize<BaseJsonSerializer>();
                lista = _contextoSerializacion.Serializar(listObj);

                log.Info("Busqueda finalizada.");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error al realizar busqueda {0}", ex.Message);
                throw ex;
            }
            return lista;
        }


    }

   
}
