using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
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
        /// To Handle Logout
        /// </summary>
        public Logout()
        {
            InitializeComponent();
            LogoutActivityIndicator.IsVisible = true;
            GetData();
            //To clear Global properties
            var fields = typeof(gblRegisteration).GetFields(BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                var type = field.GetType();
                field.SetValue(null, null);
            }
           // BioLoginClear();
            gblRegisteration.strLoginFirstName = null;
            gblRegisteration.strLoginUser = null;
            //App.gblLanguage = "En";
            App.gblRole = "An";
            // Application.Current.MainPage?.Navigation.PopToRootAsync();
            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
        }
        /// <summary>
        /// To get Data
        /// </summary>
        private async void GetData()
        {
            await Task.Delay(1000);
            LogoutActivityIndicator.IsVisible = false;
        }
    }
}