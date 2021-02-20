using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class City:BaseHome
    {
        [Display(Name ="Şehir Adı")]
        public string Name { get; set; }

        public int? ProvinceId { get; set; }
        public string UserId { get; set; }

        public virtual Province Province { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
