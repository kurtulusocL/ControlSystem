using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Country:BaseHome
    {
        [Display(Name="Ülke Adı")]
        public string Name { get; set; }
        public string Photo { get; set; }

        public string UserId { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<FromWhere> FromWheres { get; set; }
        public ICollection<ToWhere> ToWheres { get; set; }
        public ICollection<Province> Provinces { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
