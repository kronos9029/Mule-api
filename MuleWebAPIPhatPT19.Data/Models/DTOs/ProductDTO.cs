using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Data.Models.DTOs
{
    public class ProductDTO
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double QuantityInStock { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public DateTime CreatedByDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

        public ProductDTO() { }

        public ProductDTO(string productCode, string productName, string unit, double quantityInStock, double unitPrice, DateTime createdByDate, string createdBy)
        {
            ProductCode = productCode;
            ProductName = productName;
            Unit = unit;
            QuantityInStock = quantityInStock;
            UnitPrice = unitPrice;
            CreatedByDate = createdByDate;
            CreatedBy = createdBy;
        }
    }
}
