//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioInfraccional
{
    using System;
    using System.Collections.Generic;
    
    public partial class SS_ADM_USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SS_ADM_USUARIOS()
        {
            this.SS_NEG_ADC_HITO = new HashSet<SS_NEG_ADC_HITO>();
            this.SS_NEG_ADC = new HashSet<SS_NEG_ADC>();
            this.SS_NEG_ADC_RESOLUCION = new HashSet<SS_NEG_ADC_RESOLUCION>();
            this.SS_NEG_ADC1 = new HashSet<SS_NEG_ADC>();
            this.SS_NEG_ADC2 = new HashSet<SS_NEG_ADC>();
            this.SS_NEG_ADC3 = new HashSet<SS_NEG_ADC>();
            this.SS_NEG_ADC4 = new HashSet<SS_NEG_ADC>();
            this.SS_NEG_ADC_RESOLUCION1 = new HashSet<SS_NEG_ADC_RESOLUCION>();
            this.SS_NEG_ADC_SENTENCIA = new HashSet<SS_NEG_ADC_SENTENCIA>();
        }
    
        public int USR_RUT { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_LOGIN { get; set; }
        public string USR_PASSWORD { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_ACTIVO { get; set; }
        public Nullable<int> USR_MENUUSUARIO { get; set; }
        public string USR_COD_COMUNA { get; set; }
        public Nullable<int> USR_COD_OFICINA { get; set; }
        public Nullable<int> USR_COD_CARGO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC_HITO> SS_NEG_ADC_HITO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC> SS_NEG_ADC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC_RESOLUCION> SS_NEG_ADC_RESOLUCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC> SS_NEG_ADC1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC> SS_NEG_ADC2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC> SS_NEG_ADC3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC> SS_NEG_ADC4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC_RESOLUCION> SS_NEG_ADC_RESOLUCION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SS_NEG_ADC_SENTENCIA> SS_NEG_ADC_SENTENCIA { get; set; }
    }
}
