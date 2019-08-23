using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.Objetos
{
    public class _ActaDenunciaCItacionHistorico
    {
        public int IdADCHistorico { get; set; }
        public string NumeroResolucion { get; set; }
        public string Observacion { get; set; }
        public _ADCResolucion ADCResolucion { get; set; }

    }
}
