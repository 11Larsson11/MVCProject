using System.Collections.Generic;

namespace MVCProject.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public List<PersonLanguage> PersonLanguage { get; set; }    //List of languages combined with person
    }
}
