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
    /// Descripcion: Clase que representa la pregunta asociada a una fiscalizacion.
    /// </summary>
    /// 
    [Serializable]
    [Table(Name = "Pregunta")]
    public class Pregunta
    {
        [Key]
        [Column(Name = "idPregunta")]
        public int Identificador { get; set; }
        [Column(Name = "descripcionPregunta")]
        public string Descripcion { get; set; }
    }
}
