using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using RsgtApp.Models;

namespace RsgtApp.ViewModels
{
    public class BiometricregisterViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
       
        BLConnect objBl = new BLConnect();

        public Command BioMetric_Clicked { get; set; }

        //To create Collection Object used ObservableCollection
        public ObservableCollection<clsREGISTEREDUSERS> lstreguser { get; }
        string strServerSlowMsg = "";
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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

        //Twoway Binding Property
        private bool stackBioMetric = true;
        public bool StackBioMetric
        {
            get { return stackBioMetric; }
            set
            {
                stackBioMetric = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBioMetric");
            }
        }
        //msgInvalidUserName purpose of using Manditory varaiable
        private bool msgInvalidUserName = false;
        public bool MsgInvalidUserName
        {
            get { return msgInvalidUserName; }
            set
            {
                msgInvalidUserName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgInvalidUserName");
            }
        }
        //msgInvalidPassword purpose of using Manditory varaiable
        private bool msgInvalidPassword = false;
        public bool MsgInvalidPassword
        {
            get { return msgInvalidPassword; }
            set
            {
                msgInvalidPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgInvalidPassword");
            }
        }
        //msgYourAccountInactive purpose of using Manditory varaiable
        private bool msgYourAccountInactive = false;
        public bool MsgYourAccountInactive
        {
            get { return msgYourAccountInactive; }
            set
            {
                msgYourAccountInactive = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgYourAccountInactive");
            }
        }
        //txtBioPassword purpose of using Password varaiable
        private string txtBioPassword = "";
        public string TxtBioPassword
        {
            get { return txtBioPassword; }
            set
            {
                txtBioPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBioPassword");
            }
        }
        //txtBioUserName purpose of using username varaiable
        private string txtBioUserName = "";
        public string TxtBioUserName
        {
            get { return txtBioUserName; }
            set
            {
                txtBioUserName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBioUserName");
            }
        }
        //isBusy purpose of using indicator varaiable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                BioMetric_Clicked.ChangeCanExecute();
            }
        }

        /// <summary>
        /// ViewModel Constructor
        /// </summary>
        public BiometricregisterViewModel()
        {
            lstreguser = new ObservableCollection<clsREGISTEREDUSERS>();
            BioMetric_Clicked = new Command(async () => await bioMetric_Clicked(), () => !IsBusy);
        }

        /// <summary>
        /// To Verify BioMetric User
        /// </summary>
        /// <returns></returns>
        private async Task bioMetric_Clicked()
        {
            IsBusy = true;
            StackBioMetric = false;
            await Task.Delay(1000);
            MsgInvalidPassword = false;
            MsgInvalidUserName = false;
            try
            {

                var objRawData = new List<clsREGISTEREDUSERS>();
                objRawData = objBl.getRegisterUserDetails(TxtBioUserName);

                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);

                }

                if (lstreguser.Count > 0)
                {
                    string strReguserId = objRawData.ToArray()[0].ru_emailid.ToString();
                    //string strRegPassword = lstreguser.ToArray()[0].ru_password.ToString();
                    string strRegFlag = objRawData.ToArray()[0].ru_activestatus.ToUpper().ToString();
                    //string strDecryRegPassword = DecryptString(strRegPassword, AppSettings.getEncrptyKey);
                    gblRegisteration.strLoginUser = objRawData.ToArray()[0].ru_emailid.ToString();
                    gblRegisteration.strLoginFirstName = objRawData.ToArray()[0].ru_firstname1.ToString();
                    gblRegisteration.strLoginMobileNO = objRawData.ToArray()[0].ru_mobileno.ToString();
                    gblRegisteration.strIdNo = objRawData.ToArray()[0].ru_idno.ToString();
                    gblRegisteration.strImpExpLisNo = objRawData.ToArray()[0].ru_licenseno.ToString();
                    if (strRegFlag == "A") // A - Activated
                    {
                        if (strReguserId == TxtBioUserName)
                        {
                            //Navigation.PushAsync(new PageLoginOTP());
                            if (!string.IsNullOrEmpty(TxtBioUserName) && !string.IsNullOrEmpty(TxtBioPassword))
                            {
                                await SecureStorage.SetAsync("us", TxtBioUserName);
                                //await SecureStorage.SetAsync("P", "39qW!@$9oe*s");
                                await App.Current.MainPage?.DisplayAlert("Success", "UserName saved", "OK");
                                // await Navigation.PushModalAsync(new PageLogin());
                            }
                        }
                        else
                        {
                            //activityIndicator.IsVisible = false;
                            MsgInvalidPassword = true;
                            MsgInvalidUserName = true;
                        }
                    }
                    else
                    {
                        MsgYourAccountInactive = true;
                    }
                }
                else
                {
                    // activityIndicator.IsVisible = false;
                    MsgInvalidPassword = true;
                    MsgInvalidUserName = true;
                    MsgInvalidUserName = true;
                }

                StackBioMetric = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {

                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                   App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}