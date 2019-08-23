using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    public class ActaDenunciaCitacionDetalle
    {
        public int idFiscalizacion { get; set; }
        public int ID_REGION { get; set; }
        public string REGION_NOMBRE { get; set; }
        public int idComuna { get; set; }
        public string COMUNA_NOMBRE { get; set; }
        public int ID_SUB_MATERIA { get; set; }
        public string NOMBRE_SUB_MATERIA { get; set; }
        public int ID_MATERIA { get; set; }
        public string NOMBRE_MATERIA { get; set; }
        public int ID_AMBITO { get; set; }
        public string NOMBRE_AMBITO { get; set; }
        public string folio { get; set; }
        public string rutRepresentante { get; set; }
        public string nombreRepresentante { get; set; }
        public string urlAdc { get; set; }
        public int idchecklist { get; set; }
        public int idOficina { get; set; }
        public string descOficina { get; set; }
    }
}
