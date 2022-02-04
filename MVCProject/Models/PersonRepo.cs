using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class PersonRepo : IPersonRepo

    {
        private static int idCounter = 4;
        private static List<Person> listedPersons = new List<Person>();


        static PersonRepo()
        {
            listedPersons.Add(new Person() { Id = 1, Name = "Pölen", City = "Rottne", PhoneNumber = "043016624" });
            listedPersons.Add(new Person() { Id = 2, Name = "TeKå", City = "Borås", PhoneNumber = "0721453456" });
            listedPersons.Add(new Person() { Id = 3, Name = "Koma", City = "Sundbyberg", PhoneNumber = "0771242424" });
            listedPersons.Add(new Person() { Id = 4, Name = "Greven", City = "Malmö", PhoneNumber = "031184698" });

        }

        public Person Create(Person person)
        {
            Person newPerson = new Person();
            newPerson.Id = ++idCounter;
            newPerson.Name = person.Name;
            newPerson.City = person.City;
            newPerson.PhoneNumber = person.PhoneNumber;

            listedPersons.Add(newPerson);
            return newPerson;
        }

        public List<Person> Read()
        {
            return listedPersons;
        }

        public Person Read(int id)
        {
            return listedPersons.SingleOrDefault(c => c.Id == id);
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

            return listedPersons.Remove(original);

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