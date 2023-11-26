﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApiHumanModels.Enums;

namespace WebApiHumanModels.Data
{
    public class Human
    {
        [Key]
        public int HumanId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name value cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int Age { get; set;  }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }

    }
}
