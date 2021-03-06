﻿using JS_MVC_Project.Models;
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

            Session["numberOfGuesses"] = Convert.ToInt32(Session["numberOfGuesses"]) + 1;
            Session["choiceNumber"] = guess;


            if (guess < random)
            { Session["reply"] = "Too low!"; }
            else if (guess > random)
            { Session["reply"] = "Too high!"; }
            else
            {
                HttpCookie highScore = Request.Cookies["Highscore"];
                highScore[Convert.ToString(highScore.Values.Count + 1)] = Convert.ToString(Session["numberOfGuesses"]);
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

            if (Session["choiceNumber"] == null)
            { Session["choiceNumber"] = 50; }

            if (Session["numberOfGuesses"] == null)
            { Session["numberOfGuesses"] = 0; }

            return View();
        }





        public ActionResult Experimental()
        {
            return View();
        }

        //----------------------------------



        public ActionResult ListOfPeople()
        {

            if (Request.IsAjaxRequest())
            {

                if (ModelState.IsValid)
                {

                return PartialView("PV_EditPerson");
                }

            }

            return View(StaticDataStorage.personList);
        }






        public ActionResult DisplayTable()
        {


            if (ModelState.IsValid)
            {

                return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });

        }
            return View(StaticDataStorage.personList);

        }





    [HttpPost]
        public ActionResult FilterList(string filter, bool caseSensitive)
        {

            if (ModelState.IsValid)
            {


                StaticDataStorage.FilterList(filter, caseSensitive);

                return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });


            }
            return View(StaticDataStorage.personList);
        }



        [HttpPost]
        public ActionResult ClearFilter()
        {

            if (ModelState.IsValid)
            {


            StaticDataStorage.ClearFilter();

            return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });


            }

            return View(StaticDataStorage.personList);

        }




        [HttpPost]
        public ActionResult AddPerson(string name, string phone, string city)
        {
            if (ModelState.IsValid)
            {

            StaticDataStorage.AddPersonToList(name, phone, city);

            return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });
            }
            return View(StaticDataStorage.personList);

        }




        [HttpPost]
        public ActionResult SortList(string pressedButton)
        {
            if (ModelState.IsValid)
            {

            StaticDataStorage.SortList(pressedButton);

            return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });
            }
            return View(StaticDataStorage.personList);
        }



        public ActionResult EditListEntry(string id)
        {

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {


                return PartialView("PV_EditPerson", id);

            }
                }


            return View("ListOfPeople", StaticDataStorage.personList);
        }

        [HttpPost]
        public ActionResult MakeEdit([Bind(Include = "Id, Name, Phone, City")] PersonData data)
        {

            if (ModelState.IsValid)
            {
                StaticDataStorage.ReplacePerson(data);
                return PartialView("PV_Person", data);
            }

            return View("ListOfPeople", StaticDataStorage.personList);
        }

        [HttpPost]
        public ActionResult RemoveListEntry(string id)
        {

            if (ModelState.IsValid)
            {
                StaticDataStorage.RemovePersonFromList(id);


                return PartialView("PV_Blank");
            }


            return View("ListOfPeople", StaticDataStorage.personList);

        }

        public ActionResult PrevNext(string pressedButton)
        {

            if (ModelState.IsValid)
            {

                if (pressedButton == "Prev 10")
                {
                    if(StaticDataStorage.displayIndex > 0) { StaticDataStorage.displayIndex -= 10;}

                    
                }
                else if (pressedButton == "Next 10")
                {
                    if (StaticDataStorage.displayIndex < (StaticDataStorage.personList.Count-10)) { StaticDataStorage.displayIndex += 10; }
                }




                return PartialView("PV_PersonTable", new PersonDataBundle { TheList = StaticDataStorage.personList, TheListStart = StaticDataStorage.displayIndex });






            }



            return View("ListOfPeople", StaticDataStorage.personList);


        }













        public string GetStuff()
        {
            return "Stuff!";
        }




    }
}