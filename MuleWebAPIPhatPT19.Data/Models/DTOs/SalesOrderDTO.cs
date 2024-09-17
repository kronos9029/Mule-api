using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Data.Models.DTOs
{
    public class SalesOrderDTO
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedByDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

        public SalesOrderDTO() { }

        public SalesOrderDTO(string orderNo, DateTime orderDate, string title, string description, DateTime createdByDate, string createdBy)
        {
            OrderNo = orderNo;
            OrderDate = orderDate;
            Title = title;
            Description = description;
            CreatedByDate = createdByDate;
            CreatedBy = createdBy;
        }
    }
}
