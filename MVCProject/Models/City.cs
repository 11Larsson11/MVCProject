using System.Collections.Generic;

namespace MVCProject.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }

        public List<Person> Persons { get; set; }
    }
}
