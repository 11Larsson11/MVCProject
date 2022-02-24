using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Linq;

namespace MVCProject.Controllers
{

    public class PersonLanguageController : Controller
        {
            private readonly PersonContext _context;

            public PersonLanguageController(PersonContext context)
            {
                _context = context;
            }

            public IActionResult Index()
            {
                ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name");   //Sending in data to the dropdown menu
                ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
                return View(new PersonLanguageViewModel(_context.PersonLanguage
                            .Include(p => p.Language)
                            .Include(p => p.Person).ToList()
                    )); ;
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(int PersonId, int LanguageId, PersonLanguage personLanguage)
            {
                _context.Add(personLanguage);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            public IActionResult Delete(int? id)
            {

                var personLanguage = _context.PersonLanguage
                    .Include(p => p.Language)
                    .Include(p => p.Person)
                    .FirstOrDefault(m => m.PersonId == id);

                _context.PersonLanguage.Remove(personLanguage);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }

