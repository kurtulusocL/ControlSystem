using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Employee:BaseHome
    {
        public string NameSurname { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime HireDate { get; set; }

        public int TitleId { get; set; }
        public int EmployeeInfoId { get; set; }
        public int? DepartmantId { get; set; }
        public string UserId { get; set; }

        public virtual Title Title { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
        public virtual Departmant Departmant { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
