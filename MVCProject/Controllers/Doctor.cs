using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCProject.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult FeverCheck(int temp)
        {
            ViewBag.diagnosis = FeverChecker.TempChecking(temp);

            return View();
        }
    }
}
