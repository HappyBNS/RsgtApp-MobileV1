using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;
using System.Security.Cryptography;
using Xamarin.CommunityToolkit.Extensions;
using System.Runtime.CompilerServices;
using RsgtApp.Views;
using RsgtApp.Models;
using RsgtApp.Helpers;

namespace RsgtApp.ViewModels
{
    public class ForgetpasswordViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWeb = new WebApiMethod();
        //gotopasswordmessage Button
        public Command gotopasswordmessage { get; set; }
        //gotoLogin Button
        public Command gotoLogin { get; set; }
        private string strServerSlowMsg = "";
        //To create Collection Object used ObservableCollection
        public List<clsREGISTEREDUSERS> lstreguser { get; }
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
        // Twowaybinding process on Propertychange Event
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
        //To handle Activity Indicator
        private bool stackForgetPassword = true;
        public bool StackForgetPassword
        {
            get { return stackForgetPassword; }
            set
            {
                stackForgetPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("StackForgetPassword");
            }
        }
        //lblpasswordAssistance purpose of using label variable
        private string lblpasswordAssistance = "";
        public string lblPasswordAssistance
        {
            get { return lblpasswordAssistance; }
            set
            {
                lblpasswordAssistance = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPasswordAssistance");
            }
        }
        //lblcontent purpose of using label variable
        private string lblcontent = "";
        public string lblContent
        {
            get { return lblcontent; }
            set
            {
                lblcontent = value;
                OnPropertyChanged();
                RaisePropertyChange("lblContent");
            }
        }
        //placeMobileNumber purpose of using placeholder variable
        private string placeMobileNumber = "";
        public string PlaceMobileNumber
        {
            get { return placeMobileNumber; }
            set
            {
                placeMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceMobileNumber");
            }
        }
        //msgMobileNo purpose of using Mandatory variable
        private string msgMobileNo = "";
        public string MsgMobileNo
        {
            get { return msgMobileNo; }
            set
            {
                msgMobileNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileNo");
            }
        }
        //txtEmailAddress purpose of using entiry variable
        private string txtEmailAddress = "";
        public string TxtEmailAddress
        {
            get { return txtEmailAddress; }
            set
            {
                txtEmailAddress = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtEmailAddress");
            }
        }
        //placeEmailAddress purpose of using placeholder variable
        private string placeEmailAddress = "";
        public string PlaceEmailAddress
        {
            get { return placeEmailAddress; }
            set
            {
                placeEmailAddress = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceEmailAddress");
            }
        }
        //msgEmail purpose of using Mandatory variable
        private string msgEmail = "";
        public string MsgEmail
        {
            get { return msgEmail; }
            set
            {
                msgEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmail");
            }
        }
        //btnrecoverPassword purpose of using button variable
        private string btnrecoverPassword = "";
        public string btnRecoverPassword
        {
            get { return btnrecoverPassword; }
            set
            {
                btnrecoverPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("btnRecoverPassword");
            }
        }
        //txtMobileNumber purpose of using entiry variable
        private string txtMobileNumber = "";
        public string TxtMobileNumber
        {
            get { return txtMobileNumber; }
            set
            {
                txtMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtMobileNumber");
            }
        }
        //btnrememberPassword purpose of using button variable
        private string btnrememberPassword = "";
        public string btnRememberPassword
        {
            get { return btnrememberPassword; }
            set
            {
                btnrememberPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("btnRememberPassword");
            }
        }
        //ismobileno purpose of using validation variable
        private bool ismobileno = false;
        public bool isMobileNo
        {
            get { return ismobileno; }
            set
            {
                ismobileno = value;
                OnPropertyChanged();
                RaisePropertyChange("isMobileNo");
            }
        }
        //isemail purpose of using validation variable
        private bool isemail = false;
        public bool isEmail
        {
            get { return isemail; }
            set
            {
                isemail = value;
                OnPropertyChanged();
                RaisePropertyChange("isEmail");
            }
        }
        //msgInActive purpose of using Mandatory variable
        private string msgInActive = ""; //20230609
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
        //isinActive Handel Boolen Value
        private bool isinActive = false; //20230609
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
                gotopasswordmessage.ChangeCanExecute();
                gotoLogin.ChangeCanExecute();

            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        public ForgetpasswordViewModel()
        {
            Task.Run(() => assignCms()).Wait();
            lstreguser = new List<clsREGISTEREDUSERS>();
            gotopasswordmessage = new Command(async () => await gotoPasswordmessage(), () => !IsBusy);
            gotoLogin = new Command(async () => await gotologin(), () => !IsBusy);
        }
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
                    objCMSMsg = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM004");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Method is for Assign Content
        /// </summary>
        /// To assign CMS Content respect Captions
        public void assignContent()
        {

            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;

            //}           
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            lblPasswordAssistance = dbLayer.getCaption("strPasswordAssistance", objCMS);
            lblContent = dbLayer.getCaption("strRecoverPasswordMobile", objCMS);
            PlaceMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
            PlaceEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
            btnRecoverPassword = dbLayer.getCaption("strRecoverPassword2", objCMS);
            btnRememberPassword = dbLayer.getCaption("strRememberPassword1", objCMS);
            MsgMobileNo = dbLayer.getCaption("strPleasecheck", objCMSMsg);
            MsgEmail = dbLayer.getCaption("strProvideregisteredEmailID", objCMSMsg);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
            MsgInActive = dbLayer.getCaption("strAccessdenied", objCMSMsg);
        }
        /// <summary>
        /// Navigate Forgetpasswordmessage
        /// </summary>
        /// <returns></returns>
        private async Task gotoPasswordmessage()
        {
            IsBusy = true;
            StackForgetPassword = false;
            await Task.Delay(1000);
            string strEmail = TxtEmailAddress;
            string strMobile = TxtMobileNumber;
            isEmail = false;
            isMobileNo = false;
            try
            {
                var objRawData = new List<clsREGISTEREDUSERS>();
                objRawData = objBl.getForgetPasswordDetails(strEmail, strMobile);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (objRawData.Count > 0)
                {
                    string strRegEmail = objRawData.ToArray()[0].ru_emailid.ToString();
                    gblRegisteration.strIdNo = objRawData.ToArray()[0].ru_idno.ToString();
                    string strPrecom = objRawData.ToArray()[0].ru_preferredcommvalue.ToUpper().ToString().Trim();//20230206
                    gblRegisteration.strFirstName = objRawData.ToArray()[0].ru_firstname1.ToString();
                    string strGenPassword = NewPassword.Generate(6, 1);
                    gblRegisteration.strEmailAddress = strEmail;
                    gblRegisteration.strMobileNO = objRawData.ToArray()[0].ru_mobileno.ToString();
                    gblRegisteration.strNewPasword = strGenPassword;
                    string lstrActiveStatus = objRawData.ToArray()[0].ru_activestatus.ToString().Trim(); //20230609
                    objBl.updatePassword("UpdatePassword", gblRegisteration.UpdateBulidProperty(""), strRegEmail);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    if (lstrActiveStatus == "A")
                    {
                        if (strPrecom == "EMAIL")
                        {
                            objWeb.postWebApi("PostSendEmail", gblRegisteration.ForgetPassword("EMAIL"));//20230206
                            if (AppSettings.ErrorExceptionWebApi != "")
                            {
                                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                            }
                            await App.Current.MainPage?.Navigation.PushAsync(new Forgetpasswordmessage());
                        }
                        if (strPrecom == "MOBILE")
                        {
                            objWeb.postWebApi("PostSentSMS", gblRegisteration.ForgetPassword("MOBILE"));
                            if (AppSettings.ErrorExceptionWebApi != "")
                            {
                                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                            }
                            await App.Current.MainPage?.Navigation.PushAsync(new Forgetpasswordmessage());
                        }
                    }

                    if (lstrActiveStatus == "D")
                    {
                        isInActive = true;
                    }
                }
                else
                {
                    isEmail = true;
                    isMobileNo = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                    //  this.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackForgetPassword = true;
            IsBusy = false;
        }
        /// <summary>
        /// Password Validation
        /// </summary>
        public class NewPassword
        {
            private static readonly char[] Punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();
            public static string Generate(int length, int numberOfNonAlphanumericCharacters)
            {
                if (length < 1 || length > 128)
                {
                    throw new ArgumentException(nameof(length));
                }

                if (numberOfNonAlphanumericCharacters > length || numberOfNonAlphanumericCharacters < 0)
                {
                    throw new ArgumentException(nameof(numberOfNonAlphanumericCharacters));
                }
                using (var rng = RandomNumberGenerator.Create())
                {
                    var byteBuffer = new byte[length];
                    rng.GetBytes(byteBuffer);
                    var count = 0;
                    var characterBuffer = new char[length];
                    for (var iter = 0; iter < length; iter++)
                    {
                        var i = byteBuffer[iter] % 87;

                        if (i < 10)
                        {
                            characterBuffer[iter] = (char)('0' + i);
                        }
                        else if (i < 36)
                        {
                            characterBuffer[iter] = (char)('A' + i - 10);
                        }
                        else if (i < 62)
                        {
                            characterBuffer[iter] = (char)('a' + i - 36);
                        }
                        else
                        {
                            characterBuffer[iter] = Punctuations[i - 62];
                            count++;
                        }
                    }
                    if (count >= numberOfNonAlphanumericCharacters)
                    {
                        return new string(characterBuffer);
                    }
                    int j;
                    var rand = new Random();

                    for (j = 0; j < numberOfNonAlphanumericCharacters - count; j++)
                    {
                        int k;
                        do
                        {
                            k = rand.Next(0, length);
                        }
                        while (!char.IsLetterOrDigit(characterBuffer[k]));

                        characterBuffer[k] = Punctuations[rand.Next(0, Punctuations.Length)];
                    }
                    return new string(characterBuffer);
                }
            }
        }
        /// <summary>
        /// Navigate PageLogin
        /// </summary>
        /// <returns></returns>
        private async Task gotologin()
        {
            IsBusy = true;
            StackForgetPassword = false;
            await Task.Delay(1000);// Change 202206
            await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
            StackForgetPassword = true;
            IsBusy = false;
        }
    }
}