using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using RsgtApp.BusinessLayer;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TruckService : ContentPage
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
        public TruckService()
        {
            InitializeComponent();
            this.BindingContext = new TruckServiceViewModel();
        }
    }
}