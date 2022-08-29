using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Product
    {
        public Product()
        {
            Bogos = new HashSet<Bogo>();
            PurchasedProducts = new HashSet<PurchasedProduct>();
            //PriceAfterDiscount = Price * 0.9;
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string? Title { get; set; }
        public DateTime? Publishdate { get; set; }
        public string? Keywords { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public double? PriceAfterDiscount { get; set; }
        public bool IsSold { get; set; } = false;

        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Bogo> Bogos { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
