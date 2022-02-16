using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonContext _context;
        private readonly IPersonService _personService;

        public PeopleController(PersonContext context)
        {
            _context = context;
            _personService = new PersonService();
        }


        public IActionResult PeopleIndex()
        {

            var newList = new PeopleViewModel
            {
                AllPersons = _context.People.ToList()   //The Linq
            };

            return View(newList);

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _personService.Add(createViewModel);

                Person newPerson = new Person();
        

                newPerson.Name = person.Name;
                newPerson.City = person.City;
                newPerson.PhoneNumber = person.PhoneNumber;

                _context.People.Add(newPerson);
                _context.SaveChanges();


                if (person != null)
                {
                    return RedirectToAction(nameof(PeopleIndex), "People");
                }

                ModelState.AddModelError("Storage", "Failed to save");
            }

            return Redirect("PeopleIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePeople(int Id)
        {
            //if (Id != 0)
            try
            {
                var personToRemove =_context.People.Find(Id);

                _context.People.Remove(personToRemove);
                _context.SaveChanges();

                return Redirect("PeopleIndex");
             }
            
            //else
            catch
            {
                ViewBag.msg = "It can't be true. Something went wrong!";
            }

            return RedirectToAction("PeopleIndex");
        }
    }
}
