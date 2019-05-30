using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace FRSApplication.Controllers
{

    public class BookFlightController : Controller
    {
        private string ControllerName = "BookFlight";

        // GET: BookFlight
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCitiesByCountryCode()
        {
            string actionName = ".GetCitiesByCountryCode";
            string source = ControllerName + actionName;
            string jsonCities = string.Empty;

            try
            {
                if(!string.IsNullOrEmpty(Models.ApplicationSettings.Countries))
                {
                    //Fetch countries from static list as saved at the time of application start
                    jsonCities = Models.ApplicationSettings.Countries;

                }
                else
                {
                    //Fetch from DB and set on static list
                    GetCities();
                }

                return Json(new
                {
                    isSuccess = true,
                    response = jsonCities,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    isSuccess = false,
                    response = jsonCities,
                });
            }
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

            //TransactionResultDTO tempTranResDTO = new TransactionResultDTO();

            string serializedTransaction = JsonConvert.SerializeObject(countryCode);

           
            //having issue in it
            // tempTranResDTO = APIProxyController.GetCitiesByCountryCode(serializedTransaction);

            return Json(AirLine, JsonRequestBehavior.AllowGet);
        }

        private void GetCities()
        {
            string countryCode = ConfigurationManager.AppSettings["CountryCode"];
            string jsonCountries = string.Empty;

            bool isProcessed = APIFacadeProxy.GetCitiesByCountryCode(countryCode, out jsonCountries);

            Models.ApplicationSettings.Countries = jsonCountries;
        }
    }
}