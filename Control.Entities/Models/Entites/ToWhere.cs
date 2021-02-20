using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class ToWhere:BaseHome
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int? CountryId { get; set; }
        public string UserId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
