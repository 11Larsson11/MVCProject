using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public interface IPersonService
    {
        Person Add(CreatePersonViewModel personVM);
        List<Person> GetList();
        List<Person> Search(string text);
        bool DeletePerson(int id);
        Person GetById(int id);

    }
}
