using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using System.Collections.Generic;

namespace MVCProject.ViewModels
{
    public class AllCitiesViewModel
    {
        public List<CityViewModel> Cities { get; set; }
        public City City { get; set; }
        public SelectList Countries { get; set; }

        public AllCitiesViewModel(List<CityViewModel> cities)
        {
            Cities = cities;
        }
    }
}
