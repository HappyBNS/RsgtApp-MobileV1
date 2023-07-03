using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manuallnspection : ContentPage
    {

        /// <summary>
        /// Start the OnAppearing Function
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                //To check Internet Slow
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
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }


        /// <summary>
        ///  Begin Manuallnspection Constructor
        /// </summary>
        /// <param name="fstrContainerNo"></param>
        /// <param name="fstrBayanNo"></param>
        /// <param name="fstrBOLNo"></param>
        /// <param name="fstrSize"></param>
        /// <param name="fstrCarrier"></param>
        /// <param name="fstrCategory"></param>
        /// <param name="fstrFreightkind"></param>
        /// <param name="fstrPol"></param>
        /// <param name="fstrPod"></param>
        public Manuallnspection(string fstrContainerNo, string fstrBayanNo, string fstrBOLNo, string fstrSize, string fstrCarrier, string fstrCategory, string fstrFreightkind, string fstrPol, string fstrPod,string fstrFilterFlag)
        {
            try
            {
            InitializeComponent();
            //To bind ViewModel 
            BindingContext = new ManualInspectionViewModel(fstrContainerNo, fstrBayanNo, fstrBOLNo, fstrSize, fstrCarrier, fstrCategory, fstrFreightkind, fstrPol, fstrPod, fstrFilterFlag,this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        
    }
}
