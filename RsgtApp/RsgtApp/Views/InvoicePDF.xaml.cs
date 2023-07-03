using Foundation;
using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Invoice : ContentPage
    {
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
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
        /// To bind ViewModel
        /// </summary>
        /// <param name="fstrINNo"></param>
        /// <param name="fstrProFormaFlag"></param>
        public Invoice(string fstrINNo, string fstrProFormaFlag)
        {
            InitializeComponent();

            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }

            //var pdfUrl = "https://portal-dev.rsgt.com:8090/ftp/pdf/";

            var pdfUrl = "";

             if (fstrProFormaFlag == "N")
            {

                //fstrINNo = "373056811";
                pdfUrl += "Invoice/INO_" + fstrINNo + ".pdf";
            }
            if (fstrProFormaFlag == "Y")
            {
               // fstrINNo = "1557216";
                pdfUrl += "Profoma/PNO_" + fstrINNo + ".pdf";
            }

            var googleUrl = "https://docs.google.com/gview?embedded=true&url=";

            if (Device.RuntimePlatform == Device.iOS)
            {
                // InvoicePDFView.Source = pdfUrl;
                // InvoicePDFView.Source = googleUrl + pdfUrl;
               
                var url = new NSUrl(pdfUrl);
                if (UIApplication.SharedApplication.CanOpenUrl(url))
                {
                   // bool doesExist = File.Exists(pdfUrl);
                    var success = UIApplication.SharedApplication.OpenUrl(url);
                }
                
            }
            else if (Device.RuntimePlatform == Device.Android)
            {

                InvoicePDFView.Source = googleUrl + pdfUrl;



            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
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
            lblInvoicePDF.Text = dbLayer.getCaption("strAboutRSGT", objCMS);


            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>
       
               </body></html>";





        }

    }
}