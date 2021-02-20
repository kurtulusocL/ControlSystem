using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Province:BaseHome
    {
        [Display(Name = "Eyalet - Bölge Adı")]
        public string Name { get; set; }

        public int? CountryId { get; set; }
        public string UserId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
