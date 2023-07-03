using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;

namespace RsgtApp.Helpers
{
   public class WebApiMethod
    {

        //Web API Get Method 
        public ObservableCollection<Object> getWebApiData(string ApiName, Dictionary<string, string> fstrParams)
        {
            string ApiKey = AppSettings.getApiKey;
            AppSettings.ErrorExceptionWebApi = "";
            string AuthorizationKey = AppSettings.getApiAuthorizationKey;
            ObservableCollection<Object> objData = new ObservableCollection<object>();
            string lstrUrlParams = "";
            string lstramb = "";
            if (fstrParams.Count > 1)
            {
                lstramb = "&";
            }
            foreach (var objParam in fstrParams)
            {
                lstrUrlParams += objParam.Key + "=" + objParam.Value + lstramb;
            }
            if (fstrParams.Count > 1)
            {
                lstrUrlParams = lstrUrlParams.Remove(lstrUrlParams.Length - 1);
            }

            string url = "";
            if (ApiName == "getLatestCaptionChangesAccessIDs")//20221230 Gokul And Anand
            {
                string strEncrptKey = AppSettings.getEncrptyKey;
                string ContentUrlPROD = AppSettings.ContentUrlPROD.ToString().Trim();
                string lstrDycryptUrlPROD = gblRegisteration.DecryptString(ContentUrlPROD, strEncrptKey);


                url = lstrDycryptUrlPROD + ApiName + "?" + lstrUrlParams;

            }
            else
            {
                url = AppSettings.getContentUrl + ApiName + "?" + lstrUrlParams;

            }

            try
            {
                // prepare header parameters as per RSGT inputs
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Headers = {
                        { "X-Version", "1" }, // HERE IS HOW TO ADD HEADERS,
                       // { HttpRequestHeader.Authorization.ToString(), ApiKey },
                        { HttpRequestHeader.Authorization.ToString(), AuthorizationKey },
                        { HttpRequestHeader.Accept.ToString(), "application/json, application/xml" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" },  //use this content type if you want to send more than one content type
                    },
                };

                //Api call and API process
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
                client.DefaultRequestHeaders.Add("Authorization", AuthorizationKey);//20220531
               // client.DefaultRequestHeaders.Add("Cookie", $"RSGT-Orcale-BMC-LBS-Route=17c710dbbcea606321ece0f04d325ea6c353f1d5");  //20230107  Oracle Server Anand

                int lintTimeOut = 30;

                lintTimeOut = AppSettings.WepApiTimeOut;

                client.Timeout = TimeSpan.FromSeconds(lintTimeOut);
                var responseTask = client.SendAsync(request).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var objOutputTask = responseTask.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    var jss = new JavaScriptSerializer();
                    string lstrTemp = objOutputTask.Result;
                    //Finally To Deserialized result Object 
                    objData = JsonConvert.DeserializeObject<ObservableCollection<Object>>(lstrTemp);
                   

                }
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();                
                // Handle timeout exception
                AppSettings.ErrorExceptionWebApi = lstrError;

            }
            return objData;
        }

