using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSApplication.Controllers
{
    public class CheckSchedulesController : Controller
    {
        private string ControllerName = "CheckSchedulesController";
        // GET: CheckSchedules
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFlightSchedules(GetFlightSchedulesRequest request)
        {
            string actionName = ".GetFlightSchedules";
            string source = ControllerName + actionName;
            string responseJSON = string.Empty;

            try
            {
                bool isProcessed = false;
                isProcessed = APIFacadeProxy.GetFlightSchedules(request, out responseJSON);

                return Json(new
                {
                    isSuccess = true,
                    flightSchedule = responseJSON,
                  
                });
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    isSuccess = false,
                    flightSchedule = responseJSON,

                });
            }
        }
    }
}