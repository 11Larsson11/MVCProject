using MVCProject.Models;
using System.Collections.Generic;

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
