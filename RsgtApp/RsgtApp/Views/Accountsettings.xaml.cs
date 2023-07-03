using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using RsgtApp.BusinessLayer;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Services;
using RsgtApp.ViewModels;

namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accountsettings : ContentPage
    {
        /// <summary>
        /// To Check Internet Connection
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
                        await this.DisplayToastAsync("Network Connection is slow", 3000);
                }
            }
            else
            {
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }
        }
        /// <summary>
        /// To Bind ViewModel
        /// </summary>
        public Accountsettings()
        {
            InitializeComponent();
          this.BindingContext = new AccountSettingsViewModel();
        }     
    }
}