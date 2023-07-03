using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManifestUpdateRequest2 : ContentPage
    {
        //To check internet connection
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
        //To bind ViewModel
        public ManifestUpdateRequest2(string fstrVesselno,string fstrVoyageno,string fstrBOLno, string fstrScreenflag)
        {
            InitializeComponent();
            this.BindingContext = new ManifestUpdateRequest2ViewModel(fstrVesselno, fstrVoyageno, fstrBOLno, fstrScreenflag);
        }
    }
}