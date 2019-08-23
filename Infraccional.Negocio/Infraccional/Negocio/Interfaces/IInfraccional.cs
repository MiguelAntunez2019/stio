using Infraccional.ObjetoTransferencia.Infraccional.Objetos;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.Negocio.Infraccional.Negocio.Interfaces
{
    /// <summary>
    /// Descripcion: Interfaz que despliega los metodos del negocio infraccional.
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
    /// 1.1 07/01/2019 Patricio Aros Olguin : Se agrega Metodo que obtiene Detalle segun Numero de ADC. 
    ///
    public interface IInfraccional
    {
        /// <summary>
        /// Metodo que permite obtener actas de denuncia y citacion segun numero de fiscalizacion.
        /// </summary>
        /// <param name="IdentificadorFiscalizacion">Numero de Fiscalizacion.</param>
        /// <returns></returns>
        List<ActaDenunciaCitacion> ObtenerActasSegunFiscalizacion(string IdentificadorFiscalizacion);
        /// <summary>
        /// Metodo que permite registrar actas de denuncia y citacion.
        /// </summary>
        /// <param name="actaDenuncia">Acta de Denuncia y Citación</param>
        /// <returns></returns>
        int RegistrarActaDenunciaCitacion(ActaDenunciaCitacionTO actaDenuncia);
        /// <summary>
        /// Metodo que permite obtener las Bitacoras de denuncia y citacion según numero de fiscalizacion.
        /// </summary>
        /// <param name="IdentificadorFiscalizacion">Numero de Fiscalizacion.</param>
        /// <returns></returns>
        List<ActaDenunciaCitacion> ObtenerBistacorasSegunFiscalizacion(string IdentificadorFiscalizacion);
        List<ActaDenunciaCitacionDetalle> ObtenerADCdetalleSegunFiscalizacion(string IdentificadorFiscalizacion);
        List<ADCHito> ObtenerADCdetalleSegunNumeroADC(string FoliioADC);
        string DUMMYObtenerADCdetalleSegunNumeroADC(string FoliioADC);

        List<ADCResolucion> ObtenerADCResolucion(string ADC);
    }
    
}
