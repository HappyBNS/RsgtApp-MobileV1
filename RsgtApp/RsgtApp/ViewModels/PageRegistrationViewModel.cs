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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace RsgtApp.ViewModels
{
    class PageRegistrationViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        public Command gotoNextPageFrom1 { get; set; }
        public Command gotoPreviousPageFrom2 { get; set; }
        public Command gotoNextPageFrom2 { get; set; }
        public Command gotoPreviousPageFrom3 { get; set; }
        public Command gotoNextPageFrom3 { get; set; }
        public Command gotoPreviousPageFrom4 { get; set; }
        public Command gotoPageFrom4 { get; set; }
        public Command GotoModify { get; set; }
        public Command gotoOTP { get; set; }
        public Command gotoLogIn { get; set; }
        public Command gotoList { get; set; }
        public Command gotoREG { get; set; }
        public Command TC_tapped { get; set; }
        public Command gotoPageRegistration7 { get; set; }
        private List<EnumCombo> _lobjPrefer { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjPrefer
        {
            get { return _lobjPrefer; }
            set
            {
                if (_lobjPrefer == value)
                    return;
                _lobjPrefer = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjPrefer");

            }
        }

        private List<EnumCombo> _lobJobFunction { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobJobFunction
        {
            get { return _lobJobFunction; }
            set
            {
                if (_lobJobFunction == value)
                    return;
                _lobJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("lobJobFunction");

            }
        }

        private List<EnumCombo> _lobjContryMobCode { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjContryMobCode
        {
            get { return _lobjContryMobCode; }
            set
            {
                if (_lobjContryMobCode == value)
                    return;
                _lobjContryMobCode = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjContryMobCode");

            }
        }

        private List<EnumCombo> _lobjCompanyType { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCompanyType
        {
            get { return _lobjCompanyType; }
            set
            {
                if (_lobjCompanyType == value)
                    return;
                _lobjCompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCompanyType");

            }
        }

        private List<EnumCombo> _lobjCountry { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCountry
        {
            get { return _lobjCountry; }
            set
            {
                if (_lobjCountry == value)
                    return;
                _lobjCountry = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCountry");

            }
        }

        private List<EnumCombo> _lobjCity { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCity
        {
            get { return _lobjCity; }
            set
            {
                if (_lobjCity == value)
                    return;
                _lobjCity = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCity");

            }
        }

        private List<EnumCombo> _lobjCustomerType { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCustomerType
        {
            get { return _lobjCustomerType; }
            set
            {
                if (_lobjCustomerType == value)
                    return;
                _lobjCustomerType = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCustomerType");

            }
        }
        public List<clsREGISTEREDUSERS> lstreguser { get; set; } = new List<clsREGISTEREDUSERS>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
       
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
        protected bool SetProperty<T>(ref T backfield, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //To Declare IndicatorBGColor Variable
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
        //To Declare indicatorBGOpacity Variable
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
        //To Get Enum Value _selectedCountryMobCode
        private EnumCombo _selectedCountryMobCode;
        public EnumCombo SelectedCountryMobCode
        {
            get { return _selectedCountryMobCode; }
            set
            {
                SetProperty(ref _selectedCountryMobCode, value);
            }
        }
        //To Get Enum Value _selectedJobFunction
        private EnumCombo _selectedJobFunction;
        public EnumCombo SelectedJobFunction
        {
            get { return _selectedJobFunction; }
            set
            {
                SetProperty(ref _selectedJobFunction, value);
            }
        }
        //To Get Enum Value _selectedCompanyType
        private EnumCombo _selectedCompanyType;
        public EnumCombo SelectedCompanyType
        {
            get { return _selectedCompanyType; }
            set
            {
                SetProperty(ref _selectedCompanyType, value);
            }
        }
        //To Get Enum Value _selectedPrefComm
        private EnumCombo _selectedPrefComm;
        public EnumCombo SelectedPrefComm
        {
            get { return _selectedPrefComm; }
            set
            {
                SetProperty(ref _selectedPrefComm, value);
            }
        }
        //To Get Enum Value _selectedCountry
        private EnumCombo _selectedCountry;
        public EnumCombo SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                SetProperty(ref _selectedCountry, value);
            }
        }
        //To Get Enum Value _selectedCity
        private EnumCombo _selectedCity;
        public EnumCombo SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                SetProperty(ref _selectedCity, value);
            }
        }
        //To Get Enum Value _selectedCustomerType
        private EnumCombo _selectedCustomerType;
        public EnumCombo SelectedCustomerType
        {
            get { return _selectedCustomerType; }
            set
            {
                SetProperty(ref _selectedCustomerType, value);
            }
        }
        //PageRegistration1
        //txtFirstName purpose of using textbox variable
        private string txtFirstName = "";
        public string TxtFirstName
        {
            get { return txtFirstName; }
            set
            {
                txtFirstName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFirstName");
            }
        }
        //msgFirstName purpose of using Message variable
        private string msgFirstName = "";
        public string MsgFirstName
        {
            get { return msgFirstName; }
            set
            {
                msgFirstName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFirstName");
            }
        }
        //txtFirstName1 purpose of using textbox variable
        private string txtFirstName1 = "";
        public string TxtFirstName1
        {
            get { return txtFirstName1; }
            set
            {
                txtFirstName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFirstName1");
            }
        }
        //msgFirstNameArbic purpose of using Arabic variable
        private string msgFirstNameArbic = "";
        public string MsgFirstNameArbic
        {
            get { return msgFirstNameArbic; }
            set
            {
                msgFirstNameArbic = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFirstNameArbic");
            }
        }
        //txtLastName purpose of using textbox variable
        private string txtLastName = "";
        public string TxtLastName
        {
            get { return txtLastName; }
            set
            {
                txtLastName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLastName");
            }
        }
        //msgLastName purpose of using Message variable
        private string msgLastName = "";
        public string MsgLastName
        {
            get { return msgLastName; }
            set
            {
                msgLastName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLastName");
            }
        }
        //txtLastName2 purpose of using textbox variable
        private string txtLastName2 = "";
        public string TxtLastName2
        {
            get { return txtLastName2; }
            set
            {
                txtLastName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLastName2");
            }
        }
        //msgLastNameArabic purpose of using Message
        private string msgLastNameArabic = "";
        public string MsgLastNameArabic
        {
            get { return msgLastNameArabic; }
            set
            {
                msgLastNameArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLastNameArabic");
            }
        }
        //MsgCountryP1 purpose of using Message
        private string msgCountryP1 = "";
        public string MsgCountryP1
        {
            get { return msgCountryP1; }
            set
            {
                msgCountryP1 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCountryP1");
            }
        }
        //msgCompany purpose of using Message
        private string msgCompany = "";
        public string MsgCompany
        {
            get { return msgCompany; }
            set
            {
                msgCompany = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompany");
            }
        }
        //MsgPref purpose of using Message
        private string msgPref = "";
        public string MsgPref
        {
            get { return msgPref; }
            set
            {
                msgPref = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPref");
            }
        }
        //txtMobileNumber purpose of using textbox variable
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
        //msgMobileNumber purpose of using Message
        private string msgMobileNumber = "";
        public string MsgMobileNumber
        {
            get { return msgMobileNumber; }
            set
            {
                msgMobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileNumber");
            }
        }
        //msgMobileNoUnique purpose of using Message
        private string msgMobileNoUnique = "";
        public string MsgMobileNoUnique
        {
            get { return msgMobileNoUnique; }
            set
            {
                msgMobileNoUnique = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileNoUnique");
            }
        }
        //txtEmailAddress purpose of using textbox variable
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
        //msgEmailAddress purpose of using Message
        private string msgEmailAddress = "";
        public string MsgEmailAddress
        {
            get { return msgEmailAddress; }
            set
            {
                msgEmailAddress = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmailAddress");
            }
        }
        //msgEmailAddressUnique purpose of using Message
        private string msgEmailAddressUnique = "";
        public string MsgEmailAddressUnique
        {
            get { return msgEmailAddressUnique; }
            set
            {
                msgEmailAddressUnique = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmailAddressUnique");
            }
        }
        //msgEmailValid purpose of using Message
        private string msgEmailValid = "";
        public string MsgEmailValid
        {
            get { return msgEmailValid; }
            set
            {
                msgEmailValid = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmailValid");
            }
        }
        //txtJobTitle purpose of using textbox variable
        private string txtJobTitle = "";
        public string TxtJobTitle
        {
            get { return txtJobTitle; }
            set
            {
                txtJobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtJobTitle");
            }
        }
        //txtPassword purpose of using textbox variable
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
        //msgPassword purpose of using Message
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
        //MsgConfirmPassword purpose of using Message
        private string msgConfirmPassword = "";
        public string MsgConfirmPassword
        {
            get { return msgConfirmPassword; }
            set
            {
                msgConfirmPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgConfirmPassword");
            }
        }
        //txtConfirmPassword purpose of using textbox variable
        private string txtConfirmPassword = "";
        public string TxtConfirmPassword
        {
            get { return txtConfirmPassword; }
            set
            {
                txtConfirmPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtConfirmPassword");
            }
        }
        //msgPasswordMisMatch purpose of using Message
        private string msgPasswordMisMatch = "";
        public string MsgPasswordMisMatch
        {
            get { return msgPasswordMisMatch; }
            set
            {
                msgPasswordMisMatch = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPasswordMisMatch");
            }
        }
        //placeFirstName purpose of using Placeholder
        private string placeFirstName = "";
        public string PlaceFirstName
        {
            get { return placeFirstName; }
            set
            {
                placeFirstName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFirstName");
            }
        }
        //placeFirstName1 purpose of using Placeholder
        private string placeFirstName1 = "";
        public string PlaceFirstName1
        {
            get { return placeFirstName1; }
            set
            {
                placeFirstName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFirstName1");
            }
        }
        //placeLastName purpose of using Placeholder
        private string placeLastName = "";
        public string PlaceLastName
        {
            get { return placeLastName; }
            set
            {
                placeLastName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceLastName");
            }
        }
        //placeLastName2 purpose of using Placeholder
        private string placeLastName2 = "";
        public string PlaceLastName2
        {
            get { return placeLastName2; }
            set
            {
                placeLastName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceLastName2");
            }
        }
        //placeMobileNumber purpose of using Placeholder
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
        //placeEmailAddress purpose of using Placeholder
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
        //placeJobTitle purpose of using Placeholder
        private string placeJobTitle = "";
        public string PlaceJobTitle
        {
            get { return placeJobTitle; }
            set
            {
                placeJobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceJobTitle");
            }
        }
        //placePassword purpose of using Placeholder
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
        //placeConfirmPassword purpose of using Placeholder
        private string placeConfirmPassword = "";
        public string PlaceConfirmPassword
        {
            get { return placeConfirmPassword; }
            set
            {
                placeConfirmPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceConfirmPassword");
            }
        }
        //lblpersonalInformation2 purpose of using Label
        private string lblpersonalInformation2 = "";
        public string lblPersonalInformation2
        {
            get { return lblpersonalInformation2; }
            set
            {
                lblpersonalInformation2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPersonalInformation2");
            }
        }
        //lblfirstName2 purpose of using Label
        private string lblfirstName2 = "";
        public string lblFirstName2
        {
            get { return lblfirstName2; }
            set
            {
                lblfirstName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstName2");
            }
        }
        //lblfirstNamesAr purpose of using Label
        private string lblfirstNamesAr = "";
        public string lblFirstNamesAr
        {
            get { return lblfirstNamesAr; }
            set
            {
                lblfirstNamesAr = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstNamesAr");
            }
        }
        //lbllastName2 purpose of using Label
        private string lbllastName2 = "";
        public string lblLastName2
        {
            get { return lbllastName2; }
            set
            {
                lbllastName2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastName2");
            }
        }
        //lbllastNamesAr purpose of using Label
        private string lbllastNamesAr = "";
        public string lblLastNamesAr
        {
            get { return lbllastNamesAr; }
            set
            {
                lbllastNamesAr = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastNamesAr");
            }
        }
        //lblemailAddress purpose of using Label
        private string lblemailAddress = "";
        public string lblEmailAddress
        {
            get { return lblemailAddress; }
            set
            {
                lblemailAddress = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmailAddress");
            }
        }
        //lbljobTitle1 purpose of using Label
        private string lbljobTitle1 = "";
        public string lblJobTitle1
        {
            get { return lbljobTitle1; }
            set
            {
                lbljobTitle1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobTitle1");
            }
        }
        //lblpassword1 purpose of using Label
        private string lblpassword1 = "";
        public string lblPassword1
        {
            get { return lblpassword1; }
            set
            {
                lblpassword1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPassword1");
            }
        }
        //lblconfirmPassword purpose of using Label
        private string lblconfirmPassword = "";
        public string lblConfirmPassword
        {
            get { return lblconfirmPassword; }
            set
            {
                lblconfirmPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("lblConfirmPassword");
            }
        }
        //imgregisterIcon purpose of using Image
        private string imgregisterIcon = "";
        public string imgRegisterIcon
        {
            get { return imgregisterIcon; }
            set
            {
                imgregisterIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRegisterIcon");
            }
        }
        //lblcustomerRegistration purpose of using Label
        private string lblcustomerRegistration = "";
        public string lblCustomerRegistration
        {
            get { return lblcustomerRegistration; }
            set
            {
                lblcustomerRegistration = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerRegistration");
            }
        }
        //lblpersonalInformation1 purpose of using Label
        private string lblpersonalInformation1 = "";
        public string lblPersonalInformation1
        {
            get { return lblpersonalInformation1; }
            set
            {
                lblpersonalInformation1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPersonalInformation1");
            }
        }
        //lblcompanyInformation purpose of using Label
        private string lblcompanyInformation = "";
        public string lblCompanyInformation
        {
            get { return lblcompanyInformation; }
            set
            {
                lblcompanyInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyInformation");
            }
        }
        //lblnationalAddress purpose of using Label
        private string lblnationalAddress = "";
        public string lblNationalAddress
        {
            get { return lblnationalAddress; }
            set
            {
                lblnationalAddress = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNationalAddress");
            }
        }
        //lbladditionalInformation purpose of using Label
        private string lbladditionalInformation = "";
        public string lblAdditionalInformation
        {
            get { return lbladditionalInformation; }
            set
            {
                lbladditionalInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalInformation");
            }
        }
        //btnnext purpose of using Button
        private string btnnext = "";
        public string btnNext
        {
            get { return btnnext; }
            set
            {
                btnnext = value;
                OnPropertyChanged();
                RaisePropertyChange("btnNext");
            }
        }
        //Msgpagevise purpose of using Message
        private string Msgpagevise = "";
        public string MsgPagevise
        {
            get { return Msgpagevise; }
            set
            {
                Msgpagevise = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise");
            }
        }
        //Msgpagevise2 purpose of using Message
        private string Msgpagevise2 = "";
        public string MsgPagevise2
        {
            get { return Msgpagevise2; }
            set
            {
                Msgpagevise2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise2");
            }
        }
        //Msgpagevise3 purpose of using Message
        private string Msgpagevise3 = "";
        public string MsgPagevise3
        {
            get { return Msgpagevise3; }
            set
            {
                Msgpagevise3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise3");
            }
        }
        //Msgpagevise4 purpose of using Message
        private string Msgpagevise4 = "";
        public string MsgPagevise4
        {
            get { return Msgpagevise4; }
            set
            {
                Msgpagevise4 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise4");
            }
        }
        //lblcountryCode1 purpose of using Label
        private string lblcountryCode1 = "";
        public string lblCountryCode1
        {
            get { return lblcountryCode1; }
            set
            {
                lblcountryCode1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountryCode1");
            }
        }
        //lblmobileNumber2 purpose of using Label
        private string lblmobileNumber2 = "";
        public string lblMobileNumber2
        {
            get { return lblmobileNumber2; }
            set
            {
                lblmobileNumber2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumber2");
            }
        }
        //lblprefComm1 purpose of using label
        private string lblprefComm1 = "";
        public string lblPrefComm1
        {
            get { return lblprefComm1; }
            set
            {
                lblprefComm1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPrefComm1");
            }
        }
        //lbljobFunction1 purpose of using Label
        private string lbljobFunction1 = "";
        public string lblJobFunction1
        {
            get { return lbljobFunction1; }
            set
            {
                lbljobFunction1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobFunction1");
            }
        }
        //piccountryMobCode purpose of using Image
        private string piccountryMobCode = "";
        public string picCountryMobCode
        {
            get { return piccountryMobCode; }
            set
            {
                piccountryMobCode = value;
                OnPropertyChanged();
                RaisePropertyChange("picCountryMobCode");
            }
        }
        //picprefComm purpose of using Image
        private string picprefComm = "";
        public string picPrefComm
        {
            get { return picprefComm; }
            set
            {
                picprefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("picPrefComm");
            }
        }
        //picjobFunction purpose of using Image
        private string picjobFunction = "";
        public string picJobFunction
        {
            get { return picjobFunction; }
            set
            {
                picjobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("picJobFunction");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedFirstname = false;
        public bool IsvalidatedFirstname
        {
            get { return isvalidatedFirstname; }
            set
            {
                isvalidatedFirstname = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedFirstname");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedFirstnameArabic = false;
        public bool IsvalidatedFirstnameArabic
        {
            get { return isvalidatedFirstnameArabic; }
            set
            {
                isvalidatedFirstnameArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedFirstnameArabic");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedLastName = false;
        public bool IsvalidatedLastName
        {
            get { return isvalidatedLastName; }
            set
            {
                isvalidatedLastName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLastName");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedLastnameArabic = false;
        public bool IsvalidatedLastnameArabic
        {
            get { return isvalidatedLastnameArabic; }
            set
            {
                isvalidatedLastnameArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLastnameArabic");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedMobileNo = false;
        public bool IsvalidatedMobileNo
        {
            get { return isvalidatedMobileNo; }
            set
            {
                isvalidatedMobileNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMobileNo");
            }
        }

        private bool isvalidatedMobileNoExist = false;
        public bool IsvalidatedMobileNoExist
        {
            get { return isvalidatedMobileNoExist; }
            set
            {
                isvalidatedMobileNoExist = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMobileNoExist");
            }
        }
        //To handle Boolen variable
        private bool validateMobilNo = false;
        public bool ValidateMobilNo
        {
            get { return validateMobilNo; }
            set
            {
                validateMobilNo = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateMobilNo");
            }
        }
        //To handle Boolen variable
        private bool validateEmail = false;
        public bool ValidateEmail
        {
            get { return validateEmail; }
            set
            {
                validateEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateEmail");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedPrefComm = false;
        public bool IsvalidatedPrefComm
        {
            get { return isvalidatedPrefComm; }
            set
            {
                isvalidatedPrefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedPrefComm");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedPassword = false;
        public bool IsvalidatedPassword
        {
            get { return isvalidatedPassword; }
            set
            {
                isvalidatedPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedPassword");
            }
        }
        //To handle Boolen variable
        private bool _IsvalidatedOTP = false;
        public bool IsvalidatedOTP
        {
            get { return _IsvalidatedOTP; }
            set
            {
                _IsvalidatedOTP = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedOTP");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedConfirmPass = false;
        public bool IsvalidatedConfirmPass
        {
            get { return isvalidatedConfirmPass; }
            set
            {
                isvalidatedConfirmPass = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedConfirmPass");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedMisMatchPass = false;
        public bool IsvalidatedMisMatchPass
        {
            get { return isvalidatedMisMatchPass; }
            set
            {
                isvalidatedMisMatchPass = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMisMatchPass");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedCompanyType = false;
        public bool IsvalidatedCompanyType
        {
            get { return isvalidatedCompanyType; }
            set
            {
                isvalidatedCompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCompanyType");
            }
        }
        ////To handle Boolen variable
        //private bool isvalidatedCompanyname = false;
        //public bool IsvalidatedCompanyname
        //{
        //    get { return isvalidatedCompanyname; }
        //    set
        //    {
        //        isvalidatedCompanyname = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("IsvalidatedCompanyname");
        //    }
        //}
        //To handle Boolen variable
        private bool chkmandatoryGenP2 = false;
        public bool ChkMandatoryGenP2
        {
            get { return chkmandatoryGenP2; }
            set
            {
                chkmandatoryGenP2 = value;
                OnPropertyChanged();
                RaisePropertyChange("ChkMandatoryGenP2");
            }
        }
        //To handle Boolen variable
        private bool validateEmailUni = false;
        public bool ValidateEmailUni
        {
            get { return validateEmailUni; }
            set
            {
                validateEmailUni = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateEmailUni");
            }
        }
        //To handle Boolen variable
        private string validateEmailAdd = "";
        public string ValidateEmailAdd
        {
            get { return validateEmailAdd; }
            set
            {
                validateEmailAdd = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateEmailAdd");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedCountry = false;
        public bool IsvalidatedCountry
        {
            get { return isvalidatedCountry; }
            set
            {
                isvalidatedCountry = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCountry");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedBuildingNo = false;
        public bool IsvalidatedBuildingNo
        {
            get { return isvalidatedBuildingNo; }
            set
            {
                isvalidatedBuildingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedBuildingNo");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedUnitNo = false;
        public bool IsvalidatedUnitNo
        {
            get { return isvalidatedUnitNo; }
            set
            {
                isvalidatedUnitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedUnitNo");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedstreetName = false;
        public bool IsvalidatedstreetName
        {
            get { return isvalidatedstreetName; }
            set
            {
                isvalidatedstreetName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedstreetName");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedDistrict = false;
        public bool IsvalidatedDistrict
        {
            get { return isvalidatedDistrict; }
            set
            {
                isvalidatedDistrict = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedDistrict");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedCity = false;
        public bool IsvalidatedCity
        {
            get { return isvalidatedCity; }
            set
            {
                isvalidatedCity = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCity");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedZipCode = false;
        public bool IsvalidatedZipCode
        {
            get { return isvalidatedZipCode; }
            set
            {
                isvalidatedZipCode = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedZipCode");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedAdditionalNo = false;
        public bool IsvalidatedAdditionalNo
        {
            get { return isvalidatedAdditionalNo; }
            set
            {
                isvalidatedAdditionalNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedAdditionalNo");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedTelephone = false;
        public bool IsvalidatedTelephone
        {
            get { return isvalidatedTelephone; }
            set
            {
                isvalidatedTelephone = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTelephone");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedfax = false;
        public bool Isvalidatedfax
        {
            get { return isvalidatedfax; }
            set
            {
                isvalidatedfax = value;
                OnPropertyChanged();
                RaisePropertyChange("Isvalidatedfax");
            }
        }
        //To handle Boolen variable
        private bool ChkmandatoryGenP3 = false;
        public bool ChkMandatoryGenP3
        {
            get { return ChkmandatoryGenP3; }
            set
            {
                ChkmandatoryGenP3 = value;
                OnPropertyChanged();
                RaisePropertyChange("ChkMandatoryGenP3");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedCustomerType = false;
        public bool IsvalidatedCustomerType
        {
            get { return isvalidatedCustomerType; }
            set
            {
                isvalidatedCustomerType = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCustomerType");
            }
        }
        //To handle Boolen variable
        private bool iValidateId = false;
        public bool IValidateId
        {
            get { return iValidateId; }
            set
            {
                iValidateId = value;
                OnPropertyChanged();
                RaisePropertyChange("IValidateId");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedIDNo = false;
        public bool IsvalidatedIDNo
        {
            get { return isvalidatedIDNo; }
            set
            {
                isvalidatedIDNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedIDNo");
            }
        }
        //To handle Boolen variable
        private bool isvalidatedLicNo = false;
        public bool IsvalidatedLicNo
        {
            get { return isvalidatedLicNo; }
            set
            {
                isvalidatedLicNo = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLicNo");
            }
        }
        ////To handle Boolen variable
        private bool ischkmandatoryTerms = false;
        public bool isChkMandatoryTerms
        {
            get { return ischkmandatoryTerms; }
            set
            {
                ischkmandatoryTerms = value;
                OnPropertyChanged();
                RaisePropertyChange("isChkMandatoryTerms");
            }
        }
        //To handle Boolen variable
        private bool pagevise1 = false;
        public bool Pagevise1
        {
            get { return pagevise1; }
            set
            {
                pagevise1 = value;
                OnPropertyChanged();
                RaisePropertyChange("Pagevise1");
            }
        }
        //To handle Boolen variable
        private bool pagevise4 = false;
        public bool Pagevise4
        {
            get { return pagevise4; }
            set
            {
                pagevise4 = value;
                OnPropertyChanged();
                RaisePropertyChange("Pagevise4");
            }
        }
        //txtJobFunction purpose of using textbox variable
        private string txtJobFunction = "";
        public string TxtJobFunction
        {
            get { return txtJobFunction; }
            set
            {
                txtJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtJobFunction");
            }
        }
        //stepText1 purpose of using textbox variable
        private string stepText1;
        public string StepText1
        {
            get { return stepText1; }
            set
            {
                stepText1 = value;
                OnPropertyChanged();
                RaisePropertyChange("StepText1");
            }
        }
        //stepText2 purpose of using textbox variable
        private string stepText2;
        public string StepText2
        {
            get { return stepText2; }
            set
            {
                stepText2 = value;
                OnPropertyChanged();
                RaisePropertyChange("StepText2");
            }
        }
        //stepText3 purpose of using textbox variable
        private string stepText3;
        public string StepText3
        {
            get { return stepText3; }
            set
            {
                stepText3 = value;
                OnPropertyChanged();
                RaisePropertyChange("StepText3");
            }
        }
        //stepText4 purpose of using textbox variable
        private string stepText4;
        public string StepText4
        {
            get { return stepText4; }
            set
            {
                stepText4 = value;
                OnPropertyChanged();
                RaisePropertyChange("StepText4");
            }
        }
        //stepactive1 purpose of using textbox variable
        private string stepactive1 = "";
        public string Stepactive1
        {
            get { return stepactive1; }
            set
            {
                stepactive1 = value;
                OnPropertyChanged();
                RaisePropertyChange("Stepactive1");
            }
        }
        //stepactive2 purpose of using textbox variable
        private string stepactive2 = "";
        public string Stepactive2
        {
            get { return stepactive2; }
            set
            {
                stepactive2 = value;
                OnPropertyChanged();
                RaisePropertyChange("Stepactive2");
            }
        }
        //stepactive3 purpose of using textbox variable
        private string stepactive3 = "";
        public string Stepactive3
        {
            get { return stepactive3; }
            set
            {
                stepactive3 = value;
                OnPropertyChanged();
                RaisePropertyChange("Stepactive3");
            }
        }
        //stepactive4 purpose of using textbox variable
        private string stepactive4 = "";
        public string Stepactive4
        {
            get { return stepactive4; }
            set
            {
                stepactive4 = value;
                OnPropertyChanged();
                RaisePropertyChange("Stepactive4");
            }
        }
        //Hide Page
        //To handle Boolen variable
        private bool pageHeader = false;
        public bool PageHeader
        {
            get { return pageHeader; }
            set
            {
                pageHeader = value;
                OnPropertyChanged();
                RaisePropertyChange("PageHeader");
            }
        }
        //To handle Boolen variable
        private bool page1 = false;
        public bool Page1
        {
            get { return page1; }
            set
            {
                page1 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page1");
            }
        }
        //To handle Boolen variable
        private bool page2 = false;
        public bool Page2
        {
            get { return page2; }
            set
            {
                page2 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page2");
            }
        }
        //To handle Boolen variable
        private bool page3 = false;
        public bool Page3
        {
            get { return page3; }
            set
            {
                page3 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page3");
            }
        }
        //To handle Boolen variable
        private bool page4 = false;
        public bool Page4
        {
            get { return page4; }
            set
            {
                page4 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page4");
            }
        }
        //To handle Boolen variable
        private bool page5 = false;
        public bool Page5
        {
            get { return page5; }
            set
            {
                page5 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page5");
            }
        }
        //To handle Boolen variable
        private bool page6 = false;
        public bool Page6
        {
            get { return page6; }
            set
            {
                page6 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page6");
            }
        }
        //To handle Boolen variable
        private bool page7 = false;
        public bool Page7
        {
            get { return page7; }
            set
            {
                page7 = value;
                OnPropertyChanged();
                RaisePropertyChange("Page7");
            }
        }
        //To handle Boolen variable
        private bool pageFooter = false;
        public bool PageFooter
        {
            get { return pageFooter; }
            set
            {
                pageFooter = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter");
            }
        }
        //To handle Boolen variable
        private bool pageFooter_1 = false;
        public bool PageFooter_1
        {
            get { return pageFooter_1; }
            set
            {
                pageFooter_1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter_1");
            }
        }
        //To handle Boolen variable
        private bool pageFooter_2 = false;
        public bool PageFooter_2
        {
            get { return pageFooter_2; }
            set
            {
                pageFooter_2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter_2");
            }
        }
        //To handle Boolen variable
        private bool pageFooter_3 = false;
        public bool PageFooter_3
        {
            get { return pageFooter_3; }
            set
            {
                pageFooter_3 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter_3");
            }
        }
        //To handle Boolen variable
        private bool pageFooter_4 = false;
        public bool PageFooter_4
        {
            get { return pageFooter_4; }
            set
            {
                pageFooter_4 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter_4");
            }
        }
        //To handle Boolen variable
        private bool pageFooter_5 = false;
        public bool PageFooter_5
        {
            get { return pageFooter_5; }
            set
            {
                pageFooter_5 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter_5");
            }
        }
        //lblcompanyInformation2 purpose of using Label
        private string lblcompanyInformation2 = "";
        public string lblCompanyInformation2
        {
            get { return lblcompanyInformation2; }
            set
            {
                lblcompanyInformation2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyInformation2");
            }
        }
        //lblcompanyType1 purpose of using Label
        private string lblcompanyType1 = "";
        public string lblCompanyType1
        {
            get { return lblcompanyType1; }
            set
            {
                lblcompanyType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyType1");
            }
        }
        //MsgcompanyType purpose of using Message
        private string MsgcompanyType = "";
        public string MsgCompanyType
        {
            get { return MsgcompanyType; }
            set
            {
                MsgcompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyType");
            }
        }
        //lblcompanyName1 purpose of using Label
        private string lblcompanyName1 = "";
        public string lblCompanyName1
        {
            get { return lblcompanyName1; }
            set
            {
                lblcompanyName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyName1");
            }
        }
        //TxtcompanyName purpose of using Textbox Variable
        private string TxtcompanyName = "";
        public string TxtCompanyName
        {
            get { return TxtcompanyName; }
            set
            {
                TxtcompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCompanyName");
            }
        }
        //placeCompanyName purpose of using Placeholder
        private string placeCompanyName = "";
        public string PlaceCompanyName
        {
            get { return placeCompanyName; }
            set
            {
                placeCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceCompanyName");
            }
        }
        //MsgcompanyName purpose of using Message
        private string MsgcompanyName = "";
        public string MsgCompanyName
        {
            get { return MsgcompanyName; }
            set
            {
                MsgcompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyName");
            }
        }
        //msgCheckmandatoryGenP2 purpose of using Message
        private string msgCheckmandatoryGenP2 = "";
        public string MsgCheckMandatoryGenP2
        {
            get { return msgCheckmandatoryGenP2; }
            set
            {
                msgCheckmandatoryGenP2 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCheckMandatoryGenP2");
            }
        }
        //btnpreviousP2 purpose of using Button
        private string btnpreviousP2 = "";
        public string btnPreviousP2
        {
            get { return btnpreviousP2; }
            set
            {
                btnpreviousP2 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnPreviousP2");
            }
        }
        //btnnextP2 purpose of using Button
        private string btnnextP2 = "";
        public string btnNextP2
        {
            get { return btnnextP2; }
            set
            {
                btnnextP2 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnNextP2");
            }
        }
        //PageReg-3
        //lblnational purpose of using Label
        private string lblnational = "";
        public string lblNational
        {
            get { return lblnational; }
            set
            {
                lblnational = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNational");
            }
        }
        //lblcountry1 purpose of using Label
        private string lblcountry1 = "";
        public string lblCountry1
        {
            get { return lblcountry1; }
            set
            {
                lblcountry1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountry1");
            }
        }
        //msgCountryP3 purpose of using Message
        private string msgCountryP3 = "";
        public string MsgCountryP3
        {
            get { return msgCountryP3; }
            set
            {
                msgCountryP3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCountryP3");
            }
        }
        //lblbuildingNo1 purpose of using Label
        private string lblbuildingNo1 = "";
        public string lblBuildingNo1
        {
            get { return lblbuildingNo1; }
            set
            {
                lblbuildingNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBuildingNo1");
            }
        }
        //txtBuildingNo purpose of using textbox variable
        private string txtBuildingNo = "";
        public string TxtBuildingNo
        {
            get { return txtBuildingNo; }
            set
            {
                txtBuildingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtBuildingNo");
            }
        }
        //placeBuildingNo purpose of using Placeholder
        private string placeBuildingNo = "";
        public string PlaceBuildingNo
        {
            get { return placeBuildingNo; }
            set
            {
                placeBuildingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceBuildingNo");
            }
        }
        //msgBuildingNo purpose of using Message
        private string msgBuildingNo = "";
        public string MsgBuildingNo
        {
            get { return msgBuildingNo; }
            set
            {
                msgBuildingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgBuildingNo");
            }
        }
        //lblunitNo1 purpose of using Label
        private string lblunitNo1 = "";
        public string lblUnitNo1
        {
            get { return lblunitNo1; }
            set
            {
                lblunitNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblUnitNo1");
            }
        }
        //txtUnitNo purpose of using textbox variable
        private string txtUnitNo = "";
        public string TxtUnitNo
        {
            get { return txtUnitNo; }
            set
            {
                txtUnitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtUnitNo");
            }
        }
        //placeUnitNo purpose of using textbox variable
        private string placeUnitNo = "";
        public string PlaceUnitNo
        {
            get { return placeUnitNo; }
            set
            {
                placeUnitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceUnitNo");
            }
        }
        //lblstreetName1 purpose of using Label
        private string lblstreetName1 = "";
        public string lblStreetName1
        {
            get { return lblstreetName1; }
            set
            {
                lblstreetName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStreetName1");
            }
        }
        //txtStreetName purpose of using textbox variable
        private string txtStreetName = "";
        public string TxtStreetName
        {
            get { return txtStreetName; }
            set
            {
                txtStreetName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtStreetName");
            }
        }
        //placeStreetName purpose of using Placeholder
        private string placeStreetName = "";
        public string PlaceStreetName
        {
            get { return placeStreetName; }
            set
            {
                placeStreetName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceStreetName");
            }
        }
        //msgStreetName purpose of using Message
        private string msgStreetName = "";
        public string MsgStreetName
        {
            get { return msgStreetName; }
            set
            {
                msgStreetName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgStreetName");
            }
        }
        //lbldistrictName1 purpose of using Label
        private string lbldistrictName1 = "";
        public string lblDistrictName1
        {
            get { return lbldistrictName1; }
            set
            {
                lbldistrictName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDistrictName1");
            }
        }
        //txtDistrict purpose of using textbox variable
        private string txtDistrict = "";
        public string TxtDistrict
        {
            get { return txtDistrict; }
            set
            {
                txtDistrict = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDistrict");
            }
        }
        //placeDistrict purpose of using Placeholder
        private string placeDistrict = "";
        public string PlaceDistrict
        {
            get { return placeDistrict; }
            set
            {
                placeDistrict = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceDistrict");
            }
        }
        //msgDistrict purpose of using Message
        private string msgDistrict = "";
        public string MsgDistrict
        {
            get { return msgDistrict; }
            set
            {
                msgDistrict = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDistrict");
            }
        }
        //lblcity1 purpose of using Label
        private string lblcity1 = "";
        public string lblCity1
        {
            get { return lblcity1; }
            set
            {
                lblcity1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCity1");
            }
        }
        //msgCityName purpose of using Message
        private string msgCityName = "";
        public string MsgCityName
        {
            get { return msgCityName; }
            set
            {
                msgCityName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCityName");
            }
        }
        //lblzipCode purpose of using Label
        private string lblzipCode = "";
        public string lblZipCode
        {
            get { return lblzipCode; }
            set
            {
                lblzipCode = value;
                OnPropertyChanged();
                RaisePropertyChange("lblZipCode");
            }
        }
        //txtZipCode purpose of using textbox variable
        private string txtZipCode = "";
        public string TxtZipCode
        {
            get { return txtZipCode; }
            set
            {
                txtZipCode = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtZipCode");
            }
        }
        //msgZipCode purpose of using Message
        private string msgZipCode = "";
        public string MsgZipCode
        {
            get { return msgZipCode; }
            set
            {
                msgZipCode = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgZipCode");
            }
        }
        //lbladditionalNo1 purpose of using Label
        private string lbladditionalNo1 = "";
        public string lblAdditionalNo1
        {
            get { return lbladditionalNo1; }
            set
            {
                lbladditionalNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalNo1");
            }
        }
        //txtAdditionalNo purpose of using textbox variable
        private string txtAdditionalNo = "";
        public string TxtAdditionalNo
        {
            get { return txtAdditionalNo; }
            set
            {
                txtAdditionalNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtAdditionalNo");
            }
        }
        //placeAdditionalNo purpose of using Placeholder
        private string placeAdditionalNo = "";
        public string PlaceAdditionalNo
        {
            get { return placeAdditionalNo; }
            set
            {
                placeAdditionalNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceAdditionalNo");
            }
        }
        //msgAdditional purpose of using Message
        private string msgAdditional = "";
        public string MsgAdditional
        {
            get { return msgAdditional; }
            set
            {
                msgAdditional = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAdditional");
            }
        }
        //lbltelephone1 purpose of using Label
        private string lbltelephone1 = "";
        public string lblTelephone1
        {
            get { return lbltelephone1; }
            set
            {
                lbltelephone1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTelephone1");
            }
        }
        //txtTelephone purpose of using textbox variable
        private string txtTelephone = "";
        public string TxtTelephone
        {
            get { return txtTelephone; }
            set
            {
                txtTelephone = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTelephone");
            }
        }
        //placeTelephone purpose of using Placeholder
        private string placeTelephone = "";
        public string PlaceTelephone
        {
            get { return placeTelephone; }
            set
            {
                placeTelephone = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTelephone");
            }
        }
        //msgTelephone purpose of using Message
        private string msgTelephone = "";
        public string MsgTelephone
        {
            get { return msgTelephone; }
            set
            {
                msgTelephone = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTelephone");
            }
        }
        //lblfax1 purpose of using Label
        private string lblfax1 = "";
        public string lblFax1
        {
            get { return lblfax1; }
            set
            {
                lblfax1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFax1");
            }
        }
        //msgfax purpose of using Message
        private string msgfax = "";
        public string Msgfax
        {
            get { return msgfax; }
            set
            {
                msgfax = value;
                OnPropertyChanged();
                RaisePropertyChange("Msgfax");
            }
        }
        //placeZipCode purpose of using Placeholder
        private string placeZipCode = "";
        public string PlaceZipCode
        {
            get { return placeZipCode; }
            set
            {
                placeZipCode = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceZipCode");
            }
        }

        //btnpreviousP3 purpose of using Button
        private string btnpreviousP3 = "";
        public string btnPreviousP3
        {
            get { return btnpreviousP3; }
            set
            {
                btnpreviousP3 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnPreviousP3");
            }
        }
        //btnnextP3 purpose of using Button
        private string btnnextP3 = "";
        public string btnNextP3
        {
            get { return btnnextP3; }
            set
            {
                btnnextP3 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnNextP3");
            }
        }
        //txtFax purpose of using Textbox Variable
        private string txtFax = "";
        public string TxtFax
        {
            get { return txtFax; }
            set
            {
                txtFax = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtFax");
            }
        }
        //placeFax purpose of using Placeholder
        private string placeFax = "";
        public string PlaceFax
        {
            get { return placeFax; }
            set
            {
                placeFax = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceFax");
            }
        }
        //msgUnitNo purpose of using Message
        private string msgAlreadyUnitNo = "";
        public string MsgAlreadyUnitNo
        {
            get { return msgAlreadyUnitNo; }
            set
            {
                msgAlreadyUnitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAlreadyUnitNo");
            }
        }
        private string msgUnitNo = "";
        public string MsgUnitNo
        {
            get { return msgUnitNo; }
            set
            {
                msgUnitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgUnitNo");
            }
        }
        //PageReg-4
        //lbladditionalInfo2 purpose of using Label
        private string lbladditionalInfo2 = "";
        public string lblAdditionalInfo2
        {
            get { return lbladditionalInfo2; }
            set
            {
                lbladditionalInfo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalInfo2");
            }
        }
        //lblcustomerType1 purpose of using Label
        private string lblcustomerType1 = "";
        public string lblCustomerType1
        {
            get { return lblcustomerType1; }
            set
            {
                lblcustomerType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerType1");
            }
        }
        //msgCustomerType purpose of using Message
        private string msgCustomerType = "";
        public string MsgCustomerType
        {
            get { return msgCustomerType; }
            set
            {
                msgCustomerType = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCustomerType");
            }
        }
        //lblnationalIDNo1 purpose of using Label
        private string lblnationalIDNo1 = "";
        public string lblNationalIDNo1
        {
            get { return lblnationalIDNo1; }
            set
            {
                lblnationalIDNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNationalIDNo1");
            }
        }
        //txtIDNo purpose of using Textbox Variable
        private string txtIDNo = "";
        public string TxtIDNo
        {
            get { return txtIDNo; }
            set
            {
                txtIDNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtIDNo");
            }
        }
        //placeIDNo purpose of using Placeholder
        private string placeIDNo = "";
        public string PlaceIDNo
        {
            get { return placeIDNo; }
            set
            {
                placeIDNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceIDNo");
            }
        }
        //msgIDNo purpose of using Message
        private string msgIDNo = "";
        public string MsgIDNo
        {
            get { return msgIDNo; }
            set
            {
                msgIDNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgIDNo");
            }
        }
        //msgUniqIdNo purpose of using Message
        private string msgUniqIdNo = "";
        public string MsgUniqIdNo
        {
            get { return msgUniqIdNo; }
            set
            {
                msgUniqIdNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgUniqIdNo");
            }
        }
        //lbllicenseNo1 purpose of using Label
        private string lbllicenseNo1 = "";
        public string lblLicenseNo1
        {
            get { return lbllicenseNo1; }
            set
            {
                lbllicenseNo1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNo1");
            }
        }
        //txtImpExpLicNo purpose of using Textbox Variable
        private string txtImpExpLicNo = "";
        public string TxtImpExpLicNo
        {
            get { return txtImpExpLicNo; }
            set
            {
                txtImpExpLicNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtImpExpLicNo");
            }
        }
        //placeImpExpLicNo purpose of using Placeholder
        private string placeImpExpLicNo = "";
        public string PlaceImpExpLicNo
        {
            get { return placeImpExpLicNo; }
            set
            {
                placeImpExpLicNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceImpExpLicNo");
            }
        }
        //msgLicNo purpose of using Message
        private string msgLicNo = "";
        public string MsgLicNo
        {
            get { return msgLicNo; }
            set
            {
                msgLicNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLicNo");
            }
        }
        //txtlicenceNo2 purpose of using Textbox Variable
        private string txtlicenceNo2 = "";
        public string TxtlicenceNo2
        {
            get { return txtlicenceNo2; }
            set
            {
                txtlicenceNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo2");
            }
        }
        //placelicenceNo2 purpose of using Placeholder
        private string placelicenceNo2 = "";
        public string PlacelicenceNo2
        {
            get { return placelicenceNo2; }
            set
            {
                placelicenceNo2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo2");
            }
        }
        //txtlicenceNo3 purpose of using Textbox Variable
        private string txtlicenceNo3 = "";
        public string TxtlicenceNo3
        {
            get { return txtlicenceNo3; }
            set
            {
                txtlicenceNo3 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo3");
            }
        }
        //placelicenceNo3 purpose of using Placeholder
        private string placelicenceNo3 = "";
        public string PlacelicenceNo3
        {
            get { return placelicenceNo3; }
            set
            {
                placelicenceNo3 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo3");
            }
        }
        //txtlicenceNo4 purpose of using Textbox Variable
        private string txtlicenceNo4 = "";
        public string TxtlicenceNo4
        {
            get { return txtlicenceNo4; }
            set
            {
                txtlicenceNo4 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo4");
            }
        }
        //placelicenceNo4 purpose of using Placeholder
        private string placelicenceNo4 = "";
        public string PlacelicenceNo4
        {
            get { return placelicenceNo4; }
            set
            {
                placelicenceNo4 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo4");
            }
        }
        //txtlicenceNo5 purpose of using Textbox Variable
        private string txtlicenceNo5 = "";
        public string TxtlicenceNo5
        {
            get { return txtlicenceNo5; }
            set
            {
                txtlicenceNo5 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo5");
            }
        }
        //placelicenceNo5 purpose of using Placeholder
        private string placelicenceNo5 = "";
        public string PlacelicenceNo5
        {
            get { return placelicenceNo5; }
            set
            {
                placelicenceNo5 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo5");
            }
        }
        //txtlicenceNo6 purpose of using Textbox Variable
        private string txtlicenceNo6 = "";
        public string TxtlicenceNo6
        {
            get { return txtlicenceNo6; }
            set
            {
                txtlicenceNo6 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo6");
            }
        }
        //placelicenceNo6 purpose of using Placeholder
        private string placelicenceNo6 = "";
        public string PlacelicenceNo6
        {
            get { return placelicenceNo6; }
            set
            {
                placelicenceNo6 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo6");
            }
        }
        //txtlicenceNo7 purpose of using Textbox Variable
        private string txtlicenceNo7 = "";
        public string TxtlicenceNo7
        {
            get { return txtlicenceNo7; }
            set
            {
                txtlicenceNo7 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo7");
            }
        }
        //placelicenceNo7 purpose of using Placeholder
        private string placelicenceNo7 = "";
        public string PlacelicenceNo7
        {
            get { return placelicenceNo7; }
            set
            {
                placelicenceNo7 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo7");
            }
        }
        //txtlicenceNo8 purpose of using Textbox Variable
        private string txtlicenceNo8 = "";
        public string TxtlicenceNo8
        {
            get { return txtlicenceNo8; }
            set
            {
                txtlicenceNo8 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo8");
            }
        }
        //placelicenceNo8 purpose of using Placeholder
        private string placelicenceNo8 = "";
        public string PlacelicenceNo8
        {
            get { return placelicenceNo8; }
            set
            {
                placelicenceNo8 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo8");
            }
        }
        //txtlicenceNo9 purpose of using Textbox Variable
        private string txtlicenceNo9 = "";
        public string TxtlicenceNo9
        {
            get { return txtlicenceNo9; }
            set
            {
                txtlicenceNo9 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo9");
            }
        }
        //placelicenceNo9 purpose of using Placeholder
        private string placelicenceNo9 = "";
        public string PlacelicenceNo9
        {
            get { return placelicenceNo9; }
            set
            {
                placelicenceNo9 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo9");
            }
        }
        //txtlicenceNo10 purpose of using Textbox Variable
        private string txtlicenceNo10 = "";
        public string TxtlicenceNo10
        {
            get { return txtlicenceNo10; }
            set
            {
                txtlicenceNo10 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtlicenceNo10");
            }
        }
        //placelicenceNo10 purpose of using Placeholder
        private string placelicenceNo10 = "";
        public string PlacelicenceNo10
        {
            get { return placelicenceNo10; }
            set
            {
                placelicenceNo10 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlacelicenceNo10");
            }
        }
        //btnok purpose of using Button
        private string btnok = "";
        public string btnOk
        {
            get { return btnok; }
            set
            {
                btnok = value;
                OnPropertyChanged();
                RaisePropertyChange("btnOk");
            }
        }
        //chkMandatoryTerms purpose of using Error Message
        private string chkMandatoryTerms = "";
        public string ChkMandatoryTerms
        {
            get { return chkMandatoryTerms; }
            set
            {
                chkMandatoryTerms = value;
                OnPropertyChanged();
                RaisePropertyChange("ChkMandatoryTerms");
            }
        }
        //lbltermsAndConditions purpose of using Label
        private string lbltermsAndConditions = "";
        public string lblTermsAndConditions
        {
            get { return lbltermsAndConditions; }
            set
            {
                lbltermsAndConditions = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTermsAndConditions");
            }
        }
        //lbltc purpose of using Label
        private string lbltc = "";
        public string lblTc
        {
            get { return lbltc; }
            set
            {
                lbltc = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTc");
            }
        }
        //msgMandatoryTerms purpose of using Button
        private string msgMandatoryTerms = "";
        public string MsgMandatoryTerms
        {
            get { return msgMandatoryTerms; }
            set
            {
                msgMandatoryTerms = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMandatoryTerms");
            }
        }
        //btnpreviousP4 purpose of using Button
        private string btnpreviousP4 = "";
        public string btnPreviousP4
        {
            get { return btnpreviousP4; }
            set
            {
                btnpreviousP4 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnPreviousP4");
            }
        }
        //btnnextP4 purpose of using Button
        private string btnnextP4 = "";
        public string btnNextP4
        {
            get { return btnnextP4; }
            set
            {
                btnnextP4 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnNextP4");
            }
        }
        //To handle Boolen variable
        private bool licencenodiv = false;
        public bool Licencenodiv
        {
            get { return licencenodiv; }
            set
            {
                licencenodiv = value;
                OnPropertyChanged();
                RaisePropertyChange("Licencenodiv");
            }
        }
        //To handle Licencenodiv
        private async Task gotoreg()
        {
            IsBusy = true;
            StackPageRegistration = false;
            await Task.Delay(1000);
            Licencenodiv = false;
            StackPageRegistration = true;
            IsBusy = false;
        }
        //PageReg-5
        //imgregisterIconP5 purpose of using Image
        private string imgregisterIconP5 = "";
        public string imgRegisterIconP5
        {
            get { return imgregisterIconP5; }
            set
            {
                imgregisterIconP5 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRegisterIconP5");
            }
        }
        //lblcustomerRegistrationP5 purpose of using Label
        private string lblcustomerRegistrationP5 = "";
        public string lblCustomerRegistrationP5
        {
            get { return lblcustomerRegistrationP5; }
            set
            {
                lblcustomerRegistrationP5 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerRegistrationP5");
            }
        }
        //lblpersonalInformation purpose of using Label
        private string lblpersonalInformation = "";
        public string lblPersonalInformation
        {
            get { return lblpersonalInformation; }
            set
            {
                lblpersonalInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPersonalInformation");
            }
        }
        //lblfirstName purpose of using Label
        private string lblfirstName = "";
        public string lblFirstName
        {
            get { return lblfirstName; }
            set
            {
                lblfirstName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstName");
            }
        }//lblfirstNameVal purpose of using Label
        private string lblfirstNameVal = "";
        public string lblFirstNameVal
        {
            get { return lblfirstNameVal; }
            set
            {
                lblfirstNameVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstNameVal");
            }
        }
        //lblfirstName1 purpose of using Label
        private string lblfirstName1 = "";
        public string lblFirstName1
        {
            get { return lblfirstName1; }
            set
            {
                lblfirstName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstName1");
            }
        }
        //lblfirstNameVal1 purpose of using Label
        private string lblfirstNameVal1 = "";
        public string lblFirstNameVal1
        {
            get { return lblfirstNameVal1; }
            set
            {
                lblfirstNameVal1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstNameVal1");
            }
        }
        //lbllastName purpose of using Label
        private string lbllastName = "";
        public string lblLastName
        {
            get { return lbllastName; }
            set
            {
                lbllastName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastName");
            }
        }
        //lbllastNameVal purpose of using Label
        private string lbllastNameVal = "";
        public string lblLastNameVal
        {
            get { return lbllastNameVal; }
            set
            {
                lbllastNameVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastNameVal");
            }
        }
        //lbllastName1 purpose of using Label
        private string lbllastName1 = "";
        public string lblLastName1
        {
            get { return lbllastName1; }
            set
            {
                lbllastName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastName1");
            }
        }
        //lbllastNameVal1 purpose of using Label
        private string lbllastNameVal1 = "";
        public string lblLastNameVal1
        {
            get { return lbllastNameVal1; }
            set
            {
                lbllastNameVal1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastNameVal1");
            }
        }
        //lblcountry2 purpose of using Label
        private string lblcountry2 = "";
        public string lblCountry2
        {
            get { return lblcountry2; }
            set
            {
                lblcountry2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountry2");
            }
        }
        //lblcountryMobCode purpose of using Label
        private string lblcountryMobCode = "";
        public string lblCountryMobCode
        {
            get { return lblcountryMobCode; }
            set
            {
                lblcountryMobCode = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountryMobCode");
            }
        }
        //lblmobileNumber purpose of using Label
        private string lblmobileNumber = "";
        public string lblMobileNumber
        {
            get { return lblmobileNumber; }
            set
            {
                lblmobileNumber = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumber");
            }
        }
        //lblmobileNumberVal purpose of using Label
        private string lblmobileNumberVal = "";
        public string lblMobileNumberVal
        {
            get { return lblmobileNumberVal; }
            set
            {
                lblmobileNumberVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMobileNumberVal");
            }
        }
        //lblemailAdress purpose of using Label
        private string lblemailAdress = "";
        public string lblEmailAdress
        {
            get { return lblemailAdress; }
            set
            {
                lblemailAdress = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmailAdress");
            }
        }
        //lblemailAdressVal purpose of using Label
        private string lblemailAdressVal = "";
        public string lblEmailAdressVal
        {
            get { return lblemailAdressVal; }
            set
            {
                lblemailAdressVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEmailAdressVal");
            }
        }
        //lblprefComm purpose of using Label
        private string lblprefComm = "";
        public string lblPrefComm
        {
            get { return lblprefComm; }
            set
            {
                lblprefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPrefComm");
            }
        }
        //lblprefCommsVal purpose of using Label
        private string lblprefCommsVal = "";
        public string lblPrefCommsVal
        {
            get { return lblprefCommsVal; }
            set
            {
                lblprefCommsVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPrefCommsVal");
            }
        }
        //lbljobTitle purpose of using Label
        private string lbljobTitle = "";
        public string lblJobTitle
        {
            get { return lbljobTitle; }
            set
            {
                lbljobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobTitle");
            }
        }
        //lbljobTitleVal purpose of using Label
        private string lbljobTitleVal = "";
        public string lblJobTitleVal
        {
            get { return lbljobTitleVal; }
            set
            {
                lbljobTitleVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobTitleVal");
            }
        }
        //lbljobFunction purpose of using Label
        private string lbljobFunction = "";
        public string lblJobFunction
        {
            get { return lbljobFunction; }
            set
            {
                lbljobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobFunction");
            }
        }
        //lbljobFunctionVal purpose of using Label
        private string lbljobFunctionVal = "";
        public string lblJobFunctionVal
        {
            get { return lbljobFunctionVal; }
            set
            {
                lbljobFunctionVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblJobFunctionVal");
            }
        }
        //lblpassword purpose of using Label
        private string lblpassword = "";
        public string lblPassword
        {
            get { return lblpassword; }
            set
            {
                lblpassword = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPassword");
            }
        }
        //txtPasswordVal purpose of using Label
        private string txtPasswordVal = "";
        public string TxtPasswordVal
        {
            get { return txtPasswordVal; }
            set
            {
                txtPasswordVal = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtPasswordVal");
            }
        }
        //lblcompanyInformationP5 purpose of using Label
        private string lblcompanyInformationP5 = "";
        public string lblCompanyInformationP5
        {
            get { return lblcompanyInformationP5; }
            set
            {
                lblcompanyInformationP5 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyInformationP5");
            }
        }
        //lblcompanyType purpose of using Label
        private string lblcompanyType = "";
        public string lblCompanyType
        {
            get { return lblcompanyType; }
            set
            {
                lblcompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyType");
            }
        }
        //lblcompanyTypeVal purpose of using Label
        private string lblcompanyTypeVal = "";
        public string lblCompanyTypeVal
        {
            get { return lblcompanyTypeVal; }
            set
            {
                lblcompanyTypeVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyTypeVal");
            }
        }
        //lblcompanyName purpose of using Label
        private string lblcompanyName = "";
        public string lblCompanyName
        {
            get { return lblcompanyName; }
            set
            {
                lblcompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyName");
            }
        }
        //lblcompanyNameVal purpose of using Label
        private string lblcompanyNameVal = "";
        public string lblCompanyNameVal
        {
            get { return lblcompanyNameVal; }
            set
            {
                lblcompanyNameVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCompanyNameVal");
            }
        }
        //lblnationalAdress purpose of using Label
        private string lblnationalAdress = "";
        public string lblNationalAdress
        {
            get { return lblnationalAdress; }
            set
            {
                lblnationalAdress = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNationalAdress");
            }
        }
        //lblcountry purpose of using Label
        private string lblcountry = "";
        public string lblCountry
        {
            get { return lblcountry; }
            set
            {
                lblcountry = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountry");
            }
        }
        //lblcountryVal purpose of using Label
        private string lblcountryVal = "";
        public string lblCountryVal
        {
            get { return lblcountryVal; }
            set
            {
                lblcountryVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountryVal");
            }
        }
        //lblbuildingNo purpose of using Label
        private string lblbuildingNo = "";
        public string lblBuildingNo
        {
            get { return lblbuildingNo; }
            set
            {
                lblbuildingNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBuildingNo");
            }
        }
        //lblbuildingNoVal purpose of using Label
        private string lblbuildingNoVal = "";
        public string lblBuildingNoVal
        {
            get { return lblbuildingNoVal; }
            set
            {
                lblbuildingNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblBuildingNoVal");
            }
        }
        //lblunitNo purpose of using Label
        private string lblunitNo = "";
        public string lblUnitNo
        {
            get { return lblunitNo; }
            set
            {
                lblunitNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblUnitNo");
            }
        }
        //lblunitNoVal purpose of using Label
        private string lblunitNoVal = "";
        public string lblUnitNoVal
        {
            get { return lblunitNoVal; }
            set
            {
                lblunitNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblUnitNoVal");
            }
        }
        //lblstreetName purpose of using Label
        private string lblstreetName = "";
        public string lblStreetName
        {
            get { return lblstreetName; }
            set
            {
                lblstreetName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStreetName");
            }
        }
        //lblstreetNameVal purpose of using Label
        private string lblstreetNameVal = "";
        public string lblStreetNameVal
        {
            get { return lblstreetNameVal; }
            set
            {
                lblstreetNameVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblStreetNameVal");
            }
        }
        //lbldistrictName purpose of using Label
        private string lbldistrictName = "";
        public string lblDistrictName
        {
            get { return lbldistrictName; }
            set
            {
                lbldistrictName = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDistrictName");
            }
        }
        //lbldistrictNameVal purpose of using Label
        private string lbldistrictNameVal = "";
        public string lblDistrictNameVal
        {
            get { return lbldistrictNameVal; }
            set
            {
                lbldistrictNameVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDistrictNameVal");
            }
        }
        //lblcity purpose of using Label
        private string lblcity = "";
        public string lblCity
        {
            get { return lblcity; }
            set
            {
                lblcity = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCity");
            }
        }
        //lblcityVal purpose of using Label
        private string lblcityVal = "";
        public string lblCityVal
        {
            get { return lblcityVal; }
            set
            {
                lblcityVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCityVal");
            }
        }
        //lblpostCode purpose of using Label
        private string lblpostCode = "";
        public string lblPostCode
        {
            get { return lblpostCode; }
            set
            {
                lblpostCode = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPostCode");
            }
        }
        //lblpostCodeVal purpose of using Label
        private string lblpostCodeVal = "";
        public string lblPostCodeVal
        {
            get { return lblpostCodeVal; }
            set
            {
                lblpostCodeVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPostCodeVal");
            }
        }
        //lbladditionalNo purpose of using Label
        private string lbladditionalNo = "";
        public string lblAdditionalNo
        {
            get { return lbladditionalNo; }
            set
            {
                lbladditionalNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalNo");
            }
        }
        //lbladditionalNoVal purpose of using Label
        private string lbladditionalNoVal = "";
        public string lblAdditionalNoVal
        {
            get { return lbladditionalNoVal; }
            set
            {
                lbladditionalNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalNoVal");
            }
        }
        //lbltelephone purpose of using Label
        private string lbltelephone = "";
        public string lblTelephone
        {
            get { return lbltelephone; }
            set
            {
                lbltelephone = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTelephone");
            }
        }
        //lbltelephoneVal purpose of using Label
        private string lbltelephoneVal = "";
        public string lblTelephoneVal
        {
            get { return lbltelephoneVal; }
            set
            {
                lbltelephoneVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTelephoneVal");
            }
        }
        //lblfax purpose of using Label
        private string lblfax = "";
        public string lblFax
        {
            get { return lblfax; }
            set
            {
                lblfax = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFax");
            }
        }
        //lblfaxVal purpose of using Label
        private string lblfaxVal = "";
        public string lblFaxVal
        {
            get { return lblfaxVal; }
            set
            {
                lblfaxVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFaxVal");
            }
        }
        //lbladdditionalInformation2 purpose of using Label
        private string lbladdditionalInformation2 = "";
        public string lblAddditionalInformation2
        {
            get { return lbladdditionalInformation2; }
            set
            {
                lbladdditionalInformation2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAddditionalInformation2");
            }
        }
        //lblcustomerType purpose of using Label
        private string lblcustomerType = "";
        public string lblCustomerType
        {
            get { return lblcustomerType; }
            set
            {
                lblcustomerType = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerType");
            }
        }
        //lblcustomerTypeVal purpose of using Label
        private string lblcustomerTypeVal = "";
        public string lblCustomerTypeVal
        {
            get { return lblcustomerTypeVal; }
            set
            {
                lblcustomerTypeVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerTypeVal");
            }
        }
        //lblidNo purpose of using Label
        private string lblidNo = "";
        public string lblIdNo
        {
            get { return lblidNo; }
            set
            {
                lblidNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblIdNo");
            }
        }
        //lblidNoVal purpose of using Label
        private string lblidNoVal = "";
        public string lblIdNoVal
        {
            get { return lblidNoVal; }
            set
            {
                lblidNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblIdNoVal");
            }
        }
        //lbllicenseNo purpose of using Label
        private string lbllicenseNo = "";
        public string lblLicenseNo
        {
            get { return lbllicenseNo; }
            set
            {
                lbllicenseNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNo");
            }
        }
        //lbllicenseNoVal purpose of using Label
        private string lbllicenseNoVal = "";
        public string lblLicenseNoVal
        {
            get { return lbllicenseNoVal; }
            set
            {
                lbllicenseNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal");
            }
        }
        //lbllicenseNoVal2 purpose of using Label
        private string lbllicenseNoVal2 = "";
        public string lblLicenseNoVal2
        {
            get { return lbllicenseNoVal2; }
            set
            {
                lbllicenseNoVal2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal2");
            }
        }
        //lbllicenseNoVal3 purpose of using Label
        private string lbllicenseNoVal3 = "";
        public string lblLicenseNoVal3
        {
            get { return lbllicenseNoVal3; }
            set
            {
                lbllicenseNoVal3 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal3");
            }
        }
        //lbllicenseNoVal4 purpose of using Label
        private string lbllicenseNoVal4 = "";
        public string lblLicenseNoVal4
        {
            get { return lbllicenseNoVal4; }
            set
            {
                lbllicenseNoVal4 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal4");
            }
        }
        //lbllicenseNoVal5 purpose of using Label
        private string lbllicenseNoVal5 = "";
        public string lblLicenseNoVal5
        {
            get { return lbllicenseNoVal5; }
            set
            {
                lbllicenseNoVal5 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal5");
            }
        }
        //lbllicenseNoVal6 purpose of using Label
        private string lbllicenseNoVal6 = "";
        public string lblLicenseNoVal6
        {
            get { return lbllicenseNoVal6; }
            set
            {
                lbllicenseNoVal6 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal6");
            }
        }
        //lbllicenseNoVal7 purpose of using Label
        private string lbllicenseNoVal7 = "";
        public string lblLicenseNoVal7
        {
            get { return lbllicenseNoVal7; }
            set
            {
                lbllicenseNoVal7 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal7");
            }
        }
        //lbllicenseNoVal8 purpose of using Label
        private string lbllicenseNoVal8 = "";
        public string lblLicenseNoVal8
        {
            get { return lbllicenseNoVal8; }
            set
            {
                lbllicenseNoVal8 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal8");
            }
        }
        //lbllicenseNoVal9 purpose of using Label
        private string lbllicenseNoVal9 = "";
        public string lblLicenseNoVal9
        {
            get { return lbllicenseNoVal9; }
            set
            {
                lbllicenseNoVal9 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal9");
            }
        }
        //lbllicenseNoVal10 purpose of using Label
        private string lbllicenseNoVal10 = "";
        public string lblLicenseNoVal10
        {
            get { return lbllicenseNoVal10; }
            set
            {
                lbllicenseNoVal10 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLicenseNoVal10");
            }
        }
        //lblpasswordVal purpose of using Label
        private string lblpasswordVal = "";
        public string lblPasswordVal
        {
            get { return lblpasswordVal; }
            set
            {
                lblpasswordVal = value;
                OnPropertyChanged();
                RaisePropertyChange("lblPasswordVal");
            }
        }
        //txtDummy purpose of using textbox variable
        private string txtDummy = "";
        public string TxtDummy
        {
            get { return txtDummy; }
            set
            {
                txtDummy = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDummy");
            }
        }
        //btnmodifyInformation purpose of using Button
        private string btnmodifyInformation = "";
        public string btnModifyInformation
        {
            get { return btnmodifyInformation; }
            set
            {
                btnmodifyInformation = value;
                OnPropertyChanged();
                RaisePropertyChange("btnModifyInformation");
            }
        }
        //btnsentOTP purpose of using Button
        private string btnsentOTP = "";
        public string btnSentOTP
        {
            get { return btnsentOTP; }
            set
            {
                btnsentOTP = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSentOTP");
            }
        }
        //btnalreadyLogIn purpose of using Button
        private string btnalreadyLogIn = "";
        public string btnAlreadyLogIn
        {
            get { return btnalreadyLogIn; }
            set
            {
                btnalreadyLogIn = value;
                OnPropertyChanged();
                RaisePropertyChange("btnAlreadyLogIn");
            }
        }
        //licenseNoVal purpose of using Button
        private bool licenseNoVal = false;
        public bool LicenseNoVal
        {
            get { return licenseNoVal; }
            set
            {
                licenseNoVal = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal");
            }
        }
        //licenseNoVal2 purpose of using Button
        private bool licenseNoVal2 = false;
        public bool LicenseNoVal2
        {
            get { return licenseNoVal2; }
            set
            {
                licenseNoVal2 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal2");
            }
        }
        private string strServerSlowMsg = "";
        //licenseNoVal3 purpose of using Button
        private bool licenseNoVal3 = false;
        public bool LicenseNoVal3
        {
            get { return licenseNoVal3; }
            set
            {
                licenseNoVal3 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal3");
            }
        }
        //licenseNoVal4 purpose of using Button
        private bool licenseNoVal4 = false;
        public bool LicenseNoVal4
        {
            get { return licenseNoVal4; }
            set
            {
                licenseNoVal4 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal4");
            }
        }
        //licenseNoVal5 purpose of using Button
        private bool licenseNoVal5 = false;
        public bool LicenseNoVal5
        {
            get { return licenseNoVal5; }
            set
            {
                licenseNoVal5 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal5");
            }
        }
        //licenseNoVal6 purpose of using Button
        private bool licenseNoVal6 = false;
        public bool LicenseNoVal6
        {
            get { return licenseNoVal6; }
            set
            {
                licenseNoVal6 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal6");
            }
        }
        //licenseNoVal7 purpose of using Button
        private bool licenseNoVal7 = false;
        public bool LicenseNoVal7
        {
            get { return licenseNoVal7; }
            set
            {
                licenseNoVal7 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal7");
            }
        }
        //licenseNoVal8 purpose of using Button
        private bool licenseNoVal8 = false;
        public bool LicenseNoVal8
        {
            get { return licenseNoVal8; }
            set
            {
                licenseNoVal8 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal8");
            }
        }
        //licenseNoVal9 purpose of using Button
        private bool licenseNoVal9 = false;
        public bool LicenseNoVal9
        {
            get { return licenseNoVal9; }
            set
            {
                licenseNoVal9 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal9");
            }
        }
        //licenseNoVal10 purpose of using Button
        private bool licenseNoVal10 = false;
        public bool LicenseNoVal10
        {
            get { return licenseNoVal10; }
            set
            {
                licenseNoVal10 = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenseNoVal10");
            }
        }
        //PageReg-6
        //imgregisterIconP6 purpose of using Image
        private string imgregisterIconP6 = "";
        public string imgRegisterIconP6
        {
            get { return imgregisterIconP6; }
            set
            {
                imgregisterIconP6 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRegisterIconP6");
            }
        }
        //lblcustomerRegistrationP6 purpose of using Label
        private string lblcustomerRegistrationP6 = "";
        public string lblCustomerRegistrationP6
        {
            get { return lblcustomerRegistrationP6; }
            set
            {
                lblcustomerRegistrationP6 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCustomerRegistrationP6");
            }
        }
        //lblenterTheOtp purpose of using Label
        private string lblenterTheOtp = "";
        public string lblEnterTheOtp
        {
            get { return lblenterTheOtp; }
            set
            {
                lblenterTheOtp = value;
                OnPropertyChanged();
                RaisePropertyChange("lblEnterTheOtp");
            }
        }
        //txtOtp purpose of using textbox variable
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
        //btnconfirm purpose of using Button
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


        private bool _IsvalidatedMobileLength = false;
        public bool IsvalidatedMobileLength
        {
            get { return _IsvalidatedMobileLength; }
            set
            {
                _IsvalidatedMobileLength = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMobileLength");
            }
        }
        private string _MsgMobileLength = "";
        public string MsgMobileLength
        {
            get { return _MsgMobileLength; }
            set
            {
                _MsgMobileLength = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileLength");
            }
        }
        //btncancel purpose of using Button
        private string btncancel = "";
        public string btnCancel
        {
            get { return btncancel; }
            set
            {
                btncancel = value;
                OnPropertyChanged();
                RaisePropertyChange("btnCancel");
            }
        }
        //placeOtp purpose of using Placeholder 
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
        private string _MsgValidOTP = "";
        public string MsgValidOTP
        {
            get { return _MsgValidOTP; }
            set
            {
                _MsgValidOTP = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgValidOTP");
            }
        }

        //PageReg-7
        //imgregisterIconP7 purpose of using Label
        private string imgregisterIconP7 = "";
        public string imgRegisterIconP7
        {
            get { return imgregisterIconP7; }
            set
            {
                imgregisterIconP7 = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRegisterIconP7");
            }
        }
        //lbldearCustomer purpose of using Label
        private string lbldearCustomer = "";
        public string lblDearCustomer
        {
            get { return lbldearCustomer; }
            set
            {
                lbldearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDearCustomer");
            }
        }
        //lblmessage purpose of using Label
        private string lblmessage = "";
        public string lblMessage
        {
            get { return lblmessage; }
            set
            {
                lblmessage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessage");
            }
        }
        private string msgJobTitle = "";
        public string MsgJobTitle
        {
            get { return msgJobTitle; }
            set
            {
                msgJobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgJobTitle");
            }
        }
        private string msgJobfunction = "";
        public string MsgJobFunction
        {
            get { return msgJobfunction; }
            set
            {
                msgJobfunction = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgJobFunction");
            }
        }
        private bool isvalidatedJobFunction = false;
        public bool IsvalidatedJobFunction
        {
            get { return isvalidatedJobFunction; }
            set
            {
                isvalidatedJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedJobFunction");
            }
        }

        private bool isvalidatedJobTitle = false;
        public bool IsvalidatedJobTitle
        {
            get { return isvalidatedJobTitle; }
            set
            {
                isvalidatedJobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedJobTitle");
            }
        }

        //btnlogIn purpose of using Button
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
        //ChkmandatoryTerms purpose of using Error Page
        private bool ChkmandatoryTerms = false;
        public bool ChkMandatoryterms
        {
            get { return ChkmandatoryTerms; }
            set
            {
                ChkmandatoryTerms = value;
                OnPropertyChanged();
                RaisePropertyChange("ChkMandatoryterms");
            }
        }
        //ValidateemailAdd purpose of using Validation
        private bool ValidateemailAdd = false;
        public bool ValidateEmailadd
        {
            get { return ValidateemailAdd; }
            set
            {
                ValidateemailAdd = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateEmailadd");
            }
        }
        //To handle boolean
        private bool stackPageRegistration = true;

        public bool StackPageRegistration
        {
            get { return stackPageRegistration; }
            set
            {
                stackPageRegistration = value;
                OnPropertyChanged();
                RaisePropertyChange("StackPageRegistration");
            }
        }
        private bool isvalidatedCompanyName = false;

        public bool IsvalidatedCompanyName
        {
            get { return isvalidatedCompanyName; }
            set
            {
                isvalidatedCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCompanyName");
            }
        }
        private string msgCompanyName = "";

        public string MsgCompanyname
        {
            get { return msgCompanyName; }
            set
            {
                msgCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyname");
            }
        }
        ContentPage Myview;
        //To handle Boolen
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoNextPageFrom1.ChangeCanExecute();
                gotoPreviousPageFrom2.ChangeCanExecute();
                gotoNextPageFrom2.ChangeCanExecute();
                gotoPreviousPageFrom3.ChangeCanExecute();
                gotoNextPageFrom3.ChangeCanExecute();
                //gotoPreviousPageFrom4.ChangeCanExecute();
                //gotoNextPageFrom4.ChangeCanExecute();
                GotoModify.ChangeCanExecute();
                gotoOTP.ChangeCanExecute();
                gotoLogIn.ChangeCanExecute();
                gotoPageRegistration7.ChangeCanExecute();
                gotoList.ChangeCanExecute();
                gotoREG.ChangeCanExecute();
                TC_tapped.ChangeCanExecute();
                gotoPageFrom4.ChangeCanExecute();
            }
        }
        //To handle Page Registration View Model
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public PageRegistrationViewModel(ContentPage view)
        {
            Myview = view;
            //Appcenter Track Event handler
            Analytics.TrackEvent("PageRegistrationViewModel");
            Task.Run(() => assignCms()).GetAwaiter().GetResult();
            lstreguser = new List<clsREGISTEREDUSERS>();
            gotoNextPageFrom1 = new Command(async () => await gotonextpagefrom1(), () => !IsBusy);
            gotoPreviousPageFrom2 = new Command(async () => await gotopreviouspagefrom2(), () => !IsBusy);
            gotoNextPageFrom2 = new Command(async () => await gotonextpagefrom2(), () => !IsBusy);
            gotoPreviousPageFrom3 = new Command(async () => await gotopreviouspagefrom3(), () => !IsBusy);
            gotoNextPageFrom3 = new Command(async () => await gotonextpagefrom3(), () => !IsBusy);
            //gotoPreviousPageFrom4 = new Command(async () => await gotopreviouspagefrom4(), () => !IsBusy);
            //// gotoNextPageFrom4 = new Command(async () => await gotonextpagefrom4(), () => !IsBusy);
            GotoModify = new Command(async () => await gotomodify(), () => !IsBusy);
            gotoOTP = new Command(async () => await gotootp(), () => !IsBusy);
            gotoLogIn = new Command(async () => await goto_login(), () => !IsBusy);
            gotoPageRegistration7 = new Command(async () => await gotopageregistration7(), () => !IsBusy);
            gotoList = new Command(async () => await gotolist(), () => !IsBusy);
            gotoREG = new Command(async () => await gotoreg(), () => !IsBusy);
            TC_tapped = new Command(async () => await GoToTC(), () => !IsBusy);
            gotoPageFrom4 = new Command(async () => await GotoPageFrom4(), () => !IsBusy);

        }
        //To bind CMS captions
        /// <summary>
		/// To bind CMS captions
		/// </summary>
        public async Task assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM003");
                    objCMSMSG = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {

                    //20230411
                    if (AppSettings.objRegCms.Count == 0)
                    {
                        objCMS = dbLayer.LoadContent("RM003").GetAwaiter().GetResult();
                    }
                    if (AppSettings.objRegCms.Count > 0)
                    {
                        objCMS = AppSettings.objRegCms;
                    }
                    objCMSMSG = dbLayer.LoadContent("RM026").GetAwaiter().GetResult();
                }
                await Task.Delay(1000);
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              


                await Task.Delay(1000);
                assignCaptions().GetAwaiter().GetResult();
                await Task.Delay(1000);
                int lintDummy = HideStack(1);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Hide & Show the Screens
        /// </summary>
        public  int HideStack(int lintCurrentPageNo)
        {
            switch (lintCurrentPageNo)
            {
                case 1:
                    Page2 = Page3 = Page5 = page6 = Page7 = PageFooter_2 = PageFooter_3 = PageFooter_5 = false;
                    Page1 = true;
                    PageHeader = true;
                    PageFooter = true;
                    PageFooter_1 = true;
                    Stepactive1 = "#0073a2";
                    Stepactive2 = "#FFFFFF";
                    Stepactive3 = "#FFFFFF";
                    StepText1 = "#FFFFFF";
                    StepText2 = "#0073a2";
                    StepText3 = "#0073a2";
                    return 1;
                case 2:
                    Page1 = Page3 = Page5 = Page6 = Page7 = PageFooter_1 = PageFooter_3 = PageFooter_5 = false;
                    Page2 = true;
                    PageHeader = true;
                    PageFooter_2 = true;
                    PageFooter = true;
                    Stepactive1 = "#FFFFFF";
                    Stepactive2 = "#0073a2";
                    Stepactive3 = "#FFFFFF";
                    StepText1 = "#0073a2";
                    StepText2 = "#FFFFFF";
                    StepText3 = "#0073a2";
                    Entry JobTitle = Myview.FindByName<Entry>("EntryJobTitle");
                    JobTitle.Focus();
                    return 1;
                case 3:
                    Page1 = Page2 = Page5 = Page6 = Page7 = PageFooter_1 = PageFooter_2 = PageFooter_5 = false;
                    Page3 = true;
                    pageHeader = true;
                    PageFooter_3 = true;
                    PageFooter = true;
                    Stepactive1 = "#FFFFFF";
                    Stepactive2 = "#FFFFFF";
                    Stepactive3 = "#0073a2";
                    StepText1 = "#0073a2";
                    StepText2 = "#0073a2";
                    StepText3 = "#FFFFFF";
                    return 1;
                //case 4:
                //    Page1 = Page2 = Page3 = Page5 = Page6 = Page7 = PageFooter_1 = PageFooter_2 = PageFooter_3 = PageFooter_5 = false;
                //    Page4 = true;
                //    pageHeader = true;
                //    PageFooter_4 = true;
                //    PageFooter = true;
                //   // assignPage4Captions();
                //    Stepactive1 = "#FFFFFF";
                //    Stepactive2 = "#FFFFFF";
                //    Stepactive3 = "#FFFFFF";
                //    Stepactive4 = "#0073a2";
                //    StepText1 = "#0073a2";
                //    StepText2 = "#0073a2";
                //    StepText3 = "#0073a2";
                //    StepText4 = "#FFFFFF";
                //    Entry ImpExpLicNo = Myview.FindByName<Entry>("FocusImpExpLicNo");
                //    ImpExpLicNo.Focus();
                //    return 1;
                case 4:
                    PageHeader = Page1 = Page2 = Page3 = Page4 = Page6 = Page7 = PageFooter_1 = false;
                    PageFooter_2 = PageFooter_3 = PageFooter_4 = false;
                    Page5 = true;
                    PageFooter_5 = true;
                     assignPage5thData();
                    return 1;
                case 5:
                    Page1 = PageHeader = Page2 = Page3 = Page5 = Page7 = false;
                    PageFooter_1 = PageFooter_2 = PageFooter_3 = PageFooter_5 = false;
                    Page6 = true;
                    return 1;
                case 6:
                    Page1 = PageHeader = Page2 = Page3 = Page5 = Page6 = false;
                    PageFooter_1 = PageFooter_2 = PageFooter_3 = PageFooter_5 = false;
                    Page7 = true;
                    return 1;
            }
            return 1;
        }
        /// <summary>
        /// To get Page5th Data
        /// </summary>
        private void assignPage5thData()
        {
            try
            {
                if (TxtFirstName != null)
                {
                    gblRegisteration.strFirstName = TxtFirstName;
                    lblFirstNameVal = TxtFirstName;
                }
                if (TxtLastName != null)
                {
                    gblRegisteration.strLastName = TxtLastName;
                    lblLastNameVal = gblRegisteration.strLastName;
                }
                if (TxtFirstName1 != null)
                {
                    gblRegisteration.strFirstName1 = TxtFirstName1;
                    lblFirstNameVal1 = gblRegisteration.strFirstName1;
                }
                if (TxtLastName2 != null)
                {
                    gblRegisteration.strLastName1 = TxtLastName2;
                    lblLastNameVal1 = gblRegisteration.strLastName1;
                }
                if (TxtMobileNumber != null)
                {
                    gblRegisteration.strMobileNO = TxtMobileNumber;
                    lblMobileNumberVal = gblRegisteration.strMobileNO;
                }
                if (TxtEmailAddress != null)
                {
                    gblRegisteration.strEmailAddress = TxtEmailAddress;
                    lblEmailAdressVal = gblRegisteration.strEmailAddress;
                }
                if (TxtJobTitle != null)
                {
                    gblRegisteration.strJobTitle = TxtJobTitle;

                    lblJobTitleVal = gblRegisteration.strJobTitle;
                }
                if (TxtPassword != null)
                {
                    gblRegisteration.strPassWord = TxtPassword;
                    gblRegisteration.strConfirmPassword = TxtPassword;
                    lblPasswordVal = gblRegisteration.strPassWord;
                }
                if (TxtCompanyName != null)
                {
                    gblRegisteration.strCompanyName = TxtCompanyName;
                    lblCompanyNameVal = gblRegisteration.strCompanyName;
                }
                if (TxtBuildingNo != null)
                {
                    gblRegisteration.strBulidingNo = TxtBuildingNo;
                    lblBuildingNoVal = gblRegisteration.strBulidingNo;
                }
                if (TxtUnitNo != null)
                {
                    gblRegisteration.strUnitNo = TxtUnitNo;
                    lblUnitNoVal = gblRegisteration.strUnitNo;
                }
                if (TxtStreetName != null)
                {
                    gblRegisteration.strStreetName = TxtStreetName;
                    lblStreetNameVal = gblRegisteration.strStreetName;
                }
                if (TxtDistrict != null)
                {
                    gblRegisteration.strdistrictName1 = TxtDistrict;
                    lblDistrictNameVal = gblRegisteration.strdistrictName1;
                }
                if (gblRegisteration.strImpExpLisNo != null)
                {
                    lblLicenseNoVal = gblRegisteration.strImpExpLisNo;
                }
                if (TxtZipCode != null)
                {
                    gblRegisteration.strZipCode = TxtZipCode;
                    lblPostCodeVal = gblRegisteration.strZipCode;
                }
                if (TxtAdditionalNo != null)
                {
                    gblRegisteration.strAdditionalNo = TxtAdditionalNo;
                    lblAdditionalNoVal = gblRegisteration.strAdditionalNo;
                }
                if (TxtTelephone != null)
                {
                    gblRegisteration.strTelePhoneNo = TxtTelephone;
                    lblTelephoneVal = gblRegisteration.strTelePhoneNo;
                }
                if (TxtFax != null)
                {
                    gblRegisteration.strFax = TxtFax;
                    lblFaxVal = gblRegisteration.strFax;
                }
                if (TxtIDNo != null)
                {
                    gblRegisteration.strIdNo = TxtIDNo;
                    lblIdNoVal = gblRegisteration.strIdNo;
                }
                if (SelectedCountryMobCode != null)
                {
                    gblRegisteration.strCountryCode = _selectedCountryMobCode.Value;
                    lblCountryMobCode = SelectedCountryMobCode.Key.ToString().Trim();
                }
                if (SelectedPrefComm != null)
                {
                    gblRegisteration.strPreCommun = _selectedPrefComm.Value;
                    lblPrefCommsVal = SelectedPrefComm.Key.ToString().Trim();
                }
                if (SelectedJobFunction != null)
                {
                    gblRegisteration.strJobFunction = _selectedJobFunction.Value;
                    lblJobFunctionVal = SelectedJobFunction.Key.ToString().Trim();
                }
                if (SelectedCompanyType != null)
                {
                    gblRegisteration.strCompanyType = _selectedCompanyType.Value;
                    lblCompanyTypeVal = SelectedCompanyType.Key.ToString().Trim();
                }
                if (SelectedCity != null)
                {
                    gblRegisteration.strCityName = _selectedCity.Value;
                    lblCityVal = SelectedCity.Key.ToString().Trim();
                }
                if (SelectedCustomerType != null)
                {
                    gblRegisteration.strCusType = _selectedCustomerType.Value;
                    lblCustomerTypeVal = SelectedCustomerType.Key.ToString().Trim();
                }
                if (SelectedCountry != null)
                {
                    gblRegisteration.strCountry = _selectedCountry.Value;
                    lblCountryVal = SelectedCountry.Key.ToString().Trim();
                }
                if (TxtImpExpLicNo != null)
                {
                    gblRegisteration.strImpExpLisNo = TxtImpExpLicNo;
                    lblLicenseNoVal = gblRegisteration.strImpExpLisNo;
                }
                if (TxtlicenceNo2 != null)
                {
                    gblRegisteration.strAdditionalNO2 = TxtlicenceNo2;
                    lblLicenseNoVal2 = gblRegisteration.strAdditionalNO2;
                }
                if (TxtlicenceNo3 != null)
                {
                    gblRegisteration.strAdditionalNO3 = TxtlicenceNo3;
                    lblLicenseNoVal3 = gblRegisteration.strAdditionalNO3;
                }
                if (TxtlicenceNo4 != null)
                {
                    gblRegisteration.strAdditionalNO4 = TxtlicenceNo4;
                    lblLicenseNoVal4 = gblRegisteration.strAdditionalNO4;
                }
                if (TxtlicenceNo5 != null)
                {
                    gblRegisteration.strAdditionalNO5 = TxtlicenceNo5;
                    lblLicenseNoVal5 = gblRegisteration.strAdditionalNO5;
                }
                if (TxtlicenceNo6 != null)
                {
                    gblRegisteration.strAdditionalNO6 = TxtlicenceNo6;
                    lblLicenseNoVal6 = gblRegisteration.strAdditionalNO6;
                }
                if (TxtlicenceNo7 != null)
                {
                    gblRegisteration.strAdditionalNO7 = TxtlicenceNo7;
                    lblLicenseNoVal7 = gblRegisteration.strAdditionalNO7;
                }
                if (TxtlicenceNo8 != null)
                {
                    gblRegisteration.strAdditionalNO8 = TxtlicenceNo8;
                    lblLicenseNoVal8 = gblRegisteration.strAdditionalNO8;
                }
                if (TxtlicenceNo9 != null)
                {
                    gblRegisteration.strAdditionalNO9 = TxtlicenceNo9;
                    lblLicenseNoVal9 = gblRegisteration.strAdditionalNO9;
                }
                if (txtlicenceNo10 != null)
                {
                    gblRegisteration.strAdditionalNO10 = txtlicenceNo10;
                    lblLicenseNoVal10 = gblRegisteration.strAdditionalNO10;
                }
            }
            catch (Exception ex)
            {
                 App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To Assign Captions for Page1
        /// <summary>
        /// To get Page1st Data
        /// </summary>
        public async Task assignCaptions()
        {

            try
            {

                objCMS = dbLayer.LoadContent("RM003").GetAwaiter().GetResult();
                #region First Page Caption

                await Task.Delay(1000);
                lobjCustomerType = dbLayer.getEnum("strCustomerTypeLOV", objCMS);
                lobjCompanyType = dbLayer.getEnum("strCompanyTypeLOV", objCMS);
                lblCompanyInformation = dbLayer.getCaption("strCompanyInformation", objCMS);
                lblNationalAddress = dbLayer.getCaption("strNationalAddress", objCMS);
                lblCompanyName1 = dbLayer.getCaption("strCompanyName", objCMS);
                imgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
                lblCustomerType1 = dbLayer.getCaption("strCustomerType", objCMS);
                lblNationalIDNo1 = dbLayer.getCaption("strIDNo", objCMS);
                lblLicenseNo1 = dbLayer.getCaption("strImportExportLicenseNo", objCMS);
                lblCustomerRegistration = dbLayer.getCaption("strCustomerRegistration", objCMS);
                lblCompanyInformation2 = dbLayer.getCaption("strCompanyInformation", objCMS);
                PlaceCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
                lblCompanyType1 = dbLayer.getCaption("strCompanyType", objCMS);
                lblAdditionalInformation = dbLayer.getCaption("strAdditionalInformation", objCMS);
                lblAdditionalInfo2 = dbLayer.getCaption("strAdditionalInformation", objCMS);
                PlaceImpExpLicNo = dbLayer.getCaption("strImportExportLicenseNo", objCMS);
                PlaceIDNo = dbLayer.getCaption("strIDNo", objCMS);
                lblTermsAndConditions = dbLayer.getCaption("strReadandAgreeMsg", objCMS);
                lblTc = dbLayer.getCaption("strTerms", objCMS);
                lblTermsAndConditions = dbLayer.getCaption("strRSGTTerms1", objCMS);


                PlacelicenceNo2 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo3 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo4 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo5 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo6 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo7 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo8 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo9 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                PlacelicenceNo10 = dbLayer.getCaption("strAdditionalNumber", objCMS);
                MsgCompanyname = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompanyType = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgIDNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompanyName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCheckMandatoryGenP2 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCustomerType = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompanyType = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgLicNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgUniqIdNo = dbLayer.getCaption("strAlreadyexists", objCMSMSG);
                MsgMandatoryTerms = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompanyType = dbLayer.getCaption("strMandatory", objCMSMSG);

                btnOk = dbLayer.getCaption("strok", objCMS);
                btnNextP2 = dbLayer.getCaption("strNEXT", objCMS);
                btnPreviousP2 = dbLayer.getCaption("strPrevious", objCMS);
                btnAlreadyLogIn = dbLayer.getCaption("strAlreadyhaveaccountLogIn", objCMS);

                #endregion

                #region Second Page Caption
                await Task.Delay(1000);
                lobjPrefer = dbLayer.getEnum("strPrefCommLov", objCMS);
                lobJobFunction = dbLayer.getEnum("strJobFunctionLOV", objCMS);
                lobjContryMobCode = dbLayer.getEnum("strCountryMobCode", objCMS);
                imgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
                lblCustomerRegistration = dbLayer.getCaption("strCustomerRegistration", objCMS);
                lblPersonalInformation1 = dbLayer.getCaption("strPersonalInformation", objCMS);
                lblPersonalInformation2 = dbLayer.getCaption("strPersonalInformation", objCMS);
                lblNationalAddress = dbLayer.getCaption("strNationalAddress", objCMS);
                lblAdditionalInformation = dbLayer.getCaption("strAdditionalInformation", objCMS);
                PlaceFirstName = dbLayer.getCaption("strFirstName", objCMS);
                PlaceLastName = dbLayer.getCaption("strLastName", objCMS);
                PlaceMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
                PlaceEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
                PlaceJobTitle = dbLayer.getCaption("strJobTitle", objCMS);
                PlaceConfirmPassword = dbLayer.getCaption("strConfirmPassword", objCMS);
                PlacePassword = dbLayer.getCaption("strPassword", objCMS);
                PlaceFirstName1 = dbLayer.getCaption("strFirstNameArabic", objCMS);
                PlaceLastName2 = dbLayer.getCaption("strLastNameArabic", objCMS);
                lblFirstName2 = dbLayer.getCaption("strFirstName", objCMS);
                PlaceLastName2 = dbLayer.getCaption("strLastName", objCMS);
                lblLastName2 = dbLayer.getCaption("strLastName", objCMS);
                lblFirstNamesAr = dbLayer.getCaption("strFirstNameArabic", objCMS);
                lblLastNamesAr = dbLayer.getCaption("strLastNameArabic", objCMS);
                lblCountryCode1 = dbLayer.getCaption("strCountryCode", objCMS);
                lblMobileNumber2 = dbLayer.getCaption("strMobileNumber", objCMS);
                lblEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
                lblPrefComm1 = dbLayer.getCaption("strPreferredCommunications", objCMS);
                lblJobTitle1 = dbLayer.getCaption("strJobTitle", objCMS);
                lblJobFunction1 = dbLayer.getCaption("strJobFunction", objCMS);
                lblPassword1 = dbLayer.getCaption("strPassword", objCMS);
                lblConfirmPassword = dbLayer.getCaption("strConfirmPassword", objCMS);
                picCountryMobCode = dbLayer.getCaption("strCountryMobCode", objCMS);
                picPrefComm = dbLayer.getCaption("strPreferredCommunication", objCMS);
                picJobFunction = dbLayer.getCaption("strJobFunction", objCMS);

                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
                MsgJobTitle = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgJobFunction = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCompany = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCountryP1 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgEmailAddress = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgPref = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgEmailValid = dbLayer.getCaption("strEmailpattern", objCMSMSG);
                MsgFirstName = dbLayer.getCaption("strMandatory", objCMSMSG);
                Msgfax = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgLastName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgMobileNumber = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgPassword = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgConfirmPassword = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgFirstNameArbic = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgLastNameArabic = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgPagevise = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
                MsgPagevise2 = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
                MsgPagevise3 = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
                MsgPagevise4 = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
                MsgEmailAddressUnique = dbLayer.getCaption("strAlreadyexists", objCMSMSG);
                MsgMobileNoUnique = dbLayer.getCaption("strAlreadyexists", objCMSMSG);
                MsgPasswordMisMatch = dbLayer.getCaption("strNotmatch", objCMSMSG);
                MsgMobileLength = dbLayer.getCaption("strEmailpattern", objCMSMSG);
                btnNext = dbLayer.getCaption("strNEXT", objCMS);
                btnAlreadyLogIn = dbLayer.getCaption("strAlreadyhaveaccountLogIn", objCMS);
                if (_selectedCountryMobCode == null)
                {
                    _selectedCountryMobCode = lobjContryMobCode.First(item => item.Value == "SA");
                }

                #endregion

                #region Third Page Caption

                await Task.Delay(1000);
                imgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
                lblCustomerRegistration = dbLayer.getCaption("strCustomerRegistration", objCMS);
                lblCompanyInformation = dbLayer.getCaption("strCompanyInformation", objCMS);
                lblNationalAddress = dbLayer.getCaption("strNationalAddress", objCMS);
                lblAdditionalInformation = dbLayer.getCaption("strAdditionalInformation", objCMS);
                lblNational = dbLayer.getCaption("strNationalAddress", objCMS);
                lblCountry1 = dbLayer.getCaption("strCountry", objCMS);
                lblBuildingNo1 = dbLayer.getCaption("strBuildingNo", objCMS);
                lblUnitNo1 = dbLayer.getCaption("strUnitNo", objCMS);
                lblStreetName1 = dbLayer.getCaption("strStreetName", objCMS);
                lblDistrictName1 = dbLayer.getCaption("strDistrictName", objCMS);
                lblCity1 = dbLayer.getCaption("strCity", objCMS);
                lblZipCode = dbLayer.getCaption("strZipCode", objCMS);
                lblAdditionalNo1 = dbLayer.getCaption("strAdditionalNo", objCMS);
                lblTelephone1 = dbLayer.getCaption("strTelephone", objCMS);
                lblFax1 = dbLayer.getCaption("strFax", objCMS);
                lobjCountry = dbLayer.getEnum("strCountryCodegrid", objCMS);
                lobjCity = dbLayer.getEnum("strCitygrid", objCMS);


                PlaceBuildingNo = dbLayer.getCaption("strBuildingNo", objCMS);
                PlaceUnitNo = dbLayer.getCaption("strUnitNo", objCMS);
                PlaceStreetName = dbLayer.getCaption("strStreetName", objCMS);
                PlaceDistrict = dbLayer.getCaption("strDistrictName", objCMS);
                PlaceZipCode = dbLayer.getCaption("strZipCode", objCMS);
                PlaceAdditionalNo = dbLayer.getCaption("strAdditionalNo", objCMS);
                PlaceTelephone = dbLayer.getCaption("strTelephone", objCMS);
                PlaceFax = dbLayer.getCaption("strFax", objCMS);

                MsgCountryP3 = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgTelephone = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgZipCode = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgDistrict = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCityName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgStreetName = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgUnitNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgBuildingNo = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgAdditional = dbLayer.getCaption("strMandatory", objCMSMSG);

                btnNextP3 = dbLayer.getCaption("strNEXT", objCMS);
                btnPreviousP3 = dbLayer.getCaption("strPrevious", objCMS);
                if (_selectedCountry == null)
                {
                    _selectedCountry = lobjCountry.First(item => item.Value == "SA");
                }
                // lblPersonalInformation.Text = dbLayer.getCaption("strPersonalInformation", objCMS);
                #endregion

                #region Fourth Page Caption
                await Task.Delay(2000);
                lblCountry2 = dbLayer.getCaption("strCountryMobCode", objCMS);
                imgRegisterIconP5 = dbLayer.getCaption("imgRegistericon", objCMS);
                lblCustomerRegistrationP5 = dbLayer.getCaption("strCustomerRegistration", objCMS);
                lblPersonalInformation = dbLayer.getCaption("strPersonalInformation", objCMS);
                lblFirstName = dbLayer.getCaption("strFirstName1", objCMS);
                lblLastName = dbLayer.getCaption("strLastName1", objCMS);
                lblFirstName1 = dbLayer.getCaption("strFirstNameArabic1", objCMS);
                lblLastName1 = dbLayer.getCaption("strLastNameArabic1", objCMS);
                lblMobileNumber = dbLayer.getCaption("strMobileNumber1", objCMS);
                lblNationalAdress = dbLayer.getCaption("strNationalAddress", objCMS);
                lblEmailAdress = dbLayer.getCaption("strEmailAddress1", objCMS);
                lblPrefComm = dbLayer.getCaption("strPreferredCommunication1", objCMS);
                lblJobTitle = dbLayer.getCaption("strJobTitle1", objCMS);
                lblJobFunction = dbLayer.getCaption("strJobFunction1", objCMS);
                lblPassword = dbLayer.getCaption("strPassword1", objCMS);
                lblCompanyInformationP5 = dbLayer.getCaption("strCompanyInformation", objCMS);
                lblCompanyType = dbLayer.getCaption("strCompanyType1", objCMS);
                lblCompanyName = dbLayer.getCaption("strCompanyName1", objCMS);
                lblBuildingNo = dbLayer.getCaption("strBuildingNo1", objCMS);
                lblUnitNo = dbLayer.getCaption("strUnitNo1", objCMS);
                lblStreetName = dbLayer.getCaption("strStreetName1", objCMS);
                lblDistrictName = dbLayer.getCaption("strDistrictName1", objCMS);
                lblCity = dbLayer.getCaption("strCity1", objCMS);
                lblPostCode = dbLayer.getCaption("strPostcodeZIP1", objCMS);
                lblAdditionalNo = dbLayer.getCaption("strAdditionalNo1", objCMS);
                lblTelephone = dbLayer.getCaption("strTelephone1", objCMS);
                lblFax = dbLayer.getCaption("strFax1", objCMS);
                lblAddditionalInformation2 = dbLayer.getCaption("strAdditionalInformation", objCMS);
                lblCustomerType = dbLayer.getCaption("strCustomerType1", objCMS);
                lblLicenseNo = dbLayer.getCaption("strImportExportLicenseNo1", objCMS);
                lblIdNo = dbLayer.getCaption("strIdNo1", objCMS);
                btnModifyInformation = dbLayer.getCaption("strModifyInformation1", objCMS);
                btnSentOTP = dbLayer.getCaption("strSendOTPtoConfirm1", objCMS);
                btnAlreadyLogIn = dbLayer.getCaption("strAlreadyhaveaccountLogIn", objCMS);
                lblCountry = dbLayer.getCaption("strCountry1", objCMS);
                lblCountry2 = dbLayer.getCaption("strCountryMobCode1", objCMS);
                if ((lblLicenseNoVal2 == null) || (lblLicenseNoVal2 == "")) LicenseNoVal2 = false;
                if ((lblLicenseNoVal3 == null) || (lblLicenseNoVal3 == "")) LicenseNoVal3 = false;
                if ((lblLicenseNoVal4 == null) || (lblLicenseNoVal4 == "")) LicenseNoVal4 = false;
                if ((lblLicenseNoVal5 == null) || (lblLicenseNoVal5 == "")) LicenseNoVal5 = false;
                if ((lblLicenseNoVal6 == null) || (lblLicenseNoVal6 == "")) LicenseNoVal6 = false;
                if ((lblLicenseNoVal7 == null) || (lblLicenseNoVal7 == "")) LicenseNoVal7 = false;
                if ((lblLicenseNoVal8 == null) || (lblLicenseNoVal8 == "")) LicenseNoVal8 = false;
                if ((lblLicenseNoVal9 == null) || (lblLicenseNoVal9 == "")) LicenseNoVal9 = false;
                if ((lblLicenseNoVal10 == null) || (lblLicenseNoVal10 == "")) LicenseNoVal10 = false;
                #endregion

                #region Fifth Page Caption

                await Task.Delay(1000);
                imgRegisterIconP6 = dbLayer.getCaption("imgRegistericon", objCMS);
                lblCustomerRegistrationP6 = dbLayer.getCaption("strCustomerRegistration", objCMS);
                lblEnterTheOtp = dbLayer.getCaption("strPlsEnterOtp", objCMS);
                PlaceOtp = dbLayer.getCaption("strOTP", objCMS);
                btnConfirm = dbLayer.getCaption("strConfirm", objCMS);
                btnCancel = dbLayer.getCaption("strCancel", objCMS);
                MsgValidOTP = dbLayer.getCaption("strProvidvalidOTP", objCMSMSG);

                #endregion

                #region Sixth Page Caption

                await Task.Delay(1000);
                imgRegisterIconP7 = dbLayer.getCaption("imgRegistericon", objCMS);
                lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
                lblMessage = dbLayer.getCaption("strEmailMsgSent", objCMS);
                btnLogIn = dbLayer.getCaption("strLogIn", objCMS);

                #endregion

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        ///  To go First Page
        /// </summary>
        private async Task gotonextpagefrom1()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(2000);
                await reg1Validation();
                IsBusy = false;
                StackPageRegistration = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To handle validattion
        /// <summary>
        /// To handle validattion
        /// </summary>
        private async Task reg1Validation()
        {
            try
            {
                await Task.Delay(1000);
                bool blResult = false;
                HideValidatedErrMsg();
                if ((TxtCompanyName == null) || (TxtCompanyName == ""))
                {
                    blResult = true;
                    IsvalidatedCompanyName = true;
                }
                else
                {
                    IsvalidatedCompanyName = false;
                }
                //if (_selectedCompanyType != null)
                //{
                //    IsvalidatedCompanyType = false;
                //}
                //else
                //{
                //    blResult = true;
                //    IsvalidatedCompanyType = true;
                //}
                //HideValidatedErrMsg();
                if (_selectedCustomerType != null)
                {
                    IsvalidatedCustomerType = false;
                }
                else
                {
                    IsvalidatedCustomerType = true;
                }
                if (TxtIDNo == null || TxtIDNo == "")
                {
                    blResult = true;
                    IsvalidatedIDNo = true;
                }
                else
                {
                    IsvalidatedIDNo = false;
                }
                if (TxtIDNo != null || TxtIDNo != "")
                {
                    bool blValidateId = validateuniqconstraints(TxtIDNo);
                    if (blValidateId == true)
                    {
                        blResult = true;
                        IValidateId = true;
                    }
                }
                if (TxtImpExpLicNo == null || TxtImpExpLicNo == "")
                {
                    blResult = true;
                    IsvalidatedLicNo = true;
                }
                else
                {
                    IsvalidatedLicNo = false;
                }

                if (blResult == false)
                {

                    HideStack(2);
                    Entry JobTitle = Myview.FindByName<Entry>("EntryJobTitle");
                    JobTitle.Focus();
                }
                else
                {

                    HideStack(1);
                }

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //To handle boolean
        /// <summary>
        /// To handle boolean
        /// </summary>

        private async Task GotoPageFrom4()
        {
            IsBusy = true;
            StackPageRegistration = false;
            await Task.Delay(1000);
            HideStack(3);
            StackPageRegistration = true;
            IsBusy = false;
        }

        private bool validateuniqconstraints(string fstrinput)
        {
            bool blResult = false;
            try
            {
                lstreguser = objBl.getRegisterUserDetails(fstrinput);
                if (lstreguser.Count > 0)
                {
                    blResult = true;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            return blResult;
        }
        //To go Previous Page
        /// <summary>
        ///  Go to Previous Page
        /// </summary>
        private async Task gotopreviouspagefrom2()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                HideValidatedErrMsg();
                if (_selectedCompanyType != null)
                {
                    gblRegisteration.strCompanyType = _selectedCompanyType.Value;
                }
                if (_selectedCustomerType != null)
                {
                    gblRegisteration.strCompanyType = _selectedCustomerType.Value;
                }
                if (TxtCompanyName != null)
                {
                    gblRegisteration.strCompanyName = TxtCompanyName;
                }

                HideStack(1);
                //Entry emailEntry = Myview.FindByName<Entry>("focusJobTitle");
                //emailEntry.Focus();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackPageRegistration = true;
            IsBusy = false;
        }
        //To go next page
        /// <summary>
        /// To go next page
        /// </summary>
        private async Task gotonextpagefrom2()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                bool blResult = false;
                HideValidatedErrMsg();
                if ((TxtFirstName == null) || (TxtFirstName == ""))
                {
                    IsvalidatedFirstname = true;
                    blResult = true;
                }
                else
                {
                    IsvalidatedFirstname = false;
                }
                if ((TxtLastName == null) || (TxtLastName == ""))
                {
                    IsvalidatedLastName = true;
                    blResult = true;
                }
                else
                {
                    IsvalidatedLastName = false;
                }
                if ((TxtFirstName1 == null) || (TxtFirstName1 == ""))
                {
                    IsvalidatedFirstnameArabic = true;
                    blResult = true;
                }
                else
                {
                    IsvalidatedFirstnameArabic = false;
                }
                if ((TxtLastName2 == null) || (TxtLastName2 == ""))
                {
                    IsvalidatedLastnameArabic = true;
                    blResult = true;
                }
                else
                {
                    IsvalidatedLastnameArabic = false;
                }
                if ((TxtMobileNumber == null) || (TxtMobileNumber == ""))
                {
                    IsvalidatedMobileNo = true;
                    blResult = true;
                }
                else
                {
                    IsvalidatedMobileNo = false;
                }
                if ((TxtMobileNumber != null) && (TxtMobileNumber != ""))
                {
                    if (TxtMobileNumber.Length < 10)
                    {
                        blResult = true;
                        IsvalidatedMobileLength = true;
                    }
                    else
                    {
                        IsvalidatedMobileLength = false;
                    }

                    bool blValidateMobilNo = validateuniqconstraints(TxtMobileNumber);
                    if (blValidateMobilNo == true)
                    {
                        IsvalidatedMobileNoExist = true;
                        blResult = true;
                    }
                    else
                    {
                        IsvalidatedMobileNoExist = false;
                    }
                }
                if (_selectedPrefComm != null)
                {
                    IsvalidatedPrefComm = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedPrefComm = true;
                }

                if (_selectedCountryMobCode != null)
                {
                    IsvalidatedCountry = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedCountry = true;
                }
                if ((TxtJobTitle == null) || (TxtJobTitle == ""))
                {
                    blResult = true;
                    IsvalidatedJobTitle = true;
                }
                else
                {
                    IsvalidatedJobTitle = false;
                }
                if (_selectedJobFunction != null)
                {
                    IsvalidatedJobFunction = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedJobFunction = true;
                }
                if ((TxtEmailAddress == null) || (TxtEmailAddress == ""))
                {
                    blResult = true;
                    ValidateEmail = true;
                }
                else
                {
                    var email = TxtEmailAddress;
                    var emailpattern = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
                    if (!string.IsNullOrWhiteSpace(email) && !(Regex.IsMatch(email, emailpattern)))
                    {
                        blResult = true;
                        ValidateEmailadd = true;
                    }
                    else
                    {
                        ValidateEmail = false;
                        ValidateEmailadd = false;
                    }
                }
                if ((TxtEmailAddress != null) || (TxtEmailAddress != ""))
                {
                    bool blValidateEmail = validateuniqconstraints(TxtEmailAddress);
                    if (blValidateEmail == true)
                    {
                        blResult = true;
                        ValidateEmailUni = true;
                    }
                }
                if ((TxtConfirmPassword == null) || (TxtConfirmPassword == ""))
                {
                    blResult = true;
                    IsvalidatedConfirmPass = true;
                }
                if ((TxtPassword == null) || (TxtPassword == ""))
                {
                    blResult = true;
                    IsvalidatedPassword = true;
                }
                else
                {
                    if (TxtPassword == TxtConfirmPassword)
                    {
                        IsvalidatedMisMatchPass = false;
                    }
                    else
                    {
                        blResult = true;
                        IsvalidatedConfirmPass = false;
                        IsvalidatedMisMatchPass = true;
                    }
                }
                if (blResult == false)
                {
                    HideStack(3);
                }
                else
                {
                    Entry emailEntry = Myview.FindByName<Entry>("FocusBuildingNo1");
                    emailEntry.Focus();
                    HideStack(2);
                    Pagevise1 = true;
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To go previous page
        /// <summary>
        /// To go previous page
        /// </summary>
        private async Task gotopreviouspagefrom3()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                HideStack(2);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackPageRegistration = true;
            IsBusy = false;
        }
        //To Update Reg user
        /// <summary>
        /// To Update Reg user
        /// </summary>
        private void updatereguser()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                HideValidatedErrMsg();
                if (TxtBuildingNo == null || TxtBuildingNo == "")
                {
                    IsvalidatedBuildingNo = true;
                }
                else
                {
                    IsvalidatedBuildingNo = false;
                }
                //if (TxtUnitNo == null || TxtUnitNo == "")
                //{
                //    IsvalidatedUnitNo = true;
                //}
                //else
                //{
                //    IsvalidatedUnitNo = false;
                //}
                if (TxtStreetName == null || TxtStreetName == "")
                {
                    IsvalidatedstreetName = true;
                }
                else
                {
                    IsvalidatedstreetName = false;
                }
                //if (TxtDistrict == null || TxtDistrict == "")
                //{
                //    IsvalidatedDistrict = true;
                //}
                //else
                //{
                //    IsvalidatedDistrict = false;
                //}
                //if (TxtZipCode == null || TxtZipCode == "")
                //{
                //    IsvalidatedZipCode = true;
                //}
                //else
                //{
                //    IsvalidatedZipCode = false;
                //}
                //if (TxtAdditionalNo == null || TxtAdditionalNo == "")
                //{
                //    IsvalidatedAdditionalNo = true;
                //}
                //else
                //{
                //    IsvalidatedAdditionalNo = false;
                //}
                if (TxtTelephone == null || TxtTelephone == "")
                {
                    IsvalidatedTelephone = true;
                }
                else
                {
                    IsvalidatedTelephone = false;
                }
                //if (TxtFax == null || TxtFax == "")
                //{
                //    Isvalidatedfax = true;
                //}
                //else
                //{
                //    Isvalidatedfax = false;
                //}
                if (_selectedCountry != null)
                {
                    IsvalidatedCountry = false;
                }
                else
                {
                    IsvalidatedCountry = true;
                }
                if (_selectedCity != null)
                {
                    IsvalidatedCity = false;
                }
                else
                {
                    IsvalidatedCity = true;
                }
                if (ChkMandatoryterms == false)
                {
                    // blResult = true;
                    isChkMandatoryTerms = true;
                }
                else
                {
                    isChkMandatoryTerms = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackPageRegistration = true;
            IsBusy = false;
        }

        /// <summary>
        /// To go next page
        /// </summary>
        private async Task gotonextpagefrom3()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(3000);

                updatereguser();
                if ((IsvalidatedCountry == false) && (IsvalidatedBuildingNo != true)
                     && (IsvalidatedstreetName != true) && (IsvalidatedCity != true)
                    && (IsvalidatedTelephone != true) && (isChkMandatoryTerms != true))
                {
                    HideStack(4);
                }
                else
                {
                    Entry FaxEntry = Myview.FindByName<Entry>("EntryFax");
                    FaxEntry.Focus();
                    HideStack(3);
                }

                //&& (IsvalidatedUnitNo != true) && (IsvalidatedDistrict != true) && (IsvalidatedZipCode != true)
                //&& (IsvalidatedAdditionalNo != true) && (Isvalidatedfax != true)
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }

        /// <summary>
        /// To go previous page
        /// </summary>
        //private async Task gotopreviouspagefrom4()
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        StackPageRegistration = false;
        //        await Task.Delay(1000);
        //        HideStack(3);

        //    }
        //    catch (Exception ex)
        //    {
        //       App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
        //    }
        //    IsBusy = false;
        //    StackPageRegistration = true;
        //}

        /// <summary>
        /// To go next page
        /// </summary>
        //private async Task gotonextpagefrom4()
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        StackPageRegistration = false;
        //        await Task.Delay(3000);

        //        IsBusy = false;
        //        StackPageRegistration = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        App.Current.MainPage?.DisplayAlert("", ex.Message, "");
        //    }
        //}
        //To go to Modify
        private async Task gotomodify()
        {
            try
            {

                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                HideStack(1);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To go OTP
        private async Task gotootp()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                if (gblRegisteration.strPreCommun.ToUpper().Trim() == "EMAIL")//20230206
                {
                    objWebApi.postWebApi("postsendemail", gblRegisteration.Mailotp());
                }
                else
                {
                    objWebApi.postWebApi("postsentsms", gblRegisteration.SMSOTP());
                }
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }


                HideStack(5);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To go page Registration
        private async Task gotopageregistration7()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                if (gblRegisteration.OTP == TxtOtp)
                {

                    objWebApi.postWebApi("newregisteruser", gblRegisteration.NewUserRegistration("new"));
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }



                    objWebApi.postWebApi("postsendemail", gblRegisteration.MailRegistration());
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    //to clear global properties
                    var fields = typeof(gblRegisteration).GetFields(BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var field in fields)
                    {
                        var type = field.GetType();
                        field.SetValue(null, null);
                    }
                    gblRegisteration.strLoginFirstName1 = null;
                    gblRegisteration.strLoginUser = null;
                    HideStack(6);
                    App.gblLanguage = "En";
                    App.gblRole = "An";

                }
                else
                {
                    IsvalidatedOTP = true;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To go Login
        private async Task goto_login()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);
                // navigation.pushasync(new pagelogin());
                await App.Current.MainPage?.Navigation.PushAsync(new PageLogin());
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To go List 
        private async Task gotolist()
        {
            try
            {
                IsBusy = true;
                StackPageRegistration = false;
                await Task.Delay(1000);

                Licencenodiv = true;
                await Task.Delay(1000);
                Entry FocusTxtIdNo = Myview.FindByName<Entry>("FocuslicenceNo10");
                FocusTxtIdNo.Focus();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackPageRegistration = true;
        }
        //To hide Hide Validated Error Msg
        private void HideValidatedErrMsg()
        {
            try
            {
                // Page Registration 1
                Pagevise1 = false;
                IsvalidatedOTP = false;
                IsvalidatedFirstnameArabic = false;
                IsvalidatedLastnameArabic = false;
                IsvalidatedConfirmPass = false;
                IsvalidatedMisMatchPass = false;
                IsvalidatedPassword = false;
                IsvalidatedPrefComm = false;
                IsvalidatedPrefComm = false;
                IsvalidatedCompanyType = false;
                IsvalidatedCountry = false;
                IsvalidatedMobileNo = false;
                IsvalidatedLastName = false;
                IsvalidatedFirstname = false;
                ValidateEmailadd = false;
                ValidateEmail = false;
                ValidateEmailUni = false;
                ValidateMobilNo = false;
                isChkMandatoryTerms = false; //20230408
                //Page Registration 2
                //   IsvalidatedCompanyname = false;
                IsvalidatedCompanyType = false;
                //Page Registration 3
                Isvalidatedfax = false;
                IsvalidatedBuildingNo = false;
                IsvalidatedUnitNo = false;
                IsvalidatedstreetName = false;
                IsvalidatedDistrict = false;
                IsvalidatedZipCode = false;
                IsvalidatedAdditionalNo = false;
                IsvalidatedTelephone = false;
                IsvalidatedCountry = false;
                IsvalidatedCity = false;
                ////Page Registration 4
                IsvalidatedCustomerType = false;
                IsvalidatedIDNo = false;
                IValidateId = false;
                IsvalidatedLicNo = false;
                IsvalidatedJobTitle = false;
                IsvalidatedJobFunction = false;
                IsvalidatedCompanyName = false;
                IsvalidatedMobileLength = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        public async Task GoToTC()
        {
            IsBusy = true;
            StackPageRegistration = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new TC());
            StackPageRegistration = true;
            IsBusy = false;
        }
    }
}