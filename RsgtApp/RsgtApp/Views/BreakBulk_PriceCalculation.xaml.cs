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
    public partial class BreakBulk_PriceCalculation : ContentPage
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
        /// To bind view model
        /// </summary>
        /// <param name="fstrTypeofCargo"></param>
        /// <param name="fstrCategoryofCargo"></param>
        /// <param name="fstrWeight"></param>
        /// <param name="fstrLength"></param>
        /// <param name="fstrWidth"></param>
        /// <param name="fstrHeight"></param>
        /// <param name="fstrDGCargo"></param>
        /// <param name="fstrDGaddlch"></param>
        public BreakBulk_PriceCalculation(string fstrTypeofCargo, string fstrCategoryofCargo, string fstrWeight, string fstrLength, string fstrWidth, string fstrHeight,string fstrDGCargo, string fstrDGaddlch)
        {
            InitializeComponent();
            this.BindingContext = new BreakBulk_PriceCalculationViewModel(fstrTypeofCargo, fstrCategoryofCargo, fstrWeight, fstrLength, fstrWidth, fstrHeight, fstrDGCargo, fstrDGaddlch);
        }
    }
}