using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HelpModel
{
    public class BuyModelClub
    {
        public List<Product>? ProductsToRemove { get; set; }
        public ClubMember? Customer { get; set; }
        public Transaction? Transaction { get; set; }
       // public ShipmentAddress? ShipmentAddress { get; set; }

    }
}
