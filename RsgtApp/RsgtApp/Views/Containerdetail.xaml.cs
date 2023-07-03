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
    public partial class Containerdetail : ContentPage
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
        /// <param name="fstrConatinerNo"></param>
        /// <param name="fstrBLNo"></param>
        /// <param name="fstrBayanNo"></param>
        public Containerdetail(string fstrConatinerNo, string fstrBLNo, string fstrBayanNo)
        {
            try
            {
                InitializeComponent();
                BindingContext = new ContainerdetailViewModel(fstrConatinerNo, fstrBLNo, fstrBayanNo);//To Bind ViewModel
            }
            catch (Exception ex)
            {
                this.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}