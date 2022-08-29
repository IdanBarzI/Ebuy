using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Bogo
    {
        public int Id { get; set; }
        public int Bogolevel { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
