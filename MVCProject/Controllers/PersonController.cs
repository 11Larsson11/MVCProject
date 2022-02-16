using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PersonController()
        {
            _personService = new PersonService();   //An instance to reach 
        }

        public ActionResult PersonIndex()
        {
            PeopleViewModel model = new PeopleViewModel();
            model.AllPersons = _personService.GetList();

            return View(model.AllPersons);

        }


        [HttpGet]
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

                if (person != null)
                {
                    return RedirectToAction(nameof(PersonIndex), "Person");
                }

                ModelState.AddModelError("Storage", "Failed to save");
            }

            return Redirect("PersonIndex");

        }
   

        public IActionResult Search(string text)
        {
            return View("PersonIndex", _personService.Search(text));
        }

        [HttpGet]
        public IActionResult SearchPartial()
        {
            return PartialView("_SearchPartial");
        }

        [HttpPost]
        public IActionResult SearchPartial(string text)
        {
            return PartialView("_SearchPartial", _personService.Search(text));
        }


        public IActionResult Details(int id)
        {
            Person person = _personService.GetById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(PersonIndex));
            }

            return View(person);
        }

        public IActionResult DeletePerson(int Id)
        {
            
            try
            {
                _personService.DeletePerson(Id);
            }
            catch
            
            {
                ViewBag.msg = "It can't be true. Something went wrong!";
            }

            return RedirectToAction("PersonIndex");
        }
    }
}