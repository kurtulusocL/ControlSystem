using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Title : BaseHome
    {
        [Display(Name = "Ünvan")]
        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
