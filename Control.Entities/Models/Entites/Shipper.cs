using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Shipper:BaseHome
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public string UserId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
