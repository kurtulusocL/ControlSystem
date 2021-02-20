using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class CustomerInfo:BaseHome
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }

        public string UserId { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
