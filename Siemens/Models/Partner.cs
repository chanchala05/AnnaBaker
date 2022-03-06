using System;
using System.Collections.Generic;

#nullable disable

namespace Siemens.Models
{
    public partial class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
