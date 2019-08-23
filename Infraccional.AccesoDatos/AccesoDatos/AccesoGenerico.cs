using BaseDatosFactoria.Entities;
using BaseDatosFactoria.Factory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System.Data.SqlClient;
using Infraccional.ObjetoTransferencia.Infraccional.Objetos;

namespace Clientes.AccesoDatos.AccesoDatos
{
    /// <summary>
    /// Descripcion: Clase de acceso a datos generico.
    /// </summary>
    /// 
    /// <remarks>
    /// Derechos reservados para unidad transversal, departamento informatica
    /// Servicio agricola y ganadero
    /// </remarks>
    /// 
    /// Control de versiones:
    /// 
    /// 1.0 17/04/2017 Carlos Chacon Ibacache : Version Inicial.
    /// 
    public class AccesoGenerico
    {
        /// <summary>
        /// Nombre de conexion.
        /// </summary>
        private readonly string NombreConexion;

        /// <summary>
        /// Constructor de acceso generico.
        /// </summary>
        /// <param name="nombreConexion"></param>
        public AccesoGenerico(string nombreConexion)
        {
            NombreConexion = nombreConexion;
        }

        /// <summary>
        /// Metodo que permite obtener una lista de entidades.
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="condiciones">Condiciones para filtros.</param>
        /// <returns></returns>
        public T Obtener<T>(string condiciones)
        {
            T clientes = Activator.CreateInstance<T>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        clientes = dbCon.GetList<T>(condiciones).FirstOrDefault(); // .SingleOrDefault();
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return clientes;
        }


        public List<ADCResolucion> ObtenereResolucionADC(string sql)
        {
            List<ADCResolucion> lista = new List<ADCResolucion>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        using (var grid = dbCon.QueryMultiple(sql, null, commandType: CommandType.Text))
                        {
                            //lista = grid.Read<ActaDenunciaCitacion, NegocioFiscalizacion, NegocioFiscalizacionAdjuntos,  Oficina, Usuario, CausalIncumplimiento, ActaDenunciaCitacion>
                            lista = grid.Read<ADCResolucion, ActaDenunciaCItacionHistorico, ADCResolucion>
                               ((_resolusion, _hito) =>
                               {
                                   _resolusion.ActaDenunciaCItacionHistorico = _hito;

                                   return _resolusion;
                               }, splitOn: "ADR_ID, CodigoResolucion").ToList();
                        }
                    }

                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }

        public List<ADCHito> ObtenereHitosADC(string sql)
        {
            List<ADCHito> lista = new List<ADCHito>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (SqlConnection connection = new SqlConnection(db.conexionString))
                {
                    string queryString = sql;

                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    var obj = new ADCHito();
                    int cont = 1;

                    while (reader.Read())
                    {
                        if (cont == 1)
                        {
                            obj.Estados = new List<_ADCEstado>();
                            obj.IdADC = reader.GetInt32(reader.GetOrdinal("ADC_ID"));
                            obj.FolioFiscalizacion = reader.GetInt64(reader.GetOrdinal("FolioFiscalizacion"));
                            obj.FolioADC = reader.GetInt32(reader.GetOrdinal("FolioADC"));
                            obj.FechaCreacionADC = reader.GetDateTime(reader.GetOrdinal("ADC_FECHA_CREACION"));
                            obj.FechaAudiencia = reader.GetDateTime(reader.GetOrdinal("ADC_FECHA_AUDIENCIA"));
                        }
                        
                        obj.Estados.Add(new _ADCEstado {
                            IdEstadoSancionatorio = reader.GetInt32(reader.GetOrdinal("ADH_COD_HITO")),
                            EstadoSancionatorio = reader.GetString(reader.GetOrdinal("HIT_DES_HITO")),
                            FechaActualizacion = reader.GetDateTime(reader.GetOrdinal("ADH_FECHA_HITO")),
                            Orden = cont});
                            cont = cont +1;
                    }

                    lista.Add(obj);
                    reader.Close();
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }

        public List<ActaDenunciaCitacion> ObtenerActasSegunIdFiscalizacion(string sql)
        {
            List<ActaDenunciaCitacion> lista = new List<ActaDenunciaCitacion>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        using (var grid = dbCon.QueryMultiple(sql, null, commandType: CommandType.Text))
                        {
                            //lista = grid.Read<ActaDenunciaCitacion, NegocioFiscalizacion, NegocioFiscalizacionAdjuntos,  Oficina, Usuario, CausalIncumplimiento, ActaDenunciaCitacion>
                            lista = grid.Read<ActaDenunciaCitacion, NegocioFiscalizacion, NegocioFiscalizacionAdjuntos, Usuario, ActaDenunciaCitacion>
                            
                               //    ((_ActaDenunciaCitacion, _NegocioFiscalizacion, _NegocioFiscaAdjunto, _Oficina, _Usuario, _causalImcumplimiento) =>
                               ((_ActaDenunciaCitacion, _NegocioFiscalizacion, _NegocioFiscaAdjunto, _Usuario) =>
                               {
                                   _ActaDenunciaCitacion.NegocioFiscalizacion = _NegocioFiscalizacion;
                                   _ActaDenunciaCitacion.usuario = _Usuario;
                                   _NegocioFiscalizacion.negocioFiscalizacionAdjunto = _NegocioFiscaAdjunto;

                                   return _ActaDenunciaCitacion;
                               }, splitOn: "ADC_ID, fis_id, IdNegocioFiscaAdjunto, Identificador").ToList();
                        }
                    }

                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }



