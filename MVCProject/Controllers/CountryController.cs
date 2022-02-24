﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataModels;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Linq;

namespace MVCProject.Controllers
{
    public class CountryController : Controller
    {
        private readonly PersonContext _context;

        public CountryController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new AllCountriesViewModel(_context.Countries.ToList()
                .Select(country => CreateCountryViewModel(country)).ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id, string Name, Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public IActionResult Delete(int id)
        {
            var country = _context.Countries
                .Include(country => country.Cities)

                .FirstOrDefault(m => m.Id == id);

                _context.Countries.Remove(country);
                _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private CountryViewModel CreateCountryViewModel(Country country)
        {
            CountryViewModel model = new CountryViewModel();
            model.CountryId = country.Id;
            model.Name = country.Name;
            model.Cities = country.Cities;
            return model;
        }
    }
}