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
    public partial class Evaluate : ContentPage
    {
        /// <summary>
        /// To check internet connection
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
                        if (App.isinternetSlowEnablement == true)
                        {
                            bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                            if (isConnectionFast)
                            { }
                            else
                                await this.DisplayToastAsync("Network Connection is slow", 3000);
                        }
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
        /// To bind view model
        /// </summary>
        /// <param name="strSearchbox"></param>
        public Evaluate(string strSearchbox )
        {
            try
            {
                InitializeComponent();
                BindingContext = new EvaluateViewModel(strSearchbox);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}