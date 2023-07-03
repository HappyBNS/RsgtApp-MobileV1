using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManifestContainerList : ContentPage
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
        //To bind view model
        public ManifestContainerList(string fstrVesselno, string fstrVoyageno, string fstrBOLno)
        {
            InitializeComponent();
            this.BindingContext = new ManifestContainerListViewModel(fstrVesselno, fstrVoyageno, fstrBOLno);
        }

        private async void clickedbackbtn(object sender, System.EventArgs e)
        {
            ManifastbackActivity.IsVisible = true;
            ManifastbackActivity.IsRunning = true;
            ManifastIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            aiLayout.IsEnabled = true;
            ManifastIndicator.IsVisible = false;
            ManifastbackActivity.IsRunning = false;
            ManifastbackActivity.IsVisible = false;

        }
    }
}