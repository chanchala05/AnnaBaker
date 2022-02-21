using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpgradehrBaker.Model
{
    public class PartnerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Passworrd { get; set; }
    }
}
