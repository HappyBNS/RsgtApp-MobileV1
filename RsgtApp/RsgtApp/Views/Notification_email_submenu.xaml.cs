﻿using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notification_email_submenu : ContentPage
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
        /// <param name="fstrFlag"></param>
        public Notification_email_submenu(string fstrFlag)
        {
            InitializeComponent();
            BindingContext = new NotificationSubmenusViewModel(fstrFlag);
        }
    }
}