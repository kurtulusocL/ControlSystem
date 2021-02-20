using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class Communicate:BaseHome
    {
        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }
    }
}
