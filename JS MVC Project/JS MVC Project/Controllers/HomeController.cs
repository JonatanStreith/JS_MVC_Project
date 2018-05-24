using JS_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeverCheck(int temp, string scale)
        {
            ViewBag.TempMessage = FeverChecker.CheckTemp(temp, scale);

            return View();
        }

        public ActionResult FeverCheck()
        {
            return View();
        }



        [HttpPost]
        public ActionResult GuessingGame(int guess, string name)
        {

            int random = Convert.ToInt32(Session["randomNumber"]);
            
            Session["numberOfGuesses"] = Convert.ToInt32(Session["numberOfGuesses"]) +1;
            Session["choiceNumber"] = guess;


            if (guess < random)
            { Session["reply"] = "Too low!"; }
            else if (guess > random)
            { Session["reply"] = "Too high!"; }
            else
            {


                HttpCookie highScore = Request.Cookies["Highscore"];
                highScore[Convert.ToString(highScore.Values.Count+1)] = Convert.ToString(Session["numberOfGuesses"]);
                highScore.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(highScore);




                Session["reply"] = "That's right!";
                Session["numberOfGuesses"] = 0;
                Session["randomNumber"] = new Random().Next(100);



            }
            return View();
        }


        public ActionResult GuessingGame()
        {
            if (Request.Cookies.AllKeys.Contains("Highscore") == false)
            {
                HttpCookie highScore = new HttpCookie("Highscore");
                highScore.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(highScore);
            }




            if (Session["randomNumber"] == null)
            { Session["randomNumber"] = new Random().Next(100); }

            if(Session["choiceNumber"] == null)
            { Session["choiceNumber"] = 50; }

            if (Session["numberOfGuesses"] == null)
            { Session["numberOfGuesses"] = 0; }


            return View();
        }




        public ActionResult ListOfPeople()
        {

            //PeopleList personList = new PeopleList();

            List<PersonData> personList = new List<PersonData>();

            personList.Add(new PersonData("Jonatan Streith", "070-2560731", "Skövde"));
            personList.Add(new PersonData("Vladimir Putin", "0500-Communism", "Moscow"));
            personList.Add(new PersonData("Princess Celestia", "0500-Sunshine", "Canterlot"));
            personList.Add(new PersonData("Monkey D. Luffy", "020-GomuGomu", "Grand Line"));
            personList.Add(new PersonData("Sheogorath", "0660-CHEESE", "Shivering Isles"));

            return View(personList);
        }



    }
}