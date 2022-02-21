using System;
using System.Collections.Generic;

#nullable disable

namespace UpgradehrBaker.Models
{
    public partial class TblOrder
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int? UserId { get; set; }
        public int? PartnerId { get; set; }

        public virtual TblUser User { get; set; }
    }
}
