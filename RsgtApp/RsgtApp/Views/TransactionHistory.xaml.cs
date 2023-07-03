using RsgtApp.BusinessLayer;
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
    public partial class TransactionHistory : ContentPage
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
        /// To handle in TransactionHistory view model
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strSelectedPeriod"></param>
        /// <param name="strSelectedTransactionType"></param>
        /// <param name="strFromDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="strFromAmount"></param>
        /// <param name="strToAmount"></param>
        public TransactionHistory(string strSearchbox,string strSelectedPeriod, string strSelectedTransactionType, string strFromDate, string strToDate, string strFromAmount, string strToAmount)
        {
            InitializeComponent();
            this.BindingContext = new TransactionHistoryViewModel(strSearchbox, strSelectedPeriod,  strSelectedTransactionType,  strFromDate,  strToDate,  strFromAmount,  strToAmount,this);
        }

        private void ImgReset(object sender, EventArgs e)
        {
            dtTodate.CleanDate();
            dtFromdate.CleanDate();
        }

        private void BtnClose(object sender, EventArgs e)
        {
            dtTodate.CleanDate();
            dtFromdate.CleanDate();
        }
    }
}
