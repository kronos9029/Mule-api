using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    [Table("salesorderdetail")]
    public partial class salesorderdetail
    {
        public string OrderNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public double? Quantity { get; set; }
        public double SalesPrice { get; set; }
        public double? Tax { get; set; }
    }
}
