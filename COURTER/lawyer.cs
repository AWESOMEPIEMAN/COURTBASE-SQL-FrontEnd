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

    public partial class lawyer
    {
        public int Lawyer_ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string name_lawyer { get; set; }
        [Required(ErrorMessage = "Required")]
        public string client { get; set; }
        public Nullable<int> Firm_ID { get; set; }
        public Nullable<int> Plaintiff { get; set; }
        public Nullable<int> Defendant_ID { get; set; }
    
        public virtual Defendant Defendant { get; set; }
        public virtual firm firm { get; set; }
        public virtual Plaintiff Plaintiff1 { get; set; }
    }
}