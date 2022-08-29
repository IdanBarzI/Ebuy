using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }

        public int Id { get; set; }
        public int DeliveryModeId { get; set; }
        public int ShipmentAddressId { get; set; }
        public int ShipmentCompanyId { get; set; }
        public int ShipmentOptionId { get; set; }
        public int CctypeId { get; set; }
        public string Ccnumber { get; set; } = null!;
        public DateTime CcexpireDate { get; set; }
        public double ShipmentCost { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CcownerName { get; set; } = null!;

        public virtual CreditCardType Cctype { get; set; } = null!;
        public virtual DeliveryMode DeliveryMode { get; set; } = null!;
        public virtual ShipmentAddress ShipmentAddress { get; set; } = null!;
        public virtual ShipmentOption ShipmentOption { get; set; } = null!;
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
