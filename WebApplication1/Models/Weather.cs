using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Weather : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }
    }
}