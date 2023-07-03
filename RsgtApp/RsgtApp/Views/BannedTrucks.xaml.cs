using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BannedTrucks : ContentPage
    {
        /// <summary>
        /// To Check Internet Connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                var profiles = Connectivity.ConnectionProfiles;
                if (current == NetworkAccess.Internet)
                {
                    if (App.isinternetSlowEnablement == true)
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
        /// <param name="fstrTruckNo"></param>
        /// <param name="fsrtBanDate"></param>
        /// <param name="fstrBanReason"></param>
        /// <param name="fstrBanType"></param>
        /// <param name="fstrStatus"></param>
        public BannedTrucks(string strSearchbox, string fstrTruckNo, string fsrtBanDate, string fstrBanReason, string fstrBanType, string fstrStatus)
        {
            try
            {
                InitializeComponent();
                BindingContext = new BannedTrucksViewModel(strSearchbox, fstrTruckNo, fsrtBanDate, fstrBanReason, fstrBanType, fstrStatus,this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        private void btnReset(object sender, EventArgs e)
        {
            DtBannedDate.CleanDate();
        }

        private void BtnClose(object sender, EventArgs e)
        {
            DtBannedDate.CleanDate();
        }
    }
}