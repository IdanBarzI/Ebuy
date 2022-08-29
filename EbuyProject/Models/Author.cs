using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Author
    {
        public Author()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string AuthorName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
