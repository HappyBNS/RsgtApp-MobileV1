
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
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using Xamarin.Essentials;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BOL_payment : ContentPage
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        //private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<clsBayan> lstBayan = new List<clsBayan>();
        
        private string strLanguage = App.gblLanguage;

        [Obsolete]
        public System.Windows.Input.ICommand MyPdftap => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
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
                        await this.DisplayToastAsync("Network Connection is slow", 3000);
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
        public BOL_payment()
        {
            InitializeComponent();
            this.BindingContext = this;
            assignCms();
        }
        /// <summary>
        /// To bind Cms Caption
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM028");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM028");
                }
                assignContent();

            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To Assign Captions
        /// </summary>
        public async void assignContent()
        {

            BOLPaymentActivityIndicator.IsVisible = true;
            BOLPaymentActivityIndicator.IsRunning = true;
            StackBOLPayment.IsEnabled = false;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);
            
          

            lblPayment.Text = dbLayer.getCaption("strPayment",objCMS);
            lblBayan.Text = dbLayer.getCaption("strBayan",objCMS);
            imgWallet.Source = dbLayer.getCaption("imgWallet",objCMS);
            lblMyWallet.Text = dbLayer.getCaption("strMyWallet",objCMS);
            lblInvoices.Text = dbLayer.getCaption("strInvoices",objCMS);
            lblAmount.Text = dbLayer.getCaption("strAmountSAR",objCMS);
            imgCancelIcon1.Source = dbLayer.getCaption("imgCancel",objCMS);
            imgCancelIcon2.Source = dbLayer.getCaption("imgCancel",objCMS);
            imgCancelIcon3.Source = dbLayer.getCaption("imgCancel",objCMS);
            lblPaymentMethod.Text = dbLayer.getCaption("strPaymentMethod",objCMS);
            txtEnterOtp.Placeholder = dbLayer.getCaption("strEnterOTP",objCMS);
            txtEnterOpt2.Placeholder = dbLayer.getCaption("strEnterOTP",objCMS);
            imgCreditCard.Source = dbLayer.getCaption("imgCreditcards",objCMS);
            imgMadaIcon.Source = dbLayer.getCaption("imgMada",objCMS);
            btnPayNow.Text = dbLayer.getCaption("strPayNow",objCMS);

            BOLPaymentActivityIndicator.IsVisible = false;
            BOLPaymentActivityIndicator.IsRunning = false;
            StackBOLPayment.IsEnabled = true;
            aiLayout.IsVisible = false;

        }
        /// <summary>
        /// To Handle RadioButton_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var AP = Apayment;
            var FP = Fpayment;

            AP.IsVisible = true;
            FP.IsVisible = false;

        }
        /// <summary>
        /// To Handle RadioButton_FPChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_FPChanged(object sender, CheckedChangedEventArgs e)
        {
            var AP = Apayment;
            var FP = Fpayment;

            AP.IsVisible = false;
            FP.IsVisible = false;

        }
        /// <summary>
        /// To Get Radio Button Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CCChanged(object sender, CheckedChangedEventArgs e)
        {
            var AP = Apayment;
            var FP = Fpayment;

            AP.IsVisible = false;
            FP.IsVisible = false;

        }
        /// <summary>
        /// To get payment confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void payment_confirm(object sender, EventArgs e)
        {
            BOLPaymentActivityIndicator.IsVisible = true;
            BOLPaymentActivityIndicator.IsRunning = true;
            StackBOLPayment.IsEnabled = false;
            aiLayout.IsVisible = true;
            await Task.Delay(1000);

            await App.Current.MainPage?.Navigation.PushAsync(new BOL_payment_confirm());

            BOLPaymentActivityIndicator.IsVisible = false;
            BOLPaymentActivityIndicator.IsRunning = false;
            StackBOLPayment.IsEnabled = true;
            aiLayout.IsVisible = false;
        }
    }
}