//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUARTEROPTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUARTEROPTION()
        {
            this.CHARTs = new HashSet<CHART>();
            this.FISCALYEARs = new HashSet<FISCALYEAR>();
            this.GOALACTUALs = new HashSet<GOALACTUAL>();
        }
    
        public int quarteroptionID { get; set; }
        public Nullable<int> subcategoryID { get; set; }
        public Nullable<int> fiscalYearID { get; set; }
        public string quarterOpt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHART> CHARTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FISCALYEAR> FISCALYEARs { get; set; }
        public virtual FISCALYEAR FISCALYEAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOALACTUAL> GOALACTUALs { get; set; }
    }
}
