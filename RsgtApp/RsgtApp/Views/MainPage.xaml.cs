using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;

using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Themes;
using System.Net.Http;
using RsgtApp.Views;
using System.Runtime.CompilerServices;
using static RsgtApp.Models.Tracking;
using RsgtApp.Models;

namespace RsgtApp.Views
{
    public partial class MainPage : ContentPage
    {
        // private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
        BLConnect objcon = new BLConnect();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        string strServerSlowMsg = "";
       
       
        private string strLanguage = App.gblLanguage;
        private List<InfoItem> objCMSMSG = new List<InfoItem>();



        //Indicator BGColor
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");

        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;

            }
        }

        //Indicator BGOpacity
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");

        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;

            }
        }
        /// <summary>
        /// To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            txtcontainerNo.Text = "";

            if (current == NetworkAccess.Internet)
            {
                //Change 20220617
                tapbefore.IsEnabled = true;
                tapafter.IsEnabled = true;
                // lblTrack.IsEnabled = true;
                taplogin.IsEnabled = true;
                msgcontainer.IsVisible = false;
               
                if (App.isinternetSlowEnablement == true)
                {
                    bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                    if (isConnectionFast)
                    { }
                    else
                        await this.DisplayToastAsync("Network Connection is slow", 3000);
                }
            }
            else
            {
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }
        }
        /// <summary>
        /// To handle MainPage
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            IndicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
            IndicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
            msgcontainer.IsVisible = false;           


            //StackManiPage.IsEnabled = true;
            if (gblRegisteration.strLoginUser != null)
            {
                if (gblRegisteration.strLoginUser.Length > 0)
                {
                    btnsBeforeLogin.IsVisible = false;
                    btnsAfterLogin.IsVisible = true;
                }

            }
            else
            {
                btnsBeforeLogin.IsVisible = true;
                btnsAfterLogin.IsVisible = false;
            }
            assignCms();
            assignCmsMsg();


        }
        /// <summary>
        /// To bind Cms
        /// </summary>
        public async void assignCms()
        {
            try
            {
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");
                }


            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }

        }
        /// <summary>
        /// To bind Cms Msg
        /// </summary>
        public async void assignCmsMsg()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                //objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                msgcontainer.Text = dbLayer.getCaption("strEmailpattern", objCMSMSG);
                assignContent();
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }

        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            StackManiPage.IsEnabled = false;
            mainpageActivityIndicator.IsVisible = true;
            mainpageActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);

            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }

            // dbLayer.lintLanguage = lintIndex;
            // dbLayer.objInfoitems = objCMS;
            this.FlowDirection = enumDirection;

            txtcontainerNo.Placeholder = dbLayer.getCaption("strContainerNumber", objCMS);
            lblLogin.Text = dbLayer.getCaption("strLoginA", objCMS);
            lblTrack.Text = dbLayer.getCaption("strTrack", objCMS);
            lblTrackShip.Text = dbLayer.getCaption("strTrackYourShipment", objCMS);
            lblVesselsch.Text = dbLayer.getCaption("strVesselSchedule", objCMS);
            imgLogin.Source = dbLayer.getCaption("imgLoginiconwhitepng", objCMS);
            //imglogowhite.Source = dbLayer.getCaption("imglogowhitepng", objCMS);
            //  imgTrack.Source = dbLayer.getCaption("imgtrackiconpng");
            imgVessel.Source = dbLayer.getCaption("imgvesselschedulehomepng", objCMS);
            lblTitle.Text = dbLayer.getCaption("strTitle", objCMS);
            lblVesselsch2.Text = dbLayer.getCaption("strVesselSchedule", objCMS);
            imgVessel2.Source = dbLayer.getCaption("imgvesselschedulehomepng", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);

            await Task.Delay(1000);


            string result = await SecureStorage.GetAsync("ApplyTheme");

            if (result == null)
            {
                App.gblSelectedTheme = "1";
                await SecureStorage.SetAsync("ApplyTheme", "1");
            }
            else
            {
                App.gblSelectedTheme = result.ToString();
            }
            //l̥objCMS = await dbLayer.LoadContent("RM004");
            mainpageActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            mainpageActivityIndicator.IsVisible = false;
            StackManiPage.IsEnabled = true;

            setThemes();


            //  BioLogin();

            //Begin - Code for Back Button - 20220429
            //2.When Back button clicked in other pages like PageRegistraion1.aspx,PageRegistration2.aspx,MyProfile1.aspx,MyProfile2.aspx etc... screen should navigate each page by page
            SecureStorage.Remove("V");
            //End - Code for Back Button - 20220429
        }
        /// <summary>
        /// To set Themes
        /// </summary>
        private void setThemes()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                switch (App.gblSelectedTheme)
                {
                    case "2":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "3":
                        mergedDictionaries.Add(new GreenTheme());
                        break;
                    case "1":
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
        /// <summary>
        /// To Handle OnTappedVesselschedule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnTappedVesselschedule(object sender, EventArgs e)
        {
            //Change 20220617
            tapbefore.IsEnabled = false;
            tapafter.IsEnabled = false;
            // lblTrack.IsEnabled = false;
            taplogin.IsEnabled = false;
            //Change 20220617
            // Begin -- 2022/06/02 - Code for Indicatorview set to true
            //StackManiPage.IsEnabled = true;
            StackManiPage.IsEnabled = false;
            mainpageActivityIndicator.IsVisible = true;
            mainpageActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623
            await Navigation.PushAsync(new VesselSchedule("Inport"));
            //Begin - Code for Back Button - 20220429
            await SecureStorage.SetAsync("V", "VesselBack");
            //End - Code for Back Button - 20220429
            mainpageActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            mainpageActivityIndicator.IsVisible = false;
            StackManiPage.IsEnabled = true;
            // StackManiPage.IsEnabled = true;

            // End -- 2022/06/02 - Code for Indicatorview set to true/false
        }
        /// <summary>
        /// To Handle gotoBasicTracking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gotoBasicTracking(object sender, EventArgs e)
        {

            //Change 20220617
            tapbefore.IsEnabled = false;
            tapafter.IsEnabled = false;
            // lblTrack.IsEnabled = false;
            taplogin.IsEnabled = false;
            //Change 20220617
            // Begin -- 2022/06/02 - Code for Indicatorview set to true
            //StackManiPage.IsEnabled = true;
            StackManiPage.IsEnabled = false;
            mainpageActivityIndicator.IsVisible = true;
            mainpageActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623
            int lint = 0;
            msgcontainer.IsVisible = false;
            try
            {

              
                gblRegisteration.strContainerNo = txtcontainerNo.Text.Trim().ToUpper();
                Tracking.lstTracking = objcon.getBasicTrakingContainerDetail(txtcontainerNo.Text.Trim().ToUpper());
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    await this.DisplayToastAsync(strServerSlowMsg, 3000);

                }



                if (lstTracking.Count == lint)
                {
                    //Change 20220617
                    tapbefore.IsEnabled = true;
                    tapafter.IsEnabled = true;
                    // lblTrack.IsEnabled = true;
                    taplogin.IsEnabled = true;
                    //Change 20220617
                    msgcontainer.IsVisible = true;


                }
                else
                {


                   await App.Current.MainPage?.Navigation.PushAsync(new Basic_Tracking_Result());

                    // StackManiPage.IsEnabled = true;
                    //mainpageActivityIndicator.IsVisible = false;
                    // End -- 2022/06/02 - Code for Indicatorview set to false
                }

            }
            catch (Exception ex)
            {

                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                    await this.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                    await this.DisplayToastAsync(ex.Message, 3000);

            }


            mainpageActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            mainpageActivityIndicator.IsVisible = false;
            StackManiPage.IsEnabled = true;

        }
        /// <summary>
        /// To Handle getLogin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void getLogin(object sender, EventArgs e)
        {
            StackManiPage.IsEnabled = false;
            mainpageActivityIndicator.IsVisible = true;
            mainpageActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623


            await Navigation.PushAsync(new PageLogin());
            mainpageActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            mainpageActivityIndicator.IsVisible = false;
            StackManiPage.IsEnabled = true;
        }
        /// <summary>
        /// To Handle OnTappedLogin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnTappedLogin(object sender, EventArgs e)
        {
            //Change 20220617
            tapbefore.IsEnabled = false;
            tapafter.IsEnabled = false;
            // lblTrack.IsEnabled = false;
            taplogin.IsEnabled = false;
            StackManiPage.IsEnabled = false;
            mainpageActivityIndicator.IsVisible = true;
            mainpageActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623
                                   //Change 20220617

            await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
            mainpageActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            mainpageActivityIndicator.IsVisible = false;
            StackManiPage.IsEnabled = true;
        }
    }
}
