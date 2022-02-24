using System.Collections.Generic;

namespace MVCProject.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }   //List of people combined with language
        public Language(){}
    }
}
