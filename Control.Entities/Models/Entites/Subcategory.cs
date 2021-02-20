using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Subcategory : BaseHome
    {
        [Display(Name = "Altkategori Adı")]
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
