using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ticket_Detail : ContentPage
    {

        /// <summary>
        /// Begin OnAppearing function
        /// </summary>
        protected async override void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                var profiles = Connectivity.ConnectionProfiles;
                if (current == NetworkAccess.Internet)
                {
                    //To check internet flow
                    if (App.isinternetSlowEnablement == true)
                    {
                        bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                        if (isConnectionFast)
                        { }
                        else
                            await this.DisplayToastAsync("Network Connection is slow", 3000); // DependencyService.Get<IToast>().ShowToast("Network Connection is slow");
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
        ///  Begin Ticket_Detail constructor
        /// </summary>
        /// <param name="fstrCasegkey"></param>
        /// <param name="fstrCasetype"></param>
        /// <param name="fstrStatus"></param>
        /// <param name="fstrCreatedon"></param>
        /// <param name="fstrCompletedOn"></param>
        /// <param name="fstrTicketno"></param>
        public Ticket_Detail(string fstrCasegkey, string fstrCasetype, string fstrStatus, string fstrCreatedon, string fstrCompletedOn, string fstrTicketno)
        {
            try
            {
                InitializeComponent();
                //To Bind ViewModel
                BindingContext = new TicketDetailsViewModel(fstrCasegkey, fstrCasetype, fstrStatus, fstrCreatedon, fstrCompletedOn, fstrTicketno);
            }
            catch (Exception ex)
            {
                 App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
       
    }
}