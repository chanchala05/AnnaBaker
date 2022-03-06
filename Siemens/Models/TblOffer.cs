using System;
using System.Collections.Generic;

#nullable disable

namespace Siemens.Models
{
    public partial class TblOffer
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? PartnerId { get; set; }
        public int? ProductOffer { get; set; }
    }
}
