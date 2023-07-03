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
    public partial class Request_TicketsList : ContentPage
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
                    //To check internet slow
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
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        /// <summary>
        /// Begin Request_TicketsList constructor
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strselectedStatus"></param>
        /// <param name="strselectedcategory"></param>
        /// <param name="strselectedtype"></param>
        /// <param name="strTicketNo"></param>
        public Request_TicketsList(string strSearchbox, string strselectedStatus, string strselectedcategory, string strselectedtype, string strTicketNo,string fstrFilterFlag)
        {
            try
            {
                InitializeComponent();
                //To Bind View Model
                BindingContext = new TicketListViewModel(strSearchbox, strselectedStatus, strselectedcategory, strselectedtype, strTicketNo, fstrFilterFlag,this);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }

    }
}

