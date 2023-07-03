using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Models;
using RsgtApp.Helpers;

namespace RsgtApp.ViewModels
{
    public class PageLoginOTPViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
       
        WebApiMethod objWeb = new WebApiMethod();
        //gotoDashBoard Button
        public Command gotoDashBoard { get; set; }
        //gotoOPTResend Button
        public Command gotoOPTResend { get; set; }
        //To create Collection Object used ObservableCollection
        public ObservableCollection<clsREGISTEREDUSERS> lstreguser { get; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on Propertychange Event
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        protected bool SetProperty<T>(ref T backfield, T value,
           [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //Indicator Color
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGColor");
            }
        }
        //Indicator Opacity
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGOpacity");
            }
        }
        private bool stackLoginOtp = true;
        public bool StackLoginOtp
        {
            get { return stackLoginOtp; }
            set
            {
                stackLoginOtp = value;
                OnPropertyChanged();
                RaisePropertyChange("StackLoginOtp");
            }
        }
        //lbllogInAccount purpose of using label variable
        private string lbllogInAccount = "";
        public string lblLogInAccount
        {
            get { return lbllogInAccount; }
            set
            {
                lbllogInAccount = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLogInAccount");
            }
        }
        //lblhi purpose of using label variable
        private string lblhi = "";
        public string lblHi
        {
            get { return lblhi; }
            set
            {
                lblhi = value;
                OnPropertyChanged();
                RaisePropertyChange("lblHi");
            }
        }
        //lblotpNumber purpose of using label variable
        private string lblotpNumber = "";
        public string lblOtpNumber
        {
            get { return lblotpNumber; }
            set
            {
                lblotpNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOtpNumber");
            }
        }
        //txtOtp purpose of using entiry variable
        private string txtOtp = "";
        public string TxtOtp
        {
            get { return txtOtp; }
            set
            {
                txtOtp = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtOtp");
            }
        }
        //btnconfirm purpose of using button variable
        private string btnconfirm = "";
        public string btnConfirm
        {
            get { return btnconfirm; }
            set
            {
                btnconfirm = value;
                OnPropertyChanged();
                RaisePropertyChange("btnConfirm");
            }
        }
        //btnresendOtp purpose of using button variable
        private string btnresendOtp = "";
        public string btnResendOtp
        {
            get { return btnresendOtp; }
            set
            {
                btnresendOtp = value;
                OnPropertyChanged();
                RaisePropertyChange("btnResendOtp");
            }
        }
        private string strServerSlowMsg = "";
        //placeOtp purpose of using placeholder variable
        private string placeOtp = "";
        public string PlaceOtp
        {
            get { return placeOtp; }
            set
            {
                placeOtp = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceOtp");
            }
        }
        //To Handel Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoDashBoard.ChangeCanExecute();
                gotoOPTResend.ChangeCanExecute();
            }
        }
        //Begin-ViewModel Constructor
        /// <summary>
        /// ViewModel Constructor 
        /// </summary
        public PageLoginOTPViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("PageLoginOTPViewModel");
            Task.Run(() => assignCms()).Wait();
            lstreguser = new ObservableCollection<clsREGISTEREDUSERS>();
            gotoDashBoard = new Command(async () => await gotodashBoard(), () => !IsBusy);
            gotoOPTResend = new Command(async () => await gotooPTResend(), () => !IsBusy);
        }
        //To bind CMS captions
        /// <summary>
		/// To bind CMS captions
		/// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");

                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //To assign CMS Content respect Captions
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
		/// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            lblLogInAccount = dbLayer.getCaption("strLoginAccount", objCMS);
            lblHi = dbLayer.getCaption("strHi", objCMS) + " " + gblRegisteration.strLoginFirstName + " (" + gblRegisteration.strLoginUser + ")";
            lblOtpNumber = dbLayer.getCaption("strEnterOTP", objCMS);
            PlaceOtp = dbLayer.getCaption("strOTP", objCMS);
            btnResendOtp = dbLayer.getCaption("strOtpNotReceivedA", objCMS);
            btnConfirm = dbLayer.getCaption("strconfirmA", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);

            await Task.Delay(1000);
            await OTP();
        }

        /// <summary>
        /// To Navigate OTP Page
        /// </summary>
        private async Task OTP()
        {

            string strPrecom = gblRegisteration.strPreCommun;
            if (strPrecom == "") strPrecom = "EMAIL";
            strPrecom = strPrecom.ToUpper().Trim();

            gblRegisteration.strEmailAddress = gblRegisteration.strLoginUser.ToString();
            gblRegisteration.strMobileNO = gblRegisteration.strLoginMobileNO.ToString();
            if (strPrecom == "") strPrecom = "MOBILE";

            if (strPrecom == "EMAIL")
            {
                objWeb.postWebApi("PostSendEmail", gblRegisteration.LoginMailotp());
            }
            if (strPrecom == "MOBILE")
            {
                objWeb.postWebApi("PostSentSMS", gblRegisteration.SMSOTP());
            }
            await Task.Delay(1000);
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }

        }

        /// <summary>
        ///  To Navigate gotodashBoard Page
        /// </summary>
        private async Task gotodashBoard()
        {
            try
            {
                IsBusy = true;
                StackLoginOtp = false;
                await Task.Delay(1000);
                if (gblRegisteration.OTP == TxtOtp)
                {
                    await Task.Delay(1000);
                    Application.Current.MainPage?.Navigation.PopAsync();
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    string lstrMsg = dbLayer.getCaption("strPleaseEnterValidOTP", objCMSMSG);
                    string lstrCancel = dbLayer.getCaption("strcancel", objCMSMSG);
                    string lstrMsgHeader = dbLayer.getCaption("strOTPVerifiction", objCMSMSG);
                    await App.Current.MainPage?.DisplayAlert(lstrMsgHeader, lstrMsg, lstrCancel);
                }
                StackLoginOtp = true;
                IsBusy = false;

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To Navigate gotooPTResend Page
        /// </summary>
        private async Task gotooPTResend()
        {
            try
            {
                IsBusy = true;
                StackLoginOtp = false;
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new ResendOTP_message());
                StackLoginOtp = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
    }
}