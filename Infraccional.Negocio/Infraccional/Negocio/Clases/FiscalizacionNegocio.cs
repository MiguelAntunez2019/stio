using Infraccional.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using Clientes.AccesoDatos.AccesoDatos;

namespace Infraccional.Negocio.Clases
{
    /// <summary>
    /// Descripcion: Interfaz que despliega los metodos del negocio fiscalizacion.
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
    [Export(typeof(IFiscalizacion))]
    class FiscalizacionNegocio : IFiscalizacion
    {
        /// <summary>
        /// Acceso generico.
        /// </summary>
        private AccesoGenerico _daoGenerico;
        /// <summary>
        /// Nombre de la conexion a sancionatorio.
        /// </summary>
        private readonly string CONEXION_FISCALIZACION = "fiscalizacion";
        /// <summary>
        /// Constructor de negocio fiscalizacion.
        /// </summary>
        public FiscalizacionNegocio()
        {
            _daoGenerico = new AccesoGenerico(CONEXION_FISCALIZACION);
        }

        /// <summary>
        /// Metodo que permite obtener los incumplientos asociados a una fiscalizacion.
        /// </summary>
        /// <param name="numeroFiscalizacion">Numero de fiscalizacion.</param>
        /// <returns></returns>
        public List<Incumplimiento> ObtenerIncumplimientos(string numeroFiscalizacion)
        {
            List<Incumplimiento> incumplimientos = new List<Incumplimiento>();

            try
            {

                string query = string.Format(@"SELECT [idIncumplimientoHis] as Identificador
                                                ,incum.idOpcionPregunta as Identificador
                                                ,descripcionOpcion as descripcion
	                                            ,idPregunta as Identificador     
                                                ,descripcionPregunta as Descripcion
                                            FROM [SKV_SAG].[dbo].[IncumplimientoHis] as incum                                           
                                            WHERE idChecklist = '{0}'", numeroFiscalizacion);

                incumplimientos = _daoGenerico.ObtenerListaQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return incumplimientos;
        }
    }
}
