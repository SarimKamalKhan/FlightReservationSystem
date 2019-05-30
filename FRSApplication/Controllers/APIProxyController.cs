using DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FRSApplication.Controllers
{
    public class APIProxyController : Controller
    {

        private string ClassName = "APIProxy";

        public HttpResponseMessage APIConsumer(string URL, string HttpMethod, Dictionary<string, string> Header, Dictionary<string, string> RequestParams, string JSON, MultipartFormDataContent MultipartContent = null)
        {
            HttpResponseMessage Response = new HttpResponseMessage();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIURL"]);

            #region OverRideSSLValidation

            try
            {
                string OverRideSSLValidation = "yes";

                if (OverRideSSLValidation.ToLower() == "yes")
                {
                    SSLValidator.OverrideValidation();
                }
            }
            catch (Exception e)
            {
            }

            #endregion OverRideSSLValidation


            if (Header != null)
            {
                foreach (var Item in Header)
                {
                    Client.DefaultRequestHeaders.Add(Item.Key, Item.Value);
                }
            }

            switch (HttpMethod.ToUpper())
            {
                case "POST":
                    var StringContent = new StringContent(JSON, Encoding.UTF8, "application/json");

                    if (MultipartContent != null)
                    {
                        MultipartContent.Add(StringContent, "DisputeAddRequest");
                        Response = Client.PostAsync(URL, MultipartContent).Result;
                    }
                    else
                    {
                        Response = Client.PostAsync(URL, StringContent).Result;
                    }
                    break;

                case "GET":
                    if (RequestParams != null)
                    {
                        URL = URL + "/get?";
                        foreach (var item in RequestParams)
                        {
                            URL = URL += item.Key + "=" + item.Value + "&";
                        }
                        URL = URL.Remove(URL.Length - 1, 1);
                    }

                    Response = Client.GetAsync(URL).Result;
                    break;

                case "DELETE":
                    Response = Client.DeleteAsync(URL).Result;
                    break;

            }


            return Response;
        }

        public CityDTO GetCitiesByCountryCode(string Request)
        {
            string ActionName = ".GetCitiesByCountryCode";
            string Source = ClassName + ActionName;
            string ResponseJSON = string.Empty;
            TransactionResultsDTO Result = new TransactionResultsDTO();

            string URL = "businessapi/api/Home/GetCities/";
            string HttpMethod = "POST";

            try
            {
                string RequestJSON = JsonConvert.SerializeObject(Request, Formatting.Indented);

                var Response = APIConsumer(URL, HttpMethod, null, null, RequestJSON);

                ResponseJSON = Response.Content.ReadAsStringAsync().Result;

                GetCitiesResponseDTO response = JsonConvert.DeserializeObject<GetCitiesResponseDTO>(ResponseJSON);

                if (response != null && response.ResponseCode == "00")
                {
                    Result.IsSuccessful = true;
                    Result.ResponseCode = response.ResponseCode;
                    Result.ResponseDescription = response.ResponseMessage;
                }
                else
                {
                    Result.ResponseCode = "99";
                }

            }

            catch (Exception Ex)
            {
                //#region File Logging

                //LogManager.GetAutoStatusUpdate_WinLogger().Error(
                //    new LogMessage().AddSource(Source)
                //        .AddText("Exception", Ex.ToString())
                //);

                //#endregion File Logging

                Result.IsSuccessful = false;
            }

            return Result;
        }

    }


    public class SSLValidator
    {
        private static RemoteCertificateValidationCallback _orgCallback;

        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void OverrideValidation()
        {
            _orgCallback = ServicePointManager.ServerCertificateValidationCallback;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidateCertificate);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public static void RestoreValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = _orgCallback;
        }
    }
}
