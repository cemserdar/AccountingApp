using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accountingWebSite.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }
    }
}