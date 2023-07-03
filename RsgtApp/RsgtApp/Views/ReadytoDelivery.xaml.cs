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
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadytoDelivery : ContentPage
    {
      
        public System.Windows.Input.ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        /// <summary>
        /// To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
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
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// Begin ReadytoDelivery Constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strslectedSize"></param>
        /// <param name="strselectedCarrier"></param>
        /// <param name="strselsctedCategory"></param>
        /// <param name="strselectedFreightkind"></param>
        /// <param name="strselectedPOL"></param>
        /// <param name="strselectedPOD"></param>
        /// <param name="strselectedContainerNo"></param>
        /// <param name="strselectedBayanNo"></param>
        /// <param name="strselectedBOLNo"></param>
        public ReadytoDelivery(string strSearchbox, string strslectedSize, string strselectedCarrier, string strselsctedCategory, string strselectedFreightkind, string strselectedPOL, string strselectedPOD, string strselectedContainerNo, string strselectedBayanNo, string strselectedBOLNo,string fstrFilterFlag)
        {
            try
            {
                InitializeComponent();
                // To bind ViewModel 
                BindingContext = new ReadytoDeliveryViewModel(strSearchbox, strslectedSize, strselectedCarrier, strselsctedCategory, strselectedFreightkind, strselectedPOL, strselectedPOD, strselectedContainerNo, strselectedBayanNo, strselectedBOLNo, fstrFilterFlag,this);
            }
            catch (Exception ex)
            {

                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
      
    }

}