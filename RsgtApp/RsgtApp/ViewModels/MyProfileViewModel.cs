using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Models;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
namespace RsgtApp.ViewModels
{
    public class MyProfileViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //gotoREG Button 
        public Command gotoREG { get; set; }
        //gotoMyProfile2 Button 
        public Command goto_Page2 { get; set; }
        //gotoMyUpdate1 Button 
        public Command goto_Page1Update { get; set; }
        //gotoMyProfile1 Button 
        public Command goto_Page1 { get; set; }
        //gotoMyProfile3 Button 
        public Command goto_Page3 { get; set; }
        //gotoMyUpdate2 Button 
        public Command goto_Page2Update { get; set; }
        //goto3MyProfile2 Button 
        public Command goto_Page3toPage2 { get; set; }
        //gotoMyProfile4 Button 
        public Command goto_Page4 { get; set; }
        //gotoUpdate3 Button 
        public Command goto_Page3Update { get; set; }
        //gotoMyUpdate Button 
        public Command gotoMyUpdate { get; set; }
        //gotoList Button 
        public Command gotoList { get; set; }
        //Serever error Message
        string strServerSlowMsg = "";

        //To Get Enum Value lobjCountryCodee
        private List<EnumCombo> _lobjCountryCodee { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjCountryCodee
        {
            get { return _lobjCountryCodee; }
            set
            {
                if (_lobjCountryCodee == value)
                    return;
                _lobjCountryCodee = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCountryCodee");

            }
        }

        //To Get Enum Value lobjPrefComm
        private List<EnumCombo> _lobjPrefComm { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjPrefComm
        {
            get { return _lobjPrefComm; }
            set
            {
                if (_lobjPrefComm == value)
                    return;
                _lobjPrefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjPrefComm");

            }
        }

        //To Get Enum Value lobjJobFunction
        private List<EnumCombo> _lobjJobFunction { get; set; } = new List<EnumCombo>();
        public List<EnumCombo> lobjJobFunction
        {
            get { return _lobjJobFunction; }
            set
            {
                if (_lobjJobFunction == value)
                    return;
                _lobjJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjJobFunction");

            }
        }

        //To Get Enum Value lobjCompanyType
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

        //To Get Enum Value lobjCountry
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

        //To Get Enum Value lobjCity
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

        //To Get Enum Value lobjCustomerType
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
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();

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
        //To Get Enum Value _selectedCountryCode
        private EnumCombo _selectedCountryCode;
        public EnumCombo SelectedCountryCode
        {
            get { return _selectedCountryCode; }
            set
            {
                SetProperty(ref _selectedCountryCode, value);
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
        //To handle Boolean variable
        private bool stackMyProfile = true;
        public bool StackMyProfile
        {
            get { return stackMyProfile; }
            set
            {
                stackMyProfile = value;
                OnPropertyChanged();
                RaisePropertyChange("StackMyProfile");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool pagevise3 = false;
        public bool Pagevise3
        {
            get { return pagevise3; }
            set
            {
                pagevise3 = value;
                OnPropertyChanged();
                RaisePropertyChange("Pagevise3");
            }
        }
        //Version Number
        //string TxtVersionNo = AppSettings.VersionNo;
        private string txtVersionNo = AppSettings.VersionNo;
        public string TxtVersionNo
        {
            get { return txtVersionNo; }
            set
            {
                txtVersionNo = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtVersionNo");
            }
        }
        //Page1 Captions
        //lblpersonalInformation2 purpose of Label
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
        //msgFirstName purpose of using Message
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
        //lblfirstNameAr purpose of using Label
        private string lblfirstNameAr = "";
        public string lblFirstNameAr
        {
            get { return lblfirstNameAr; }
            set
            {
                lblfirstNameAr = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFirstNameAr");
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
        //msgFirstNameArm purpose of using Message
        private string msgFirstNameArm = "";
        public string MsgFirstNameArm
        {
            get { return msgFirstNameArm; }
            set
            {
                msgFirstNameArm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFirstNameArm");
            }
        }
        //lbllastName1 purpose of using textbox variable
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
        //msgLastName purpose of using Message
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
        //lbllastNameArabic purpose of using textbox variable
        private string lbllastNameArabic = "";
        public string lblLastNameArabic
        {
            get { return lbllastNameArabic; }
            set
            {
                lbllastNameArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("lblLastNameArabic");
            }
        }
        //txtLastName1 purpose of using textbox variable
        private string txtLastName1 = "";
        public string TxtLastName1
        {
            get { return txtLastName1; }
            set
            {
                txtLastName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtLastName1");
            }
        }
        //msgLastNameArm purpose of using Message
        private string msgLastNameArm = "";
        public string MsgLastNameArm
        {
            get { return msgLastNameArm; }
            set
            {
                msgLastNameArm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgLastNameArm");
            }
        }
        //lblcountryCode purpose of using Label
        private string lblcountryCode = "";
        public string lblCountryCode
        {
            get { return lblcountryCode; }
            set
            {
                lblcountryCode = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCountryCode");
            }
        }
        //msgCountryCode purpose of using Message
        private string msgCountryCode = "";
        public string MsgCountryCode
        {
            get { return msgCountryCode; }
            set
            {
                msgCountryCode = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCountryCode");
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
        //lblprefComm1 purpose of using Label
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
        //msgPrefComm purpose of using Message
        private string msgPrefComm = "";
        public string MsgPrefComm
        {
            get { return msgPrefComm; }
            set
            {
                msgPrefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPrefComm");
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
        //msgJobTitle purpose of using Message
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
        //msgJobFunction purpose of using Message
        private string msgJobFunction = "";
        public string MsgJobFunction
        {
            get { return msgJobFunction; }
            set
            {
                msgJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgJobFunction");
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
        //TxtConfirmPassword purpose of using textbox variable
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
        //msgConfirmPassword purpose of using "Message
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
        private string _MsgConfirmPass = "";
        public string MsgConfirmPass
        {
            get { return _MsgConfirmPass; }
            set
            {
                _MsgConfirmPass = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgConfirmPass");
            }
        }
        //Footer_1
        //msgpagevise purpose of using Message
        private string msgpagevise = "";
        public string MsgPagevise
        {
            get { return msgpagevise; }
            set
            {
                msgpagevise = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise");
            }
        }
        //btnNext purpose of using Button
        private string btnNext = "";
        public string BtnNext
        {
            get { return btnNext; }
            set
            {
                btnNext = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnNext");
            }
        }
        //btnUpdate purpose of using Button
        private string btnUpdate = "";
        public string BtnUpdate
        {
            get { return btnUpdate; }
            set
            {
                btnUpdate = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnUpdate");
            }
        }
        //To handle Boolean variable
        private bool page1 = true;
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
        //placeFirstName1 purpose of using textbox Placeholder
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
        //placeLastName1 purpose of using Placeholder
        private string placeLastName1 = "";
        public string PlaceLastName1
        {
            get { return placeLastName1; }
            set
            {
                placeLastName1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceLastName1");
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
        //Page2 Captions
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
        //msgCompanyType purpose of using Message
        private string msgCompanyType = "";
        public string MsgCompanyType
        {
            get { return msgCompanyType; }
            set
            {
                msgCompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyType");
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
        //txtCompanyName purpose of using textbox variable
        private string txtCompanyName = "";
        public string TxtCompanyName
        {
            get { return txtCompanyName; }
            set
            {
                txtCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtCompanyName");
            }
        }
        //msgCompanyName purpose of using Message
        private string msgCompanyName = "";
        public string MsgCompanyName
        {
            get { return msgCompanyName; }
            set
            {
                msgCompanyName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCompanyName");
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
        //To handle Boolean variables
        private bool page2 = true;
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
        //Page3 Captions
        //lblnationalAddress2 purpose of using Label
        private string lblnationalAddress2 = "";
        public string lblNationalAddress2
        {
            get { return lblnationalAddress2; }
            set
            {
                lblnationalAddress2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNationalAddress2");
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
        //msgCountry purpose of using Message
        private string msgCountry = "";
        public string MsgCountry
        {
            get { return msgCountry; }
            set
            {
                msgCountry = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCountry");
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
        //MsgBuildingNo purpose of using Message
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
        //msgUnitNo purpose of using Message
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
        //msgDistrictName purpose of using Message
        private string msgDistrictName = "";
        public string MsgDistrictName
        {
            get { return msgDistrictName; }
            set
            {
                msgDistrictName = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgDistrictName");
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
        //msgCity purpose of using Message
        private string msgCity = "";
        public string MsgCity
        {
            get { return msgCity; }
            set
            {
                msgCity = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCity");
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
        //msgAdditionalNo purpose of using Message
        private string msgAdditionalNo = "";
        public string MsgAdditionalNo
        {
            get { return msgAdditionalNo; }
            set
            {
                msgAdditionalNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgAdditionalNo");
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
        //msgFax purpose of using Message
        private string msgFax = "";
        public string MsgFax
        {
            get { return msgFax; }
            set
            {
                msgFax = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgFax");
            }
        }
        //To handle Boolean variable
        private bool page3 = true;
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
        //txtDistrictName purpose of using textbox variable
        private string txtDistrictName = "";
        public string TxtDistrictName
        {
            get { return txtDistrictName; }
            set
            {
                txtDistrictName = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtDistrictName");
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
        //txtFax purpose of using textbox variable
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
        //Page4 Captions
        //lbladditionalInformation2 purpose of using Label
        private string lbladditionalInformation2 = "";
        public string lblAdditionalInformation2
        {
            get { return lbladditionalInformation2; }
            set
            {
                lbladditionalInformation2 = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAdditionalInformation2");
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
        //lblnationalIDNo purpose of using Label
        private string lblnationalIDNo = "";
        public string lblNationalIDNo
        {
            get { return lblnationalIDNo; }
            set
            {
                lblnationalIDNo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblNationalIDNo");
            }
        }
        //txtIdNo purpose of using textbox variable
        private string txtIdNo = "";
        public string TxtIdNo
        {
            get { return txtIdNo; }
            set
            {
                txtIdNo = value;
                OnPropertyChanged();
                RaisePropertyChange(TxtIdNo);
            }
        }
        //msgIdNo purpose of using Message
        private string msgIdNo = "";
        public string MsgIdNo
        {
            get { return msgIdNo; }
            set
            {
                msgIdNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgIdNo");
            }
        }
        //To handle Boolean variable
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
        //txtImpExpLicNo purpose of using textbox variable
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
        //msgImpExpLicNo purpose of using Message
        private string msgImpExpLicNo = "";
        public string MsgImpExpLicNo
        {
            get { return msgImpExpLicNo; }
            set
            {
                msgImpExpLicNo = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgImpExpLicNo");
            }
        }
        //txtlicenceNo2 purpose of using textbox variable
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
        //txtlicenceNo3 purpose of using textbox variable
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
        //txtlicenceNo4 purpose of using textbox variable
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
        //txtlicenceNo5 purpose of using textbox variable
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
        //txtlicenceNo6 purpose of using textbox variable
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
        //txtlicenceNo7 purpose of using textbox variable
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
        //txtlicenceNo8 purpose of using textbox variable
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
        //txtlicenceNo9 purpose of using textbox variable
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
        //txtlicenceNo10 purpose of using textbox variable
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
        //To handle Boolean variable
        private bool page4 = true;
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
        //To handle Boolean variable
        private bool licenceNodiv = false;
        public bool LicenceNodiv
        {
            get { return licenceNodiv; }
            set
            {
                licenceNodiv = value;
                OnPropertyChanged();
                RaisePropertyChange("LicenceNodiv");
            }
        }
        //placeIdNo purpose of using Placeholder
        private string placeIdNo = "";
        public string PlaceIdNo
        {
            get { return placeIdNo; }
            set
            {
                placeIdNo = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceIdNo");
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
        //imgMyProfileIcon purpose of using Image
        private string imgMyProfileIcon = "";
        public string ImgMyProfileIcon
        {
            get { return imgMyProfileIcon; }
            set
            {
                imgMyProfileIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgMyProfileIcon");
            }
        }
        //lblmyProfile purpose of using textbox Label
        private string lblmyProfile = "";
        public string lblMyProfile
        {
            get { return lblmyProfile; }
            set
            {
                lblmyProfile = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMyProfile");
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
        //TxtConfirmPassword purpose of using Label
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
        //picCountryCode purpose of using Image
        private string picCountryCode = "";
        public string PicCountryCode
        {
            get { return picCountryCode; }
            set
            {
                picCountryCode = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCountryCode");
            }
        }
        //picPrefComm purpose of using Image
        private string picPrefComm = "";
        public string PicPrefComm
        {
            get { return picPrefComm; }
            set
            {
                picPrefComm = value;
                OnPropertyChanged();
                RaisePropertyChange("PicPrefComm");
            }
        }
        //picJobFunction purpose of using Image
        private string picJobFunction = "";
        public string PicJobFunction
        {
            get { return picJobFunction; }
            set
            {
                picJobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("PicJobFunction");
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
        }
        //msgPagevise3 purpose of using Message
        private string msgPagevise3 = "";
        public string MsgPagevise3
        {
            get { return msgPagevise3; }
            set
            {
                msgPagevise3 = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgPagevise3");
            }
        }
        //To handle boolean variable
        private bool pageFooter = true;
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
        //msgPagevise purpose of using Message
        private string msgPagevise = "";
        public string Msgpagevise
        {
            get { return msgPagevise; }
            set
            {
                msgPagevise = value;
                OnPropertyChanged();
                RaisePropertyChange("Msgpagevise");
            }
        }
        //To handle Boolean variable
        private bool pageFooter2 = true;
        public bool PageFooter2
        {
            get { return pageFooter2; }
            set
            {
                pageFooter2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter2");
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
        //btnupdateP2 purpose of using Button
        private string btnupdateP2 = "";
        public string btnUpdateP2
        {
            get { return btnupdateP2; }
            set
            {
                btnupdateP2 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnUpdateP2");
            }
        }
        //To handle Boolean variable
        private bool validateId = false;
        public bool ValidateId
        {
            get { return validateId; }
            set
            {
                validateId = value;
                OnPropertyChanged();
                RaisePropertyChange("ValidateId");
            }
        }
        //picCompanyType purpose of using Image
        private string picCompanyType = "";
        public string PicCompanyType
        {
            get { return picCompanyType; }
            set
            {
                picCompanyType = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCompanyType");
            }
        }
        //To handle Boolean variable
        private bool pageFooter3 = true;
        public bool PageFooter3
        {
            get { return pageFooter3; }
            set
            {
                pageFooter3 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter3");
            }
        }
        //msgpagevise3 purpose of using Message
        private string msgpagevise3 = "";
        public string Msgpagevise3
        {
            get { return msgpagevise3; }
            set
            {
                msgpagevise3 = value;
                OnPropertyChanged();
                RaisePropertyChange("Msgpagevise3");
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
        //btnupdateP3 purpose of using Button
        private string btnupdateP3 = "";
        public string btnUpdateP3
        {
            get { return btnupdateP3; }
            set
            {
                btnupdateP3 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnUpdateP3");
            }
        }
        //picCountry purpose of using Image
        private string picCountry = "";
        public string PicCountry
        {
            get { return picCountry; }
            set
            {
                picCountry = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCountry");
            }
        }
        //picCity purpose of using Image
        private string picCity = "";
        public string PicCity
        {
            get { return picCity; }
            set
            {
                picCity = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCity");
            }
        }
        //Error Validation 
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
        //To handle Boolean variable
        private bool isvalidatedFirstNameAr = false;
        public bool IsvalidatedFirstNameAr
        {
            get { return isvalidatedFirstNameAr; }
            set
            {
                isvalidatedFirstNameAr = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedFirstNameAr");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool isvalidatedLastNameArabic = false;
        public bool IsvalidatedLastNameArabic
        {
            get { return isvalidatedLastNameArabic; }
            set
            {
                isvalidatedLastNameArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedLastNameArabic");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool isvalidatedEmailID = false;
        public bool IsvalidatedEmailID
        {
            get { return isvalidatedEmailID; }
            set
            {
                isvalidatedEmailID = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedEmailID");
            }
        }
        //To handle Boolean variable
        private bool isvalidatedEmail = false;
        public bool IsvalidatedEmail
        {
            get { return isvalidatedEmail; }
            set
            {
                isvalidatedEmail = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedEmail");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool isvalidatedConfirmPassword = false;
        public bool IsvalidatedConfirmPassword
        {
            get { return isvalidatedConfirmPassword; }
            set
            {
                isvalidatedConfirmPassword = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedConfirmPassword");
            }
        }
        private bool _IsvalidatedConfirmPass = false;
        public bool IsvalidatedConfirmPass
        {
            get { return _IsvalidatedConfirmPass; }
            set
            {
                _IsvalidatedConfirmPass = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedConfirmPass");
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool isvalidatedCountryCode = false;
        public bool IsvalidatedCountryCode
        {
            get { return isvalidatedCountryCode; }
            set
            {
                isvalidatedCountryCode = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCountryCode");
            }
        }
        //To handle Boolean variable
        private bool pageFooter1 = false;
        public bool PageFooter1
        {
            get { return pageFooter1; }
            set
            {
                pageFooter1 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter1");
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

        private string _MsgMobileNoUnique = "";
        public string MsgMobileNoUnique
        {
            get { return _MsgMobileNoUnique; }
            set
            {
                _MsgMobileNoUnique = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgMobileNoUnique");
            }
        }
        private string _MsgIDNoUnique = "";
        public string MsgIDNoUnique
        {
            get { return _MsgIDNoUnique; }
            set
            {
                _MsgIDNoUnique = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgIDNoUnique");
            }
        }
        //To handle Boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                goto_Page2.ChangeCanExecute();
                goto_Page1Update.ChangeCanExecute();
                goto_Page1.ChangeCanExecute();
                goto_Page3.ChangeCanExecute();
                goto_Page2Update.ChangeCanExecute();
                goto_Page3toPage2.ChangeCanExecute();
                goto_Page4.ChangeCanExecute();
                goto_Page3Update.ChangeCanExecute();
                gotoMyUpdate.ChangeCanExecute();
                gotoList.ChangeCanExecute();
                gotoREG.ChangeCanExecute();
            }
        }
        ContentPage Myview;
        /// <summary>
        /// My Profile View Model-Constructor
        /// </summary>
        /// <param name="view"></param>
        public MyProfileViewModel(ContentPage view)
        {
            Myview = view;
            Task.Run(() => assignCms()).GetAwaiter().GetResult();
            goto_Page2 = new Command(async () => await gotoPage2(), () => !IsBusy);
            goto_Page1Update = new Command(async () => await gotoPage1Update(), () => !IsBusy);
            goto_Page1 = new Command(async () => await gotoPage1(), () => !IsBusy);
            goto_Page3 = new Command(async () => await gotoPage3(), () => !IsBusy);
            goto_Page2Update = new Command(async () => await gotoPage2Update(), () => !IsBusy);
            goto_Page3toPage2 = new Command(async () => await gotoPage3toPage2(), () => !IsBusy);
            goto_Page4 = new Command(async () => await gotoPage4(), () => !IsBusy);
            goto_Page3Update = new Command(async () => await gotoPage3Update(), () => !IsBusy);
            gotoMyUpdate = new Command(async () => await gotomyUpdate(), () => !IsBusy);
            gotoList = new Command(async () => await ExpandLicenceNodiv(), () => !IsBusy);
            gotoREG = new Command(async () => await goto_REG(), () => !IsBusy);
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}


                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM019");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    //20230411
                    if (AppSettings.objMyprofileCms.Count == 0)
                    {
                        objCMS = dbLayer.LoadContent("RM019").GetAwaiter().GetResult(); ;
                    }
                    if (AppSettings.objMyprofileCms.Count > 0)
                    {
                        objCMS = AppSettings.objMyprofileCms;
                    }

                    objCMSMSG = dbLayer.LoadContent("RM026").GetAwaiter().GetResult();


                    gblRegisteration.getreguser().GetAwaiter().GetResult();
                    assignContent();

                    fetchData().GetAwaiter().GetResult();
                    //  HideValidatedErrMsg();
                    int lintDummy = HideStack(1);
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public void assignContent()
        {

            #region Header Captions

            ImgMyProfileIcon = dbLayer.getCaption("imgmyprofile", objCMS);
            lblMyProfile = dbLayer.getCaption("strMyProfile", objCMS);
            lblPersonalInformation = dbLayer.getCaption("strPersonalInformation", objCMS);
            lblCompanyInformation = dbLayer.getCaption("strCompanyInformation", objCMS);
            lblNationalAddress = dbLayer.getCaption("strNationalAddress", objCMS);
            lblAdditionalInformation = dbLayer.getCaption("strAdditionalInformation", objCMS);

            #endregion


            #region Page 1 Captions

            lblCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
            lblCustomerType = dbLayer.getCaption("strCustomerType", objCMS);
            lblNationalIDNo = dbLayer.getCaption("strIDNo", objCMS);
            lblCompanyType = dbLayer.getCaption("strCompanyType", objCMS);
            lblLicenseNo = dbLayer.getCaption("strImportExportLicenseNo", objCMS);

            MsgCompanyName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCustomerType = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgIdNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCompanyType = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgIDNoUnique= dbLayer.getCaption("strAlreadyexists", objCMSMSG);
            PlaceCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
            picCustomerType = dbLayer.getCaption("strCustomerType", objCMS);
            lobjCustomerType = dbLayer.getEnum("strCustomerTypeLOV", objCMS);
            PlacelicenceNo2 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo3 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo4 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo5 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo6 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo7 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo8 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo9 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            PlacelicenceNo10 = dbLayer.getCaption("strAdditionalNumber", objCMS);
            MsgImpExpLicNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            #endregion

            #region Page 2 Captions

            //lblCompanyInformation = dbLayer.getCaption("strCompanyInformation", objCMS);
            lblFirstName1 = dbLayer.getCaption("strFirstName", objCMS);
            lblFirstNameAr = dbLayer.getCaption("strFirstNameArabic", objCMS);
            lblLastName1 = dbLayer.getCaption("strLastName", objCMS);
            lblLastNameArabic = dbLayer.getCaption("strLastNameArabic", objCMS);
            lblCountryCode = dbLayer.getCaption("strCountryCode", objCMS);
            lblMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
            lblEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
            lblPrefComm1 = dbLayer.getCaption("strPreferredCommunications", objCMS);
            lblJobTitle = dbLayer.getCaption("strJobTitle", objCMS);
            lblJobFunction = dbLayer.getCaption("strJobFunction", objCMS);
            lblPassword = dbLayer.getCaption("strPassword", objCMS);
            lblConfirmPassword = dbLayer.getCaption("strConfirmPassword", objCMS);

            MsgFirstName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgFirstNameArm = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgLastName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgLastNameArm = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCountryCode = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgMobileNumber = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgEmailAddress = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgEmailValid = dbLayer.getCaption("strEmailpattern", objCMSMSG);
            MsgPrefComm = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgjobTitle = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgJobFunction = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgPassword = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgConfirmPassword = dbLayer.getCaption("strNotmatch", objCMSMSG);
            MsgConfirmPass = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgMobileLength = dbLayer.getCaption("strEmailpattern", objCMSMSG);

            #endregion

            #region Page 3 Captions

            lblNationalAddress2 = dbLayer.getCaption("strNationalAddress", objCMS);
            lblCountry = dbLayer.getCaption("strCountry", objCMS);
            lblBuildingNo = dbLayer.getCaption("strBuildingNo", objCMS);
            lblUnitNo = dbLayer.getCaption("strUnitNo", objCMS);
            lblStreetName = dbLayer.getCaption("strStreetName", objCMS);
            lblDistrictName = dbLayer.getCaption("strDistrictName", objCMS);
            lblCity = dbLayer.getCaption("strCity", objCMS);
            lblZipCode = dbLayer.getCaption("strZipCode", objCMS);
            lblAdditionalNo = dbLayer.getCaption("strAdditionalInformation", objCMS);
            lblTelephone = dbLayer.getCaption("strTelephone", objCMS);
            lblFax = dbLayer.getCaption("strFax", objCMS);

            MsgEmailNoUnique= dbLayer.getCaption("strAlreadyexists", objCMSMSG);
            MsgMobileNoUnique= dbLayer.getCaption("strAlreadyexists", objCMSMSG);
            MsgBuildingNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCountry = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgUnitNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgStreetName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgDistrictName = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCity = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgZipCode = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgAdditionalNo = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgTelephone = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgFax = dbLayer.getCaption("strMandatory", objCMSMSG);
            #endregion


            #region First Page Caption

            //lblCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
            //lblCustomerType = dbLayer.getCaption("strCustomerType", objCMS);
            //MsgCompanyName = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgCustomerType = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //lblFirstName1 = dbLayer.getCaption("strFirstName", objCMS);
            //lblLastName1 = dbLayer.getCaption("strLastName", objCMS);
            //lblMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
            //lblJobTitle = dbLayer.getCaption("strJobTitle", objCMS);
            // msgCompany.Text = dbLayer.getCaption("strMandatory", "");
            //MsgConfirmPassword = dbLayer.getCaption("strNotmatch", "", objCMSMSG);
            //lblCountryCode = dbLayer.getCaption("strCountryCode", objCMS);
            //MsgCountry = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgEmailAddress = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //lblEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
            //MsgFirstName = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgLastName = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgMobileNumber = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgPassword = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgConfirmPass = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //lblPrefComm1 = dbLayer.getCaption("strPreferredCommunications", objCMS);
            //lblJobFunction = dbLayer.getCaption("strJobFunction", objCMS);
            //lblPassword = dbLayer.getCaption("strPassword", objCMS);
            //lblConfirmPassword = dbLayer.getCaption("strConfirmPassword", objCMS);
            //lblFirstNameAr = dbLayer.getCaption("strFirstNameArabic", objCMS);
            //MsgFirstNameArm = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //lblLastNameArabic = dbLayer.getCaption("strLastNameArabic", objCMS);
            //MsgLastNameArm = dbLayer.getCaption("strMandatory", "", objCMSMSG);


            lblPersonalInformation2 = dbLayer.getCaption("strPersonalInformation", objCMS);
            PlaceFirstName = dbLayer.getCaption("strFirstName", objCMS);
            PlaceLastName = dbLayer.getCaption("strLastName", objCMS);
            PlaceMobileNumber = dbLayer.getCaption("strMobileNumber", objCMS);
            MsgPagevise = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
            MsgPagevise3 = dbLayer.getCaption("strPleaseCheckMandatory", objCMSMSG);
            PlaceEmailAddress = dbLayer.getCaption("strEmailAddress", objCMS);
            PlaceJobTitle = dbLayer.getCaption("strJobTitle", objCMS);
            PlaceConfirmPassword = dbLayer.getCaption("strConfirmPassword", objCMS);
            PlacePassword = dbLayer.getCaption("strPassword", objCMS);
            BtnNext = dbLayer.getCaption("strNEXT", objCMS);
            BtnUpdate = dbLayer.getCaption("strUpdate", objCMS);
            PlaceFirstName1 = dbLayer.getCaption("strFirstNameArabic", objCMS);
            PlaceLastName1 = dbLayer.getCaption("strLastNameArabic", objCMS);
            PicCountryCode = dbLayer.getCaption("strCountryMobCode", objCMS);
            PicPrefComm = dbLayer.getCaption("strPreferredCommunication", objCMS);
            PicJobFunction = dbLayer.getCaption("strJobFunction", objCMS);
            lobjCountryCodee = dbLayer.getEnum("strCountryMobCode", objCMS);
            lobjPrefComm = dbLayer.getEnum("strPrefCommLov", objCMS);
            lobjJobFunction = dbLayer.getEnum("strJobFunctionLOV", objCMS);
            MsgEmailValid = dbLayer.getCaption("strEmailpattern", objCMSMSG);

            string strHi = dbLayer.getCaption("strHi", objCMS);

            lblFirstName = strHi + gblRegisteration.strFirstName;
            if (App.gblLanguage == "Ar")
            {
                lblFirstName = strHi + gblRegisteration.strFirstName1;
            }
            //  await Task.Delay(2000);
            //defaultActivityIndicator.IsRunning = false;
            //defaultActivityIndicator.IsVisible = false;

            #endregion

            #region Second Page Caption



            lblCompanyInformation2 = dbLayer.getCaption("strCompanyInformation", objCMS);

            btnPreviousP2 = dbLayer.getCaption("strPrevious", objCMS);
            btnNextP2 = dbLayer.getCaption("strNEXT", objCMS);
            btnUpdateP2 = dbLayer.getCaption("strUpdate", objCMS);
            //lblCompanyType = dbLayer.getCaption("strCompanyType", objCMS);

            PicCompanyType = dbLayer.getCaption("strCustomerType", objCMS);
            //MsgjobTitle = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgJobfunction = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            lobjCompanyType = dbLayer.getEnum("strCompanyTypeLOV", objCMS);

            #endregion

            #region Third Page Caption

            //lblNationalAddress2 = dbLayer.getCaption("strNationalAddress", objCMS);
            //MsgCountry = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgBuildingNo = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgUnitNo = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgStreetName = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgDistrictName = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgAdditionalNo = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //MsgTelephone = dbLayer.getCaption("strMandatory", "", objCMSMSG);
            //lblCountry = dbLayer.getCaption("strCountry", objCMS);
            //lblBuildingNo = dbLayer.getCaption("strBuildingNo", objCMS);
            //lblUnitNo = dbLayer.getCaption("strUnitNo", objCMS);
            //lblStreetName = dbLayer.getCaption("strStreetName", objCMS);
            //lblDistrictName = dbLayer.getCaption("strDistrictName", objCMS);
            //lblCity = dbLayer.getCaption("strCity", objCMS);
            //lblZipCode = dbLayer.getCaption("strZipCode", objCMS);
            //lblAdditionalNo = dbLayer.getCaption("strAdditionalInformation", objCMS);
            //lblTelephone = dbLayer.getCaption("strTelephone", objCMS);
            //lblFax = dbLayer.getCaption("strFax", objCMS);


            PlaceBuildingNo = dbLayer.getCaption("strBuildingNo", objCMS);
            PlaceUnitNo = dbLayer.getCaption("strUnitNo", objCMS);
            PlaceStreetName = dbLayer.getCaption("strStreetName", objCMS);
            PlaceDistrictName = dbLayer.getCaption("strDistrictName", objCMS);
            PlaceZipCode = dbLayer.getCaption("strZipCode", objCMS);
            PlaceAdditionalNo = dbLayer.getCaption("strAdditionalNo", objCMS);
            PlaceTelephone = dbLayer.getCaption("strTelephone", objCMS);
            PlaceFax = dbLayer.getCaption("strFax", objCMS);
            btnUpdateP3 = dbLayer.getCaption("strUpdate", objCMS);
            btnNextP3 = dbLayer.getCaption("strNEXT", objCMS);
            btnPreviousP3 = dbLayer.getCaption("strPrevious", objCMS);
            MsgCity = dbLayer.getCaption("strMandatory", objCMSMSG);
            PicCountry = dbLayer.getCaption("strCountry", objCMS);
            PicCity = dbLayer.getCaption("strCitys", objCMS);
            lobjCountry = dbLayer.getEnum("strCountryCodegrid", objCMS);
            lobjCity = dbLayer.getEnum("strCitygrid", objCMS);


            #endregion

            #region Fourth Page Caption

            //lblNationalIDNo = dbLayer.getCaption("strNationalAddress", objCMS);
            //lblLicenseNo = dbLayer.getCaption("strImportExportLicenseNo", objCMS);
            //MsgIdNo = dbLayer.getCaption("strMandatory", "", objCMSMSG);

            lblAdditionalInformation2 = dbLayer.getCaption("strAdditionalInformation", objCMS);
            PlaceImpExpLicNo = dbLayer.getCaption("strImportExportLicenseNo", objCMS);
            PlaceIdNo = dbLayer.getCaption("strIDNo", objCMS);
            btnPreviousP4 = dbLayer.getCaption("strPrevious", objCMS);
            btnUpdateP4 = dbLayer.getCaption("strUpdate", objCMS);
            btnOk = dbLayer.getCaption("strok", objCMS);



            #endregion


        }
        /// <summary>
        /// To fetch Data
        /// </summary>
        /// <returns></returns>
        private async Task fetchData()
        {
            try
            {
                TxtFirstName = gblRegisteration.strFirstName;
                TxtFirstName1 = gblRegisteration.strFirstName1;
                TxtLastName1 = gblRegisteration.strLastName1;
                TxtLastName = gblRegisteration.strLastName;
                TxtMobileNumber = gblRegisteration.strMobileNO;
                TxtJobTitle = gblRegisteration.strJobTitle.Trim();
                TxtEmailAddress = gblRegisteration.strEmailAddress;
                TxtPassword = gblRegisteration.strPassWord;
                TxtConfirmPassword = gblRegisteration.strConfirmPassword;
                TxtCompanyName = gblRegisteration.strCompanyName;
                //if (gblRegisteration.strCountryCode != null) picCountryCode.SelectedIndex = getSelectedIndex("Country", gblRegisteration.strCountryCode);
                //if (gblRegisteration.strPreCommun != null) picPrefComm.SelectedIndex = getSelectedIndex("PreCom", gblRegisteration.strPreCommun);
                //if (gblRegisteration.strJobFunction != null) picJobFunction.SelectedIndex = getSelectedIndex("Jobfunc", gblRegisteration.strJobFunction);
                if (gblRegisteration.strCountryCode != null)
                {
                    SelectedCountryCode = lobjCountryCodee.First(item => item.Value.ToUpper() == gblRegisteration.strCountryCode.ToUpper().Trim());
                }
                if (gblRegisteration.strPreCommun != null)
                {
                    SelectedPrefComm = lobjPrefComm.First(item => item.Value.ToUpper() == gblRegisteration.strPreCommun.ToUpper().Trim());
                }
                if (gblRegisteration.strJobFunction != null)
                {
                    SelectedJobFunction = lobjJobFunction.First(item => item.Value.ToUpper() == gblRegisteration.strJobFunction.ToUpper().Trim());
                }
                if ((gblRegisteration.strCompanyType != null) && (gblRegisteration.strCompanyType != ""))//20230420 Gokul
                {
                    SelectedCompanyType = lobjCompanyType.First(item => item.Value.ToUpper() == gblRegisteration.strCompanyType.ToUpper().Trim());
                }
                //picCountry.SelectedIndex = getSelectedIndex("Country", gblRegisteration.strCountry);
                if ((gblRegisteration.strBulidingNo != null) && (gblRegisteration.strBulidingNo != ""))
                {
                    TxtBuildingNo = gblRegisteration.strBulidingNo.ToString();
                }
                if ((gblRegisteration.strUnitNo != null) && (gblRegisteration.strUnitNo != ""))
                {
                    TxtUnitNo = gblRegisteration.strUnitNo.ToString();
                }
                if ((gblRegisteration.strStreetName != null) && (gblRegisteration.strStreetName != ""))
                {
                    TxtStreetName = gblRegisteration.strStreetName;
                }
                if ((gblRegisteration.strdistrictName1 != null) && (gblRegisteration.strdistrictName1 != ""))
                {
                    TxtDistrictName = gblRegisteration.strdistrictName1;
                }
                if ((gblRegisteration.strZipCode != null) && (gblRegisteration.strZipCode != ""))
                {
                    TxtZipCode = gblRegisteration.strZipCode;
                }
                if ((gblRegisteration.strAdditionalNo != null) && (gblRegisteration.strAdditionalNo != ""))
                {
                    TxtAdditionalNo = gblRegisteration.strAdditionalNo;
                }
                if ((gblRegisteration.strTelePhoneNo != null) && (gblRegisteration.strTelePhoneNo != ""))
                {
                    TxtTelephone = gblRegisteration.strTelePhoneNo;
                }
                if ((gblRegisteration.strFax != null) && (gblRegisteration.strFax != ""))
                {
                    TxtFax = gblRegisteration.strFax;
                }
                if (gblRegisteration.strCountry != null)
                {
                    SelectedCountry = lobjCountry.First(item => item.Value.ToUpper() == gblRegisteration.strCountry.ToUpper().Trim());
                }
                if (gblRegisteration.strCityName != null)
                {
                    SelectedCity = lobjCity.First(item => item.Value.ToUpper() == gblRegisteration.strCityName.ToUpper().Trim());
                }
                TxtIdNo = gblRegisteration.strIdNo;
                TxtImpExpLicNo = gblRegisteration.strImpExpLisNo;
                TxtlicenceNo2 = gblRegisteration.strAdditionalNO2;
                TxtlicenceNo3 = gblRegisteration.strAdditionalNO3;
                TxtlicenceNo4 = gblRegisteration.strAdditionalNO4;
                TxtlicenceNo5 = gblRegisteration.strAdditionalNO5;
                TxtlicenceNo6 = gblRegisteration.strAdditionalNO6;
                TxtlicenceNo7 = gblRegisteration.strAdditionalNO7;
                TxtlicenceNo8 = gblRegisteration.strAdditionalNO8;
                TxtlicenceNo9 = gblRegisteration.strAdditionalNO9;
                TxtlicenceNo10 = gblRegisteration.strAdditionalNO10;
                if (gblRegisteration.strCusType != null)
                {
                    SelectedCustomerType = lobjCustomerType.First(item => item.Value.ToUpper() == gblRegisteration.strLoginCustomerType.ToUpper().Trim());
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        // Page3 Captions
        //placeUnitNo purpose of using Placeholder
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
        //placeDistrictName purpose of using Placeholder
        private string placeDistrictName = "";
        public string PlaceDistrictName
        {
            get { return placeDistrictName; }
            set
            {
                placeDistrictName = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceDistrictName");
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
        //placeAdditionalNo purpose of using textbox Placeholder
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
        private bool isvalidatedjobTitle = false;

        public bool IsvalidatedJobtitle
        {
            get { return isvalidatedjobTitle; }
            set
            {
                isvalidatedjobTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedJobtitle");
            }
        }
        private string msgJobtitle = "";

        public string MsgjobTitle
        {
            get { return msgJobtitle; }
            set
            {
                msgJobtitle = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgjobTitle");
            }
        }

        private bool isvalidatedjobFunction = false;

        public bool IsvalidatedJobfunction
        {
            get { return isvalidatedjobFunction; }
            set
            {
                isvalidatedjobFunction = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedJobfunction");
            }
        }
        //private string msgJobfunction = "";

        //public string MsgJobfunction
        //{
        //    get { return msgJobfunction; }
        //    set
        //    {
        //        msgJobfunction = value;
        //        OnPropertyChanged();
        //        RaisePropertyChange("MsgJobfunction");
        //    }
        //}

        // Page 4 Captions
        /// <summary>
        /// To handle Boolean variable
        /// </summary>
        private bool pageFooter4 = true;
        public bool PageFooter4
        {
            get { return pageFooter4; }
            set
            {
                pageFooter4 = value;
                OnPropertyChanged();
                RaisePropertyChange("PageFooter4");
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
        //btnupdateP4 purpose of using Button
        private string btnupdateP4 = "";
        public string btnUpdateP4
        {
            get { return btnupdateP4; }
            set
            {
                btnupdateP4 = value;
                OnPropertyChanged();
                RaisePropertyChange("btnUpdateP4");
            }
        }
        //picCustomerType purpose of using Image
        private string picCustomerType = "";
        public string PicCustomerType
        {
            get { return picCustomerType; }
            set
            {
                picCustomerType = value;
                OnPropertyChanged();
                RaisePropertyChange("PicCustomerType");
            }
        }
        private bool _IsvalidatedIDNoExist = false;
        public bool IsvalidatedIDNoExist
        {
            get { return _IsvalidatedIDNoExist; }
            set
            {
                _IsvalidatedIDNoExist = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedIDNoExist");
            }
        }
        /// <summary>
        /// To Go My Profile
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage2()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                Entry emailEntry = Myview.FindByName<Entry>("FocusFirstName");
                emailEntry.Focus();
                HideValidatedErrMsg();
                bool blResult = validation4FirstPage();
                if (blResult == true)
                {
                    HideStack(2);
                }
                else
                {
                    Pagevise1 = true;
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Get validation4FirstPage Function
        /// </summary>
        /// <returns></returns>
        private bool validation4FirstPage()
        {
            HideValidatedErrMsg();

            //  HideStack(3);
            bool Result = true;
            try
            {

                gblRegisteration.strActiveStatus = false;
                HideValidatedErrMsg();
                // string strGetValueCusType = "";
                string strSelectedValueCusType = "";

                strSelectedValueCusType = _selectedCustomerType.Value;

                if (TxtCompanyName == null || TxtCompanyName == "")
                {
                    Result = false;
                    IsvalidatedCompanyName = true;
                }
                else
                {
                    IsvalidatedCompanyName = false;
                }
                if (gblRegisteration.strCusType.Trim().ToUpper() != strSelectedValueCusType.Trim().ToUpper())
                {
                    
                    gblRegisteration.strActiveStatus = true;
                }

                if (gblRegisteration.strIdNo != TxtIdNo)
                {
                  
                    gblRegisteration.strActiveStatus = true;
                    if (TxtIdNo != null || TxtIdNo != "") //20230125
                    {
                        var ValidateId1 = ValidateUniqConstraints(TxtIdNo);
                        if (ValidateId1 == true)
                        {
                            Result = false;
                            IsvalidatedIDNoExist = true;
                        }
                    }
                }

                if (TxtIdNo == null || TxtIdNo == "")
                {
                    Result = false;
                    IsvalidatedIDNo = true;
                }
                else
                {
                    IsvalidatedIDNo = false;
                }


                if (gblRegisteration.strImpExpLisNo != TxtImpExpLicNo)
                {
                    
                    gblRegisteration.strActiveStatus = true;
                }

                if (TxtImpExpLicNo == null || TxtImpExpLicNo == "")
                {
                    Result = false;
                    IsvalidatedLicNo = true;
                }
                else
                {
                    IsvalidatedLicNo = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            return Result;
        }
        /// <summary>
        /// To hide Validation Error Message
        /// </summary>
        private void HideValidatedErrMsg()
        {
            try
            {
                IsvalidatedConfirmPassword = false;
                IsvalidatedConfirmPass = false;
                IsvalidatedPassword = false;
                IsvalidatedEmail = false;
                IsvalidatedEmailID = false;
                IsvalidatedPrefComm = false;
                IsvalidatedCompanyType = false;
                //  isvalidatedCountry = false;
                IsvalidatedMobileNo = false;
                IsvalidatedLastName = false;
                IsvalidatedFirstname = false;
                IsvalidatedFirstNameAr = false;
                IsvalidatedLastNameArabic = false;
                Pagevise3 = false;
                IsvalidatedCountry = false;
                Isvalidatedfax = false;
                IsvalidatedBuildingNo = false;
                IsvalidatedUnitNo = false;
                IsvalidatedstreetName = false;
                IsvalidatedDistrict = false;
                IsvalidatedZipCode = false;
                IsvalidatedAdditionalNo = false;
                IsvalidatedTelephone = false;
                IsvalidatedCountryCode = false;
                IsvalidatedCity = false;
                IsvalidatedCustomerType = false;
                IsvalidatedIDNo = false;
                IsvalidatedLicNo = false;
                IsvalidatedJobtitle = false;
                IsvalidatedJobfunction = false;
                IsvalidatedCompanyName = false;
                IsvalidatedMobileLength = false;
                IsvalidatedMobileNoExist = false;
                IsvalidatedEmailID = false;
                IsvalidatedIDNoExist = false;
                IsvalidatedEmailNoExist = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Go to My Update
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage1Update()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                HideValidatedErrMsg();
                bool blResult = validation4FirstPage();
                if (blResult == true)
                {
                    await updateMyprofile();
                    if (gblRegisteration.strActiveStatus == true)
                    {

                       
                        await App.Current.MainPage?.Navigation.PushAsync(new MyprofileNotifiction());
                    }
                    else
                    {

                        string lstrResult = objWebApi.putWebApi("UpdateRegisterUser", gblRegisteration.NewUserRegistration("MODIFY"), gblRegisteration.strLoginUser);
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                            App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        if (lstrResult == "true")
                        {
                            await App.Current.MainPage?.Navigation.PushAsync(new MyProfileMessagePage());
                        }
                    }
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        private bool _IsvalidatedMobileNoExist = false;
        public bool IsvalidatedMobileNoExist
        {
            get { return _IsvalidatedMobileNoExist; }
            set
            {
                _IsvalidatedMobileNoExist = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedMobileNoExist");
            }
        }
        private bool _IsvalidatedEmailNoExist = false;
        public bool IsvalidatedEmailNoExist
        {
            get { return _IsvalidatedEmailNoExist; }
            set
            {
                _IsvalidatedEmailNoExist = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedEmailNoExist");
            }
        }
        private string _MsgEmailNoUnique = "";
        public string MsgEmailNoUnique
        {
            get { return _MsgEmailNoUnique; }
            set
            {
                _MsgEmailNoUnique = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgEmailNoUnique");
            }
        }
        /// <summary>
        /// To Get updateMyprofile Function
        /// </summary>
        /// <returns></returns>
        private async Task updateMyprofile()
        {
            try
            {
                gblRegisteration.strFirstName = TxtFirstName;
                gblRegisteration.strLoginFirstName = TxtFirstName;
                gblRegisteration.strLastName = TxtLastName;
                gblRegisteration.strFirstName1 = TxtFirstName1;
                gblRegisteration.strLoginFirstName1 = TxtFirstName1;
                gblRegisteration.strLastName1 = TxtLastName1;
                gblRegisteration.strMobileNO = TxtMobileNumber;
                gblRegisteration.strPreCommun = _selectedPrefComm.Value;
                gblRegisteration.strCountryCode = _selectedCountryCode.Value;
                gblRegisteration.strJobFunction = _selectedJobFunction.Value;
                gblRegisteration.strEmailAddress = TxtEmailAddress;
                gblRegisteration.strPassWord = TxtPassword;
                gblRegisteration.strJobTitle = TxtJobTitle;
                gblRegisteration.strCompanyType = _selectedCompanyType.Value;
                gblRegisteration.strCompanyName = TxtCompanyName;
                gblRegisteration.strBulidingNo = TxtBuildingNo;
                gblRegisteration.strUnitNo = TxtUnitNo;
                gblRegisteration.strStreetName = TxtStreetName;
                gblRegisteration.strdistrictName1 = TxtDistrictName;
                gblRegisteration.strZipCode = TxtZipCode;
                gblRegisteration.strAdditionalNo = TxtAdditionalNo;
                gblRegisteration.strTelePhoneNo = TxtTelephone;
                gblRegisteration.strFax = TxtFax;
                gblRegisteration.strCountry = _selectedCountry.Value;
                gblRegisteration.strCityName = _selectedCity.Value;
                gblRegisteration.strBulidingNo = TxtBuildingNo;
                gblRegisteration.strUnitNo = TxtUnitNo;
                gblRegisteration.strStreetName = TxtStreetName;
                gblRegisteration.strdistrictName1 = TxtDistrictName;
                gblRegisteration.strZipCode = TxtZipCode;
                gblRegisteration.strAdditionalNo = TxtAdditionalNo;
                gblRegisteration.strCusType = _selectedCustomerType.Value;
                gblRegisteration.strTelePhoneNo = TxtTelephone;
                gblRegisteration.strFax = TxtFax;
                gblRegisteration.strCountry = _selectedCountry.Value;
                gblRegisteration.strCityName = _selectedCity.Value;
                gblRegisteration.strIdNo = TxtIdNo;
                gblRegisteration.strImpExpLisNo = TxtImpExpLicNo;
                gblRegisteration.strAdditionalNO2 = TxtlicenceNo2;
                gblRegisteration.strAdditionalNO3 = TxtlicenceNo3;
                gblRegisteration.strAdditionalNO4 = TxtlicenceNo4;
                gblRegisteration.strAdditionalNO5 = TxtlicenceNo5;
                gblRegisteration.strAdditionalNO6 = TxtlicenceNo6;
                gblRegisteration.strAdditionalNO7 = TxtlicenceNo7;
                gblRegisteration.strAdditionalNO8 = TxtlicenceNo8;
                gblRegisteration.strAdditionalNO9 = TxtlicenceNo9;
                gblRegisteration.strAdditionalNO10 = TxtlicenceNo10;
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Go to My Profile
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage1()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                HideValidatedErrMsg();
                bool blResult = validateIdPage2();
                if (blResult == false)
                {

                    HideStack(1);
                }
                else
                {
                    HideStack(2);
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Go to My Update
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage2Update()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                HideValidatedErrMsg();

                //if (_selectedCompanyType != null)
                //{
                //    gblRegisteration.strCompanyType = _selectedCompanyType.Value;
                //}
                //gblRegisteration.strCompanyName = TxtCompanyName;
                bool blResult = validateIdPage2();
                if (blResult == false)
                {

                    await updateMyprofile();
                    if (gblRegisteration.strActiveStatus == true)
                    {
                       
                        await App.Current.MainPage?.Navigation.PushAsync(new MyprofileNotifiction());
                    }
                    else
                    {


                        string lstrResult = objWebApi.putWebApi("UpdateRegisterUser", gblRegisteration.NewUserRegistration("MODIFY"), gblRegisteration.strLoginUser);
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                            App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                        }
                        if (lstrResult == "true")
                        {
                            //As per Mr.Raju Advice 20220909
                            await App.Current.MainPage?.Navigation.PushAsync(new MyProfileMessagePage());
                        }
                    }
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                if (ex.Message == "One or more errors occurred. (A task was canceled.)")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 3000);
                }
                else
                {
                    App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
                }
            }
        }
        /// <summary>
        /// To Go My Profile
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage3()
        {

            IsBusy = true;
            StackMyProfile = false;
            await Task.Delay(1000);

            validateIdPage2();
            StackMyProfile = true;
            IsBusy = false;


        }
        private bool validateIdPage2()
        {
            bool blResult = false;
            try
            {
                if ((TxtFirstName == null) || (TxtFirstName == ""))
                {
                    blResult = true;
                    IsvalidatedFirstname = true;
                }
                else
                {
                    IsvalidatedFirstname = false;
                }

                if ((TxtLastName == null) || (TxtLastName == ""))
                {
                    blResult = true;
                    IsvalidatedLastName = true;
                }
                else
                {
                    IsvalidatedLastName = false;
                }
                if ((TxtFirstName1 == null) || (TxtFirstName1 == ""))
                {
                    blResult = true;
                    IsvalidatedFirstNameAr = true;
                }
                else
                {
                    IsvalidatedFirstNameAr = false;
                }
                if ((TxtLastName1 == null) || (TxtLastName1 == ""))
                {
                    blResult = true;
                    IsvalidatedLastNameArabic = true;
                }
                else
                {
                    IsvalidatedLastNameArabic = false;
                }
                if ((TxtMobileNumber == null) || (TxtMobileNumber == ""))
                {
                    blResult = true;
                    IsvalidatedMobileNo = true;
                }
                else
                {
                    IsvalidatedMobileNo = false;
                }
                if ((TxtMobileNumber != null) && (TxtMobileNumber != ""))
                {

                    if (TxtMobileNumber.Length == 10)
                    {
                        IsvalidatedMobileLength = false;
                    }
                    else
                    {
                        blResult = true;
                        IsvalidatedMobileLength = true;
                    }
                }
                if(gblRegisteration.strMobileNO!= TxtMobileNumber)
                {
                  bool blResult1=  ValidateUniqConstraints(TxtMobileNumber);
                    if (blResult1 == true)
                    {
                        blResult = true;
                        IsvalidatedMobileNoExist = true;
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
                if ((TxtJobTitle == null) || (TxtJobTitle == ""))
                {
                    blResult = true;
                    IsvalidatedJobtitle = true;
                }
                else
                {
                    IsvalidatedJobtitle = false;
                }
                if (_selectedJobFunction != null)
                {
                    IsvalidatedJobfunction = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedJobfunction = true;
                }
                if (_selectedCountryCode != null)
                {
                    IsvalidatedCountryCode = false;
                }
                else
                {
                    blResult = true;
                    IsvalidatedCountryCode = true;
                }
                if ((TxtEmailAddress == null) || (TxtEmailAddress == ""))
                {
                    blResult = true;
                    IsvalidatedEmail = true;
                }
                else
                {
                    var email = TxtEmailAddress;
                    var emailpattern = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
                    if (!string.IsNullOrWhiteSpace(email) && !(Regex.IsMatch(email, emailpattern)))
                    {
                        blResult = true;
                        IsvalidatedEmailID = true;
                    }
                    else
                    {
                        IsvalidatedEmailID = false;
                    }
                }
                if(gblRegisteration.strEmailAddress!= TxtEmailAddress)
                {
                    bool blResult1 = ValidateUniqConstraints(TxtEmailAddress);
                    if (blResult1 == true)
                    {
                        blResult = true;
                        IsvalidatedEmailNoExist = true;
                    }
                }
                if ((TxtPassword == null) || (TxtPassword == ""))
                {
                    blResult = true;
                    IsvalidatedPassword = true;
                }
                else
                {
                    if ((TxtPassword == TxtConfirmPassword))
                    {
                        IsvalidatedPassword = false;
                    }
                    else
                    {
                        blResult = true;
                        //msgPassword.IsVisible = true;
                        IsvalidatedConfirmPassword = true;
                    }
                }

                if ((TxtConfirmPassword == null) || (TxtConfirmPassword == ""))
                {
                    blResult = true;

                    IsvalidatedConfirmPass = true;
                }
                else
                {
                    if ((TxtPassword == TxtConfirmPassword))
                    {
                        IsvalidatedPassword = false;
                    }
                    else
                    {
                        blResult = true;
                        //msgPassword.IsVisible = true;
                        IsvalidatedConfirmPassword = true;

                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            if (blResult == false)
            {
                HideStack(3);
            }
            return blResult;
        }


        /// <summary>
        /// To go to My Profile
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage3toPage2()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                bool blResult = updateRegUser();
                if (blResult == false)
                {
                    HideStack(2);
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go to My Profile
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage4()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                bool blResult = updateRegUser();
                if (blResult == false)
                {
                    HideStack(4);
                }
                else
                {
                    Pagevise3 = false;
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Update Registered User
        /// </summary>
        /// <returns></returns>
        private bool updateRegUser()
        {
            bool blResult = false;
            try
            {
                HideValidatedErrMsg();
               
                if (TxtBuildingNo == null || TxtBuildingNo == "")
                {
                    blResult = true;
                    IsvalidatedBuildingNo = true;
                }
                else
                {
                    IsvalidatedBuildingNo = false;
                }
                //if (TxtUnitNo == null || TxtUnitNo == "")
                //{
                //    blResult = true;
                //    IsvalidatedUnitNo = true;
                //}
                //else
                //{
                //    IsvalidatedUnitNo = false;
                //}
                if (TxtStreetName == null || TxtStreetName == "")
                {
                    blResult = true;
                    IsvalidatedstreetName = true;
                }
                else
                {
                    IsvalidatedstreetName = false;
                }
                //if (TxtDistrictName == null || TxtDistrictName == "")
                //{
                //    blResult = true;
                //    IsvalidatedDistrict = true;
                //}
                //else
                //{
                //    IsvalidatedDistrict = false;
                //}
                //if (TxtZipCode == null || TxtZipCode == "")
                //{
                //    blResult = true;
                //    IsvalidatedZipCode = true;
                //}
                //else
                //{
                //    IsvalidatedZipCode = false;
                //}
                //if (TxtAdditionalNo == null || TxtAdditionalNo == "")
                //{
                //    blResult = true;
                //    IsvalidatedAdditionalNo = true;
                //}
                //else
                //{
                //    IsvalidatedAdditionalNo = false;
                //}
                if (TxtTelephone == null || TxtTelephone == "")
                {
                    blResult = true;
                    IsvalidatedTelephone = true;
                }
                else
                {
                    IsvalidatedTelephone = false;
                }
                //if (TxtFax == null || TxtFax == "")
                //{
                //    blResult = true;
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
                    blResult = true;
                    IsvalidatedCountry = true;
                }
                if (_selectedCity != null)
                {
                    //gblRegisteration.strCityName = picCity.Items[picCity.SelectedIndex];
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            return blResult;
        }
        /// <summary>
        /// To go to Update
        /// </summary>
        /// <returns></returns>
        private async Task gotoPage3Update()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                HideValidatedErrMsg();
                bool blResult = true;
                if (TxtBuildingNo == null || TxtBuildingNo == "")
                {
                    IsvalidatedBuildingNo = true;
                }
                else
                {
                    blResult = true;
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
                    blResult = true;
                    IsvalidatedstreetName = false;
                }
                //if (TxtDistrictName == null || TxtDistrictName == "")
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
                    blResult = true;
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
                    blResult = true;
                    //gblRegisteration.strCountry = picCountry.Items[picCountry.SelectedIndex];
                }
                if (_selectedCity != null)
                {
                    blResult = true;
                    //gblRegisteration.strCityName = picCity.Items[picCity.SelectedIndex];
                }

                //(IsvalidatedAdditionalNo == false) &&&& (Isvalidatedfax == false) (IsvalidatedDistrict == false) && && (IsvalidatedUnitNo == false) && (IsvalidatedZipCode == false)
                if ((IsvalidatedBuildingNo == false) &&
                  (IsvalidatedstreetName == false) && (IsvalidatedTelephone == false))
                {
                    blResult = true;
                }
                if (blResult == true)
                {
                    await updateMyprofile();
                    if (gblRegisteration.strActiveStatus == true)
                    {
                        await App.Current.MainPage?.Navigation.PushAsync(new MyprofileNotifiction());
                    }
                    else
                    {
                        await updateMyprofile();

                        string lstrResult = objWebApi.putWebApi("UpdateRegisterUser", gblRegisteration.NewUserRegistration("MODIFY"), gblRegisteration.strLoginUser);
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                            App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        if (lstrResult == "true")
                        {
                            await App.Current.MainPage?.Navigation.PushAsync(new MyProfileMessagePage());
                        }
                    }
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Go to my Update
        /// </summary>
        /// <returns></returns>
        private async Task gotomyUpdate()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                string lstrResult = "";
                await Task.Delay(1000);
                update4RegUser();
                if (gblRegisteration.strActiveStatus == false)
                {
                    await Task.Delay(1000);
                    await updateMyprofile();

                    lstrResult = objWebApi.putWebApi("UpdateRegisterUser", gblRegisteration.NewUserRegistration("MODIFY"), gblRegisteration.strLoginUser);
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                        App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
                if (lstrResult == "true")
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new MyProfileMessagePage());
                }
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To Update Register User
        /// </summary>
        private void update4RegUser()
        {

        }
        /// <summary>
        /// To handle Boolean variable
        /// </summary>
        /// <param name="fstrInput"></param>
        /// <returns></returns>
        private bool ValidateUniqConstraints(string fstrInput)
        {
            bool lstrResult = false;
            try
            {
                List<clsREGISTEREDUSERS> lstReguser = new List<clsREGISTEREDUSERS>();
                lstReguser = objBl.getValidateUserDetails(fstrInput);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                    App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (lstReguser.Count > 0)
                {
                    lstrResult = true;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            return lstrResult;
        }
        /// <summary>
        /// stepText1 purpose of using textbox variable
        /// </summary>
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
        /// <summary>
        /// stepText2 purpose of using textbox variable
        /// </summary>
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
        /// <summary>
        /// stepText3 purpose of using textbox variable
        /// </summary>
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
        /// <summary>
        /// stepText4 purpose of using textbox variable
        /// </summary>
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
        //stepactive1 purpose of using Color
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
        //stepactive2 purpose of using Color
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
        //stepactive3 purpose of using Color
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
        //Stepactive4 purpose of using Color
        public string stepactive4 = "";
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
        /// <summary>
        /// To Get HideStack
        /// </summary>
        /// <param name="lintCurrentPageNo"></param>
        /// <returns></returns>
        public int HideStack(int lintCurrentPageNo)
        {
            try
            {
                switch (lintCurrentPageNo)
                {
                    case 1:
                        Page2 = Page3 = PageFooter2 = PageFooter3 = false;
                        Page1 = true;
                        PageHeader = true;
                        PageFooter1 = true;
                        Stepactive1 = "#0073a2";
                        Stepactive2 = "#FFFFFF";
                        Stepactive3 = "#FFFFFF";
                        Stepactive4 = "#FFFFFF";
                        StepText1 = "#FFFFFF";
                        StepText2 = "#0073a2";
                        StepText3 = "#0073a2";
                        StepText4 = "#0073a2";
                        return 1;
                    case 2:
                        Page1 = Page3 = PageFooter1 = PageFooter3 = false;
                        Page2 = true;
                        PageHeader = true;
                        PageFooter2 = true;
                        Stepactive1 = "#FFFFFF";
                        Stepactive2 = "#0073a2";
                        Stepactive3 = "#FFFFFF";
                        Stepactive4 = "#FFFFFF";
                        StepText1 = "#0073a2";
                        StepText2 = "#FFFFFF";
                        StepText3 = "#0073a2";
                        StepText4 = "#0073a2";
                        return 1;
                    case 3:
                        Page1 = Page2 = PageFooter1 = PageFooter2 = false;
                        Page3 = true;
                        PageHeader = true;
                        PageFooter3 = true;
                        Stepactive1 = "#FFFFFF";
                        Stepactive2 = "#FFFFFF";
                        Stepactive3 = "#0073a2";
                        Stepactive4 = "#FFFFFF";
                        StepText1 = "#0073a2";
                        StepText2 = "#0073a2";
                        StepText3 = "#FFFFFF";
                        StepText4 = "#0073a2";
                        Entry BuildingNo = Myview.FindByName<Entry>("FocusBuildingNo");
                        BuildingNo.Focus();
                        return 1;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            return 1;
        }
        /// <summary>
        /// To Assign List
        /// </summary>
        /// <returns></returns>
        private async Task ExpandLicenceNodiv()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                LicenceNodiv = true;
                await Task.Delay(1000);
                Entry FocusTxtIdNo = Myview.FindByName<Entry>("Focuslicence10");
                FocusTxtIdNo.Focus();
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            IsBusy = false;
            StackMyProfile = true;

        }
        /// <summary>
        /// To Go registration
        /// </summary>
        /// <returns></returns>
        private async Task goto_REG()
        {
            try
            {
                IsBusy = true;
                StackMyProfile = false;
                await Task.Delay(1000);
                LicenceNodiv = false;
                StackMyProfile = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}