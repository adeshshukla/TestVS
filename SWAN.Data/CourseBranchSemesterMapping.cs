//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWAN.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseBranchSemesterMapping
    {
        public int Id { get; set; }
        public int CourseBranchId { get; set; }
        public int SemesterId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreateTs { get; set; }
        public Nullable<System.DateTime> ModTs { get; set; }
    
        public virtual CourseBranchMapping CourseBranchMapping { get; set; }
        public virtual Semester Semester { get; set; }
    }
}