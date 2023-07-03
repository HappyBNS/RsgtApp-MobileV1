using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System.Threading.Tasks;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BOL : ContentPage
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
        /// TO handel in page Refreshing
        /// </summary>
        //async void RefreshView_Refreshing()
        //{
        //    await Task.Delay(100);
        //    myRefreshView.IsRefreshing = false;
        //    App.Current.MainPage?.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));
        //}
        /// <summary>
        ///  To handel in BOL page to Container navigation function
        /// </summary>
        /// <param name="strSearchbox">Search box</param>
        /// <param name="strBaynanNo">Baynan No</param>
        /// <param name="strselectedConsignee">Filter Consignee list</param>
        /// <param name="strselectedVessel">Filter Vessel list </param>
        /// <param name="strselectedCarrier">Filter Carrier list</param>
        /// <param name="strselectedStatus">Filter Status list</param>
        public BOL(string strSearchbox, string strBaynanNo, string strselectedConsignee, string strselectedVessel, string strselectedCarrier, string strselectedStatus)
        {
            try
            {

                InitializeComponent(); // To bind ViewModel
                BindingContext = new BOLViewModel(strSearchbox, strBaynanNo, strselectedConsignee, strselectedVessel, strselectedCarrier, strselectedStatus, "N");


            }
            catch (Exception ex)
            {
                this.DisplayToastAsync(ex.Message, 3000);
            }
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// To handel cancel buttion in BOL page
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void clickedBayanPage(object sender, EventArgs e)
        {
            BOLActivityIndicator.IsVisible = true;
            BOLActivityIndicator.IsRunning = true;
            BOLIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Bayan("", "", "", "", "101,102", ""));
            aiLayout.IsEnabled = true;
            BOLIndicator.IsVisible =false;
            BOLActivityIndicator.IsRunning =false;
            BOLActivityIndicator.IsVisible = false;
        }
    }
}