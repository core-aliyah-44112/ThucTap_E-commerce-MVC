//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NNStore.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string TypeMenu { get; set; }
        public Nullable<int> TableId { get; set; }
        public string Position { get; set; }
        public Nullable<int> ParenId { get; set; }
        public Nullable<int> Orders { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public int Status { get; set; }
    }
}
