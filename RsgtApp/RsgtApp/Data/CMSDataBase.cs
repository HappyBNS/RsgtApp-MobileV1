using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
//using RsgtApp.Models;
using System.Net.Http;
using System;
using System.Net;
using Nancy.Json;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace RsgtApp.Data
{
    public class CMSDataBase
    {
        readonly SQLiteAsyncConnection database;

        public CMSDataBase(string dbPath)
        {

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<InfoItem>().Wait();
        }

        public List<InfoItem> LoadContentArr(string fstrAccessID)
        {
            //string ApiKey = AppSettings.getApiKey;
            List<InfoItem> objCms = new List<InfoItem>();

            //Development
            //string url = "http://172.19.35.68:89/api/" + "DataSource/getCmsDetail?fstrAccessID=" + fstrAccessID;

            //http://172.19.35.68:89/api/DataSource/getCmsDetail?fstrAccessID=

            string url = AppSettings.getContentUrl + "DataSource/getCmsDetail?fstrAccessID=" + fstrAccessID;

            try
            {
                // prepare header parameters as per RSGT inputs
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Headers = {
                        { "X-Version", "1" }, // HERE IS HOW TO ADD HEADERS,
                        { HttpRequestHeader.Authorization.ToString(), "hl4bA4nB4yI0fC8fH7eT6" },
                        { HttpRequestHeader.Accept.ToString(), "application/json, application/xml" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" },  //use this content type if you want to send more than one content type
                    },
                };
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("ApiKey", "hl4bA4nB4yI0fC8fH7eT6");

                try
                {
                    var responseTask = client.SendAsync(request).Result;

                    if (responseTask.IsSuccessStatusCode)
                    {
                        var objOutputTask = responseTask.Content.ReadAsStringAsync();
                        objOutputTask.Wait();
                        var jss = new JavaScriptSerializer();
                        string lstrTemp = objOutputTask.Result;
                        objCms = JsonConvert.DeserializeObject<List<InfoItem>>(lstrTemp);
                    }
                }
                catch (Exception ex)
                {
                    string lstrError = "";
                    lstrError = ex.Message.ToString();
                }



            }

            catch (Exception ex)
            {
                string lstrError = "";
                lstrError = ex.Message.ToString();
            }


            return objCms;

        }



        public async void CreateCMSAsync(InfoItem objCMS)
        {
            // Save a new CMS.
            List<InfoItem> lstCMS = new List<InfoItem>();
            List<InfoItem> lstTempCMS = new List<InfoItem>();
            lstCMS = await database.Table<InfoItem>().Where(i => i.cms_accessid == objCMS.cms_accessid && i.cms_infoid == objCMS.cms_infoid).ToListAsync();
            if (lstCMS.Count > 0)
            {
                if ((lstCMS[0].cms_info1 != objCMS.cms_info1) || (lstCMS[0].cms_info2 != objCMS.cms_info2))
                {
                    await database.UpdateAsync(objCMS);
                    lstTempCMS = await database.Table<InfoItem>().Where(i => i.cms_accessid == objCMS.cms_accessid && i.cms_infoid == objCMS.cms_infoid).ToListAsync();
                }

            }
            else
            {
                await database.InsertAsync(objCMS);
            }


        }
        public Task<List<InfoItem>> GetNotesAsync()
        {
            //Get all notes.
            // return database.Table<Note>().ToListAsync();
            //Get all CMS.
            return database.Table<InfoItem>().ToListAsync();

        }
        public async Task<List<InfoItem>> GetCmsAsyncAccessId(string AccessId)
        {
            List<InfoItem> lstCMS = new List<InfoItem>();
            // Get a specific cms.
            lstCMS = await database.Table<InfoItem>().Where(i => i.cms_accessid == AccessId).ToListAsync();
            return lstCMS;

        }

    }
}
