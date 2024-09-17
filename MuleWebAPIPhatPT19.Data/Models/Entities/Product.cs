using System;
using System.Collections.Generic;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    public partial class Product
    {
        public string ProductCode { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
        public double? QuantityInStock { get; set; }
        public double UnitPrice { get; set; }
        public DateTime? CreatedByDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
