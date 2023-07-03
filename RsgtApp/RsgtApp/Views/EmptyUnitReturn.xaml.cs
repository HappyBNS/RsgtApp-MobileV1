using System;
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
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyUnitReturn : ContentPage
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
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }

        }
        /// <summary>
        /// To bind view model
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strSelectedSize"></param>
        /// <param name="strSelectedcarrier"></param>
        /// <param name="strSelecteddepot"></param>
        /// <param name="lstrDetanDate"></param>
        public EmptyUnitReturn(string strSearchbox, string strContainerNo, string strBayanNo, string strBillofLadingNo, string strSelectedSize, string strSelectedcarrier, string strSelecteddepot, string lstrDetanDate)
        {
            InitializeComponent();
            BindingContext = new EmptyUnitReturnsViewModel(strSearchbox, strContainerNo, strBayanNo, strBillofLadingNo, strSelectedSize, strSelectedcarrier, strSelecteddepot, lstrDetanDate, "N", this);
        }
    }
}