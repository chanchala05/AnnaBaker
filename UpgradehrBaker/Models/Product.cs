using System;
using System.Collections.Generic;

#nullable disable

namespace UpgradehrBaker.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
    }
}
