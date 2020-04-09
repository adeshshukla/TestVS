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
    
    public partial class CourseBranchMapping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseBranchMapping()
        {
            this.CourseBranchSemesterMappings = new HashSet<CourseBranchSemesterMapping>();
        }
    
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int BranchId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreateTs { get; set; }
        public Nullable<System.DateTime> ModTs { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseBranchSemesterMapping> CourseBranchSemesterMappings { get; set; }
    }
}
