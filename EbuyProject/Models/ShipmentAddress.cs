using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ShipmentAddress
    {
        public ShipmentAddress()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Buyer { get; set; }
        public int? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? Pbo { get; set; }
        public string? Email { get; set; }

        public virtual CountriesArea? CountryNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
