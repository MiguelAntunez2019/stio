using Infraccional.ObjetoTransferencia.Infraccional.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    public class ADCHito
    {
        public int IdFiscalizacion { get; set; }
        public int IdADC { get; set; }
        public Int64 FolioFiscalizacion { get; set; }
        public int FolioADC { get; set; }
        public DateTime FechaCreacionADC { get; set; }
        public DateTime FechaAudiencia { get; set; }
        public List<_ADCEstado> Estados { get; set; }
    }
}
