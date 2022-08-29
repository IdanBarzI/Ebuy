using System;
using System.Collections.Generic;

namespace Models
{
    public partial class DeliveryMode
    {
        public DeliveryMode()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
