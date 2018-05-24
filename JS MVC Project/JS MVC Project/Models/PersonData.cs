using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_MVC_Project.Models
{
    public class PersonData
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }



        public PersonData(string _name, string _phone, string _city)
        {
            Name = _name;
            Phone = _phone;
            City = _city;
        }
    }
}