using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class FeverChecker
    {

        public static string TempChecking(int temp)
        {
            if (temp >= 38 && temp < 45)
            {
                string diagnosis = "You have a fever!";

                return diagnosis;
                               
            }

            else if (temp > 15 && temp <= 35)
            {
                string diagnosis = "You are suffering from hypothermia.";

                return diagnosis;
            }


            else if (temp > 35 && temp < 38)
            {
                string diagnosis = "You're fine.";

                return diagnosis;
            }

            else
            {
                string diagnosis = "noInfo";
                return diagnosis;
            }
             
        }
    }
}


