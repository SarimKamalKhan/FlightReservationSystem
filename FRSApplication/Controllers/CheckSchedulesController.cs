using Models.Requests;
using Models.Responses;
using Newtonsoft.Json;
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

        [HttpPost]
        public JsonResult GetFlightSchedules(GetFlightSchedulesRequest request)
        {
            string actionName = ".GetFlightSchedules";
            string source = ControllerName + actionName;
            string responseJSON = string.Empty;

            GetFlightSchedulesResponse getFlightSchedulesResponse = new GetFlightSchedulesResponse();

            try
            {
                bool isProcessed = false;
                isProcessed = APIFacadeProxy.GetFlightSchedules(request, out responseJSON);

                if (!string.IsNullOrEmpty(responseJSON))
                    getFlightSchedulesResponse = JsonConvert.DeserializeObject<GetFlightSchedulesResponse>(responseJSON);

                return Json(getFlightSchedulesResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(getFlightSchedulesResponse, JsonRequestBehavior.AllowGet);
            }
        }
    }
}