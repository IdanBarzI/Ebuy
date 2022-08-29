using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //[NotMapped]
    [Table("CasualCustomer")]
    public class CasualCustomer : Customer
    {
        public DateTime? FirstPurchasing { get; set; }

    }
}
