using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    [Table("salesorder")]
    public partial class salesorder
    {
        public string OrderNo { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedByDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
