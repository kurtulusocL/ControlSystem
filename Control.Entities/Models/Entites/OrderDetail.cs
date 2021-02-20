using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class OrderDetail:BaseHome
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public int? OrderId { get; set; }
        public string UserId { get; set; }

        public virtual Order Order { get; set; }        
    }
}
