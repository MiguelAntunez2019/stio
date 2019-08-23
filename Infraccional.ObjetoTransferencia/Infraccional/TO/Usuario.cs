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
    /// Descripcion: Clase que representa un usuario relacionado al acta.
    /// </summary>
    [Table(Name = "SS_ADM_USUARIOS")]
    public class Usuario
    {
        /// <summary>
        /// Representa el identificador del usuario.
        /// </summary>
        [Key]
        [Column(Name = "USR_RUT")]
        public string Identificador { get; set; }
        /// <summary>
        /// Representa el nombre del usuario.
        /// </summary>
        [Column(Name = "USR_NOMBRE")]
        public string Nombre { get; set; }

        [Column(Name = "USR_LOGIN")]
        public string Login { get; set; }

        [Column(Name = "USR_PASSWORD")]
        public string password { get; set; }

        [Column(Name = "USR_EMAIL")]
        public string Email { get; set; }

        [Column(Name = "USR_ACTIVO")]
        public string activo { get; set; }

        [Column(Name = "USR_MENUUSUARIO")]
        public int menuUsuario { get; set; }

        [Column(Name = "USR_COD_COMUNA")]
        public string Comuna { get; set; }

        [Column(Name = "USR_COD_OFICINA")]
        public int Oficina { get; set; }

        [Column(Name = "USR_COD_CARGO")]
        public int Cargo { get; set; }
    }
}
