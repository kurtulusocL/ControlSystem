﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Entites
{
    public class BaseHome
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfirm { get; set; }

        public BaseHome()
        {
            CreatedTime = DateTime.Now.ToLocalTime();
            IsConfirm = false;
        }
    }
}
