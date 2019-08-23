using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    /// <summary>
    /// Descripcion: Clase que representa la opcion asociada a una fiscalizacion.
    /// </summary>
    /// 
    [Serializable]
    [Table(Name = "OpcionesPregunta")]
    public class Opcion
    {
        [Key]
        [Column(Name = "idOpcionesPregunta")]
        public int Identificador { get; set; }
        [Column(Name = "descripcion")]
        public string Descripcion { get; set; }
    }
}
