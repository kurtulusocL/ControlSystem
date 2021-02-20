using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Departmant:BaseHome
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
