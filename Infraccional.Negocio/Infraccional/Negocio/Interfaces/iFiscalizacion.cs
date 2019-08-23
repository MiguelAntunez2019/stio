using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.Negocio.Interfaces
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
    public interface IFiscalizacion
    {
        /// <summary>
        /// Metodo que permite obtener los incumplientos asociados a una fiscalizacion.
        /// </summary>
        /// <param name="numeroFiscalizacion">Numero de fiscalizacion.</param>
        /// <returns></returns>
        List<Incumplimiento> ObtenerIncumplimientos(string numeroFiscalizacion);
    }
}
