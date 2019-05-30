using Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FRSApplication
{
    public static class APIFacadeProxy
    {
        private static string ClassName = "APIFacadeProxy";
        public static HttpResponseMessage APIConsumer(string URL, string HttpMethod, Dictionary<string, string> Header, Dictionary<string, string> RequestParams, string JSON, MultipartFormDataContent MultipartContent = null)
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

        public static bool GetCitiesByCountryCode(string countryCode, out string responseJSON)
        {
            string actionName = ".GetCitiesByCountryCode";
            string source = ClassName + actionName;
            responseJSON = string.Empty;
            bool isProcessed = false;

            string url = "Home/GetCities";
            string httpMethod = "GET";

            try
            {
                string requestJSON = JsonConvert.SerializeObject(countryCode, Formatting.Indented);
                //Set request params for get apis
                Dictionary<string, string> requestParams = new Dictionary<string, string>();
                requestParams.Add("countryCode", countryCode);

                var apiResponse = APIConsumer(url, httpMethod, null,requestParams, requestJSON);

                responseJSON = apiResponse.Content.ReadAsStringAsync().Result;

                GetCitiesResponse payResponse = JsonConvert.DeserializeObject<GetCitiesResponse>(responseJSON);

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    isProcessed = true;
                }

                else
                {
                    isProcessed = false;
                }

             
            }

            catch (Exception ex)
            {
                isProcessed = false;
            }

            return isProcessed;
        }


        public static bool GetAirLinesByCountryCode(string countryCode, out string responseJSON)
        {
            string actionName = ".GetAirLinesByCountryCode";
            string source = ClassName + actionName;
            responseJSON = string.Empty;
            bool isProcessed = false;

            string url = "Home/GetAirlines";
            string httpMethod = "GET";

            try
            {
                string requestJSON = JsonConvert.SerializeObject(countryCode, Formatting.Indented);
                //Set request params for get apis
                Dictionary<string, string> requestParams = new Dictionary<string, string>();
                requestParams.Add("countryCode", countryCode);

                var apiResponse = APIConsumer(url, httpMethod, null, requestParams, requestJSON);

                responseJSON = apiResponse.Content.ReadAsStringAsync().Result;

                GetAirlinesResponse payResponse = JsonConvert.DeserializeObject<GetAirlinesResponse>(responseJSON);

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    isProcessed = true;
                }

                else
                {
                    isProcessed = false;
                }


            }

            catch (Exception ex)
            {
                isProcessed = false;
            }

            return isProcessed;
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