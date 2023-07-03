using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using Xamarin.Essentials;
using RsgtApp.ViewModels;
using System.Threading.Tasks;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Containerlist : ContentPage
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
        /// To handel in View Connected to ViewModel
        /// </summary>
        /// <param name="strSearchbox">Search box</param>
        /// <param name="strBolNo">BOL No</param>
        /// <param name="strselectedFrightType">Filter selected FrightType Value</param>
        /// <param name="strselectedSize">Filter selected Size Value</param>
        /// <param name="strselectedAppoinment">Filter selected Appoinment Value</param>
        /// <param name="strselectedGate">Filter selected Gate Value</param>
        /// <param name="strselectedStatus">Filter selected Status Value</param>
        /// <param name="strselectedOther">Filter selected Other Value</param>
        /// <param name="fstrHoldPopup"></param>
        public Containerlist(string strSearchbox, string strBolNo, string strselectedFrightType, string strselectedSize, string strselectedAppoinment, string strselectedGate, string strselectedStatus, string strselectedOther, string fstrHoldPopup,string fstrFilterFlag)
        {
            try
            {
                InitializeComponent();
                //To Bind View Model
                BindingContext = new ContainerlistViewModel(strSearchbox, strBolNo, strselectedFrightType, strselectedSize, strselectedAppoinment, strselectedGate, strselectedStatus, strselectedOther, fstrHoldPopup, fstrFilterFlag);
            }
            catch (Exception ex)
            {
                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handel in cancel buttion click event function
        /// </summary>
        /// <param name="sender"> Sendr</param>
        /// <param name="e">E</param>
        private async void clickedBOLPage(object sender, EventArgs e)
        {
            ContainerActivityIndicator.IsVisible = true;
            ContainerActivityIndicator.IsRunning = true;
            ContainerIndecator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));
            aiLayout.IsEnabled = true;
            ContainerIndecator.IsVisible = true;
            ContainerActivityIndicator.IsRunning = false;
            ContainerActivityIndicator.IsVisible = false;
        }
    }
}