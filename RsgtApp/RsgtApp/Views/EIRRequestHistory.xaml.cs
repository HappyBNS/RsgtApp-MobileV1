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
    public partial class EIRRequestHistory : ContentPage
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
        /// To bind view model
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrRequestDate"></param>
        /// <param name="fstrSelectedStatus"></param>
        public EIRRequestHistory(string fstrsearch,string fstrContainerNo, string fstrBOLNo, string fstrRequestDate,string fstrSelectedStatus)
        {
            InitializeComponent();
            this.BindingContext = new EIRRequestHistoryViewModel(fstrsearch, fstrContainerNo, fstrBOLNo, fstrRequestDate, fstrSelectedStatus,this);
        }

        private void BtnReset(object sender, System.EventArgs e)
        {
            dtRequestedDate.CleanDate();
        }

        private void BtnClose(object sender, System.EventArgs e)
        {
            dtRequestedDate.CleanDate();
        }

        private async void clickedEIRRequestCarePage(object sender, System.EventArgs e)
        {
            EirActivity.IsVisible = true;
            EirActivity.IsRunning = true;
            EirIndicator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PopToRootAsync();
            //await App.Current.MainPage?.Navigation.PushAsync(new Other_Request_main());
            aiLayout.IsEnabled = true;
            EirIndicator.IsVisible = false;
            EirActivity.IsRunning = false;
            EirActivity.IsVisible = false;

        }
    }
}