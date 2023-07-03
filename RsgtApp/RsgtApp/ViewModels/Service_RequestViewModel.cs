using Microsoft.AppCenter.Analytics;
using Plugin.FilePicker;
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
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    class Service_RequestViewModel: INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //To declare variable
        public string strCategoryCode = "";
        public string strServerSlowMsg = "";
        //To declare combo variable
        private List<EnumCombo> _lobjCategory = new List<EnumCombo>();
        public List<EnumCombo> lobjCategory
        {
            get { return _lobjCategory; }
            set
            {
                if (_lobjCategory == value)
                    return;
                _lobjCategory = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCategory");
            }
        }
        //To declare combo variable
        private List<EnumCombo> _lobjCaseType = new List<EnumCombo>();
        public List<EnumCombo> lobjCaseType
        {
            get { return _lobjCaseType; }
            set
            {
                if (_lobjCaseType == value)
                    return;
                _lobjCaseType = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCaseTypes");
            }
        }
        //To declare combo variable
        private List<EnumCombo> _lobjSubType = new List<EnumCombo>();
        public List<EnumCombo> lobjSubType
        {
            get { return _lobjSubType; }
            set
            {
                if (_lobjSubType == value)
                    return;
                _lobjSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCaseTypes");
            }
        }
        //GotoChooseFile button
        public Command GotoChooseFile { get; set; }
        //gotoCancel button
        public Command gotoCancel { get; set; }
        //Button_send_Message button
        public Command Button_send_Message { get; set; }
        //To declare Variables
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
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
        //To declare Setproperty
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
        // Two way binding  IndicatorViewBGColor process on Propertychange Event
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
            }
        }
        // Two way binding  IndicatorViewBGColor process on Propertychange Event
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
            }
        }
        //To Declare combo variable
        private EnumCombo _selectedCaseType;
        public EnumCombo SelectedCaseType
        {
            get { return _selectedCaseType; }
            set
            {
                SetProperty(ref _selectedCaseType, value);
                if (SelectedCaseType != null)
                {
                    SubCaseFilterData(strCategoryCode, SelectedCaseType.Value);//SubcaseFilter
                }
            }
        }
        //To Declare combo variable
        private EnumCombo _selectedSubType;
        public EnumCombo SelectedSubType
        {
            get { return _selectedSubType; }
            set
            {
                SetProperty(ref _selectedSubType, value);
            }
        }
        //To declare boolean variable
        private bool serviceEn = true;
        public bool ServiceEn
        {
            get { return serviceEn; }
            set
            {
                serviceEn = value;
                OnPropertyChanged();
                RaisePropertyChange("ServiceEn");
            }
        }
        //imgrequestsService purpose of using image varaiable
        private string imgrequestsService = "";
        public string imgRequestsService
        {
            get { return imgrequestsService; }
            set
            {
                imgrequestsService = value;
                OnPropertyChanged();
                RaisePropertyChange("imgRequestsService");
            }
        }
        //lblrequestService purpose of using label varaiable
        private string lblrequestService = "";
        public string lblRequestService
        {
            get { return lblrequestService; }
            set
            {
                lblrequestService = value;
                OnPropertyChanged();
                RaisePropertyChange("lblRequestService");
            }
        }
        //lbltitle purpose of using label varaiable
        private string lbltitle = "";
        public string lblTitle
        {
            get { return lbltitle; }
            set
            {
                lbltitle = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTitle");
            }
        }
        //txtTitle purpose of using text varaiable
        private string txtTitle = "";
        public string TxtTitle
        {
            get { return txtTitle; }
            set
            {
                txtTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTitle");
            }
        }
        //placeTitle purpose of using data varaiable
        private string placeTitle = "";
        public string PlaceTitle
        {
            get { return placeTitle; }
            set
            {
                placeTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTitle");
            }
        }
        //msgTitle purpose of using data varaiable
        private string msgTitle = "";
        public string MsgTitle
        {
            get { return msgTitle; }
            set
            {
                msgTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgTitle");
            }
        }
        //lblcaseType purpose of using label varaiable
        private string lblcaseType = "";
        public string lblCaseType
        {
            get { return lblcaseType; }
            set
            {
                lblcaseType = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCaseType");
            }
        }
        //msgCase purpose of using data varaiable
        private string msgCase = "";
        public string MsgCase
        {
            get { return msgCase; }
            set
            {
                msgCase = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCase");
            }
        }
        //lblcaseSubType purpose of using label varaiable
        private string lblcaseSubType = "";
        public string lblCaseSubType
        {
            get { return lblcaseSubType; }
            set
            {
                lblcaseSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCaseSubType");
            }
        }
        //msgCaseSubType purpose of using data varaiable
        private string msgCaseSubType = "";
        public string MsgCaseSubType
        {
            get { return msgCaseSubType; }
            set
            {
                msgCaseSubType = value;
                OnPropertyChanged();
                RaisePropertyChange("MsgCaseSubType");
            }
        }
        //lblmessage purpose of using label varaiable
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
        //txtMessage purpose of using text varaiable
        private string txtMessage = "";
        public string TxtMessage
        {
            get { return txtMessage; }
            set
            {
                txtMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtMessage");
            }
        }
        //placeMessage purpose of using data varaiable
        private string placeMessage = "";
        public string PlaceMessage
        {
            get { return placeMessage; }
            set
            {
                placeMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceMessage");
            }
        }
        //lblattach purpose of using label varaiable
        private string lblattach = "";
        public string lblAttach
        {
            get { return lblattach; }
            set
            {
                lblattach = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttach");
            }
        }
        //btnchooseFile purpose of using button varaiable
        private string btnchooseFile = "";
        public string btnChooseFile
        {
            get { return btnchooseFile; }
            set
            {
                btnchooseFile = value;
                OnPropertyChanged();
                RaisePropertyChange("btnChooseFile");
            }
        }
        //imgcancel purpose of using image varaiable
        private string imgcancel = "";
        public string imgCancel
        {
            get { return imgcancel; }
            set
            {
                imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("imgCancel");
            }
        }
        //lblfilename purpose of using label varaiable
        private string lblfilename = "";
        public string lblFilename
        {
            get { return lblfilename; }
            set
            {
                lblfilename = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFilename");
            }
        }
        //btnsubmit purpose of using button varaiable
        private string btnsubmit = "";
        public string btnSubmit
        {
            get { return btnsubmit; }
            set
            {
                btnsubmit = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSubmit");
            }
        }
        //To declare boolean variable
        private bool isvalidatedTitle = false;
        public bool IsvalidatedTitle
        {
            get { return isvalidatedTitle; }
            set
            {
                isvalidatedTitle = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedTitle");
            }
        }
        //To declare boolean variable
        private bool isvalidatedCase = false;
        public bool IsvalidatedCase
        {
            get { return isvalidatedCase; }
            set
            {
                isvalidatedCase = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedCase");
            }
        }
        //To declare boolean variable
        private bool isvalidatedSubCase = false;
        public bool IsvalidatedSubCase
        {
            get { return isvalidatedSubCase; }
            set
            {
                isvalidatedSubCase = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvalidatedSubCase");
            }
        }
        //To declare boolean variable
        private bool Lblfilename = false;
        public bool LblFilename
        {
            get { return Lblfilename; }
            set
            {
                Lblfilename = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFilename");
            }
        }
        //To declare boolean variable
        private bool Imgcancel = false;
        public bool ImgCancel
        {
            get { return Imgcancel; }
            set
            {
                Imgcancel = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCancel");
            }
        }
        //To declare boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                GotoChooseFile.ChangeCanExecute();
                gotoCancel.ChangeCanExecute();
                Button_send_Message.ChangeCanExecute();
            }
        }
        //To declare boolean variable
        bool ischoosefile = true;
        public bool Ischoosefile
        {
            get { return ischoosefile; }
            set
            {
                ischoosefile = value;
                OnPropertyChanged();
                RaisePropertyChange("Ischoosefile");
            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public Service_RequestViewModel()
        {
            try
            { 
            //Appcenter Track Event handler
            Analytics.TrackEvent("Service_RequestViewModel");
            //To Call Caption Function 
            Task.Run(() => assignCms()).Wait();
            //Begin call Command Buttons
            GotoChooseFile = new Command(async () => await gotoChooseFile(), () => !IsBusy);
            gotoCancel = new Command(async () => await gotocancel(), () => !IsBusy);
            Button_send_Message = new Command(async () => await button_send_Message(), () => !IsBusy);
                //To end call of Command Buttons
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End Service Request ViewModel Constructor 
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM416");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM416");
                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignCms function
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            try
            { 
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
          
            dbLayer.objInfoitems = objCMS;
            imgRequestsService = dbLayer.getCaption("imgRequestService", objCMS);
            lblRequestService = dbLayer.getCaption("strRequestforserviceform", objCMS);
            lblTitle = dbLayer.getCaption("strTitle", objCMS);
            lblCaseType = dbLayer.getCaption("strCasetype1", objCMS);
            lblCaseSubType = dbLayer.getCaption("strSubject", objCMS);
            lblMessage = dbLayer.getCaption("strMessage", objCMS);
            lblAttach = dbLayer.getCaption("strAttachment", objCMS);
            btnSubmit = dbLayer.getCaption("strSendrequest", objCMS);
            btnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
            MsgCase = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgTitle = dbLayer.getCaption("strMandatory", objCMSMSG);
            MsgCaseSubType = dbLayer.getCaption("strMandatory", objCMSMSG);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            lobjCategory = dbLayer.getEnum("strcategorylov", objCMS);
            string lstrCategoryCode = lobjCategory[2].Value;
            strCategoryCode = lstrCategoryCode;
            RequestFilterData(lstrCategoryCode);
            await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
		/// To go the RequestFilterData function
		/// </summary>
        private async void RequestFilterData(string fstrType)
        {
            try
            {
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d&fstrcategorycode=
                lobjCaseType = objBl.RequestFilterData("getCaseType", fstrType);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To go the SubCaseFilterData function
        /// </summary>
        private async void SubCaseFilterData(string fstrCategoryType, string fstrRequestType)
        {
            try
            {
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d
                string[] lstrType = fstrRequestType.Split(':');
                fstrRequestType = lstrType[1];
                lobjSubType = objBl.RequestSubFilterData("getSubCaseType", fstrCategoryType, fstrRequestType);
                //Web Api Timeout
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To click button_send_Message function
        /// </summary>
        private async Task button_send_Message()
        {
            ServiceEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                if ((TxtTitle == null) || (TxtTitle == ""))
                {
                    IsvalidatedTitle = true;
                }
                else
                {
                    gblTrackRequests.strTitle = TxtTitle;
                    IsvalidatedTitle = false;
                }
                if (_selectedCaseType != null)
                {
                            gblTrackRequests.strCaseCode = _selectedCaseType.Value;
                            gblTrackRequests.strCaseDesc1 = _selectedCaseType.Key;
                            gblTrackRequests.strCaseDesc2 = _selectedCaseType.Key;
                    IsvalidatedCase = false;
                }
                else
                {
                    IsvalidatedCase = true;
                }
                if (_selectedSubType != null)
                {
                    string[] lstrTempData = _selectedSubType.Value.Split(':');
                    gblTrackRequests.strCategoryCode = lstrTempData[0].ToString().Trim();
                    gblTrackRequests.strCaseCode = lstrTempData[1].ToString().Trim();
                    gblTrackRequests.strRequestTypeCode = lstrTempData[2].ToString().Trim();
                    gblTrackRequests.strSubCaseCode = lstrTempData[3].ToString().Trim();
                    IsvalidatedSubCase = false;
                }
                else
                {
                    IsvalidatedSubCase = true;
                }
                if ((IsvalidatedTitle == false) && (IsvalidatedCase == false) && (IsvalidatedSubCase == false))
                {
                    gblTrackRequests.strTitle = "Service Request";
                    gblTrackRequests.strSubCaseDesc1 = "";
                    gblTrackRequests.strSubCaseDesc2 = "";
                    string lstrMsg = TxtMessage.ToString().Trim();
                    await gblRegisteration.getreguser();
                    string lstrDate = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                    string lstrResult = objWebApi.postWebApi("NewTruckService", gblTrackRequests.TruckRequest(lstrMsg, lstrDate));
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    gblTrackRequests.strFileName = strFileName;
                    gblTrackRequests.strFileType = strFileType;
                    gblTrackRequests.strFileBody = strFileBody;
                    lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    //Web Api Timeout
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    if (lstrResult == "True")
                    {
                        objWebApi.postWebApi("PostSendEmail", gblTrackRequests.TicketMailData(lstrDate, lstrMsg));
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
                        await App.Current.MainPage?.Navigation.PushAsync(new Request_SentMessage());
                    }
                    

                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message.ToString();
            }
            ServiceEn = true;
            IsBusy = false;
        }

        /// <summary>
        ///To click gotoChooseFile button
        /// </summary>
        private async Task gotoChooseFile()
        {
            ServiceEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "com.adobe.pdf", "public.rft", "com.microsoft.word.doc", "org.openxmlformats.wordprocessingml.document" }; 
                }
                await PickAndShow(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ServiceEn = true;
            IsBusy = false;
        }

        /// <summary>
        /// To navigate to PickAndShow function
        /// </summary>
        private async Task PickAndShow(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    LblFilename = true;
                    ImgCancel = true;
                    Ischoosefile = false;
                    lblFilename = pickedFile.FileName.ToString();
                    strFileName = pickedFile.FileName;
                    int lintLastDotPos = strFileName.LastIndexOf('.');
                    string lstrLoadFileType = strFileName.Substring(lintLastDotPos + 1);
                    strFileType = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    strFileBody = temp_inBase64;
                }
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }

        /// <summary>
        /// To click cancel button
        /// </summary>
        private async Task gotocancel()
        {
            ServiceEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                LblFilename = false;
                lblFilename = "";
                ImgCancel = false;
                Ischoosefile = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            ServiceEn = true;
            IsBusy = false;
        }
    }
}
