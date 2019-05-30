using Models.Responses;
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
            GetCitiesResponse getCitiesResponse = new GetCitiesResponse();

            try
            {
                if(!string.IsNullOrEmpty(Models.ApplicationSettings.Cities))
                {
                    //Fetch countries from static list as saved at the time of application start
                    jsonCities = Models.ApplicationSettings.Cities;

                }
                else
                {
                    //Fetch from DB and set on static list
                    GetCities();
                }

                if(!string.IsNullOrEmpty(jsonCities))
                      getCitiesResponse = JsonConvert.DeserializeObject<GetCitiesResponse>(jsonCities);

                return Json(getCitiesResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(getCitiesResponse, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetAirLineByCountryCode()
        {
            string actionName = ".GetAirLineByCountryCode";
            string source = ControllerName + actionName;
            string jsonAirlines = string.Empty;
            GetAirlinesResponse getAirlineResponse = new GetAirlinesResponse();

            try
            {
                if (!string.IsNullOrEmpty(Models.ApplicationSettings.AirLines))
                {
                    //Fetch countries from static list as saved at the time of application start
                    jsonAirlines = Models.ApplicationSettings.AirLines;

                }
                else
                {
                    //Fetch from DB and set on static list
                    GetAirlines();
                }

                if (!string.IsNullOrEmpty(jsonAirlines))
                    getAirlineResponse = JsonConvert.DeserializeObject<GetAirlinesResponse>(jsonAirlines);

                return Json(getAirlineResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(getAirlineResponse, JsonRequestBehavior.AllowGet);
            }
        }

        private void GetCities()
        {
            string countryCode = ConfigurationManager.AppSettings["CountryCode"];
            string jsonCountries = string.Empty;

            bool isProcessed = APIFacadeProxy.GetCitiesByCountryCode(countryCode, out jsonCountries);

            Models.ApplicationSettings.Cities = jsonCountries;
        }

        private void GetAirlines()
        {
            string countryCode = ConfigurationManager.AppSettings["CountryCode"];
            string jsonCountries = string.Empty;

            bool isProcessed = APIFacadeProxy.GetAirLinesByCountryCode(countryCode, out jsonCountries);

            Models.ApplicationSettings.AirLines = jsonCountries;
        }


        [HttpPost]
        public JsonResult GetTravelCategory()
        {
            List<string> TravelCategory = new List<string>();
            TravelCategory.Add("First");
            TravelCategory.Add("Business");
            TravelCategory.Add("Economy");
            return Json(TravelCategory, JsonRequestBehavior.AllowGet);
        }
    }
}