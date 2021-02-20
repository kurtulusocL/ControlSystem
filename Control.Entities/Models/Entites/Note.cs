using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Note:BaseHome
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }

        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int? PaymentId { get; set; }
        public int? ProductId { get; set; }
        public string UserId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Product Product { get; set; }
    }
}
