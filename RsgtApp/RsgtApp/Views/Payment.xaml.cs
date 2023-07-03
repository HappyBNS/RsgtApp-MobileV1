using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payment : ContentPage
    {
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;

        /// <summary>
        ///  To check internet connection
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
        /// the  payment consector function
        /// </summary>
        /// <param name="fstrBLNO"></param>
        /// <param name="fstrConsigneeName"></param>
        /// <param name="fstrInvoiceFlag"></param>
        public Payment(string fstrBLNO, string fstrConsigneeName, string fstrInvoiceFlag)
        {
            InitializeComponent();



           // objCMS = await dbLayer.LoadContent("RM026");
            
            enumDirection = FlowDirection.LeftToRight;
            string strOk = dbLayer.getCaption("strOk", objCMS);
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }
            //dbLayer.lintLanguage = lintIndex;
            //dbLayer.objInfoitems = objCMS;
            this.FlowDirection = enumDirection;
            //https://portal-test.rsgt.com/AppointBooking/InvoicePaymentBLInfo?fstrBLNo=%271504466%27&fstrConName=ASTRA%20GRAINS%20COMPANY%20LIMITED
            var browser = new WebView();
            string strURL = AppSettings.MobPayment;
            string versionNo = AppSettings.WalletFlag;
            //To Handle Wallet 
            if (versionNo == "Y") versionNo = "5";

            if (fstrInvoiceFlag == "Y")
            {
                gblTrackRequests.strInvoiceandPaymentFlag = "Y";
            }
            else
            {
                gblTrackRequests.strWebInvoiceFlag = "Y";
            }


            //lblOk.Text = strOk;
            var url = strURL;
            url = url + "fstrBLNo=" + fstrBLNO + "&fstrConName=" + fstrConsigneeName + "&fstrInvoiceFlag=" + fstrInvoiceFlag + "&fstrWebView=" + App.gblWebViewCredentials;
            url += "&fstrWebViewUserId=" + gblRegisteration.strLoginUser + "&fstrMobileVersion=" + versionNo;
            browser.Source = url;
            Content = browser;

        }
        /// <summary>
        /// To handel web view page
        /// </summary>
        /// <param name="webview"></param>
        /// <returns></returns>
        private WebView findViewById(object webview)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// To handel in cms caption 
        /// </summary>
        public void assignContent()
        {
            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }
          
            dbLayer.objInfoitems = objCMS;
            this.FlowDirection = enumDirection;
            imgPDF.Source = dbLayer.getCaption("imgAboutImage", objCMS);
            lblPaymentPDF.Text = dbLayer.getCaption("strAboutRSGT", objCMS);
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>      
               </body></html>";
        }
        /// <summary>
        /// To handel in cancel buttion click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickedBOL(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            PaymentActivityIndicator.IsVisible = true;
            PaymentActivityIndicator.IsRunning = true;
            PaymentIndecator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            if (gblTrackRequests.strWebInvoiceFlag == "Y")
            {
                gblTrackRequests.strWebInvoiceFlag = "N";
                //App.Current.MainPage?.Navigation.PopToRootAsync();
                //Application.Current.MainPage?.Navigation.PopAsync();
                //Application.Current.MainPage? = new AppShell();
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));

            }



            if (gblTrackRequests.strInvoiceandPaymentFlag == "Y")
            {
                gblTrackRequests.strInvoiceandPaymentFlag = "N";
                //App.Current.MainPage?.Navigation.PopToRootAsync();
                //Application.Current.MainPage?.Navigation.PopAsync();
                //Application.Current.MainPage? = new AppShell();
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "","N"));

            }

            aiLayout.IsEnabled = true;
            PaymentIndecator.IsVisible = false;
            PaymentActivityIndicator.IsRunning = false;
            PaymentActivityIndicator.IsVisible = false;
        }
    }
}