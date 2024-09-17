using System;
using System.Collections.Generic;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    public partial class Salesorderdetail
    {
        public string OrderNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public double? Quantity { get; set; }
        public double SalesPrice { get; set; }
        public double? Tax { get; set; }
    }
}
