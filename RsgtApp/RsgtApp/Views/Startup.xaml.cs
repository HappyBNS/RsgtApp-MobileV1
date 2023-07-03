using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Startup : ContentPage
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;

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



            }
            else
            {
                //lblNetworkStatus.Text = "Network is Not Available";
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
                //Navigation.PushAsync(new InternetConnectivity());
            }

        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    try
        //    {
        //        var Token = await SecureStorage.GetAsync("Y");
        //        if(Token== "Skipslide")
        //        {

        //            Application.Current.MainPage?.Navigation.PopAsync();
        //            Application.Current.MainPage? = new AppShell();
        //        }
        //        else
        //        {
        //            await SecureStorage.SetAsync("Y", "Skipslide");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Possible that device doesn't support secure storage on device.
        //    }

        //}
        /// <summary>
        /// To handel in Startup
        /// </summary>
        /// <param name="fstrLang"></param>
        public Startup(string fstrLang)
        {

            InitializeComponent();
           
            // BioLoginClear();

            gblRegisteration.strLoginFirstName = null;
            gblRegisteration.strLoginUser = null;
            App.gblLanguage = "Ar";
            App.lintLanguage = 1;
            if (fstrLang == "En")
            {
                App.lintLanguage = 0;
                App.gblLanguage = "En";//Ar Means Arabic or En Means English
            }

            this.BindingContext = this;
            //await dbLayer.LoadContent("RM004", pageContent);
            //objCMS = await dbLayer.LoadContent("RM004");

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {

            }
            assignContent();

        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {

            if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
            {
                objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
            }
            if (App.gblCMSSource.ToUpper().Trim() == "JSON")
            {
                objCMS = await dbLayer.LoadContent("RM004");
            }
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}

          
            dbLayer.objInfoitems = objCMS;

            lblGetStart.Text = dbLayer.getCaption("strGetStarted", objCMS);
            //sampletxt.BindingContext = "<p>Invoices can be accessed per below:</p> </p>1) By sending request per e - mail(include BL # / Bayan / Container number please) mailto:to:rsgtinvoice@rsgt.com, CC: mailto:c.s@rsgt.com </p> 2) Alternatively by visiting us at RSGT finance desk(Saturday to Thursday from 8 am to 8 pm, Friday 2 pm to 4 pm) </p>";
           
            //Begin - First time only this slider page will show, from 2nd time onwards this page will not be shown
            try
            {
                
            }
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString();

                // Possible that device doesn't support secure storage on device.
            }
            //End - First time only this slider page will show, from 2nd time onwards this page will not be shown

        }

        public List<AppKeyfeatures> Kfeatures { get => KeyfeaturesData(); }
        /// <summary>
        /// To handle in KeyfeaturesData
        /// </summary>
        /// <returns></returns>
        private List<AppKeyfeatures> KeyfeaturesData()
        {
            var templist = new List<AppKeyfeatures>();
            templist.Add(new AppKeyfeatures { Serviceinfo = "Shipment Tracking", IconImage = "slide1.gif" });
            templist.Add(new AppKeyfeatures { Serviceinfo = "Vessel Schedule", IconImage = "slide2.gif" });
            templist.Add(new AppKeyfeatures { Serviceinfo = "Secure Payment", IconImage = "slide3.gif" });

            return templist;
        }
        /// <summary>
        /// To handle in cileck event gotoMainPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gotoMainPage(object sender, EventArgs e)
        {

            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
        }
    }

    public class AppKeyfeatures
    {
        public string Serviceinfo { get; set; }
        public string IconImage { get; set; }
    }
}