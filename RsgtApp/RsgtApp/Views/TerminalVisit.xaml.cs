using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.ViewModels;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using System;
using Xamarin.CommunityToolkit.Extensions;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TerminalVisit : ContentPage
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
                if (current == NetworkAccess.Internet)
                {
                    //BannedTruckEn.IsEnabled = true;
                    if (App.isinternetSlowEnablement == true)
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
                }
                else
                {
                    await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handle in TerminalVisit constructor
        /// </summary>
        public TerminalVisit()
        {
            InitializeComponent();
            this.BindingContext = new TerminalVisitViewModel();
        }
    }
}