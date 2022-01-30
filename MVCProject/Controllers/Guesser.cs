using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{

    public class Guesser : Controller
    {

        public int RandomGenerator()
        {
            Random rand = new Random();
            return rand.Next(1, 100);
        }

        public IActionResult GuessingGame()
        {

            int actualRandomNr = RandomGenerator();
            HttpContext.Session.SetString("NewRand", actualRandomNr.ToString());
         
            return View();

        }

        [HttpPost]
        public IActionResult GuessingGame(string userGuess)
        {

            string sessionNr = HttpContext.Session.GetString("NewRand");
            int randomNr;

            bool existingRandom = int.TryParse(sessionNr, out randomNr);

            while (!existingRandom)
            {
                Redirect("GuessingGame");   //avoiding the void situation
            }
            

            int parsedGuess;

            bool correctInput = int.TryParse(userGuess, out parsedGuess);
            while (!correctInput)

            {
                ViewBag.GuessResponse = "Guess a number between 1 and 100"; //Prompting the user to enter a correct value
                return View();
            }


        if (parsedGuess > randomNr && parsedGuess <= 100)
        {
            ViewBag.GuessResponse = "Too high. Try a lower number...";
        }

        if (parsedGuess < randomNr && parsedGuess >= 1)
        {
            ViewBag.GuessResponse = "Too low. Try a higher number...";
        }

        if (parsedGuess == randomNr)
        {
            ViewBag.GuessResponse = "Correct";
        }
            
            return View();

        }
    }
}



    
