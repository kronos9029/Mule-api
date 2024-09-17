using System;
using System.Collections.Generic;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    public partial class Salesorder
    {
        public string OrderNo { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedByDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
