using RsgtApp.ViewModels;
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

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestHistory : ContentPage
    {
        /// <summary>
        ///  To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                if (App.isinternetSlowEnablement == true)//20220912 BABU
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
        /// Begin Request_TicketsList constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="strselectedcategory"></param>
        /// <param name="strselectedtype"></param>
        /// <param name="strTicketNo"></param>
        /// <param name="fstrScreenFlag"></param>
        public RequestHistory(string strSearchbox, string strselectedStatus, string strselectedcategory, string strselectedtype, string strTicketNo, string fstrScreenFlag)
        {
            InitializeComponent();
            this.BindingContext = new RequestHistoryViewModel(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo, fstrScreenFlag,this);
        }

        private async void clickedRequest(object sender, System.EventArgs e)
        {
            ReqhistActivity.IsVisible = true;
            ReqhistActivity.IsRunning = true;
            ReqhistIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            aiLayout.IsEnabled = true;
            ReqhistIndicator.IsVisible = false;
            ReqhistActivity.IsRunning = false;
            ReqhistActivity.IsVisible = false;

        }


    }
}