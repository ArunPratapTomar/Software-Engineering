//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S2G7_PVFAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public int VendorID { get; set; }
        public int MaterialID { get; set; }
        public Nullable<decimal> SupplyUnitPrice { get; set; }
    
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
