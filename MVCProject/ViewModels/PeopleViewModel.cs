using System.Collections.Generic;
using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> AllPeople { get; set; }

        public List<PersonViewModel> People { get; set; }

        public PersonLanguage PersonLanguage { get; set; }

        public CreatePersonViewModel CreatePersonViewModel { get; set; }

        public PeopleViewModel(List<PersonViewModel> people)
        {
            People = people;
        }
    }
}
