using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VesselSchedule : ContentPage
    {
        //CMS caption related property       
        string lstrAnyWhere { get; set; }
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        public string lblstrVesselName { get; set; }
        public string lblstrStatus { get; set; }
        public string lblstrEta { get; set; }
        public string lblstrAtd { get; set; }
        public string strimgDownArrow { get; set; }
        public string lblstrVisitId { get; set; }
        public string lblstrVoyage { get; set; }
        public string lblstrServiceId { get; set; }
        public string lblstrCutOffTime { get; set; }

        /// <summary>
        /// To check internet connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                var profiles = Connectivity.ConnectionProfiles;
                // To check Internet connectivity
                if (current == NetworkAccess.Internet)
                {

                    // To check Internet Slow
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
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To bind viewmodel
        /// </summary>
        public VesselSchedule(string fstrOrgin)
        {
            try
            {
                InitializeComponent();
                // To bind ViewModel 
                BindingContext = new VesselScheduleViewModel(fstrOrgin);

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }




       
    }
}