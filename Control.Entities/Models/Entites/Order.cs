using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Order : BaseHome
    {
        public string OrderNo { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPostalCode { get; set; }

        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public string UserId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Category Category { get; set; }
        public virtual Province Province { get; set; }
        public virtual City City { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
