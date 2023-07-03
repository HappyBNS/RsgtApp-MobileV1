using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContainerPhotoDetails : ContentPage
    {

        /// <summary>
        /// To Check Internet Connection
        /// </summary>
        protected async override void OnAppearing()
        {
            try
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
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To handle in view connect to ViewModel
        /// </summary>
        /// <param name="strBOL">BOL NUMBER</param>
        /// <param name="fstrContainerNo">Container Number</param>
        public ContainerPhotoDetails(string strBOL, string fstrContainerNo)
        {
            // To bind ViewModel
            InitializeComponent();
            this.BindingContext = new ContainerPhotoDetailsViewModel(strBOL, fstrContainerNo);
        }
        /// <summary>
        /// To handel in Cancel buttion click event function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickedContainerPage(object sender, EventArgs e)
        {
            ContainerPhotoActivityIndicator.IsVisible = true;
            ContainerPhotoActivityIndicator.IsRunning = true;
            ContainerPhotoIndecator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Containerlist("", gblBol.strgblBolNo, "", "", "", "", "", "", "","N"));
            aiLayout.IsEnabled = true;
            ContainerPhotoIndecator.IsVisible = false;
            ContainerPhotoActivityIndicator.IsRunning = false;
            ContainerPhotoActivityIndicator.IsVisible = false;
        }
    }
}