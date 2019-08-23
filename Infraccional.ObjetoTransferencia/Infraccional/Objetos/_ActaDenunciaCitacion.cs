using Infraccional.ObjetoTransferencia.Infraccional.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.Objetos
{
    public class _ActaDenunciaCitacion
    {
        public int IdADC { get; set; }
        public int NroExpedienteRol { get; set; }
        public string NumeroFiscalizacion { get; set; }
        public DateTime FechaDenuncia { get; set; }
        public DateTime FechaAudiencia { get; set; }
        public _Usuario Usuario { get; set; }
        public _ActaDenunciaCItacionHistorico ActaDenunciaCItacionHistorico { get; set; }
        public _NegocioFiscalizacion NegocioFiscalizacion { get; set; }
        public _Proceso Proceso { get; set; }
        public List<_Incumplimiento> Incumplimientos { get; set; }
    }
}
