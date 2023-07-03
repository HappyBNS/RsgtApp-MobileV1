using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.IO;
using System.Net;
using RsgtApp.Helpers;
using System.Reflection;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]




    public partial class Splash : ContentPage
    {

        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        WebApiMethod objWebApi = new WebApiMethod();
        /// <summary>
        ///  To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                if (App.isinternetSlowEnablement == true)
                {
                    bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                    if (isConnectionFast)
                    { }
                    else
                        await this.DisplayToastAsync("Network Connection is slow", 3000); // DependencyService.Get<IToast>().ShowToast("Network Connection is slow");
                }
                //Change 20220617 
                //// Here to check Internet Speed handled by Anand 20220907
                //bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                //if (isConnectionFast)
                //    {}
                //else
                //    this.DisplayToastAsync("Network Connection is slow", 3000); // DependencyService.Get<IToast>().ShowToast("Network Connection is slow");

            }
            else
            {
                //lblNetworkStatus.Text = "Network is Not Available";
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
                //Navigation.PushAsync(new InternetConnectivity());
            }

        }
        /// <summary>
        /// To handel in Splash constructor
        /// </summary>
        public Splash()
        {
            try
            {


                InitializeComponent();
                //lblTitleEng.Text = "Synchronising data from server. <br> Please wait...";
                //lblTitleAra.Text = "مزامنة البيانات من الخادم. <br> يرجى الإنتظار......";

                // Task.Run(() =>   assignCMS()).Wait();
            }
            catch (Exception ex)
            {

                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        private async Task assignCMS()
        {
            await Task.Delay(1000);
            objCMSMSG = await dbLayer.LoadContent("RM026");
            dbLayer.objInfoitems = objCMSMSG;
            // lblTitle.Text = dbLayer.getCaption("strDataConfigurationInProgress", objCMSMSG);

        }

        /// <summary>
        /// To handle in On Tapped startup
        /// </summary>
        string fstrLang = "En";
        private void OnTappedstartup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Startup(fstrLang));
            //Navigation.PushModalAsync(new NavigationPage(new VesselSchedule()));
        }

        /// <summary>
        /// To handle English Button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void gotoEnglishButtonClicked(object sender, EventArgs e)
        {
            try
            {


                SplashActivityIndicator.IsVisible = true;
                SplashActivityIndicator.IsRunning = true;
                aiLayout.IsVisible = true;
                SplashEn.IsEnabled = false;
                //lblTitleEng.IsVisible = true;

                await Task.Delay(1000);
                fstrLang = "En";
                //await procWriteCMS();
                var Token = await SecureStorage.GetAsync("Ye");
                //App.Current.MainPage?.DisplayToastAsync("Splash", 3000);
                if (Token == "Skipslidee") // -----------------------> 2nd time skipping Startup Page then Navigate to "Main Page"
                {

                    //To clear Global properties
                    var fields = typeof(gblRegisteration).GetFields(BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var field in fields)
                    {
                        var type = field.GetType();
                        field.SetValue(null, null);
                    }
                    App.gblLanguage = "Ar";
                    if (fstrLang == "En") App.gblLanguage = "En";//Ar Means Arabic or En Means English
                    App.lintLanguage = 0;//20230605
                    Application.Current.MainPage?.Navigation.PopAsync();
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await SecureStorage.SetAsync("Ye", "Skipslidee");
                    await SecureStorage.SetAsync("B", "rsgt_touchenablement_No");
                    App.Current.MainPage?.Navigation.PushAsync(new Startup(fstrLang));
                }


                SplashActivityIndicator.IsVisible = false;
                SplashActivityIndicator.IsRunning = false;
                aiLayout.IsVisible = false;
                SplashEn.IsEnabled = true;
                //lblTitleEng.IsVisible = false;
            }
            catch (Exception ex)
            {

                await this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handel in CMS write url in API Commented this Function we are calling respective Page
        /// </summary>

        //private async Task procWriteCMS()
        //{
        //    try
        //    {

        //        List<CMSUPDATES> objCms = new List<CMSUPDATES>();
        //        WebApiMethod objWebApi = new WebApiMethod();

        //        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LastModifiedDate.txt");

        //        Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
        //        string ApiName = "getLatestCaptionChangesAccessIDs";
        //        IEnumerable<Object> lobjApiData;

        //        //File.Delete(fileName);
        //        if (File.Exists(fileName))
        //        {
        //            string lstrLastModifiedDate = File.ReadAllText(fileName);
        //            lobjInParams.Add("fstrUpdatedDate", lstrLastModifiedDate);
        //        }
        //        else
        //        {
        //            lobjInParams.Add("fstrUpdatedDate", "0");

        //        }
        //        lobjApiData = objWebApi.getWebApiData(ApiName, lobjInParams);

        //        objCms = procgetCMSList(lobjApiData);

        //        if (objCms.Count > 0)
        //        {
        //          //  procWriteJsonFile(objCms);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        string lstrErrormsg = ex.Message;
        //    }
        //}

        /// <summary>
        /// To handel in CMS write url in list
        /// </summary>
        private List<CMSUPDATES> procgetCMSList(IEnumerable<Object> lobjApiData)
        {
            List<CMSUPDATES> objCms = new List<CMSUPDATES>();
            foreach (IEnumerable<Object> lobjVesselRow in lobjApiData)
            {
                // Info object
                CMSUPDATES lobjCMS = new CMSUPDATES();

                foreach (Newtonsoft.Json.Linq.JProperty Column in lobjVesselRow)
                {
                    //  KeyValuePair<string, string[]> Column = (KeyValuePair<string, string[]>)lobjInfoRow.ElementAt(lintIndex);

                    string strColumnName = Column.Name;
                    string strColumnValue = Column.Value.ToString();

                    switch (strColumnName)
                    {
                        case "cmsu_accessid":
                            lobjCMS.cmsu_accessid = strColumnValue;
                            break;
                        case "cmsu_lastupdateddatetime":
                            lobjCMS.cmsu_lastupdateddatetime = strColumnValue;
                            break;
                    }
                }

                objCms.Add(lobjCMS);
            }

            return objCms;
        }
        /// <summary>
        /// To handel in CMS write url in file
        /// </summary>
        /// <param name="objCms"></param>
        /// <returns></returns>
        private async Task procWriteJsonFile(List<CMSUPDATES> objCms)
        {
            string Encrypturl = AppSettings.MobCMSUrl;
            string strEncrptKey = AppSettings.getEncrptyKey;
            string lstrDycryptUrl = gblRegisteration.DecryptString(Encrypturl, strEncrptKey);
            string lstrFilePath = lstrDycryptUrl;
            string fileName = "";
            string contentCMS = "";

            if (objCms.Count > 0)
            {
                string[] lstAccessID = objCms[0].cmsu_accessid.Split(',');

                if (lstAccessID.Length > 1)
                {
                    foreach (var itemAccessID in lstAccessID)
                    {
                        fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "" + itemAccessID + ".txt");
                        // contentCMS = objBL.getCMSData(item);

                        lstrFilePath = lstrDycryptUrl + "/Json/" + itemAccessID + ".txt";

                        //URL based Caption
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                                var json = client.DownloadString(lstrFilePath);
                                contentCMS = Convert.ToString(json);
                            }
                            catch (Exception ex)
                            {
                                await this.DisplayToastAsync(ex.Message, 3000);
                            }
                        }
                        try
                        {
                            //https://webgateway.rsgt.com:9090/eportal_api/procWriteApiTraceLog?fstrCode=A1000&fstrCustomMsg=testing&fstrSystemMsg=testing&fstrSuggestion=testing&fstrsource=apk

                            string strAcceSSID = itemAccessID;
                            string strSource = "Mobile-App";
                            string strCustomMsg = "To Write CMS Caption List";
                            string strSystemMsg = "";
                            string strSuggestion = "";

                            string fstrCondition = "fstrCode=" + strAcceSSID + "&fstrCustomMsg=" + strCustomMsg + "&fstrSystemMsg=" + strSystemMsg + "&fstrSuggestion=" + strSuggestion + "&fstrsource=" + strSource + "";
                            string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);

                            //0 if (File.Exists(fileName)) File.Delete(fileName);
                            //await Task.Delay(2000);
                            //File.WriteAllText(fileName, contentCMS);
                             procWriteJsonFileAccessID(fileName, contentCMS);

                        }
                        catch (Exception ex)
                        {
                            await this.DisplayToastAsync(ex.Message, 3000);
                        }

                    }
                    fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LastModifiedDate.txt");
                    try
                    {
                        // File.WriteAllText(fileName, objCms[0].cmsu_lastupdateddatetime.ToString());
                         procWriteJsonFileAccessID(fileName, objCms[0].cmsu_lastupdateddatetime.ToString());
                    }
                    catch (Exception ex)
                    {
                        await this.DisplayToastAsync(ex.Message, 3000);
                    }


                }



            }
        }

        private void procWriteJsonFileAccessID(string fstAccessID, string fstrJsontxt)
        {

            File.WriteAllText(fstAccessID, fstrJsontxt);
        }

        /// <summary>
        /// To handle  click in Arabic buttion event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gotoArabicButtonClicked(object sender, EventArgs e)
        {
            try
            {


                SplashActivityIndicator.IsVisible = true;
                SplashActivityIndicator.IsRunning = true;
                aiLayout.IsVisible = true;
                SplashEn.IsEnabled = false;
                //lblTitleAra.IsVisible = true;

                await Task.Delay(1000);
                //await procWriteCMS();
                fstrLang = "Ar";

                var Token = await SecureStorage.GetAsync("Ye");
                if (Token == "Skipslidee") // -----------------------> 2nd time skipping Startup Page then Navigate to "Main Page"
                {
                    App.gblLanguage = "Ar";
                    if (fstrLang == "En") App.gblLanguage = "En";//Ar Means Arabic or En Means English
                    App.lintLanguage = 1;//20230605
                    Application.Current.MainPage?.Navigation.PopAsync();
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await SecureStorage.SetAsync("Ye", "Skipslidee");
                     App.Current.MainPage?.Navigation.PushAsync(new Startup(fstrLang));
                }
                SplashActivityIndicator.IsVisible = false;
                SplashActivityIndicator.IsRunning = false;
                aiLayout.IsVisible = false;
                SplashEn.IsEnabled = true;
                //lblTitleAra.IsVisible = false;

            }
            catch (Exception ex)
            {

                await this.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}