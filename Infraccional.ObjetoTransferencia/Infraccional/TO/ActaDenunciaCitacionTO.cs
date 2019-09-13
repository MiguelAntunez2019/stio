using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.ObjetoTransferencia.Infraccional.TO
{
    public class ActaDenunciaCitacionTO
    {
        /// <summary>
        /// Representa el numero del acta.
        /// </summary>        
        public double Numero { get; set; }
        /// <summary>
        /// Representa la fecha de la audencia.
        /// </summary>
        public DateTime FechaAudiencia { get; set; }
        /// <summary>
        /// Representa el identificador de la submaterio.
        /// </summary>
        public int SubMateria { get; set; }
        /// <summary>
        /// Representa la fecha de ingreso del acta
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Representa la fecha de denuncia.
        /// </summary>
        public DateTime FechaDenuncia { get; set; }
        /// <summary>
        /// Represena el numero de la fiscalizacion.
        /// </summary>
        public string NumeroFiscalizacion { get; set; }
        /// <summary>
        /// Representa el numero de la oficina.
        /// </summary>
        public int OficinaUsuario { get; set; }
        /// <summary>
        /// Representa el identificador de la region.
        /// </summary>
        public string Region { get; set; } 
        /// <summary>
        /// Representa el correo electronico del inspector.
        /// </summary>
        public string EmailInspector { get; set; }
        /// <summary>
        /// Representa el correo electronico del usuario creador.
        /// </summary>
        public string EmailUsuario { get; set; }
        /// <summary>
        /// Representa el Infractor del acta.
        /// </summary>
        public Infractor Infractor { get; set; }
    }
}
