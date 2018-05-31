using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_MVC_Project.Models
{
    public static class StaticDataStorage
    {

        public static int displayIndex = 0;


        public static List<PersonData> fullList = new List<PersonData>()
        {
            new PersonData(){ Id = "1", Name = "Jonatan Streith", Phone = "070-2560731", City = "Skövde" },
            new PersonData(){ Id = "2", Name = "Vladimir Putin", Phone = "0500-Communism", City = "Moscow" },
            new PersonData(){ Id = "3", Name = "Princess Celestia", Phone = "0500-Sunshine", City = "Canterlot" },
            new PersonData(){ Id = "4", Name = "Monkey D. Luffy", Phone = "020-GomuGomu", City = "Grand Line" },
            new PersonData(){ Id = "5", Name = "Sheogorath", Phone = "0660-CHEESE", City = "Shivering Isles" },
            new PersonData(){ Id = "6", Name = "Number 2", Phone = "0200-22222", City = "The Village" },
            new PersonData(){ Id = "7", Name = "Laharl", Phone = "No", City = "Netherworld" },
            new PersonData(){ Id = "8", Name = "Bob", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "9", Name = "Dave", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "10", Name = "Jane", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "11", Name = "Slagathor", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "12", Name = "Ushnik Yan", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "13", Name = "Greg", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "14", Name = "2nd Greg", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "15", Name = "Caboose", Phone = "Blank", City = "Bloodgulch" },
            new PersonData(){ Id = "16", Name = "Faceless Protagonist", Phone = "Blank", City = "Hero City" },
            new PersonData(){ Id = "17", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "18", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "19", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "20", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "21", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "22", Name = "Blank", Phone = "Blank", City = "Blank" },
            new PersonData(){ Id = "23", Name = "Blank", Phone = "Blank", City = "Blank" }

        };

        public static List<PersonData> personList = new List<PersonData>(fullList);


        public static void AddPersonToList(string name, string phone, string city)
        {

            string id = Convert.ToString(personList.Count + 1);

            personList.Add(new PersonData() { Id = id, City = city, Name = name, Phone = phone });
            fullList.Add(new PersonData() { Id = id, City = city, Name = name, Phone = phone });
        }

        public static void RemovePersonFromList(string id)
        {


            personList.Remove(personList.Find(p => p.Id == id));
            fullList.Remove(personList.Find(p => p.Id == id));
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

            fullList.RemoveAt(pos);
            fullList.Insert(pos, person);

        }



        public static void FilterList(string filter, bool caseSensitive)
        {

            personList.Clear();

            if (caseSensitive)
            {
                foreach (PersonData person in fullList)
                {
                    if (person.Name.Contains(filter))
                    { personList.Add(person); }
                }
            }
            else
            {
                foreach (PersonData person in fullList)
                {
                    if (person.Name.ToLower().Contains(filter.ToLower()))
                    { personList.Add(person); }
                }
            }
                      
        }

        public static void ClearFilter()
        {
            personList.Clear();
            personList.AddRange(fullList);
        }


    }
}