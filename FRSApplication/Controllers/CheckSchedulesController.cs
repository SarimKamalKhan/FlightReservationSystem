using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSApplication.Controllers
{
    public class CheckSchedulesController : Controller
    {
        // GET: CheckSchedules
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckFlightSchedules()
        {
            string actionName = ".CheckFlightSchedules";
            string source = ControllerName + actionName;
            string responseJSON = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(request.pp_SecureHash))
                {
                    request.pp_SecureHash = "";
                }

                TransactionResultDTO result = ServiceClient.APIProxy.Pay(request, out responseJSON);

                #region File Logging

                LogManager.GetSandboxLogger().Info(
                    new LogMessage().AddSource(source)
                    .AddUserIdentifier("Sandbox")
                    .AddText("PAY returned", result.ResponseCode)
                    );

                #endregion File Logging

                #region File Logging

                LogManager.GetSandboxLogger().Info(
                    new LogMessage().AddSource(source)
                    .AddUserIdentifier("Sandbox")
                    .AddText("PAY response", !string.IsNullOrEmpty(responseJSON) ? responseJSON : string.Empty)
                    );

                #endregion File Logging

                return Json(new
                {
                    loginStatus = true,
                    status = result.IsSuccessful,
                    message = result.ResponseDescription,
                    transaction = responseJSON,
                    httpStatus = result.StatusCode
                });
            }
            catch (Exception ex)
            {
                #region File Logging

                LogManager.GetSandboxLogger().Error(
                    new LogMessage().AddSource(source)
                    .AddText("Exception", ex.ToString())
                    .AddUserIdentifier("Sandbox")
                );

                #endregion File Logging

                return Json(new
                {
                    loginStatus = false,
                    status = false,
                    message = Messages.GenError,
                    transaction = "",
                    httpStatus = InternalServerError
                });
            }
        }
    }
}