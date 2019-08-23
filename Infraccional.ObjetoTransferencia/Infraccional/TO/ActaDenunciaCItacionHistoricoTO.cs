using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    public class ActaDenunciaCItacionHistoricoTO
    {
        public int    Identificador { get; set; }
        public string Descripcion   { get; set; }
        public int    ADH_COD_HITO  { get; set; }
        public int    Fronterizo    { get; set; }
        public string NumeroACD     { get; set; }
    }
}
