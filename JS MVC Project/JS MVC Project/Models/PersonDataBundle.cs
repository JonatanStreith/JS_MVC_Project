using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_MVC_Project.Models
{
    public class PersonDataBundle
    {

        public List<PersonData> TheList { get; set; }
        public int TheListStart { get; set; }
    }
}