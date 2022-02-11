using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPersonService _personService;

        public AjaxController()
        {
            _personService = new PersonService();   //An instance to reach 
        }

        public IActionResult PersonIndex()
        {
            return View();
        }


        public IActionResult PartialViewAll()
        {

            PeopleViewModel model = new PeopleViewModel();
            model.AllPersons = _personService.GetList();

            return PartialView("_PartialViewAll", model.AllPersons);

        }

        
        [HttpPost]
        public IActionResult DeleteId(int Id)
        {

            if( _personService.GetById(Id) != null)
            {
                _personService.DeletePerson(Id);
                ViewBag.msg = "Person successfully removed";
                return PartialView("_PartialDeletePerson", StatusCode(200));
            }

            else
            {
                ViewBag.msg = "Person was not removed";
                return PartialView("_PartialDeletePerson", StatusCode(404));
            }
        }

        [HttpPost]
        public IActionResult FindId(int Id)
        {

            if (_personService.GetById(Id) != null)
            {
                var person = _personService.GetById(Id);
                var selectedPerson = new List<Person>();
                
                    
                selectedPerson.Add(person);
                return PartialView("_PartialViewAll", selectedPerson);
            }

            else
            {
                ViewBag.msg = "No such ID exist";
                return PartialView("_PartialDeletePerson");
            }
        }
    }
}

