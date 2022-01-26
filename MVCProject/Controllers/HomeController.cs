using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IntroMessage = "Hello and welcome!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.ContactMessage = "You can contact mr. Larsson via mail:";

            return View();
        }

        public IActionResult About()
        {

            ViewBag.Message = "I’m a creative product developer with a passion for finding solutions to problems. I have worked in a wide range of projects, from the car industry to app development. As a person, I am creative, analytical, and open-minded.";

            return View();
        }

        public IActionResult Projects()
        {
            ViewBag.ProjectMessage = "More projects are incoming.";

            return View();
        }
    }
}
