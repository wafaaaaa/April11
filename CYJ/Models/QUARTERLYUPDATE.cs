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
    using System.ComponentModel.DataAnnotations;

    public partial class QUARTERLYUPDATE
    {
        public int updateID { get; set; }
        [Display(Name = "Update Subject")]
        public string updateHeader { get; set; }
        [Display(Name = "Update Body")]
        public string updateBody { get; set; }
        [Display(Name = "Update Date")]
        public Nullable<System.DateTime> updateDate { get; set; }
    }
}
