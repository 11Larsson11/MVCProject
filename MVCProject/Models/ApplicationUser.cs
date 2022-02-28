using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class ApplicationUser : IdentityUser
    {
            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }
            [Required]
            public string BirthDate { get; set; }
    }
}
