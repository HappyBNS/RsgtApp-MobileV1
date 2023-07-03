using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLoginOTP : ContentPage
    {
        /// <summary>
        ///  To Check Internet Connection
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            txtOtp.Focused += InputFocused;
            txtOtp.Unfocused -= InputUnfocused;
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
                       App.Current.MainPage?.DisplayToastAsync("Network Connection is slow", 3000);
                }
            }
            else
            {
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
            }
        }
        /// <summary>
        /// To handel in Disappearing
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            txtOtp.Focused -= InputFocused;
            txtOtp.Unfocused -= InputUnfocused;
        }
        /// <summary>
        /// To handel  Focusedin line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void InputFocused(object sender, EventArgs args)
        {
            Content.LayoutTo(new Rectangle(0, 0, Content.Bounds.Width, Content.Bounds.Height));
        }

        /// <summary>
        /// To handel in Unfocused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void InputUnfocused(object sender, EventArgs args)
        {
            Content.LayoutTo(new Rectangle(0, 0, Content.Bounds.Width, Content.Bounds.Height));
        }
        /// <summary>
        /// To handel in ViewModel
        /// </summary>
        public PageLoginOTP()
        {
            InitializeComponent();
            this.BindingContext = new PageLoginOTPViewModel();
        }
    }
}