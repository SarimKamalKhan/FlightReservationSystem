using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FRSApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GetCitiesByCountryCode();
            GetAirLinesByCountryCode();
        }

        private void GetAirLinesByCountryCode()
        {
            string countryCode = ConfigurationManager.AppSettings["CountryCode"];
            string jsonCountries = string.Empty;

            bool isProcessed = APIFacadeProxy.GetAirLinesByCountryCode(countryCode, out jsonCountries);

            Models.ApplicationSettings.AirLines = jsonCountries;
        }

        private void GetCitiesByCountryCode()
        {
            string countryCode = ConfigurationManager.AppSettings["CountryCode"];
            string jsonCountries = string.Empty;

            bool isProcessed = APIFacadeProxy.GetCitiesByCountryCode(countryCode, out jsonCountries);

            Models.ApplicationSettings.Cities = jsonCountries;
        }
    }
}
