//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeFlowers.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class prod_Poduct
    {
        public int ProductId { get; set; }
        public string productName { get; set; }
        public Nullable<int> productCategoryId { get; set; }
    
        public virtual prod_Category prod_Category { get; set; }
    }
}