        //Web API Post Method
        public string postWebApi(string ApiName, string objstringJson)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;
            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;

            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);
              //  client1.DefaultRequestHeaders.Add("Cookie", $"RSGT-Orcale-BMC-LBS-Route=17c710dbbcea606321ece0f04d325ea6c353f1d5");  //20230107  Oracle Server Anand
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }

        //Web API Put Method
        public string putWebApi(string ApiName, string objstringJson, string fstrCondition)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrCondition;
            string strApiKey = AppSettings.getApiKey;

            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;


            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531
                                                                                        // client1.DefaultRequestHeaders.Add("Cookie", $"RSGT-Orcale-BMC-LBS-Route=17c710dbbcea606321ece0f04d325ea6c353f1d5");  //20230107  Oracle Server Anand
                int lintTimeOut = 30;

                lintTimeOut = AppSettings.WepApiTimeOut;

                client1.Timeout = TimeSpan.FromSeconds(lintTimeOut);
                var result = client1.PutAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                }
                bool BoolResult = result.IsSuccessStatusCode;
                if (BoolResult == true)
                {
                    lstrResult = "true";
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return lstrResult;
        }

        //Web API Get Method Return Single String Value
        public string getWebstringApiData(string ApiName, Dictionary<string, string> fstrParams)
        {
            // string strURL = "https://webgateway.rsgt.com:9090/eportal_api/" + ApiName;
             string strURL = AppSettings.getContentUrl+ ApiName;
            string ApiKey = "hl4bA4nB4yI0fC8fH7eT6";
            string AuthorizationKey = "5fc756ed33eebe7e6001b8b5709b257f91de4e989501a90ab805ad72";
            // AppSettings.ErrorExceptionWebApi = "";
            string objData = "";
            string lstrUrlParams = "";
            string lstramb = "";
            if (fstrParams.Count > 1)
            {
                lstramb = "&";
            }
            foreach (var objParam in fstrParams)
            {
                lstrUrlParams += objParam.Key + "=" + objParam.Value + lstramb;
            }
            if (fstrParams.Count > 1)
            {
                lstrUrlParams = lstrUrlParams.Remove(lstrUrlParams.Length - 1);
            }

            string url = strURL + "?" + lstrUrlParams;
            try
            {
                // prepare header parameters as per RSGT inputs
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Headers = {
                        { "X-Version", "1" }, // HERE IS HOW TO ADD HEADERS,
                       // { HttpRequestHeader.Authorization.ToString(), ApiKey },
                        { HttpRequestHeader.Authorization.ToString(), AuthorizationKey },
                        { HttpRequestHeader.Accept.ToString(), "application/json, application/xml" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" },  //use this content type if you want to send more than one content type
                    },
                };

                //Api call and API process
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
                client.DefaultRequestHeaders.Add("Authorization", AuthorizationKey);//20220531

                int lintTimeOut = 30;

                lintTimeOut = AppSettings.WepApiTimeOut;

                client.Timeout = TimeSpan.FromSeconds(lintTimeOut);
                var responseTask = client.SendAsync(request).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var objOutputTask = responseTask.Content.ReadAsStringAsync();
                    objOutputTask.Wait();
                    var jss = new JavaScriptSerializer();
                    string lstrTemp = objOutputTask.Result;

                    objData = lstrTemp;
                    ////var json = Newtonsoft.Json.Linq.JObject.Parse(lstrTemp);

                }
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
                //if (lstrError == "One or more errors occurred. (A task was canceled.)")
                //{

                //}
                // Handle timeout exception
                //AppSettings.ErrorExceptionWebApi = lstrError;

            }
            return objData;
        }

        //Web API Post getMethod
        public ObservableCollection<Object> getPostWebApi(string ApiName, string objstringJson, string fstrCondition)
        {
            
            HttpClient client = new HttpClient();
            string strURL = "";
            ObservableCollection<Object> objData = new ObservableCollection<object>();
            strURL = AppSettings.getContentUrl + ApiName + "/" + fstrCondition;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;

            string lstrInput = objstringJson;
            //UpadteRegisterUser
            try
            {
                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");


                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);//20220531
                                                                                        // client1.DefaultRequestHeaders.Add("Cookie", $"RSGT-Orcale-BMC-LBS-Route=17c710dbbcea606321ece0f04d325ea6c353f1d5");  //20230107  Oracle Server Anand

                int lintTimeOut = 120;

                client.Timeout = TimeSpan.FromSeconds(lintTimeOut);
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();

                    var jss = new JavaScriptSerializer();
                    string lstrTemp = objOutputTask.Result;

                    objData = JsonConvert.DeserializeObject<ObservableCollection<Object>>(lstrTemp);
                    objOutputTask.Wait();
                }
                            
            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }

            return objData;
        }


        //Web API Post Method
        public string getstringPostWebApi(string ApiName, string objstringJson, string fstrCondition)
        {
            string lstrResult = "false";
            HttpClient client = new HttpClient();
            string strURL = "";
            strURL = AppSettings.getContentUrl + ApiName + "?" + fstrCondition;
            string strApiKey = AppSettings.getApiKey;
            string strAuthorizationKey = AppSettings.getApiAuthorizationKey;
            client.DefaultRequestHeaders.Accept.Clear();
            string lstrInput = objstringJson;



            try
            {

                var content = new StringContent(lstrInput.ToString(), Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client1 = new HttpClient(handler);
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Add("ApiKey", strApiKey);
                client1.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);
                //  client1.DefaultRequestHeaders.Add("Cookie", $"RSGT-Orcale-BMC-LBS-Route=17c710dbbcea606321ece0f04d325ea6c353f1d5");  //20230107  Oracle Server Anand
                var result = client1.PostAsync(strURL, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    // retriveal of output content asyncronously 
                    var objOutputTask = result.Content.ReadAsStringAsync();
                    lstrResult = "True";
                    objOutputTask.Wait();
                }

            }
            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();

            }

            return lstrResult;
        }


    }
}
