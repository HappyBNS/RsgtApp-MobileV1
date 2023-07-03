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
using System.Collections;
using RsgtApp.BusinessLayer;
using static RsgtApp.Models.DetentionManagementModelcs;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetentionManagement : ContentPage
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
                        await this.DisplayToastAsync("Network Connection is slow", 3000); // DependencyService.Get<IToast>().ShowToast("Network Connection is slow");
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
        /// <param name="strSearchbox"></param>
        /// <param name="strselectedSize"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strBayanNo"></param>
        public DetentionManagement(string strSearchbox, string strselectedSize, string strselectedCarrier, string strContainerNo, string strBayanNo)
        {
            try
            {
                InitializeComponent();
                BindingContext = new DetentionManagementViewModel(strSearchbox, strselectedSize, strselectedCarrier, strContainerNo, strBayanNo, "N");
            }
            catch (Exception ex)
            {

                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }

}