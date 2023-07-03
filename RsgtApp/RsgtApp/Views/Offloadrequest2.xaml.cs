using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Offloadrequest2 : ContentPage
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
        /// To bind Viewmodel
        /// </summary>
        /// <param name="fstrContainerno"></param>
        /// <param name="fstrlblValBOLno"></param>
        public Offloadrequest2(string fstrContainerno,string fstrlblValBOLno )
        {
            InitializeComponent();
            this.BindingContext = new Offloadrequest2ViewModel(fstrContainerno, fstrlblValBOLno);
        }
    }
}