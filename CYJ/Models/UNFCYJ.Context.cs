﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cyjEntities2 : DbContext
    {
        public cyjEntities2()
            : base("name=cyjEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ABOUT> ABOUTs { get; set; }
        public virtual DbSet<CALENDAR> CALENDARs { get; set; }
        public virtual DbSet<CALENDAREVENT> CALENDAREVENTS { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CHART> CHARTs { get; set; }
        public virtual DbSet<FISCALYEAR> FISCALYEARs { get; set; }
        public virtual DbSet<GOALACTUAL> GOALACTUALs { get; set; }
        public virtual DbSet<QUARTERLYUPDATE> QUARTERLYUPDATEs { get; set; }
        public virtual DbSet<QUARTEROPTION> QUARTEROPTIONs { get; set; }
        public virtual DbSet<SUBCATEGORY> SUBCATEGORies { get; set; }
        public virtual DbSet<TEAM> TEAMs { get; set; }
        public virtual DbSet<WORKSTREAM> WORKSTREAMs { get; set; }
    }
}
