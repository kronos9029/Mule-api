using System;
using System.Collections.Generic;

namespace MuleWebAPIPhatPT19.Data.Models.Entities
{
    public partial class Account
    {
        public string FldAccount { get; set; } = null!;
        public string FldPassword { get; set; } = null!;
        public string? FldRole { get; set; }
    }
}
