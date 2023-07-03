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
    public partial class Wallet_Main : ContentPage
    {
        /// <summary>
        /// To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                var profiles = Connectivity.ConnectionProfiles;
                // To check Internet connectivity
                if (current == NetworkAccess.Internet)
                {

                    // To check Internet Slow
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
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind viewmodel
        /// </summary>
        public Wallet_Main()
        {
            InitializeComponent();
            this.BindingContext = new WalletMainViewModel();
        }
    }
}