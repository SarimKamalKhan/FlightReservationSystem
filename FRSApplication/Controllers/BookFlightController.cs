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


        //[HttpPost]
        //[Route("BookFlight/GetCountriesName")]

        //public static List<string> GetCountriesName()
        //{
        //    List<string> lst = new List<string>();
        //    lst.Add("Pakistan");
        //    lst.Add("Norway");
        //    lst.Add("America");
        //    return lst;

        //}


        [HttpPost]
        [Route("/BookFlight/GetCountriesName")]
        public JsonResult GetCitiesName()
        {
            List<string> city = new List<string>();
            city.Add("Karachi");
            city.Add("Islamabad");
            city.Add("Lahore");
            return Json(city, JsonRequestBehavior.AllowGet);
        }
    }
}