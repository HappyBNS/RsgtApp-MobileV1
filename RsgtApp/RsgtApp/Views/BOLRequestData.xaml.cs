﻿using RsgtApp.BusinessLayer;
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
    public partial class BOLRequestData : ContentPage
    {
        /// <summary>
        ///  To Check Internet Connection
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
        /// To bind ViewModel
        /// </summary>
        /// <param name="strBOL"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="strBaynanNo"></param>
        /// <param name="fstrRequest"></param>
        public BOLRequestData(string strBOL,string fstrContainerNo,string strBaynanNo,string fstrRequest)
        {
            InitializeComponent();
            this.BindingContext = new BOLRequestViewModel(strBOL, fstrContainerNo, strBaynanNo, fstrRequest);
        }
    }
}