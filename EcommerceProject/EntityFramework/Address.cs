//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Nullable<int> c_id { get; set; }
        public int a_id { get; set; }
        public string address_firstline { get; set; }
        public string address_secondline { get; set; }
        public string address_city { get; set; }
        public string address_country { get; set; }
        public string postcode { get; set; }
    
        public virtual CustomerData CustomerData { get; set; }
    }
}