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
    public partial class ContainerInspectionPhoto : ContentPage
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
        /// <param name="strBOLNo"></param>
        /// <param name="strContainerNo"></param>
        public ContainerInspectionPhoto(string strBOLNo,string strContainerNo)
        {
            InitializeComponent();
            this.BindingContext = new ContainerInspectionPhotoViewModel(strBOLNo, strContainerNo);
        }
    }
}