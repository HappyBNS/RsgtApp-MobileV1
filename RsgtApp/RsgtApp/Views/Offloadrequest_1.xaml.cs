﻿using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Offloadrequest_1 : ContentPage
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

        /// <summary>
        /// To bind Viewmodel
        /// </summary>
        public Offloadrequest_1()
        {
            InitializeComponent();
            this.BindingContext = new Offloadrequest1ViewModel();
        }

        private async void clickedbackbtn(object sender, System.EventArgs e)
        {
            backActivity.IsVisible = true;
            backActivity.IsRunning = true;
            backIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            aiLayout.IsEnabled = true;
            backIndicator.IsVisible = false;
            backActivity.IsRunning = false;
            backActivity.IsVisible = false;

        }
    }
}