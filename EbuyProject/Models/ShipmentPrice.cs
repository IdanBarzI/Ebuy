using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ShipmentPrice
    {
        public int Id { get; set; }
        public int ShipmentAreaId { get; set; }
        public int ShipmentOptionId { get; set; }
        public int ShipmentCompanyId { get; set; }
        public double BasicCharge { get; set; }
        public double ItemCharge { get; set; }
        public int ShipmentDuration { get; set; }

        public virtual ShipmentArea? ShipmentArea { get; set; } 
        public virtual ShipmentCompany? ShipmentCompany { get; set; } 
        public virtual ShipmentOption? ShipmentOption { get; set; } 
    }
}
