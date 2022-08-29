using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    
    public abstract class Customer
    {
        //[JsonIgnore]
        public int CustomerId { get; set; }
        public Customer()
        {
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }
        [Required(ErrorMessage = "Required fild"), MaxLength(50)]
        public string LoginName { get; set; } = null!;
        [Required(ErrorMessage = "Required fild"), MaxLength(50)]
        public string Addres { get; set; } = null!;
        [Required(ErrorMessage = "Required fild"), MaxLength(50)]
        public string Email { get; set; } = null!;
        public bool IsClubMember { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }

    }
}
