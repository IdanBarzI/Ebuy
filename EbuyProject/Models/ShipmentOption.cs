using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ShipmentOption
    {
        public ShipmentOption()
        {
            ShipmentPrices = new HashSet<ShipmentPrice>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ShipmentPrice> ShipmentPrices { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
