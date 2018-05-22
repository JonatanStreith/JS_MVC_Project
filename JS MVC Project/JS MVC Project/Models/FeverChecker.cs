using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_MVC_Project.Models
{
    public class FeverChecker
    {
        public static string CheckTemp(double temperature, string scale)
        {

            if(scale == null) 
            { return "Please choose a temperature scale."; }

            switch (scale)
            {
                case "Celsius":
                    {
                        if (temperature > 37.8)
                        { return "You're running a fever!";                      }
                        else if (temperature < 36) { return "You're having hypothermia!"; }
                        else { return "You're fine."; }

                    }


                case "Farenheit":
                    {



                        if (temperature > 100)
                        { return "You're running a fever!"; }
                        else if (temperature < 96.8) { return "You're having hypothermia!"; }
                        else { return "You're fine."; }



                    }

                default:
                    return "Something went wrong, and it's your fault.";



            }

        }

    }
}