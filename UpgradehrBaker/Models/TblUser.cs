using System;
using System.Collections.Generic;

#nullable disable

namespace UpgradehrBaker.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
