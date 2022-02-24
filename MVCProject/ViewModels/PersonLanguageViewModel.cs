using MVCProject.Models;
using System.Collections.Generic;

namespace MVCProject.ViewModels
{
    public class PersonLanguageViewModel
    {
        public List<PersonLanguage> PersonLanguages { get; set; }
        public PersonLanguage PersonLanguage { get; set; }

        public PersonLanguageViewModel(List<PersonLanguage> personLanguages)
        {
            PersonLanguages = personLanguages;
        }

        public PersonLanguageViewModel(){}

    }
}
