using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;

namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUsMessage : ContentPage
    {
        /// <summary>
        /// To check internet connection
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
        //18-01-2023-Sanduru
        /// <summary>
        /// To Bind ViewModel
        /// </summary>
        public ContactUsMessage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            InitializeComponent();
            this.BindingContext = new ContactUsMessageViewModel();
        }
    }
}