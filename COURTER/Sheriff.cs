//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourtroomProject.COURTER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sheriff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sheriff()
        {
            this.courtrooms = new HashSet<courtroom>();
        }
    
        public int Sheriff_ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<System.DateTime> DOB_Sheriff { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address_sheriff { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<courtroom> courtrooms { get; set; }
    }
}