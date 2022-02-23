using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public List<City> Cities { get; set; }

    }
}
