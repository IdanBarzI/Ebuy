using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ShipmentArea
    {
        public ShipmentArea()
        {
            CountriesAreas = new HashSet<CountriesArea>();
            ShipmentPrices = new HashSet<ShipmentPrice>();
        }

        public int Id { get; set; }
        public string? Area { get; set; } 

        public virtual ICollection<CountriesArea> CountriesAreas { get; set; }
        public virtual ICollection<ShipmentPrice> ShipmentPrices { get; set; }
    }
}
