using RsgtApp.BusinessLayer;
using RsgtApp.Views;
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


    public partial class VAS_main : ContentPage
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
                        await this.DisplayToastAsync("Network Connection is slow", 3000);
                }
            }
            else
            {
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }
        }

        /// <summary>
        /// To bind viewmodel
        /// </summary>
        public VAS_main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To handle in cilcked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bayan("","","","","",""));
        }
        /// <summary>
        ///  To handle in Dwelldays cilcked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapped_Dwelldays(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new DwellDays());
        }
        /// <summary>
        ///  To handle in Paymenthistory cilcked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapped_Paymenthistory(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentHistory("","","","","","","","","","","",""));
        }
        /// <summary>
        ///  To handle in Evaluate cilcked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapped_Evaluate(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Evaluate(""));
        }
        /// <summary>
        ///  To handle in TerminalVisit cilcked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapped_TerminalVisit(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TerminalVisit());
        }
    }
}