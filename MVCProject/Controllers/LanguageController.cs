using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Linq;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        private readonly PersonContext _context;

        public LanguageController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new LanguageViewModel(_context.Language.ToList())); //Returning view with all languages
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id, string Name, Language language)
        {
            _context.Add(language);
            _context.SaveChanges();
          
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var language = _context.Language
                .FirstOrDefault(language => language.Id == id);

            _context.Language.Remove(language);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
