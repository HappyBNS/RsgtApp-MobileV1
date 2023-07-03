using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
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
    public partial class GatePhotoRequest : ContentPage
    {

        /// <summary>
        /// To Check Internet Connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
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
                            await this.DisplayToastAsync("Network Connection is slow", 3000);
                    }
                }
                else
                {
                    await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
                }
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handel in View Connected to view Model 
        /// </summary>
        /// <param name="strLicenseNo">License Number</param>
        /// <param name="strBOL">BOL Number</param>
        /// <param name="strContainer">Container Number </param>
        /// <param name="strRequest">Request Flag</param>
        public GatePhotoRequest(string strLicenseNo, string strBOL, string strContainer, string strRequest)
        {
            InitializeComponent();
            this.BindingContext = new GatePhotoRequestBOLViewModel( strLicenseNo,strBOL,strContainer,strRequest);
        }

        /// <summary>
        /// To handel  in Canecel buttion  click event 
        /// </summary>
        /// <param name="sender">Sendr</param>
        /// <param name="e">E</param>
        private async void clickedContainerPage(object sender, EventArgs e)
        {
            GatephotoActivityIndicator.IsVisible = true;
            GatephotoActivityIndicator.IsRunning = true;
            Gatephotoindecator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Containerlist("", gblBol.strgblBolNo, "", "", "", "", "", "", "","N"));
            aiLayout.IsEnabled =true;
            Gatephotoindecator.IsVisible = false;
            GatephotoActivityIndicator.IsRunning = false;
            GatephotoActivityIndicator.IsVisible = false;
        }
    }
}