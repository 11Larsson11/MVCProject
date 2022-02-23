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
    public class PersonController : Controller
    {

        private readonly IPersonService _personService;

        private readonly PersonContext _context;
        public PersonController(IPersonService personService, PersonContext context)
        {
            _personService = personService;
            _context = context;
        }

        [HttpGet]
        public ActionResult PersonIndex()
        {
            //PeopleViewModel model = new PeopleViewModel();
            //model.People = _personService.GetList();
            //return View(model.People);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, PhoneNumber, CityId")] CreatePersonViewModel createPersonViewModel)
        {
            Person person = CreatePerson(createPersonViewModel);
            if (ModelState.IsValid)
            {
                _context.Add(person);
                _context.SaveChanges();

            }

            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", person.CityId);
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var person = _context.People
                .FirstOrDefault(person => person.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Person CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            Person person = _personService.Add(createPersonViewModel);
            return person;
        }
    }
}