        /// <summary>
        /// Metodo que permite obtener una lista de entidades.
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="condiciones">Condiciones para filtros.</param>
        /// <returns></returns>
        public List<T> ObtenerLista<T>(string condiciones)
        {
            List<T> clientes = Activator.CreateInstance<List<T>>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {

                        clientes = dbCon.GetList<T>(condiciones).ToList();
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return clientes;
        }

        /// <summary>
        /// Metodo que permite obtener una lista de entidades.
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <returns></returns>
        public List<T> ObtenerLista<T>()
        {
            List<T> clientes = Activator.CreateInstance<List<T>>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);

                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {

                        clientes = dbCon.GetList<T>().ToList();


                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return clientes;
        }


        /// <summary>
        /// Metodo que permite obtener una lista de entidades.
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Incumplimiento> ObtenerListaQuery(string query)
        {

            List<Incumplimiento> lista = new List<Incumplimiento>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);

                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {

                        using (var grid = dbCon.QueryMultiple(query, null, commandType: CommandType.Text))
                        {
                            lista = grid.Read<Incumplimiento, Opcion, Pregunta, Incumplimiento>
                                ((incumplimiento, opcion, pregunta) =>
                                {
                                    incumplimiento.Opcion = opcion;
                                    incumplimiento.Pregunta = pregunta;

                                    return incumplimiento;
                                }, splitOn: "Identificador, Identificador, Identificador").ToList();
                        }
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }

        /// <summary>
        /// Metodo que permite agregar un registro
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="objeto">Objeto para agregar.</param>
        public void AgregarRegistro<T>(T objeto)
        {

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        dbCon.Insert(objeto);
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }
        }

