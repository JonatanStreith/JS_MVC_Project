using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_MVC_Project.Models
{
    public static class StaticDataStorage
    {

        public static List<PersonData> personList = new List<PersonData>()
        {
            new PersonData("Jonatan Streith", "070-2560731", "Skövde"),
            new PersonData("Vladimir Putin", "0500-Communism", "Moscow"),
            new PersonData("Princess Celestia", "0500-Sunshine", "Canterlot"),
            new PersonData("Monkey D. Luffy", "020-GomuGomu", "Grand Line"),
            new PersonData("Sheogorath", "0660-CHEESE", "Shivering Isles")

        };
        

        public static void AddPersonToList(string name, string phone, string city)
        {
            personList.Add(new PersonData(name, phone, city));
        }

        public static void RemovePersonFromList(PersonData person)
        {
            personList.Remove(person);
        }


    }
}