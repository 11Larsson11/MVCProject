using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> AllPersons { get; set; }
    }
}