        /// <summary>
        /// Metodo que permite agregar un registro
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="objeto">Objeto para agregar.</param>
        /// <param name="procedimientoAlmacenado">Nombre del Procedimiento de Almacenado.</param>
        public void AgregarRegistro<T>(T objeto, string procedimientoAlmacenado)
        {

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        var algo = dbCon.Query<T>(procedimientoAlmacenado, objeto, commandType: CommandType.StoredProcedure);
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }
        }

        /// <summary>
        /// Metodo que permite agregar un registro
        /// </summary>
        /// <param name="objeto">Objeto para agregar.</param>
        /// <param name="procedimientoAlmacenado">Nombre del Procedimiento de Almacenado.</param>
        public object Ejecutar(object objeto, string procedimientoAlmacenado)
        {
            object resultado = null;
            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        resultado = dbCon.ExecuteScalar(procedimientoAlmacenado, objeto, commandType: CommandType.StoredProcedure);
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return resultado;
        }
        /// <summary>
        /// Metodo que permite obtener una lista de elementos distitno al objeto que consulta.
        /// </summary>
        /// <typeparam name="T">Objeto de Retorno.</typeparam>
        /// <param name="sql">Consulta SQL .</param>
        /// <returns></returns>

        //public List<ActaDenunciaCItacionHistorico> ObtenerBitacorasSegunADC(string sql)
        //{
        //    List<ActaDenunciaCItacionHistorico> lista = new List<ActaDenunciaCItacionHistorico>();
        //    try
        //    {
        //        Database db = Factorybase.TraerBasedatos(NombreConexion);
        //        using (IDbConnection dbCon = db.AbrirConexion())
        //        {
        //            try
        //            {
        //                using (var grid = dbCon.QueryMultiple(sql, null, commandType: CommandType.Text))
        //                {
        //                    lista = grid.Read<ActaDenunciaCItacionHistorico, MaestroHistorico, Usuario, ActaDenunciaCitacion, ActaDenunciaCItacionHistorico>

        //                        ((  _ADCHistorico, _maestroHistorico,  _usuario, _ADC) =>
        //                        {

        //                            _ADCHistorico.maestroHistorico = _maestroHistorico;
        //                            _ADCHistorico.usuario = _usuario;
        //                            _ADCHistorico.ADC = _ADC;

        //                            return _ADCHistorico;
        //                        }, splitOn: " ADH_COD , CodigoHistorico , USR_RUT, ADC_ID").ToList();
        //                }
        //            }

        //            finally
        //            {
        //                dbCon.Close();
        //            }
        //        }
        //    }
        //    catch (InvalidCastException icex)
        //    {
        //        throw icex;
        //    }
        //    catch (IndexOutOfRangeException iorex)
        //    {
        //        throw iorex;
        //    }
        //    catch (NullReferenceException nrex)
        //    {
        //        throw nrex;
        //    }
        //    catch (FormatException fex)
        //    {
        //        throw fex;
        //    }
        //    catch (DbException dbex)
        //    {
        //        throw dbex;
        //    }

        //    return lista;
        //}
        public List<ActaDenunciaCitacion> ObtenerBitacorasSegunADC(string sql)
        {
            List<ActaDenunciaCitacion> lista = new List<ActaDenunciaCitacion>();
            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        using (var grid = dbCon.QueryMultiple(sql, null, commandType: CommandType.Text))
                        {
                            lista = grid.Read<ActaDenunciaCitacion, ActaDenunciaCItacionHistorico, ADCResolucion, Proceso, Usuario, ActaDenunciaCitacion>

                                ((_ADC, _ADCHistorico, _resolucion, _proceso, _usuario) =>
                                {
                                    _ADC.ActaDenunciaCItacionHistorico = _ADCHistorico;
                                    _ADCHistorico.ADCResolucion = _resolucion;
                                    _ADC.Proceso = _proceso;
                                    _ADC.usuario = _usuario;


                                    return _ADC;
                                }, splitOn: "ADC_ID, CodigoResolucion, ADR_ID, IdProceso, Identificador").ToList();
                        }
                    }

                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }
        /// <summary>
        /// Metodo que permite actualizar un registro
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="objeto">Objeto para agregar.</param>
        public void ActualizarRegistro<T>(T objeto)
        {
            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        dbCon.Update(objeto);
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }
        }

        /// <summary>
        /// Metodo que permite actualizar un registro
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="objeto">Objeto para agregar.</param>
        /// <param name="procedimientoAlmacenado">Nombre del Procedimiento de Almacenado.</param>
        public void ActualizarRegistro<T>(T objeto, string procedimientoAlmacenado)
        {
            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        dbCon.Query<T>(procedimientoAlmacenado, objeto, commandType: CommandType.StoredProcedure);
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }
        }

        /// <summary>
        /// Metodo que permite obtener una lista de entidades.
        /// </summary>
        /// <typeparam name="T">Entidad.</typeparam>
        /// <param name="condiciones">Condiciones para filtros.</param>
        /// <returns></returns>
        public List<T> ObtenerDetalleFisca<T>(string query)
        {
            List<T> detalles = Activator.CreateInstance<List<T>>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {

                        detalles = dbCon.Query<T>(query).ToList();
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return detalles;
        }

        public List<ActaDenunciaCitacionDetalle> ObtenerDetalleFisca(string sql)
        {
            List<ActaDenunciaCitacionDetalle> lista = new List<ActaDenunciaCitacionDetalle>();

            try
            {
                Database db = Factorybase.TraerBasedatos(NombreConexion);
                using (IDbConnection dbCon = db.AbrirConexion())
                {
                    try
                    {
                        using (var grid = dbCon.QueryMultiple(sql, null, commandType: CommandType.Text))
                        {
                            lista = grid.Read<ActaDenunciaCitacionDetalle, Opcion, ActaDenunciaCitacionDetalle>
                                ((CitacionDetalle, opcion) =>
                                {                                    
                                    CitacionDetalle.ID_REGION = CitacionDetalle.ID_REGION;
                                    CitacionDetalle.REGION_NOMBRE = CitacionDetalle.REGION_NOMBRE;
                                    CitacionDetalle.idComuna = CitacionDetalle.idComuna;
                                    CitacionDetalle.COMUNA_NOMBRE = CitacionDetalle.COMUNA_NOMBRE;
                                    CitacionDetalle.ID_SUB_MATERIA = CitacionDetalle.ID_SUB_MATERIA;
                                    CitacionDetalle.NOMBRE_SUB_MATERIA = CitacionDetalle.NOMBRE_SUB_MATERIA;
                                    CitacionDetalle.ID_MATERIA = CitacionDetalle.ID_MATERIA;
                                    CitacionDetalle.NOMBRE_MATERIA = CitacionDetalle.NOMBRE_MATERIA;
                                    CitacionDetalle.NOMBRE_AMBITO = CitacionDetalle.NOMBRE_AMBITO;
                                    CitacionDetalle.ID_AMBITO = CitacionDetalle.ID_AMBITO;
                                    CitacionDetalle.idFiscalizacion = CitacionDetalle.idFiscalizacion;

                                    return CitacionDetalle;
                                }, splitOn: "ID_REGION, REGION_NOMBRE, idComuna, COMUNA_NOMBRE, ID_SUB_MATERIA, NOMBRE_SUB_MATERIA, ID_MATERIA, NOMBRE_MATERIA, NOMBRE_AMBITO, ID_AMBITO, idFiscalizacion").ToList();
                        }
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }            
            catch (InvalidCastException icex)
            {
                throw icex;
            }
            catch (IndexOutOfRangeException iorex)
            {
                throw iorex;
            }
            catch (NullReferenceException nrex)
            {
                throw nrex;
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (DbException dbex)
            {
                throw dbex;
            }

            return lista;
        }

    }
}
