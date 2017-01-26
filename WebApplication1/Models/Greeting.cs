using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Greeting
    {
        public string message;
        public string name;

        public Greeting()
        {
            // constructor method called when initialized, i.e. Greeting g = new Greeting()
            message = "";
            name = "";
        }
      
        public string sayGreeting()
        {
            return message + ", " + name + "!";
        }
    }
}