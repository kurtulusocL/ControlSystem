using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Category : BaseHome
    {
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
