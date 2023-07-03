using System;
using RsgtApp.BusinessLayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BayanFilter : ContentPage
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
        /// To Bind ViewModel
        /// </summary>
        public BayanFilter()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new BayanViewModel("", "", "", "", "", "Y","");
            }
            catch (Exception ex)
            {

                this.DisplayToastAsync(ex.Message, 3000);
            }

        }
    }
}