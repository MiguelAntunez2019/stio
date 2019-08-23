using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    [Table(Name = "SS_MAE_OFICINA")]
    public class Oficina
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "ID_OFICINA")]
        public int IdOficina { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        [Column(Name = "NOMBRE_OFICINA")]
        public string NombreOficina { get; set; }
        
    }
}
