//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContainermanagementsystemTP034963.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipment
    {
        public int Id { get; set; }
        public Nullable<int> source { get; set; }
        public Nullable<int> destination { get; set; }
        public Nullable<int> cargoid { get; set; }
        public Nullable<System.DateTime> departuretime { get; set; }
        public Nullable<System.DateTime> arrivaltime { get; set; }
    
        public virtual Warehouse Warehouse { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
    }
}
