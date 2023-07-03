using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EIRPhotoDetail : ContentPage
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
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrTruckNo"></param>
        public EIRPhotoDetail(string fstrContainerNo,string fstrBOLNo,string fstrTruckNo, string fstrRequestDt)
        {
            InitializeComponent();
            this.BindingContext = new EIRPhotoDetailViewModel(fstrContainerNo, fstrBOLNo, fstrTruckNo, fstrRequestDt);
        }
    }
}