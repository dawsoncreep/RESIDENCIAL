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
    
    public partial class ExternalBinnaclePhotoes
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public Nullable<int> ExternalBinnacle_Id { get; set; }
        public Nullable<int> BinnaclePhotoType_Id { get; set; }
    
        public virtual BinnaclePhotoTypes BinnaclePhotoTypes { get; set; }
        public virtual ExternalBinnacles ExternalBinnacles { get; set; }
    }
}