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
    public partial class Bayan : ContentPage
    {
        /// <summary>
        ///  To Check Internet Connection
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
        /// To handel in View connected in view Model function
        /// </summary>
        /// <param name="strsearhbox">searh box</param>
        /// <param name="strselectedConsignee">Filter selected Consignee list</param>
        /// <param name="strselectedVessel">Filter selected Vessel list</param>
        /// <param name="strselectedCarrier">Filter selected Carrier list</param>
        /// <param name="strselectedStatus">Filter selected Status list</param>
        /// <param name="strselectedCategory">Filter selected Category list</param>
        public Bayan(string strsearhbox, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus, string strselectedCategory)
        {
            try
            {
                InitializeComponent();
                // To bind ViewModel 
                this.BindingContext = new BayanViewModel(strsearhbox, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus, "N", strselectedCategory);
            }
            catch (Exception ex)
            {
                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handel in cancel buttion click event function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickedTrackPage(object sender, EventArgs e)
        {
            BayanActivityIndicator.IsVisible = true;
            BayanActivityIndicator.IsRunning = true;
            BayanIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            aiLayout.IsEnabled = true;
            BayanIndicator.IsVisible =false;
            BayanActivityIndicator.IsRunning =false;
            BayanActivityIndicator.IsVisible = false;

        }
    }
}