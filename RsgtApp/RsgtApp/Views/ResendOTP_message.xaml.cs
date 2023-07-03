using RsgtApp.BusinessLayer;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResendOTP_message : ContentPage
    {
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        public List<clsREGISTEREDUSERS> lstreguser = new List<clsREGISTEREDUSERS>();
        BLConnect objcon = new BLConnect();
        private string strLanguage = App.gblLanguage;
        private List<InfoItem> objCMS = new List<InfoItem>();
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
        /// <summary>
        /// To handle in ResendOTPMSG constructor
        /// </summary>
        public ResendOTP_message()
        {
            InitializeComponent();
            assignCms();
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM003");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await  dbLayer.LoadContent("RM003");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
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
        public  void assignContent()
        {
            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }
            this.FlowDirection = enumDirection;
            imgRegisterIcon.Source = dbLayer.getCaption("imgRegistericon", objCMS);
            lblDearCustomer.Text = dbLayer.getCaption("strCustomer", objCMS);
            lblMessage.Text = dbLayer.getCaption("strOtpMsgSent", objCMS);
            btnOK.Text = dbLayer.getCaption("strok", objCMS);
            //btnNewUser.Text = pageContent["strNewUserRegister"][lintIndex];

        }
        /// <summary>
        /// To handel in click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            aiLayout.IsVisible = true;
            resendActivityIndicator.IsRunning = true;
            resendActivityIndicator.IsVisible = true;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new PageLoginOTP());
            resendActivityIndicator.IsRunning = false;
            resendActivityIndicator.IsVisible = false;
            aiLayout.IsVisible = false;
        }
    }
}