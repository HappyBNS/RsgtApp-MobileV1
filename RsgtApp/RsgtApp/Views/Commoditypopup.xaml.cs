﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.ViewModels;

namespace RsgtApp.Views

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Commoditypopup : ContentPage
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
        /// <param name="fstrBLNo"></param>
        public Commoditypopup(string fstrBLNo)
        {
            InitializeComponent();
            this.BindingContext =new CommodityPopupViewModel(fstrBLNo);
        }
    }
}