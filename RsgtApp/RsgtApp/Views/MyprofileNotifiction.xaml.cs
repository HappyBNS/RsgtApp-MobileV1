using System.Collections.Generic;
using RsgtApp.BusinessLayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.Helpers;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyprofileNotifiction : ContentPage
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
        /// To Bind View Model
        /// </summary>
        public MyprofileNotifiction()
        {
            InitializeComponent();
            this.BindingContext = new MyprofileNotifictionViewModel();
        }
   }
}