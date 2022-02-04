using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepo _personRepo;

        public PersonService()
        {
            _personRepo = new PersonRepo();
        }

        public Person Add(CreatePersonViewModel personVM)
        {
            if (string.IsNullOrWhiteSpace(personVM.Name) || string.IsNullOrWhiteSpace(personVM.City) || string.IsNullOrWhiteSpace(personVM.PhoneNumber))
            {
                return null;
            }
            Person newPerson = new Person()
            {
                Name = personVM.Name,
                City = personVM.City,
                PhoneNumber = personVM.PhoneNumber
            };

            Person person = _personRepo.Create(newPerson);

            return person;
        }
      

        public List<Person> GetList()
        {
            return _personRepo.Read();
        }


        public List<Person> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<Person>();
            }


                var list = _personRepo.Read();
                List<Person> matches = new List<Person>();

                foreach (var item in list)
                {
                    if (item.Name.Contains(text) || item.City.Contains(text) || (item.PhoneNumber.Contains(text)))
                    {
                        matches.Add(item);
                    }
                }
                
                return matches;
        }


        public bool DeletePerson(int id)
        {
            return _personRepo.DeletePerson(id);
        }
    }
}
































































/*





private readonly IPersonRepo _personRepo;

public PersonService()
{
    _personRepo = new PersonRepo();
}



static int idCounter = 4;
public string filterInput = "";
private static List<Person> personList = new List<Person>();

static PersonService()
{
    personList.Add(new Person() { PersonID = 1, Name = "Pölen", City = "Rottne", PhoneNumber = "043016624" });
    personList.Add(new Person() { PersonID = 2, Name = "TeKå", City = "Borås", PhoneNumber = "0721453456" });
    personList.Add(new Person() { PersonID = 3, Name = "Koma", City = "Skövde", PhoneNumber = "0771242424" });
    personList.Add(new Person() { PersonID = 4, Name = "Greven", City = "Malmö", PhoneNumber = "031184698" });

}

public List<Person> All()
{
    return personList;
}
public Person Add(CreatePersonViewModel personViewModel)
{
    if (string.IsNullOrWhiteSpace(personViewModel.Name) || string.IsNullOrWhiteSpace(personViewModel.City) || string.IsNullOrWhiteSpace(personViewModel.PhoneNumber))
    {
        return null;
    }

    Person person = new Person()
    {
        PersonID = ++idCounter,
        Name = personViewModel.Name,
        City = personViewModel.City,
        PhoneNumber = personViewModel.PhoneNumber
    };

    personList.Add(person);
    return person;
}

public Person GetById(int id)
{
    return personList.SingleOrDefault(person => person.PersonID == id);
}


public Person DeletePerson(int PersonID)
{
    foreach (Person item in personList)
    {
        if (item.PersonID == PersonID)
        {
            personList.Remove(item);
        }

        return person;

    }
}

/*

public bool DeletePerson(int id)
{
    return _personRepo.Delete(id);
}

*/

/*

public bool Delete(int id)
{
    foreach (Person item in personList)
    {
        if (item.PersonID == id)
        {
            personList.Remove(item);
            return true;
        }
    }
    return false;
}



public Person Search(int id)
{
    return personList.SingleOrDefault(person => person.PersonID == id);
}





public List<Person> Search(string text)
{
    List<Person> matches = new List<Person>();

    foreach (Person item in personList)
    {
        if (item.Name == text || item.City == text || item.PhoneNumber == text)
        {
            matches.Add(item);
        }
    }



    return matches;
}






/*


public Person Add(CreatePersonViewModel personViewModel)
{
    if (string.IsNullOrWhiteSpace(personViewModel.Name) || string.IsNullOrWhiteSpace(personViewModel.City) || string.IsNullOrWhiteSpace(personViewModel.PhoneNumber))
    {
        return null;
    }
    Person newCodeInfo = new Person()
    {
        Name = personViewModel.Name,
        City = personViewModel.City,
        PhoneNumber = personViewModel.PhoneNumber
    };

    Person Create(Person person);

    Person person = Create(newPerson);

    return person;
}


*/





//Oklart vad denna gör... om den ska vara med?

/*
public List<CodeInfo> GetList()
{
    return _codeInfoRepo.Read();
}

*/




/*

public List<CodeInfo> Search(string text)
{
    if (string.IsNullOrWhiteSpace(text))
    {
        return new List<CodeInfo>();
    }

    var list = _codeInfoRepo.Read();
    List<CodeInfo> matches = new List<CodeInfo>();

    foreach (var item in list)
    {
        if (item.Code.Contains(text))
        {
            matches.Add(item);
        }
    }

    return matches;
}

*/


/*

public CodeInfo Edit(int id, CodeInfoCreateViewModel codeInfo)
{
    CodeInfo editCodeInfo = new CodeInfo()
    {
        Id = id,
        Code = codeInfo.Code,
        Explanation = codeInfo.Explanation
    };
    return _codeInfoRepo.Update(editCodeInfo);
}


}
}














//Tidigare version

/*



static int idCounter = 3;
public string filterInput = "";
private static List<Person> personList = new List<Person>();

static PersonService()
{
personList.Add(new Person() { PersonID = 1, Name = "Pölen", City = "Rottne" });
personList.Add(new Person() { PersonID = 2, Name = "Turbo", City = "Borås" });
personList.Add(new Person() { PersonID = 3, Name = "Lopez", City = "Skövde" });
personList.Add(new Person() { PersonID = 4, Name = "Greven", City = "Malmö" });

}

public List<Person> All()
{
return personList;
}
public Person Create(string name, string city, string phonenumber)
{
if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phonenumber))
{
return null;
}

Person person = new Person()
{
PersonID = ++idCounter,
Name = name,
City = city
};

personList.Add(person);
return person;
}

public bool Remove(int id)
{
foreach (Person item in personList)
{
if (item.PersonID == id)
{
    personList.Remove(item);
    return true;
}
}
return false;
}

public Person Find(int id)
{
return personList.SingleOrDefault(person => person.PersonID == id);
}

public List<Person> Filter(string filterInput)
{
List<Person> filterPersonList = new List<Person>();
foreach (Person item in personList)
{
if (item.Name == filterInput || item.City == filterInput)
{
    filterPersonList.Add(item);
}
}
return filterPersonList;
}








/*

public bool Update(PeopleViewModel peopleViewModel, int id)
{
if (peopleViewModel == null)
{
return false;
}

Person currentPerson = Find(id);

if (id == 0)
{
return false;
}

currentPerson.Name = peopleViewModel.Name;
currentPerson.City = peopleViewModel.City;

//personList.Update(currentPerson);

return true;
}

*/


