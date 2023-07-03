using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System.Threading.Tasks;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceandPayment : ContentPage
    {
        public static int Tapped { get; internal set; }

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
                    // assignCms();
                    // StackInvoicePay.IsEnabled = true;                   
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
        /// Begin Invoice and Payment Constructor
        /// </summary>
        /// <param name="strsearchbox">Search Box</param>
        /// <param name="strInvoiceNo">Invoice Number</param>
        /// <param name="strdBOLNo">BOL Number</param>
        /// <param name="strCutomer">Customer</param>
        /// <param name="strPaymentRef">Payment Ref</param>
        /// <param name="strSelectedStatus">Filter Selected Status Value</param>
        /// <param name="strSelectedMop">Filter Selected Method of payment Value</param>
        /// <param name="lstrFromDate">From Date</param>
        /// <param name="lstrToDate">To Date</param>
        /// <param name="lstrFromAmount">From Amount</param>
        /// <param name="lstrToAmount">To Amount</param>
        /// <param name="strSelectedType">Filter select type of value</param>
        /// <param name="lstrDueDate"></param>
        public InvoiceandPayment(string strsearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string lstrFromDate, string lstrToDate, string lstrFromAmount, string lstrToAmount, string strSelectedType, string lstrDueDate, string strFilterflag)
        {
            try
            {
                InitializeComponent();
                // To bind ViewModel 
                BindingContext = new InvoiceandPaymentViewModel(strsearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, lstrFromDate, lstrToDate, lstrFromAmount, lstrToAmount, strSelectedType, lstrDueDate, strFilterflag,this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        ///  Begin Invoice and Payment Constructor
        /// </summary>
        public InvoiceandPayment()
        {
            try
            {
                InitializeComponent();
                // To bind ViewModel 
                BindingContext = new InvoiceandPaymentViewModel("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "","N",this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To handel in cancel buttion click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickedMainPage(object sender, EventArgs e)
        {
            InvoicepayActivityIndicator.IsVisible = true;
            InvoicepayActivityIndicator.IsRunning = true;
            InvoiceIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
            aiLayout.IsEnabled = true;
            InvoiceIndicator.IsVisible = false;
            InvoicepayActivityIndicator.IsRunning = false;
            InvoicepayActivityIndicator.IsVisible = false;
        }

        private void btnreset(object sender, EventArgs e)
        {
            dtfromdate.CleanDate();
            dtTodate.CleanDate();
        }

        private void BtnClose(object sender, EventArgs e)
        {
            dtfromdate.CleanDate();
            dtTodate.CleanDate();
        }
    }
}