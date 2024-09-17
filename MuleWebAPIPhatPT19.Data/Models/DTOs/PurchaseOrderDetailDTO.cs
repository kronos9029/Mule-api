using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Data.Models.DTOs
{
    public class PurchaseOrderDetailDTO
    {
        public string OrderNo { get; set; }
        public string ProductCode { get; set; }
        public double Quantity { get; set; } = 0;
        public double PurchasePrice { get; set; } = 0;
        public double Tax { get; set; } = 0;

        public PurchaseOrderDetailDTO() { }

        public PurchaseOrderDetailDTO(string orderNo, string productCode, double quantity, double purchasePrice, double tax)
        {
            OrderNo = orderNo;
            ProductCode = productCode;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            Tax = tax;
        }
    }
}
