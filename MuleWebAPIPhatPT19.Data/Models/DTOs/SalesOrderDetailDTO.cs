﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Data.Models.DTOs
{
    public class SalesOrderDetailDTO
    {
        public string OrderNo { get; set; }
        public string ProductCode { get; set; }
        public double Quantity { get; set; } = 0;
        public double SalesPrice { get; set; } = 0;
        public double Tax { get; set; } = 0;

        public SalesOrderDetailDTO() { }

        public SalesOrderDetailDTO(string orderNo, string productCode, double quantity, double salesPrice, double tax)
        {
            OrderNo = orderNo;
            ProductCode = productCode;
            Quantity = quantity;
            SalesPrice = salesPrice;
            Tax = tax;
        }
    }
}
