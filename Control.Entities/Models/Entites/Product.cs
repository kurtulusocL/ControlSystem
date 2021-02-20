using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Product:BaseHome
    {
        public string ProductNumber { get; set; }
        public string Name { get; set; }       
        public bool InStock { get; set; }
        public int Stock { get; set; }       

        public int? CategoryId { get; set; }
        public int? FromWhereId { get; set; }
        public int? ToWhereId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? ProductDetailId { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual FromWhere FromWhere { get; set; }
        public virtual ToWhere ToWhere { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
       
        public ICollection<Note> Notes { get; set; }
    }
}
