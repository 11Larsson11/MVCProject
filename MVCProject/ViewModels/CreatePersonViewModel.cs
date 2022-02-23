﻿using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        public City City { get; set; }
        
        public int CityId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string PhoneNumber { get; set; }
    }
}
