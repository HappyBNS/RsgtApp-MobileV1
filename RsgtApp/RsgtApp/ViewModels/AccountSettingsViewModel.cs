using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Services;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static RsgtApp.BusinessLayer.BLConnect;

namespace RsgtApp.ViewModels
{
    public class AccountSettingsViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        readonly INotificationRegistrationService _notificationRegistrationService;
        Dictionary<string, string> lobjDefaultLanding = new Dictionary<string, string>();

        //To create bussinessLayer Object
        BLConnect objcon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        string strServerSlowMsg = "";
        //Assign Property Two way Binding
        //Two way Binding Variable
        //tglPushTouch purpose of using checkbox varaiable
        public Command Toggle { get; set; }
        public Command TogglePush { get; set; }
        bool tglPushTouch;
        public bool TglPushTouch
        {
            get
            {
                return tglPushTouch;
            }
            set
            {
                tglPushTouch = value;
                OnPropertyChanged();
                // Do any other stuff you want here
            }
        }
        //tglTouch purpose of using toggle varaiable
        bool tglTouch;
        public bool TglTouch
        {
            get
            {
                return tglTouch;
            }
            set
            {
                tglTouch = value;
                OnPropertyChanged();
                // Do any other stuff you want here
            }
        }
        //isBusy purpose of using indicator varaiable
        public bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                btnUpateSettings.ChangeCanExecute();
            }
        }

        private List<EnumCombo> _lobjTemperature { get; set; } = new List<EnumCombo>();

        public List<EnumCombo> lobjTemperature
        {
            get { return _lobjTemperature; }
            set
            {
                if (_lobjTemperature == value)
                    return;
                _lobjTemperature = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjTemperature");
            }
        }

        private List<EnumCombo> _lobjLanguage { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjLanguage
        {
            get { return _lobjLanguage; }
            set
            {
                if (_lobjLanguage == value)
                    return;
                _lobjLanguage = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjLanguage");

            }

        }

        private List<EnumCombo> _lobjCurrency { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCurrency
        {
            get { return _lobjCurrency; }
            set
            {
                if (_lobjCurrency == value)
                    return;
                _lobjCurrency = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCurrency");

            }
        }

        public List<EnumCombo> _lobjWeight { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjWeight
        {
            get { return _lobjWeight; }
            set
            {
                if (_lobjWeight == value)
                    return;
                _lobjWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjWeight");

            }
        }

        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        //accountSettingsActivityIndicator purpose of using indicator varaiable
        bool accountSettingsActivityIndicator = false;
        public bool AccountSettingsActivityIndicator
        {
            get { return accountSettingsActivityIndicator; }
            set
            {
                accountSettingsActivityIndicator = value;
                OnPropertyChanged();
                RaisePropertyChange("AccountSettingsActivityIndicator");
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
        //stkLayoutSunday purpose of using checkbox varaiable
        bool stkLayoutSunday = false;
        public bool StkLayoutSunday
        {
            get { return stkLayoutSunday; }
            set
            {
                stkLayoutSunday = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutSunday");
            }
        }
        //stkLayoutMonday purpose of using checkbox varaiable 
        bool stkLayoutMonday = false;
        public bool StkLayoutMonday
        {
            get { return stkLayoutMonday; }
            set
            {
                stkLayoutMonday = value;

                OnPropertyChanged();
                RaisePropertyChange("StkLayoutMonday");
            }
        }
        //stkLayoutTuesday purpose of using checkbox varaiable
        bool stkLayoutTuesday = false;
        public bool StkLayoutTuesday
        {
            get { return stkLayoutTuesday; }
            set
            {
                stkLayoutTuesday = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutTuesday");
            }
        }
        //stkLayoutWednesday purpose of using checkbox varaiable
        bool stkLayoutWednesday = false;
        public bool StkLayoutWednesday
        {
            get { return stkLayoutWednesday; }
            set
            {
                stkLayoutWednesday = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutWednesday");
            }
        }
        //stkLayoutThursday purpose of using checkbox varaiable
        bool stkLayoutThursday = false;
        public bool StkLayoutThursday
        {
            get { return stkLayoutThursday; }
            set
            {
                stkLayoutThursday = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutThursday");
            }
        }
        //stkLayoutFriday purpose of using checkbox varaiable
        bool stkLayoutFriday = false;
        public bool StkLayoutFriday
        {
            get { return stkLayoutFriday; }
            set
            {
                stkLayoutFriday = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutFriday");
            }
        }
        //stkLayoutSat purpose of using checkbox varaiable
        bool stkLayoutSat = false;
        public bool StkLayoutSat
        {
            get { return stkLayoutSat; }
            set
            {
                stkLayoutSat = value;
                OnPropertyChanged();
                RaisePropertyChange("StkLayoutSat");
            }
        }
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
        //lblAppDate purpose of using textbox varaiable
        private string lblAppDate = "";
        public string LblAppDate
        {
            get { return lblAppDate; }
            set
            {
                lblAppDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAppDate");
            }
        }
        //imgAccountSettingMenu purpose of using image varaiable
        private string imgAccountSettingMenu = "";
        public string ImgAccountSettingMenu
        {
            get { return imgAccountSettingMenu; }
            set
            {
                imgAccountSettingMenu = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgAccountSettingMenu");
            }
        }
        //lblAccountSettings purpose of using textbox varaiable
        private string lblAccountSettings = "";
        public string LblAccountSettings
        {
            get { return lblAccountSettings; }
            set
            {
                lblAccountSettings = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAccountSettings");
            }
        }
        //lblTemperature purpose of using textbox varaiable
        private string lblTemperature = "";
        public string LblTemperature
        {
            get { return lblTemperature; }
            set
            {
                lblTemperature = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTemperature");
            }
        }
        //lblWeight purpose of using textbox varaiable
        private string lblWeight = "";
        public string LblWeight
        {
            get { return lblWeight; }
            set
            {
                lblWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWeight");
            }
        }
        //lblDays purpose of using textbox varaiable
        private string lblDays = "";
        public string LblDays
        {
            get { return lblDays; }
            set
            {
                lblDays = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDays");
            }
        }
        //lblDays purpose of using textbox varaiable
        private string lblApplication = "";
        public string LblApplication
        {
            get { return lblApplication; }
            set
            {
                lblApplication = value;
                OnPropertyChanged();
                RaisePropertyChange("LblApplication");
            }
        }
        //lblSunday purpose of using textbox varaiable
        private string lblSunday = "";
        public string LblSunday
        {
            get { return lblSunday; }
            set
            {
                lblSunday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSunday");
            }
        }
        //lblMonday purpose of using textbox varaiable
        private string lblMonday = "";
        public string LblMonday
        {
            get { return lblMonday; }
            set
            {
                lblMonday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMonday");
            }
        }
        //lblTuesday purpose of using textbox varaiable
        private string lblTuesday = "";
        public string LblTuesday
        {
            get { return lblTuesday; }
            set
            {
                lblTuesday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTuesday");
            }
        }
        //lblThursday purpose of using textbox varaiable
        private string lblThursday = "";
        public string LblThursday
        {
            get { return lblThursday; }
            set
            {
                lblThursday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblThursday");
            }
        }
        //lblFriday purpose of using textbox varaiable
        private string lblFriday = "";
        public string LblFriday
        {
            get { return lblFriday; }
            set
            {
                lblFriday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFriday");
            }
        }
        //lblSaturday purpose of using textbox varaiable
        private string lblSaturday = "";
        public string LblSaturday
        {
            get { return lblSaturday; }
            set
            {
                lblSaturday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSaturday");
            }
        }
        //btnSave purpose of using textbox varaiable
        private string btnSave = "";
        public string BtnSave
        {
            get { return btnSave; }
            set
            {
                btnSave = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSave");
            }
        }
        //picTemperature purpose of using textbox varaiable
        private string picTemperature = "";
        public string PicTemperature
        {
            get { return picTemperature; }
            set
            {
                picTemperature = value;
                OnPropertyChanged();
                RaisePropertyChange("PicTemperature");
            }
        }
        //picWeight purpose of using textbox varaiable
        private string picWeight = "";
        public string PicWeight
        {
            get { return picWeight; }
            set
            {
                picWeight = value;
                OnPropertyChanged();
                RaisePropertyChange("PicWeight");
            }
        }
        //lblPushTouch purpose of using textbox varaiable
        private string lblPushTouch = "";
        public string LblPushTouch
        {
            get { return lblPushTouch; }
            set
            {
                lblPushTouch = value;
                OnPropertyChanged();
                RaisePropertyChange("LblPushTouch");
            }
        }
        private bool stackAccountsetting = true;
        public bool StackAccountsetting
        {
            get { return stackAccountsetting; }
            set
            {
                stackAccountsetting = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAccountsetting");
            }
        }
        //lblWednesday purpose of using textbox varaiable
        private string lblWednesday = "";
        public string LblWednesday
        {
            get { return lblWednesday; }
            set
            {
                lblWednesday = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWednesday");
            }
        }
        //_selectedTemp purpose of using combo varaiable
        private EnumCombo _selectedTemp;
        public EnumCombo SelectedTemp
        {
            get { return _selectedTemp; }
            set
            {
                SetProperty(ref _selectedTemp, value);
                OnPropertyChanged();
                RaisePropertyChange("SelectedTemp");
            }
        }
        //_selectedWeight purpose of using combo varaiable
        private EnumCombo _selectedWeight;
        public EnumCombo SelectedWeight
        {
            get { return _selectedWeight; }
            set
            {
                SetProperty(ref _selectedWeight, value);
                OnPropertyChanged();
                RaisePropertyChange("SelectedWeight");
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
        //lblTouch purpose of using textbox varaiable
        private string lblTouch = "";
        public string LblTouch
        {
            get { return lblTouch; }
            set
            {
                lblTouch = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTouch");
            }
        }
        //btnUpateSettings button
        public Command btnUpateSettings { get; set; }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        /// 
          //To create Collection Object used ObservableCollection
        public List<Accountsettings> lstreguser { get; set; }
        public AccountSettingsViewModel()
        {
            try
            {

                //Appcenter Track Event handler
                Analytics.TrackEvent("AccountSettingsViewModel");
                lstreguser =new List<Accountsettings>();
                Task.Run(() => AccountSetting(gblRegisteration.strLoginUser));

                //Begin-Call Caption Function
                Task.Run(() => assignCms());
                //End-Caption Function
                Toggle = new Command(async () => await toggleBiometric(), () => !IsBusy);
                TogglePush = new Command(async () => await toggle_Push(), () => !IsBusy);
                _notificationRegistrationService = ServiceContainer.Resolve<INotificationRegistrationService>();

                //Begin Command Button
                btnUpateSettings = new Command(async () => await UpateSettings(), () => !IsBusy);
                //End Command Button
            }
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString();
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM005");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM005");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("", ex.Message, "");
            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// Date
        /// Created By
        /// Modified By
        /// </summary>
        public async void assignContent()
        {
            try
            {

                //combo
                lobjTemperature = dbLayer.getEnum("strTemperaturelov", objCMS);
                lobjWeight = dbLayer.getEnum("strWeightlov", objCMS);
                ImgAccountSettingMenu = dbLayer.getCaption("imgAccountSettings", objCMS);
                LblAccountSettings = dbLayer.getCaption("strAccountSettings", objCMS);
                LblTemperature = dbLayer.getCaption("strTemperature", objCMS);
                LblWeight = dbLayer.getCaption("strWeight", objCMS);
                lblApplication = dbLayer.getCaption("strApplication", objCMS);
                lblDays = dbLayer.getCaption("strDays", objCMS);
                lblSunday = dbLayer.getCaption("strSunday", objCMS);
                lblMonday = dbLayer.getCaption("strMonday", objCMS);
                lblTuesday = dbLayer.getCaption("strTuesday", objCMS);
                lblWednesday = dbLayer.getCaption("strWednesday", objCMS);
                lblThursday = dbLayer.getCaption("strThursday", objCMS);
                lblFriday = dbLayer.getCaption("strFriday", objCMS);
                lblSaturday = dbLayer.getCaption("strSaturday", objCMS);
                BtnSave = dbLayer.getCaption("strSave", objCMS);
                LblTouch = dbLayer.getCaption("strTouchIdLogin", objCMS);
                PicTemperature = dbLayer.getCaption("strTemperature", objCMS);
                PicWeight = dbLayer.getCaption("strWeight", objCMS);
                LblPushTouch = dbLayer.getCaption("strPushNotification", objCMS);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                await Task.Delay(1000);
                string result = await SecureStorage.GetAsync("B");
                // App.Current.MainPage?.DisplayToastAsync("AccountSettings_Page", 3000);
                if (result == "rsgt_touchenablement_Yes")
                {
                    TglTouch = true;
                }
                else
                {
                    TglTouch = false;
                }
                result = await SecureStorage.GetAsync("PushTouch");
                if (result == "Y")
                {
                    TglPushTouch = true;
                }
                else
                {
                    TglPushTouch = false;

                }
                if (gblRegisteration.strTemperature != null) SelectedTemp = lobjTemperature.First(x => x.Value == gblRegisteration.strTemperature);

                if (gblRegisteration.strWeight != null) SelectedWeight = lobjWeight.First(x => x.Value == gblRegisteration.strWeight);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        private async Task AccountSetting(string strMailId)
        {
            //  https://portalmobapi.rsgt.com:8443/api/DataSource/getAccountSettings?fstrMailId=TEST@GMAIL.COM

            var objRawData = new List<AccountSettings>();
            objRawData = objcon.getAccountSettingDetails(strMailId);
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
                App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            if (objRawData.Count > 0)
            {
                gblRegisteration.strCurrency = objRawData.ToArray()[0].ru_currencyvalue;

                gblRegisteration.strCurrentUserLang = objRawData.ToArray()[0].ru_languagevalue;

                gblRegisteration.strTemperature = objRawData.ToArray()[0].ru_temperaturevalue;

                gblRegisteration.strWeight = objRawData.ToArray()[0].ru_weightvalue;

                gblRegisteration.strDefaultLanding = objRawData.ToArray()[0].ru_defaultlandingpage;
            }
        }


        /// <summary>
        ///   //To get UpateSettings
        /// </summary>
        /// <returns></returns>
        private async Task UpateSettings()
        {
            try
            {
                // Begin -- 2022/06/02 - Code for Indicatorview set to true
                StackAccountsetting = false;
                IsBusy = true;
                await Task.Delay(1000);
                string fstrMonday = "N";
                string fstrTuesday = "N";
                string fstrWednesday = "N";
                string fstrThursday = "N";
                string fstrFriday = "N";
                string fstrSatday = "N";
                string fstrSunday = "N";
                if (SelectedTemp.Key != null)
                {
                    gblRegisteration.strTemperature = SelectedTemp.Value;
                }
                if (SelectedWeight.Key != null)
                {
                    gblRegisteration.strWeight = SelectedWeight.Value;
                }
                if ((SelectedTemp.Key != null) || (SelectedWeight.Key != null))
                {
                    string lstrResult = objWebApi.putWebApi("UpdateAccountSettings", gblRegisteration.UpdateAccountSetting(fstrMonday, fstrTuesday, fstrWednesday, fstrThursday, fstrFriday, fstrSatday, fstrSunday), gblRegisteration.strLoginUser);

                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                        App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }

                    if (lstrResult.ToString().Trim() == "true")
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new MyProfileMessagePage());
                    }
                }
                StackAccountsetting = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get Toggle
        /// </summary>
        /// <returns></returns>
        private async Task toggleBiometric()
        {
            try
            {
                if (tglTouch == true)
                {
                    await SecureStorage.SetAsync("B", "rsgt_touchenablement_Yes"); //Key,Vaue
                    await SecureStorage.SetAsync("UID", gblRegisteration.strLoginUser); //Key,Vaue

                    string lstrsecureUserData = await SecureStorage.GetAsync("UID");

                    if ((lstrsecureUserData != null) && (lstrsecureUserData != ""))
                    {
                        if (lstrsecureUserData.Length > 0)
                        {
                            gblRegisteration.strLoginUser = lstrsecureUserData;
                        }
                    }

                }
                else
                {
                    SecureStorage.Remove("B");
                    await SecureStorage.SetAsync("B", "rsgt_touchenablement_No");
                    // await SecureStorage.SetAsync("No", "rsgt_touchenablement_No");
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To get TogglePush
        /// </summary>
        /// <returns></returns>
        private async Task toggle_Push()
        {
            try
            {
                if (tglPushTouch == true)
                {
                    await SecureStorage.SetAsync("PushTouch", "Y"); //Key,Vaue
                    string lstrReg_EmailID = gblRegisteration.strLoginUser;
                    Task task = _notificationRegistrationService.RegisterDeviceAsync(lstrReg_EmailID); //20220827  06:39
                }
                else
                {
                    await SecureStorage.SetAsync("PushTouch", "N"); //Key,Vaue
                    await _notificationRegistrationService.DeregisterDeviceAsync().ContinueWith((task)
                     =>
                    {
                        //ShowAlert(task.IsFaulted ? task.Exception.Message : $"Device deregistered");
                    });
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage?.DisplayAlert("", ex.Message, "");
            }
        }
        //RegisterButtonClicked Button
        void RegisterButtonClicked(object sender, EventArgs e)
      => _notificationRegistrationService.RegisterDeviceAsync().ContinueWith((task)
      =>
      {
          ShowAlert(task.IsFaulted ? task.Exception.Message : $"Device registered");
      });

        //DeregisterButtonClicked Button
        void DeregisterButtonClicked(object sender, EventArgs e)
         => _notificationRegistrationService.DeregisterDeviceAsync().ContinueWith((task)
        =>
         {
             ShowAlert(task.IsFaulted ? task.Exception.Message : $"Device deregistered");
         });
        //ShowAlert Button
        void ShowAlert(string message)
            => MainThread.BeginInvokeOnMainThread(()
                => DisplayAlert("PushDemo", message, "OK").ContinueWith((task)
                =>
                {
                    if (task.IsFaulted) throw task.Exception;
                }));
        /// <summary>
        /// To get DisplayAlert
        /// </summary>
        /// <param name="v1">v1</param>
        /// <param name="message">message</param>
        /// <param name="v2">v2</param>
        /// <returns></returns>
        private Task<object> DisplayAlert(string v1, string message, string v2)
        {
            throw new NotImplementedException();
        }
    }
}