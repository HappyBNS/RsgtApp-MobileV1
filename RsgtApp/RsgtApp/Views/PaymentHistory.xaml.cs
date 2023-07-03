using RsgtApp.BusinessLayer;
using RsgtApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentHistory : ContentPage
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
                // To check Internet connectivity
                if (current == NetworkAccess.Internet)
                {
                    if (App.isinternetSlowEnablement == true)//20220912 BABU
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

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// the  payment consector function
        /// </summary>
        /// <param name="strSearchbox"></param>
        /// <param name="strInvoiceNo"></param>
        /// <param name="strdBOLNo"></param>
        /// <param name="strCutomer"></param>
        /// <param name="strPaymentRef"></param>
        /// <param name="strSelectedStatus"></param>
        /// <param name="strSelectedMop"></param>
        /// <param name="strSelectedType"></param>
        /// <param name="lstrfromDate"></param>
        /// <param name="lstrToDate"></param>
        /// <param name="strFromAmount"></param>
        /// <param name="strToAmount"></param>
        public PaymentHistory(string strSearchbox, string strInvoiceNo, string strdBOLNo, string strCutomer, string strPaymentRef, string strSelectedStatus, string strSelectedMop, string strSelectedType, string lstrfromDate, string lstrToDate, string strFromAmount, string strToAmount)
        {
            InitializeComponent();
            // To bind ViewModel 
            BindingContext = new PaymentHistroyViewModel(strSearchbox, strInvoiceNo, strdBOLNo, strCutomer, strPaymentRef, strSelectedStatus, strSelectedMop, strSelectedType, lstrfromDate, lstrToDate, strFromAmount, strToAmount,this);
        }

        private void btnclear(object sender, EventArgs e)
        {
            dtDateToDate.CleanDate();
            dtDateFromdate.CleanDate();
        }

        private void btnClose(object sender, EventArgs e)
        {
            dtDateToDate.CleanDate();
            dtDateFromdate.CleanDate();
        }
    }
}