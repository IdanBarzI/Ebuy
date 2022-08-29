using System;
using System.Collections.Generic;

namespace Models
{
    public partial class CountriesArea
    {
        //public CountriesArea()
        //{
        //    ShipmentAddresses = new HashSet<ShipmentAddress>();
        //}

        public int Id { get; set; }
        public int ShipmentAreaId { get; set; }
        public string? Country { get; set; } 

        public virtual ShipmentArea? ShipmentArea { get; set; } 
        public virtual ICollection<ShipmentAddress>? ShipmentAddresses { get; set; }
    }
}
