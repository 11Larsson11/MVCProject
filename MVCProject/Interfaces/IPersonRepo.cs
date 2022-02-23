using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    interface IPersonRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool DeletePerson(int id);
    }
}
