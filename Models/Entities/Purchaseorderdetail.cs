using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    [Table("purchaseorderdetails")]
    public partial class purchaseorderdetail
    {
        public string OrderNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public double? Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double? Tax { get; set; }
    }
}
