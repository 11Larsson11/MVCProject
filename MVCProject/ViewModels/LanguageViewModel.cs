using MVCProject.Models;
using System.Collections.Generic;

namespace MVCProject.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages { get; set; }
        public Language Language { get; set; }

        public LanguageViewModel(List<Language> languages)
        {
            Languages = languages;
        }
    }
}
