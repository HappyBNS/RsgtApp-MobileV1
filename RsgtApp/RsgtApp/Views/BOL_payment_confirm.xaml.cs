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
using RsgtApp.Views;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BOL_payment_confirm : ContentPage
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
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
        public BOL_payment_confirm()
        {
            InitializeComponent();
            this.BindingContext = this;
            //await dbLayer.LoadContent("RM028", pageContent);
            //objCMS = await dbLayer.LoadContent("RM028");
            assignContent();
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            BOLPaymentConfirmActivityIndicator.IsVisible = true;
            BOLPaymentConfirmActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            StackPaymentConfirm.IsEnabled = false;
            await Task.Delay(1000);


            
         

          
            dbLayer.objInfoitems = objCMS;

            lblPaymentConfirmation.Text = dbLayer.getCaption("strPaymentConfirmation", objCMS);
            imgWallet.Source = dbLayer.getCaption("imgWallet", objCMS);
            lblMyWallet.Text = dbLayer.getCaption("strMyWallet", objCMS);
            imgCompletedIcon.Source = dbLayer.getCaption("imgCompleted", objCMS);
            lblMessage.Text = dbLayer.getCaption("strpaymentReceived", objCMS);
            lblPaymentDetails.Text = dbLayer.getCaption("strPaymentDetails", objCMS);
            lblPaymentReference.Text = dbLayer.getCaption("strPaymentReference", objCMS);
            lblDate.Text = dbLayer.getCaption("strDate", objCMS);
            lblPaymentMethod.Text = dbLayer.getCaption("strPaymentMethods", objCMS);
            lblInvoices.Text = dbLayer.getCaption("strInvoices", objCMS);
            lblAmount.Text = dbLayer.getCaption("strAmountSAR", objCMS);
            btnBookAppoinment.Text = dbLayer.getCaption("strBookanAppointment", objCMS);


            BOLPaymentConfirmActivityIndicator.IsVisible = false;
            BOLPaymentConfirmActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;
            StackPaymentConfirm.IsEnabled = true;

        }
        /// <summary>
        /// To get Button Appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Appointment(object sender, EventArgs e)
        {
            BOLPaymentConfirmActivityIndicator.IsVisible = true;
            BOLPaymentConfirmActivityIndicator.IsRunning = true;
            aiLayout.IsVisible = true;
            StackPaymentConfirm.IsEnabled = false;
            await Task.Delay(1000);
            await Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "","","N"));
            BOLPaymentConfirmActivityIndicator.IsVisible = false;
            BOLPaymentConfirmActivityIndicator.IsRunning = false;
            aiLayout.IsVisible = false;
            StackPaymentConfirm.IsEnabled = true;
        }
    }
}