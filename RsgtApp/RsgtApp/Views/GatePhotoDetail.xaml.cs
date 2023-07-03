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
    public partial class GatePhotoDetail : ContentPage
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
        /// To Bind View Model
        /// </summary>
        /// <param name="strBOL"></param>
        /// <param name="fstrContainerNo"></param>
        public GatePhotoDetail(string strBOL, string fstrContainerNo)
        {
            InitializeComponent();
            this.BindingContext =new GatePhotoDetailViewModel(strBOL, fstrContainerNo);
        }
        /// <summary>
        /// To check clickedBOLPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickedBOLPage(object sender, EventArgs e)
        {
            GatePhotoDetailActivityIndicator.IsVisible = true;
            GatePhotoDetailActivityIndicator.IsRunning = true;
            GatePhotoDetailIndecator.IsVisible = true;
            aiLayout.IsEnabled = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new BOL("", gblBayan.strgblBaynanNo, "", "", "", ""));
            aiLayout.IsEnabled = true;
            GatePhotoDetailIndecator.IsVisible =false;
            GatePhotoDetailActivityIndicator.IsRunning =false;
            GatePhotoDetailActivityIndicator.IsVisible =false;
        }
    }
}