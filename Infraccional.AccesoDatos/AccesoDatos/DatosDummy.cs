using BaseDatosFactoria.Entities;
using BaseDatosFactoria.Factory;
using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.AccesoDatos.AccesoDatos
{
    public class DatosDummy
    {

        public string ObtenereHitosADCDummy(string sql)
        {
            string lista =
                 "[{'IdFiscalizacion':23,'IdADC':23333,'FolioFiscalizacion':1,'FolioADC':1111,'FechaCreacionADC':'01/07/2014','FechaAudiencia':'01/07/2014','Estados':[{'IdEstadoSancionatorio':1,'EstadoSancionatorio':'Pendiente','FechaActualizacion':'01/07/2014','Orden':1},{'IdEstadoSancionatorio':1,'EstadoSancionatorio':'Pendiente','FechaActualizacion':'01/07/2014','Orden':2}]}]";
   
            return lista;
        }


    }
}
