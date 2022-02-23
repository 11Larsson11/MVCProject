using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }

        public int? CityId { get; set; }

        public string PhoneNumber { get; set; }

    }
}
