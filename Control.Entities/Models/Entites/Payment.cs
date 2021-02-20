using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Payment:BaseHome
    {
        [Display(Name ="Ödeme Sistemi")]
        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
