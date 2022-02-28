using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Linq;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly PersonContext _context;

        public CityController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View(new AllCitiesViewModel(_context.Cities

                //returning a view that includes country

                        .Include(city => city.Country)
                        .ToList()
                        .Select(city => CreateCityViewModel(city))
                        .ToList()
                    )
                );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id, string Name, int CountryId, City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            return View(CreateCityViewModel(city));
        }

        public IActionResult Edit(int id)
        {
            City city = _context.Cities.FirstOrDefault(city => city.Id == id);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");   //returning a dropdown list of countries to choose from
            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var city = _context.Cities
                .Include(city => city.Country)
                .Include(city => city.Persons)
                .FirstOrDefault(city => city.Id == id);
            
                _context.Cities.Remove(city);
                _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private CityViewModel CreateCityViewModel(City city)
        {
            CityViewModel model = new CityViewModel();
            model.Id = city.Id;
            model.Name = city.Name;
            model.Country = city.Country;
            model.CountryId = city.CountryId ?? default(int);
            return model;
        }
    }
}