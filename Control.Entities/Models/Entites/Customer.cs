using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Customer:BaseHome
    {
        public string NameSurname { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }

        public int PaymentId { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int CustomerInfoId { get; set; }
        public string UserId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Country Country { get; set; }       
        public virtual Province Province { get; set; }
        public virtual City City { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
