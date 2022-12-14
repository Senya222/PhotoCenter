//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> WorkerID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> PrepayID { get; set; }
        public Nullable<int> SaleID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Prepay Prepay { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
