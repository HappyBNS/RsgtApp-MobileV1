using Microsoft.AppCenter.Analytics;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class PageLoginViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //btnForgotUsername Button
        private string strServerSlowMsg = "";
        public Command gotoForgotUsername { get; set; }
        //btnForgetpassword Button
        public Command gotoForgetpassword { get; set; }
        //btnLoginOTP Button
        public Command gotoLoginOTP { get; set; }
        //btnPageRegistration1 Button
        public Command gotoPageRegistration1 { get; set; }
        //btnBioMetric Button
        public Command BioMetric { get; set; }
        //To create Collection Object used ObservableCollection
        public List<clsREGISTEREDUSERS> lstreguser { get; set; }
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
        //SetProperty Event
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
        //Twoway Binding Property
        private bool stackLogin = true;
        public bool StackLogin
        {
            get { return stackLogin; }
            set
            {
                stackLogin = value;
                OnPropertyChanged();
                RaisePropertyChange("StackLogin");
            }
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
        //btnforgotUsername purpose of using button variable
        private string btnforgotUsername = "";
        public string btnForgotUsername
        {
            get { return btnforgotUsername; }
            set
            {
                btnforgotUsername = value;
                OnPropertyChanged();
                RaisePropertyChange("btnForgotUsername");
            }
        }
        //txtUserName purpose of using button variable
        private string txtUserName = "";
        public string TxtUserName
        {
            get { return txtUserName; }
            set
            {
                txtUserName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtUserName");
            }
        }
        //placeUserName purpose of using placeholder variable
        private string placeUserName = "";
        public string PlaceUserName
        {
            get { return placeUserName; }
            set
            {
                placeUserName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceUserName");
            }
        }
        //msgUserName purpose of using Mandatory variable
        private string msgUserName = "";
        public string MsgUserName
        {
            get { return msgUserName; }
            set
            {
                msgUserName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgUserName");
            }
        }
        //msgUserNameNotExist purpose of using Mandatory variable
        private string msgUserNameNotExist = "";
        public string MsgUserNameNotExist
        {
            get { return msgUserNameNotExist; }
            set
            {
                msgUserNameNotExist = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgUserNameNotExist");
            }
        }
        //txtPassword purpose of using value variable
        private string txtPassword = "";
        public string TxtPassword
        {
            get { return txtPassword; }
            set
            {
                txtPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtPassword");
            }
        }
        //placePassword purpose of using placeholder variable
        private string placePassword = "";
        public string PlacePassword
        {
            get { return placePassword; }
            set
            {
                placePassword = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacePassword");
            }
        }
        //msgPassword purpose of using Mandatory variable
        private string msgPassword = "";
        public string MsgPassword
        {
            get { return msgPassword; }
            set
            {
                msgPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPassword");
            }
        }
        //btnforgotPassword purpose of using button variable
        private string btnforgotPassword = "";
        public string btnForgotPassword
        {
            get { return btnforgotPassword; }
            set
            {
                btnforgotPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("btnForgotPassword");
            }
        }
        //msgInActive purpose of using Mandatory variable
        private string msgInActive = "";
        public string MsgInActive
        {
            get { return msgInActive; }
            set
            {
                msgInActive = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgInActive");
            }
        }

        //MsgCRMNotLinked
        private string msgCRMNotLinked = "";
        public string MsgCRMNotLinked
        {
            get { return msgCRMNotLinked; }
            set
            {
                msgCRMNotLinked = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCRMNotLinked");
            }
        }

        //btnlogIn purpose of using button variable
        private string btnlogIn = "";
        public string btnLogIn
        {
            get { return btnlogIn; }
            set
            {
                btnlogIn = value;
                OnPropertyChanged();
                RaisePropertyChange("btnLogIn");
            }
        }
        //btnregister purpose of using button variable
        private string btnregister = "";
        public string btnRegister
        {
            get { return btnregister; }
            set
            {
                btnregister = value;
                OnPropertyChanged();
                RaisePropertyChange("btnRegister");
            }
        }
        //imgbiometric purpose of using image variable
        private string imgbiometric = "";
        public string imgBiometric
        {
            get { return imgbiometric; }
            set
            {
                imgbiometric = value;
                OnPropertyChanged();
                RaisePropertyChange("imgBiometric");
            }
        }
        //isclickBiometric Handel Boolen Value
        private bool isclickBiometric = true;
        public bool isClickBiometric
        {
            get { return isclickBiometric; }
            set
            {
                isclickBiometric = value;
                OnPropertyChanged();
                RaisePropertyChange("isClickBiometric");
            }
        }
        //isimgBiometric Handel Boolen Value
        private bool isimgBiometric = false;
        public bool IsImgBiometric
        {
            get { return isimgBiometric; }
            set
            {
                isimgBiometric = value;
                OnPropertyChanged();
                RaisePropertyChange("IsImgBiometric");
            }
        }
        //lblclickBiometric purpose of using label variable
        private string lblclickBiometric = "";
        public string lblClickBiometric
        {
            get { return lblclickBiometric; }
            set
            {
                lblclickBiometric = value;
                OnPropertyChanged();
                RaisePropertyChange("lblClickBiometric");
            }
        }
        //isuserName Handel Boolen Value
        private bool isuserName = false;
        public bool isUserName
        {
            get { return isuserName; }
            set
            {
                isuserName = value;
                OnPropertyChanged();
                RaisePropertyChange("isUserName");
            }
        }
        //isuserNameNotExist Handel Boolen Value
        private bool isuserNameNotExist = false;
        public bool isUserNameNotExist
        {
            get { return isuserNameNotExist; }
            set
            {
                isuserNameNotExist = value;
                OnPropertyChanged();
                RaisePropertyChange("isUserNameNotExist");
            }
        }
        //ispassword Handel Boolen Value
        private bool ispassword = false;
        public bool isPassword
        {
            get { return ispassword; }
            set
            {
                ispassword = value;
                OnPropertyChanged();
                RaisePropertyChange("isPassword");
            }
        }
        //isinActive Handel Boolen Value
        private bool isinActive = false;
        public bool isInActive
        {
            get { return isinActive; }
            set
            {
                isinActive = value;
                OnPropertyChanged();
                RaisePropertyChange("isInActive");
            }
        }

        //isCRMNotLinked Handel Boolen Value
        private bool _isCRMNotLinked = false;
        public bool isCRMNotLinked
        {
            get { return _isCRMNotLinked; }
            set
            {
                _isCRMNotLinked = value;
                OnPropertyChanged();
                RaisePropertyChange("isCRMNotLinked");
            }
        }
        //isforgotUsername Handel Boolen Value
        private bool isforgotUsername = false;
        public bool isForgotUsername
        {
            get { return isforgotUsername; }
            set
            {
                isforgotUsername = value;
                OnPropertyChanged();
                RaisePropertyChange("isForgotUsername");
            }
        }
        //isregister Handel Boolen Value
        private bool isregister = true;
        public bool isRegister
        {
            get { return isregister; }
            set
            {
                isregister = value;
                OnPropertyChanged();
                RaisePropertyChange("isRegister");
            }
        }
        //islogIn Handel Boolen Value
        private bool islogIn = true;
        public bool isLogIn
        {
            get { return islogIn; }
            set
            {
                islogIn = value;
                OnPropertyChanged();
                RaisePropertyChange("isLogIn");
            }
        }
        //isforgotPassword Handel Boolen Value
        private bool isforgotPassword = true;
        public bool isForgotPassword
        {
            get { return isforgotPassword; }
            set
            {
                isforgotPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("isForgotPassword");
            }
        }
        //To Handel  Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoForgotUsername.ChangeCanExecute();
                gotoForgetpassword.ChangeCanExecute();
                gotoLoginOTP.ChangeCanExecute();
                gotoPageRegistration1.ChangeCanExecute();
                BioMetric.ChangeCanExecute();
            }
        }
        //Begin-ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public PageLoginViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("PageLoginViewModel");
            Task.Run(() => assignCms()).Wait();
            Task.Run(() => assignCmsMsg()).Wait();
            lstreguser = new List<clsREGISTEREDUSERS>();
            gotoForgotUsername = new Command(async () => await gotoforgotUsername(), () => !IsBusy);
            gotoForgetpassword = new Command(async () => await gotoforgetpassword(), () => !IsBusy);
            gotoLoginOTP = new Command(async () => await gotologinOTP(), () => !IsBusy);
            gotoPageRegistration1 = new Command(async () => await gotopageRegistration1(), () => !IsBusy);
            BioMetric = new Command(async () => await bioMetric(), () => !IsBusy);
       
            
        }
        //To bind CMS captions
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                await Task.Delay(1000);
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");
                }
                assignContent();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //To bind CMS captions
        /// <summary>
        /// To bind CMSMsg captions
        /// </summary>
        public async void assignCmsMsg()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                MsgUserName = dbLayer.getCaption("strInvaliduser", objCMSMSG);
                MsgPassword = dbLayer.getCaption("strPasswordnotfound", objCMSMSG);
                MsgUserNameNotExist = dbLayer.getCaption("strUsernamenotfound", objCMSMSG);
                MsgInActive = dbLayer.getCaption("strAccessdenied", objCMSMSG);
                MsgCRMNotLinked = dbLayer.getCaption("strRegistrationCRMKeyNotLinkedmessage", objCMSMSG);
                string result = await SecureStorage.GetAsync("B");
               // App.Current.MainPage?.DisplayToastAsync("Login_Page", 3000);
                if (result == "rsgt_touchenablement_Yes")
                {
                    //Biometric not available in device
                    bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
                    if (!isFingerprintAvailable)
                    {
                        //Change 20220617 - To Hide Biometric image, when "Biometric not available in your Device"
                        IsImgBiometric = false;
                        //Change 20220617 - To Hide Label ClickBioMetric, when "Biometric not available in your Device"
                        isClickBiometric = false;
                        string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                        string lstrMsgHeader = dbLayer.getCaption("strBiometricNotAvailable", objCMSMSG);
                        string lstrCancel = dbLayer.getCaption("strcancel", objCMSMSG);
                        return;
                    }
                    else
                    {
                        IsImgBiometric = true;
                        isClickBiometric = true;
                    }
                }
                else
                {
                    IsImgBiometric = false;
                    isClickBiometric = false;
                }
            }
            catch (Exception ex)
            {
                string fstrCondition = "fstrCode=" + "PageLogin_AssignCMS" + "&fstrCustomMsg=" + "" + "&fstrSystemMsg=" + ex.Message + "&fstrSuggestion=" + "Exception" + "&fstrsource=" + "MobileApp" + "";
                string lstrResult = objWebApi.getstringPostWebApi("procWriteApiTraceLog", "", fstrCondition);
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Method is for Assign Content
        /// </summary>
        //To assign CMS Content respect Captions
        public async void assignContent()
        {
            try
            {

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}
                lblLogInAccount = dbLayer.getCaption("strLoginAccount", objCMS);
                btnForgotUsername = dbLayer.getCaption("strForgotUsername", objCMS);
                btnForgotPassword = dbLayer.getCaption("strForgetPassword", objCMS);
                PlacePassword = dbLayer.getCaption("strPassword", objCMS);
                btnLogIn = dbLayer.getCaption("strLoginA", objCMS);
                btnRegister = dbLayer.getCaption("strNewUserRegister", objCMS);
                PlaceUserName = dbLayer.getCaption("strUIDPH", objCMS);
                imgBiometric = dbLayer.getCaption("imgBiometric", objCMS);
                lblClickBiometric = dbLayer.getCaption("strClickBiometricLogin", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To Navigate Forgetusernammessage Page
        /// </summary>
        private async Task gotoforgotUsername()
        {
            try
            {
                await Task.Delay(1000);
                // App.Current.MainPage?.Navigation.PushAsync(new Forgetusernammessage());               
            }
            catch (Exception ex)
            {

                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To Navigate Forgetpassword Page
        /// </summary>
        private async Task gotoforgetpassword()
        {
            try
            {
                IsBusy = true;
                StackLogin = false;
                await Task.Delay(1000);
                await App.Current.MainPage?.Navigation.PushAsync(new Forgetpassword());
                IsBusy = false;
                StackLogin = true;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To Navigate PageLoginOTP Page
        /// </summary>
        private async Task gotologinOTP()
        {
            try
            {
                string strUserName = TxtUserName;
                await checkLoginExist(strUserName, "N");
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To checkLoginExist User
        /// </summary>
        private async Task checkLoginExist(string strUserName, string strAuthenticate)
        {
            try
            {
                IsBusy = true;
                StackLogin = false;
                isPassword = false;
                isUserName = false;
                isInActive = false;
                isUserNameNotExist = false;
                bool blResult = false;
                var objRawData = new List<clsREGISTEREDUSERS>();
                objRawData = objBl.getRegisterUserDetails(strUserName);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (objRawData.Count > 0)
                {
                    string strReguserId = objRawData.ToArray()[0].ru_emailid.ToString();
                    string strRegPassword = objRawData.ToArray()[0].ru_password.ToString();
                    string strRegFlag = objRawData.ToArray()[0].ru_activestatus.ToUpper().ToString();
                    string strDecryRegPassword = gblRegisteration.DecryptString(strRegPassword, AppSettings.getEncrptyKey);
                    gblRegisteration.strCurrentUserLang = objRawData.ToArray()[0].ru_languagevalue.ToString();
                    gblRegisteration.strLoginUser = objRawData.ToArray()[0].ru_emailid.ToString();
                    gblRegisteration.strLoginFirstName = objRawData.ToArray()[0].ru_firstname1.ToString();
                    gblRegisteration.strLoginFirstName1 = objRawData.ToArray()[0].ru_firstname2.ToString();
                    gblRegisteration.strLoginMobileNO = objRawData.ToArray()[0].ru_mobileno.ToString();
                    gblRegisteration.strIdNo = objRawData.ToArray()[0].ru_idno.ToString();
                    gblRegisteration.strImpExpLisNo = objRawData.ToArray()[0].ru_licenseno.ToString();
                    gblRegisteration.strLoginUserLinkcode = objRawData.ToArray()[0].ru_linkcode.ToString();
                    gblRegisteration.strLoginCustomerType = objRawData.ToArray()[0].ru_customertypevalue.ToString();
                    gblRegisteration.strContactGkeyCRM = objRawData.ToArray()[0].ru_crmcontactgkey.ToString();
                    gblRegisteration.strru_brokerflag = objRawData.ToArray()[0].ru_brokerflag.ToString();
                    gblRegisteration.strru_clearingagentflag = objRawData.ToArray()[0].ru_clearingagentflag.ToString();
                    gblRegisteration.strPreCommun = objRawData.ToArray()[0].ru_preferredcommvalue.ToString();


                    gblRegisteration.strCurrency = objRawData.ToArray()[0].ru_currencyvalue;

                    gblRegisteration.strCurrentUserLang =            objRawData.ToArray()[0].ru_languagevalue;

                    gblRegisteration.strTemperature = objRawData.ToArray()[0].ru_temperaturevalue;

                    gblRegisteration.strWeight = objRawData.ToArray()[0].ru_weightvalue;

                    gblRegisteration.strDefaultLanding = objRawData.ToArray()[0].ru_defaultlandingpage;

                    await Task.Delay(1000);
                    if (strRegFlag == "A")
                    {
                        //Bio-Metric handled on 20230424
                        if (strAuthenticate != "Y")
                        {
                            if ((strDecryRegPassword == TxtPassword))
                            {
                                //20230128--->Anand
                                Dictionary<string, string> lobjInParams = new Dictionary<string, string>();
                                lobjInParams.Add("fstrMailID", gblRegisteration.strLoginUser);

                                string lstrResult = objWebApi.getWebstringApiData("updateRegistereduserExtn", lobjInParams);
                                //Web Api Timeout
                                if (AppSettings.ErrorExceptionWebApi != "")
                                {
                                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                                }


                            }
                            else
                            {
                                isPassword = true;
                                blResult = true;
                            }
                        }
                    }
                    else
                    {
                        isInActive = true;
                        blResult = true;
                    }
                    if ((gblRegisteration.strContactGkeyCRM == null) || (gblRegisteration.strContactGkeyCRM == ""))
                    {
                        isCRMNotLinked = true;
                        blResult = true;
                    }

                }
                else
                {
                    isUserNameNotExist = true;
                    blResult = true;
                }

                //20230424 After Enable Bio metric Option , We have tried to login using finger print it is login sucessfully but showing
                //"Password not found or matched" 

                if ((blResult == false) && (strAuthenticate != "Y"))
                {
                    App.Current.MainPage?.Navigation.PushAsync(new PageLoginOTP());
                }
                await Task.Delay(1000);
                StackLogin = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To Navigate Registration
        /// </summary
        private async Task gotopageRegistration1()
        {
            try
            {
                IsBusy = true;
                stackLogin = false;
                await Task.Delay(1000);
                //Change 20220617
                await App.Current.MainPage?.Navigation.PushAsync(new PageRegistration());
                StackLogin = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// To Check BioMetric
        /// </summary
        private async Task bioMetric()
        {
            IsBusy = true;
            stackLogin = false;
            string lstrsecureUserData = await SecureStorage.GetAsync("UID");
          //  App.Current.MainPage?.DisplayToastAsync("Login_Biometric_Page", 3000);
            if ((lstrsecureUserData == null) && (lstrsecureUserData == ""))
            {
                await App.Current.MainPage?.DisplayAlert("Kindly ensure Biometric Enabled in accountsetting", "", "Cancel");
                return;
            }


            if (Device.RuntimePlatform == Device.iOS)
            {
                try
                {
                    //bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
                    //if (!isFingerprintAvailable)
                    //{
                    //    string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                    //    string lstrMsgHeader = dbLayer.getCaption("strBiometricNotAvailable", objCMSMSG);
                    //    string lstrCancel = dbLayer.getCaption("strcancel", objCMSMSG);
                    //    await App.Current.MainPage?.DisplayAlert(lstrError, lstrMsgHeader, lstrCancel);
                    //    return;
                    //}

                    string lstrTitle = dbLayer.getCaption("strAuthentication", objCMSMSG);
                    string lstrMsg = dbLayer.getCaption("strAuthenticateAccess", objCMSMSG);
                    AuthenticationRequestConfiguration conf = new AuthenticationRequestConfiguration(lstrTitle, lstrMsg);
                    var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
                    if (authResult.Authenticated)
                    {
                         lstrsecureUserData = await SecureStorage.GetAsync("UID");
                        if ((lstrsecureUserData != null) && (lstrsecureUserData != ""))
                        {
                            if (lstrsecureUserData.Length > 0)
                            {
                                gblRegisteration.strLoginUser = lstrsecureUserData;
                                string strUserName = lstrsecureUserData;
                                string strAuthenticate = "Y";//20230424
                                await checkLoginExist(strUserName, strAuthenticate);
                            }
                        }
                        Application.Current.MainPage?.Navigation.PopAsync();
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                        string lstrOk = dbLayer.getCaption("strOk", objCMSMSG);
                        await App.Current.MainPage?.DisplayAlert(lstrError, "Authentication failed", lstrOk);
                    }
                }
                catch (Exception ex)
                {
                    string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                    Console.WriteLine(lstrError, ex.Message);
                }
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                try
                {
                    bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
                    if (!isFingerprintAvailable)
                    {
                        string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                        string lstrMsgHeader = dbLayer.getCaption("strBiometricNotAvailable", objCMSMSG);
                        string lstrCancel = dbLayer.getCaption("strcancel", objCMSMSG);
                        await App.Current.MainPage?.DisplayAlert(lstrError, lstrMsgHeader, lstrCancel);
                        return;
                    }
                    string lstrTitle = dbLayer.getCaption("strAuthentication", objCMSMSG);
                    string lstrMsg = dbLayer.getCaption("strAuthenticateAccess", objCMSMSG);
                    AuthenticationRequestConfiguration conf = new AuthenticationRequestConfiguration(lstrTitle, lstrMsg);
                    var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
                    if (authResult.Authenticated)
                    {
                        //Success  
                        // As per Mr.Raju comments 20220506
                        // App.Current.MainPage?.DisplayAlert("Success", "Authentication succeeded", "OK");
                         lstrsecureUserData = await SecureStorage.GetAsync("UID");

                        if ((lstrsecureUserData != null) && (lstrsecureUserData != ""))
                        {
                            if (lstrsecureUserData.Length > 0)
                            {
                                gblRegisteration.strLoginUser = lstrsecureUserData;

                                string strUserName = lstrsecureUserData;
                                string strAuthenticate = "Y";//20230424
                                await checkLoginExist(strUserName, strAuthenticate);
                            }
                        }
                        Application.Current.MainPage?.Navigation.PopAsync();
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                        string lstrOk = dbLayer.getCaption("strOk", objCMSMSG);
                        string lstrAuthentication = dbLayer.getCaption("strAuthenticateFailed", objCMSMSG);
                        await App.Current.MainPage?.DisplayAlert(lstrError, lstrAuthentication, lstrOk);
                    }
                    await Task.Delay(1000);
                    StackLogin = true;
                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    string lstrError = dbLayer.getCaption("strError", objCMSMSG);
                    Console.WriteLine(lstrError, ex.Message);
                }
            }
        }
    }
}
