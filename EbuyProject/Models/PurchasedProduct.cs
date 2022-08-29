using System;
using System.Collections.Generic;

namespace Models
{
    public partial class PurchasedProduct
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double BasicCost { get; set; }
        public double Vat { get; set; }
        public double? PriceAfterDiscount { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Transaction Transaction { get; set; } = null!;
    }
}
