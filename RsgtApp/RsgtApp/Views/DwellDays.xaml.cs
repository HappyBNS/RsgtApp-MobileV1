using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DwellDays : ContentPage
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

                await this.DisplayToastAsync(ex.Message, 3000);
            }

        }
        /// <summary>
        /// To bind ViewModel 
        /// </summary>
        /// <param name="fstrSearch"></param>
        /// <param name="fstrselectedSize"></param>
        /// <param name="fstrselectedCarrier"></param>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrBillofLadingNo"></param>
        /// <param name="fstrDwellDays"></param>
        /// <param name="flstrDischargedate"></param>
        /// <param name="flstrGateOutdate"></param>
        public DwellDays(string fstrSearch, string fstrselectedSize, string fstrselectedCarrier, string fstrContainerNo, string fstrBayanNo, string fstrBillofLadingNo, string fstrDwellDays, string flstrDischargedate, string flstrGateOutdate,string fstrFilterFlag)
        {
            try
            {
                InitializeComponent();

                BindingContext = new DwelldaysViewModel(fstrSearch, fstrselectedSize, fstrselectedCarrier, fstrContainerNo, fstrBayanNo, fstrBillofLadingNo, fstrDwellDays, flstrDischargedate, flstrGateOutdate, fstrFilterFlag,this);

             
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        private void BtnReset(object sender, EventArgs e)
        {
            dtDateDischarge.CleanDate();
            dtDateGatedOut.CleanDate();
        }

        private void btnclose(object sender, EventArgs e)
        {
            GridDwellDays.ScrollTo(0);
            dtDateDischarge.CleanDate();
        }

    }
}