//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Locations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Locations()
        {
            this.Events = new HashSet<Events>();
            this.Externals = new HashSet<Externals>();
            this.LocationUsers = new HashSet<LocationUsers>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<int> EventLocation_Id { get; set; }
        public Nullable<int> LocationTelephone_Id { get; set; }
        public Nullable<int> LocationVehicle_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutNumber { get; set; }
        public string InNumber { get; set; }
        public Nullable<int> LocationType_Id { get; set; }
        public string Street { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual AspNetUsers AspNetUsers2 { get; set; }
        public virtual EventLocations EventLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Events> Events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Externals> Externals { get; set; }
        public virtual LocationTelephones LocationTelephones { get; set; }
        public virtual LocationTypes LocationTypes { get; set; }
        public virtual LocationVehicles LocationVehicles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationUsers> LocationUsers { get; set; }
    }
}
