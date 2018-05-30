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
            new PersonData(){ Id = "1", Name = "Jonatan Streith", Phone = "070-2560731", City = "Skövde" },
            new PersonData(){ Id = "2", Name = "Vladimir Putin", Phone = "0500-Communism", City = "Moscow" },
            new PersonData(){ Id = "3", Name = "Princess Celestia", Phone = "0500-Sunshine", City = "Canterlot" },
            new PersonData(){ Id = "4", Name = "Monkey D. Luffy", Phone = "020-GomuGomu", City = "Grand Line" },
            new PersonData(){ Id = "5", Name = "Sheogorath", Phone = "0660-CHEESE", City = "Shivering Isles" }

        };


        public static void AddPersonToList(string name, string phone, string city)
        {

            string id = Convert.ToString(personList.Count + 1);

            personList.Add(new PersonData() { Id = id, City = city, Name = name, Phone = phone });
        }

        public static void RemovePersonFromList(string id)
        {


            personList.Remove(personList.Find(p => p.Id == id));
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


        public static void ReplacePerson(PersonData person)
        {
            int pos = personList.IndexOf(personList.Find(p => p.Id == person.Id));

            personList.RemoveAt(pos);
            personList.Insert(pos, person);

        }



        public static List<PersonData> FilterList(string filter, bool caseSensitive)
        {

            List<PersonData> filteredList = new List<PersonData>();

            if (caseSensitive)
            {
                foreach (PersonData person in personList)
                {
                    if (person.Name.Contains(filter))
                    { filteredList.Add(person); }
                }
            }
            else
            {
                foreach (PersonData person in personList)
                {
                    if (person.Name.ToLower().Contains(filter.ToLower()))
                    { filteredList.Add(person); }
                }
            }

            return filteredList;
        }

    }
}