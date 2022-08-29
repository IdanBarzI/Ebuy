using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HelpModel
{
    public class BuyModelCasual
    {
        public List<Product>? ProductsToRemove { get; set; }
        public CasualCustomer? Customer { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
