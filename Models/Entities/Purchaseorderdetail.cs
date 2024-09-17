using System;
using System.Collections.Generic;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    public partial class Purchaseorderdetail
    {
        public string OrderNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public double? Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double? Tax { get; set; }
    }
}
