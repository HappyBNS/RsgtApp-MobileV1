
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.Views;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracksubmenu : ContentPage
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private List<InfoItem> objCMSMSG = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();

       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
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
                StackTrackMenu.IsEnabled = true;
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
        /// To Tracksubmenu constructor
        /// </summary>
        public Tracksubmenu()
        {
            InitializeComponent();
            // TrackActivityIndicator.IsVisible = true;
          
            assignContent();

        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignContent()
        {
            StackTrackMenu.IsEnabled = false;
            TrackActivityIndicator.IsRunning = true;
            TrackActivityIndicator.IsVisible = true;
            aiLayout.IsVisible = true;
            objCMS = await dbLayer.LoadContent("RM010");

            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}

          
           // dbLayer.objInfoitems = objCMS;

            imgShipmentIcon.Source = dbLayer.getCaption("imgShipment", objCMS);
            lblTrack.Text = dbLayer.getCaption("strTracking", objCMS);
            lblBasicTracking.Text = dbLayer.getCaption("strBasicTracking", objCMS);
            lblAdvanceTracking.Text = dbLayer.getCaption("strAdvanceTracking", objCMS);
            await Task.Delay(1000);
            TrackActivityIndicator.IsRunning = false;
            TrackActivityIndicator.IsVisible = false;
            StackTrackMenu.IsEnabled = true;
            aiLayout.IsVisible = false;

        }

        /// <summary>
        /// To handle in Trackbasic cilck event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Trackbasic(object sender, EventArgs e)
        {
            StackTrackMenu.IsEnabled = false;
            TrackActivityIndicator.IsVisible = true;
            TrackActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623

            await App.Current.MainPage?.Navigation.PushAsync(new Basic_tracking());

            TrackActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            TrackActivityIndicator.IsVisible = false;
            StackTrackMenu.IsEnabled = true;


        }
        /// <summary>
        /// To handle in Trackadvance event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void Trackadvance(object sender, EventArgs e)
        {
            StackTrackMenu.IsEnabled = false;
            TrackActivityIndicator.IsVisible = true;
            TrackActivityIndicator.IsRunning = true; // Change 20220623
            aiLayout.IsVisible = true;
            await Task.Delay(1000);// Change 20220623
                                   //On Vessel   100
                                   //In Yard         101
                                   //In Progress 102
                                   //Completed   103
            await App.Current.MainPage?.Navigation.PushAsync(new Bayan("", "", "", "", "101,102", ""));
            TrackActivityIndicator.IsRunning = false; // Change 20220623
            aiLayout.IsVisible = false;
            TrackActivityIndicator.IsVisible = false;
            StackTrackMenu.IsEnabled = true;

        }


    }
}