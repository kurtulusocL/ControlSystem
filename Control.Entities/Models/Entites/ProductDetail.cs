using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class ProductDetail:BaseHome
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public string UserId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
