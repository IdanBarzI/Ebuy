using System;
using System.Collections.Generic;

namespace Models
{
    public partial class CreditCardType
    {
        public CreditCardType()
        {
            //Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Prefix { get; set; } = null!;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
