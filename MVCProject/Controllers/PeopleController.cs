using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System;
using System.Linq;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PeopleController : Controller
    {
        private readonly PersonContext _context;

        public PeopleController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult PeopleIndex()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View(new PeopleViewModel(_context.People

                //returning a viewmodel that includes city and country

                                    .Include(person => person.City)
                                    .Include(person => person.City.Country)
                                    .ToList()
                                    .Select(person => CreatePersonViewModel(person))
                                    .ToList()
                                    ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id, string Name, int CityId, string PhoneNumber, CreatePersonViewModel createPersonViewModel)
        
        {
            Person person = CreatePerson(createPersonViewModel);
            if (ModelState.IsValid)
            {
                _context.Add(person);
                _context.SaveChanges();
            }

            return RedirectToAction("PeopleIndex");
        }
        public IActionResult Edit(int id)
        {
            Person person = _context.People.FirstOrDefault(person => person.Id == id);

            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");   //returning a dropdown list of cities to choose from
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("PeopleIndex");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            var person = _context.People
                .Include(person => person.City)
                .FirstOrDefault(person => person.Id == id);

                _context.People.Remove(person);
                _context.SaveChanges();

            return RedirectToAction("PeopleIndex");
        }

        private Person CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            Person person = new Person();
            person.Name = createPersonViewModel.Name;
            person.City = createPersonViewModel.City;
            person.CityId = createPersonViewModel.CityId;
            person.PhoneNumber = createPersonViewModel.PhoneNumber;
            return person;
        }

        private PersonViewModel CreatePersonViewModel(Person person)
        {
            PersonViewModel model = new PersonViewModel();
            model.Id = person.Id;
            model.Name = person.Name;
            model.City = person.City;
            model.PhoneNumber = person.PhoneNumber;
            return model;
        }
    }
}