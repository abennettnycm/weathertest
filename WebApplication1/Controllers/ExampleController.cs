using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class ExampleController : Controller
    {
       public ActionResult Hello()
        {
            Greeting g = new Models.Greeting();
            g.message = "Hola";
            g.name = "Caitlyn";


            ViewData["greeting"] = g.sayGreeting();
            return View();
        }
        public ActionResult Goodbye()
        {
            Greeting g = new Models.Greeting();
            g.message = "Adios";
            g.name = "Illaoi";


            ViewData["greeting"] = g.sayGreeting();
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        private class WeatherJSON
        {
            public string weather { get; set; }
        }
        public JsonResult WeatherFetch()
          {
            string zip = "";
            string mainWeather = "";
           zip = Request.Form["zip"];

            StreamReader reader = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string responseString = "";

            try
              {
                 // send request
                 request = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zip + ",us&appid=3691ef5b0e7eb51321af29db371a4946&units=imperial");
                 request.Method = "POST";
                 request.ContentType = "application/json";
               
                 using (Stream requestStream = request.GetRequestStream())
                 {
                     response = (HttpWebResponse)request.GetResponse();
                     using (Stream responseStream = response.GetResponseStream())
                     {
                        reader = new StreamReader(responseStream);
                        responseString = reader.ReadToEnd();
                        // test
                    }
                 }
                return Json(new { response = responseString });
              }
              catch (Exception e)
              {
                return Json(new {error = e });
            }
              finally
              {
                  // clean up
                  reader.Close();
                  reader.Dispose();
              }
              
            

        }
    }
}