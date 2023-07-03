using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentBooking : ContentPage
    {
        /// <summary>
        /// To check Internet connectivity
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                var profiles = Connectivity.ConnectionProfiles;
                if (current == NetworkAccess.Internet)
                {
                    // To check Internet Slow
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
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind ViewModel 
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strBillofLadingNo"></param>
        /// <param name="strContainerNo"></param>
        /// <param name="strTmsReference"></param>
        /// <param name="strAppDate"></param>
        /// <param name="strSelectedStatus"></param>
        /// <param name="lstrAppDate"></param>
        public AppointmentBooking(string strSearchbox, string strBillofLadingNo, string strContainerNo, string strTmsReference, string strAppDate, string strSelectedStatus,string lstrAppDate,string fstrFilterFlag)
        {
            try
            {
                InitializeComponent();
                BindingContext = new AppointmentBookingViewModel(strSearchbox, strBillofLadingNo, strContainerNo, strTmsReference, strAppDate, strSelectedStatus, lstrAppDate, fstrFilterFlag,this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        private void BtnReset(object sender, EventArgs e)
        {
            dtDateApp.CleanDate();
        }

        private void BtnClose(object sender, EventArgs e)
        {
            dtDateApp.CleanDate();
        }
    }
}