﻿using System;
using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using System.Collections;
using RsgtApp.Views;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regenerate_Invoice : ContentPage
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

        /// <summary>
        /// To handel in RegenerateInvoice Constructor
        /// </summary>
        public Regenerate_Invoice()
        {
            InitializeComponent();
            this.BindingContext = new RegenerateInvoiceViewmodel();
        }

    }
}