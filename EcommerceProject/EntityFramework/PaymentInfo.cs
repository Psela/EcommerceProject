//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceProject.DatabaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentInfo
    {
        public Nullable<int> c_id { get; set; }
        public long card_number { get; set; }
        public Nullable<int> expiry_month { get; set; }
        public Nullable<int> expiry_year { get; set; }
        public string card_name { get; set; }
    
        public virtual CustomerData CustomerData { get; set; }
    }
}
