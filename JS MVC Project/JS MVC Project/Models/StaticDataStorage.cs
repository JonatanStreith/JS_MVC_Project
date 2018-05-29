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
            new PersonData("1", "Jonatan Streith", "070-2560731", "Skövde"),
            new PersonData("2", "Vladimir Putin", "0500-Communism", "Moscow"),
            new PersonData("3", "Princess Celestia", "0500-Sunshine", "Canterlot"),
            new PersonData("4", "Monkey D. Luffy", "020-GomuGomu", "Grand Line"),
            new PersonData("5", "Sheogorath", "0660-CHEESE", "Shivering Isles")

        };


        public static void AddPersonToList(string id, string name, string phone, string city)
        {
            personList.Add(new PersonData(id, name, phone, city));
        }

        public static void RemovePersonFromList(PersonData person)
        {
            personList.Remove(person);
        }



        public static void SortList(string category)
        {

            switch (category)
            {
                case "Name":
                    personList.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;

                case "R. Name":
                    personList.Sort((x, y) => y.Name.CompareTo(x.Name));
                    break;

                case "City":
                    personList.Sort((x, y) => x.City.CompareTo(y.City));
                    break;

                case "R. City":
                    personList.Sort((x, y) => y.City.CompareTo(x.City));
                    break;

                default:
                    break;
            }




        }



    }
}