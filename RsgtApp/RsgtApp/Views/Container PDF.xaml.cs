using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using RsgtApp.BusinessLayer;
using Xamarin.Essentials;
using System;
using Foundation;
using UIKit;
using Xamarin.CommunityToolkit.Extensions;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Container_PDF : ContentPage
    {
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
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
        /// <param name="fstrBLNO"></param>
        /// <param name="fstrContainerNo"></param>
        public Container_PDF(string fstrBLNO, string fstrContainerNo)
        {
            InitializeComponent();
            //await dbLayer.LoadContent("RM001", pageContent);
           // objCMS = await dbLayer.LoadContent("RM001");
            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }

          
            dbLayer.objInfoitems = objCMS;
            this.FlowDirection = enumDirection;

            string strURL = AppSettings.MobWebUrl;      
            var pdfUrl = strURL + "@microsoft.graph.downloadUrl" + "fstrContainerNo=" + fstrContainerNo + "&fstrBlnNo=" + fstrBLNO + "";//20220829 babu
            //var pdfUrl= fstrBLNO + ""; //20220829
            if (fstrContainerNo == "N")
            {
                pdfUrl = fstrBLNO;
            }
            if (Device.RuntimePlatform == Device.iOS)
            {
                var url = new NSUrl(pdfUrl);
                if (UIApplication.SharedApplication.CanOpenUrl(url))
                {
                    // bool doesExist = File.Exists(pdfUrl);
                    var success = UIApplication.SharedApplication.OpenUrl(url);
                }
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                if (fstrContainerNo == "N")
                {
                    ContainerPDFView.Source = pdfUrl;
                }
                else
                {
                  
                    //ContainerPDFView.Source = googleUrl + pdfUrl;
                    openPdf(pdfUrl);
                }

            }

        }
        /// <summary>
        /// To get Pdf
        /// </summary>
        /// <param name="fstrUrl"></param>
        private async void  openPdf(string fstrUrl)
        {
            // Device.OpenUri(new Uri("http://example.com"))
            await Browser.OpenAsync(fstrUrl, BrowserLaunchMode.SystemPreferred);
        }

        /// <summary>
        /// To findViewById
        /// </summary>
        /// <param name="webview"></param>
        /// <returns></returns>
        private WebView findViewById(object webview)
        {
            throw new NotImplementedException();
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
            lblContainerPDF.Text = dbLayer.getCaption("strAboutRSGT", objCMS);
            // abttext.Text = dbLayer.getCaption("strTermsconditionsTitle1").ToString();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>
       
        </body></html>";
            //var txtContainerPDF = "";
            //txtTermsConditonData = dbLayer.getCaption("strTermsconditionsTitle1Test").ToString();
            //htmlSource.Html = @"<html><body>" + txtTermsConditonData+ "</body></html>";
            ////  WebView.Source = htmlSource;
            //  //Dictionary<string, string> objcotainerPDF = dbLayer.getLOV("strAboutRsgtTitle");
            //  foreach (var dic in objcotainerPDF)
            //  {
            //      txtContainerPDF += dic.Key + "</br>";
            //  }
            //  htmlSource.Html = @"<html><body style='color:#0073a2;' >  " + txtContainerPDF + "</body></html>";
        }
    }
}