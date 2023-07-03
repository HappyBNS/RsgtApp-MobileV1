
using Nancy.Json;
using Newtonsoft.Json;
using System;
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
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Keyfeatures : ContentPage
    {

        /// <summary>
        /// Global Declaration
        /// </summary>
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
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
        public Keyfeatures()
        {
            InitializeComponent();
            KeyfeaturesActivityIndicator.IsRunning = true;
            // prepareDictionary();
            // await dbLayer.LoadContent("RM023", pageContent);
            assignCms();
            GetData();
           // assignContent();
            
        }
        /// <summary>
        /// Method is for Assign Content
        /// </summary>

        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM023");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM023");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM023");
                assignContent();

            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
        }

        public async void assignContent()
        {
            
            enumDirection = FlowDirection.LeftToRight;
            if (strLanguage == "Ar")
            {
                enumDirection = FlowDirection.RightToLeft;
                
            }
          
            this.FlowDirection = enumDirection;
            await Task.Delay(1000);
            imgBackArrow.Source = dbLayer.getCaption("imgArrowicon", objCMS);
            lblKeyFeatures.Text = dbLayer.getCaption("strKeyFeatures", objCMS); 
            imgTickBlue1.Source = dbLayer.getCaption("imgblueicon", objCMS);
            lblEffective.Text = dbLayer.getCaption("strEffectiveConsignmentmsg", objCMS); 
            imgTickBlue2.Source = dbLayer.getCaption("imgblueicon", objCMS);
            lblMinute.Text = dbLayer.getCaption("strUpdatedVesselSchedulesKey", objCMS); 
            imgTickBlue3.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblGenerate.Text = dbLayer.getCaption("strGenerateandViewInvoicesmsg", objCMS); 
            imgTickBlue4.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblCustomized.Text = dbLayer.getCaption("strCustomized", objCMS);
            imgTickBlue5.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblMultiple.Text = dbLayer.getCaption("strMultipleOptions", objCMS); 
            imgTickBlue6.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblFast.Text = dbLayer.getCaption("strFastDeliverymsg", objCMS); 
            imgTickBlue7.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblReal.Text = dbLayer.getCaption("strRealTimData", objCMS); 
            imgTickBlue8.Source = dbLayer.getCaption("imgblueicon", objCMS);
            lblEase.Text = dbLayer.getCaption("strEaseofBusiness", objCMS);
            imgTickBlue9.Source = dbLayer.getCaption("imgblueicon", objCMS);
            lblSelfService.Text = dbLayer.getCaption("strselfserviceViaInternet", objCMS);
            imgTickBlue10.Source = dbLayer.getCaption("imgblueicon", objCMS); 
            lblInformationAccess.Text = dbLayer.getCaption("strEaseofinformationaccess", objCMS); 
        }

        private async void GetData()
        {
            aiLayout.IsVisible = true;
            await Task.Delay(1000);
            KeyfeaturesActivityIndicator.IsVisible = false;
            aiLayout.IsVisible = false;
        }

    }
}