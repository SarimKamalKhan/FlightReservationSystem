using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace FRSApplication.Controllers
{
    public class BookFlightController : Controller
    {
        // GET: BookFlight
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetCities()
        {
            var Countries = new List<string>();
            Countries.Add("Karachi");
            Countries.Add("Islamabad");
            Countries.Add("Lahore");
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        [HttpPost]
        //[Route("/FRSApplication/BookFlight/GetCountriesName")]
        public static List<string> GetCountriesName()
        {
            List<string> lst = new List<string>();
            lst.Add("India");
            lst.Add( "Nepal");
            lst.Add("America" );
            return lst;

        }
    }
}