using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AzureDashboard
{
    public class CallAzureAPIs
    {
        public static ExceptionClass.Example CallExceptionTelemetry()
        {
            

                        string apikey = "e8d6zyvo0bacv7hmpfkk2f345tnyfuoln4jccqjv";
                        string appId = "b3323bb1-ca98-48cf-a5f7-5fbbf0239612";
                        string query = "union(exceptions)|extend iif(itemType=='exception',itemType,'')|where cloud_RoleInstance=='DESKTOP-6J7NVN0' and itemType == 'exception'|top 10 by timestamp";
                        var timespan = "P1D";
                        string result = "";

                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("x-api-key", apikey);

                        //var req = string.Format(URL, appId, query, timespan);
                        var req = "https://api.applicationinsights.io/v1/apps/"+appId+"/query?query="+query+"&timespan="+timespan;
                        HttpResponseMessage response = client.GetAsync(req).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            result = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            result = response.ReasonPhrase;
                        }

                     
                         var jsonData = JsonConvert.DeserializeObject<ExceptionClass.Example>(result);
          
           

            return jsonData;
        }

        public static ExceptionClass.Example GetTotalException()
        {

                string apikey = "e8d6zyvo0bacv7hmpfkk2f345tnyfuoln4jccqjv";
                string appId = "b3323bb1-ca98-48cf-a5f7-5fbbf0239612";
                string query = "exceptions | summarize totalCount=sum(itemCount)";
                var timespan = "P1D";
                string result = "";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", apikey);

                //var req = string.Format(URL, appId, query, timespan);
                var req = "https://api.applicationinsights.io/v1/apps/" + appId + "/query?query=" + query + "&timespan=" + timespan;
                HttpResponseMessage response = client.GetAsync(req).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    result = response.ReasonPhrase;
                }

            var jsonData = JsonConvert.DeserializeObject<ExceptionClass.Example>(result);

          

            return jsonData;
        }


        public static ExceptionClass.Example GetTraces()
        {
            string apikey = "e8d6zyvo0bacv7hmpfkk2f345tnyfuoln4jccqjv";
            string appId = "b3323bb1-ca98-48cf-a5f7-5fbbf0239612";
            string query = "traces| project timestamp, message, cloud_RoleInstance,appId,appName";
            var timespan = "P1D";
            string result = "";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", apikey);

            //var req = string.Format(URL, appId, query, timespan);
            var req = "https://api.applicationinsights.io/v1/apps/" + appId + "/query?query=" + query + "&timespan=" + timespan;
            HttpResponseMessage response = client.GetAsync(req).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = response.ReasonPhrase;
            }

            var jsonData = JsonConvert.DeserializeObject<ExceptionClass.Example>(result);



            return jsonData;
        }
    }
}