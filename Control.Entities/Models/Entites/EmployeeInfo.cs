using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class EmployeeInfo:BaseHome
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
