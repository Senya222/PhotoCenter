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
    
    public partial class Document
    {
        public int DocumentID { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> TypeDocumentID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> WorkerID { get; set; }
    
        public virtual TypeDocument TypeDocument { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
