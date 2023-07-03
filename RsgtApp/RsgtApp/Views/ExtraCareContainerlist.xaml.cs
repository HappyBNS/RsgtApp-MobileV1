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
    public partial class ExtraCareContainerlist : ContentPage
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
        public ExtraCareContainerlist()
        {
            InitializeComponent();
            this.BindingContext = new ExtraCareContainerlistViewModel();
        }

        private async void clickedbackbtn(object sender, System.EventArgs e)
        {
            ExtracarebackActivity.IsVisible = true;
            ExtracarebackActivity.IsRunning = true;
            ExtracareIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            aiLayout.IsEnabled = true;
            ExtracareIndicator.IsVisible = false;
            ExtracarebackActivity.IsRunning = false;
            ExtracarebackActivity.IsVisible = false;

        }
    }
}