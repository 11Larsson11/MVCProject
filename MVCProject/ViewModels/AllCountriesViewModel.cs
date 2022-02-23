using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class AllCountriesViewModel
    {
        public List<CountryViewModel> Countries { get; set; }
        public Country Country { get; set; }

        public AllCountriesViewModel(List<CountryViewModel> countries)
        {
            Countries = countries;
        }
    }
}
