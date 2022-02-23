using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class PersonRepo : IPersonRepo

    {
        public List<Person> People { get; set; }

        public PersonRepo()
        {
            People = new List<Person>(){};
        }

        public Person Create(Person person)
        {
            People.Add(person);
            return person;
        }

        
        public List<Person> Read()
        {
            return People;
        }
        

        public Person Read(int id)
        {
            return People.SingleOrDefault(c => c.Id == id);
        }

        public Person Update(Person person)
        {
            Person original = Read(person.Id);

            if (original == null)
            {
                return null;
            }

            original.Name = person.Name;
            original.City = person.City;
            original.PhoneNumber = person.PhoneNumber;

            return original;
        }


        public bool DeletePerson(int id)
        {

            Person original = Read(id);

            if (original == null)
            {
                return false;
            }

            return People.Remove(original);

        }
    }
}





























































/*



{
private static int idCounter = 0;
private static List<Person> trustedPersons = new List<Person>();

public Person Create(Person person)
{
    Person newPerson = new Person();
    newPerson.PersonID = ++idCounter;
    newPerson.Name = person.Name;
    newPerson.City = person.City;
    newPerson.PhoneNumber = person.PhoneNumber;

    trustedPersons.Add(newPerson);
    return newPerson;
}

public List<Person> Read()
{
    return trustedPersons;
}

public Person Read(int id)
{
    return trustedPersons.SingleOrDefault(c => c.PersonID == id);
}

public Person Update(Person person)
{
    Person original = Read(person.PersonID);

    if (original == null)
    {
        return null;
    }

    original.Name = person.Name;
    original.City = person.City;
    original.PhoneNumber = person.PhoneNumber;

    return original;
}

public bool Delete(int id)
{
    Person original = Read(id);

    if (original == null)
    {
        return false;
    }

    return trustedPersons.Remove(original);
}
}
}
*/