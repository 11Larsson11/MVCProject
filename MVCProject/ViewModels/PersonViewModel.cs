using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
        public List<PersonLanguage> PersonLanguage { get; set; }

        public PersonViewModel(){}
    }
}
