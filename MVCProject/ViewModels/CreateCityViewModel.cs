using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
