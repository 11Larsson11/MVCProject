using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public List<Person> Persons { get; set; }
    }
}
