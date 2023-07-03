using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InLocationEquipmentrequest2 : ContentPage
    {
        /// <summary>
        /// To Check Internet Connection
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
        /// To Bind View Model
        /// </summary>
        /// <param name="fstrContainerno"></param>
        /// <param name="fstrAppointmentno"></param>
        public InLocationEquipmentrequest2(string fstrContainerno,string fstrAppointmentno)
        {
            InitializeComponent();
            this.BindingContext = new InLocationRequest2ViewModel(fstrContainerno, fstrAppointmentno);
        }   
    }
}