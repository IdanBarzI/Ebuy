using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ShipmentCompany
    {
        public ShipmentCompany()
        {
            ShipmentPrices = new HashSet<ShipmentPrice>();
        }

        public int Id { get; set; }
        public string? CompanyName { get; set; } 

        public virtual ICollection<ShipmentPrice> ShipmentPrices { get; set; }
    }
}
