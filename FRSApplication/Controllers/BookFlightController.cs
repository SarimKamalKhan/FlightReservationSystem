using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using static DataTransferObjects.TransactionResultsDTO;

namespace FRSApplication.Controllers
{

    public class BookFlightController : Controller
    {
        // GET: BookFlight
        public ActionResult Index()
        {
            return View();
        }




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



        [HttpPost]
        [Route("/BookFlight/GetAirLine")]
        public JsonResult GetAirLine()
        {
            List<string> AirLine = new List<string>();
            AirLine.Add("PIA");
            AirLine.Add("Serene");
            AirLine.Add("AirBlue");

            string countryCode = "PK";

            TransactionResultDTO tempTranResDTO = new TransactionResultDTO();

            string serializedTransaction = JsonConvert.SerializeObject(countryCode);

           
            //having issue in it
            // tempTranResDTO = APIProxyController.GetCitiesByCountryCode(serializedTransaction);

            return Json(AirLine, JsonRequestBehavior.AllowGet);
        }
    }
}