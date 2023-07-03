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
    class Complaint_requestViewModel : INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //To declare Variable
        public string strServerSlowMsg = "";
        public string strCategoryCode = "";
        //To declare Combo variable
        private List<EnumCombo> _lobjCaseType1 = new List<EnumCombo>();
        public List<EnumCombo> lobjCaseType1
        {
            get { return _lobjCaseType1; }
            set
            {
                if (_lobjCaseType1 == value)
                    return;
                _lobjCaseType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCaseTypes");
            }
        }
        //To declare Combo variable
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
        //To declare Combo variable
        private List<EnumCombo> _lobjSubType1 = new List<EnumCombo>();
        public List<EnumCombo> lobjSubType1
        {
            get { return _lobjSubType1; }
            set
            {
                if (_lobjSubType1 == value)
                    return;
                _lobjSubType1 = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCaseTypes");
            }
        }
        //Clicked button
        public Command Button_Clicked { get; set; }
        //Cancel button
        public Command btnCancel { get; set; }
        //Choose file button
        public Command gotoChooseFile { get; set; }
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
        //To declare set property
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
        // Two way binding  IndicatorViewOpacity process on Propertychange Event
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
            }
        }
        // Two way binding  IndicatorViewOpacity process on Propertychange Event
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
            }
        }
        //To declare Variable
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
        //To declare combo variable
        private EnumCombo _selectedCaseType1;
        public EnumCombo SelectedCaseType1
        {
            get { return _selectedCaseType1; }
            set
            {
                SetProperty(ref _selectedCaseType1, value);
                if (SelectedCaseType1 != null)
                {
                    SubCaseFilterData(strCategoryCode, SelectedCaseType1.Value);
                }
            }
        }
        //To declare combo variable
        private EnumCombo _selectedSubType1;
        public EnumCombo SelectedSubType1
        {
            get { return _selectedSubType1; }
            set
            {
                SetProperty(ref _selectedSubType1, value);
            }
        }
        //To declare boolean variable
        private bool complaintEn = true;
        public bool ComplaintEn
        {
            get { return complaintEn; }
            set
            {
                complaintEn = value;
                OnPropertyChanged();
                RaisePropertyChange("ComplaintEn");
            }
        }
        //imgRequestsService purpose of using image varaiable
        private string imgRequestsService = "";
        public string ImgRequestsService
        {
            get { return imgRequestsService; }
            set
            {
                imgRequestsService = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequestsService");
            }
        }
        //lblcomplaint purpose of using label varaiable
        private string lblcomplaint = "";
        public string lblComplaint
        {
            get { return lblcomplaint; }
            set
            {
                lblcomplaint = value;
                OnPropertyChanged();
                RaisePropertyChange("lblComplaint");
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
        //txtTitle1 purpose of using text varaiable
        private string txtTitle1 = "";
        public string TxtTitle1
        {
            get { return txtTitle1; }
            set
            {
                txtTitle1 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTitle1");
            }
        }
        //msgTitle purpose of using text varaiable
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
        //btnattach purpose of using button varaiable
        private string btnattach = "";
        public string btnAttach
        {
            get { return btnattach; }
            set
            {
                btnattach = value;
                OnPropertyChanged();
                RaisePropertyChange("btnAttach");
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
        //To declare Boolean variable
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
        //To declare Boolean variable
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
        //To declare Boolean variable
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
        //To declare Boolean variable
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
        //To declare Boolean variable
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
        //To declare Boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                gotoChooseFile.ChangeCanExecute();
                btnCancel.ChangeCanExecute();
                Button_Clicked.ChangeCanExecute();
            }
        }
        //To declare Boolean variable
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
        /// Begin Complaint request ViewModel Constructor 
        /// </summary>
        public Complaint_requestViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("Complaint_requestViewModel");
                //To Call Caption Function
                Task.Run(() => assignCms()).Wait();
                //Begin call Command Buttons
                Button_Clicked = new Command(async () => await button_Clicked(), () => !IsBusy);
                btnCancel = new Command(async () => await btncancel(), () => !IsBusy);
                gotoChooseFile = new Command(async () => await gotochooseFile(), () => !IsBusy);
                //To end call Command Buttons
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End Complaint request View Model constructor
        /// <summary>
        /// Begin assignCms function
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
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        //End assignCms function
        /// <summary>
        /// Begin assignContent function
        /// </summary>
        public async void assignContent()
        {
            try
            {
               
                lobjCategory = dbLayer.getEnum("strcategorylov", objCMS);
                string lstrCategoryCode = lobjCategory[0].Value;
                strCategoryCode = lstrCategoryCode;
                RequestFilterData(lstrCategoryCode);
              
                dbLayer.objInfoitems = objCMS;
                ImgRequestsService = dbLayer.getCaption("imgRequestService", objCMS);
                lblComplaint = dbLayer.getCaption("strComplains", objCMS);
                lblTitle = dbLayer.getCaption("strTitle", objCMS);
                lblCaseType = dbLayer.getCaption("strCasetype1", objCMS);
                lblCaseSubType = dbLayer.getCaption("strSubject", objCMS);
                lblMessage = dbLayer.getCaption("strMessage", objCMS);
                btnAttach = dbLayer.getCaption("strAttachment", objCMS);
                btnSubmit = dbLayer.getCaption("strSendrequest", objCMS);
                btnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
                MsgCase = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgTitle = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCaseSubType = dbLayer.getCaption("strMandatory", objCMSMSG);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
        /// To Click the RequestFilterData function
        /// </summary>
        /// <param name="fstrType"></param>
        private async void RequestFilterData(string fstrType)
        {
            try
            {
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d&fstrcategorycode=
                lobjCaseType1 = objBl.RequestFilterData("getCaseType", fstrType);
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
        /// To navigate to SubCaseFilterData function
        /// </summary>
        /// <param name="fstrCategoryType"></param>
        /// <param name="fstrRequestType"></param>
        private async void SubCaseFilterData(string fstrCategoryType, string fstrRequestType)
        {
            try
            {
                //We are using the below Get API's for filter section
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                //https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d&fstrcategorycode=
                string[] lstrType = fstrRequestType.Split(':');
                fstrRequestType = lstrType[1];
                lobjSubType1 = objBl.RequestSubFilterData("getSubCaseType", fstrCategoryType, fstrRequestType);
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
        /// To click cancel button 
        /// </summary>
        /// <returns></returns>
        private async Task button_Clicked()
        {
            ComplaintEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                if ((TxtTitle1 == null) || (TxtTitle1 == ""))
                {
                    IsvalidatedTitle = true;
                }
                else
                {
                    gblTrackRequests.strTitle = TxtTitle1;
                    IsvalidatedTitle = false;
                }
                if (_selectedCaseType1 != null)
                {
                    gblTrackRequests.strCaseCode = _selectedCaseType1.Value;
                    gblTrackRequests.strCaseDesc1 = _selectedCaseType1.Key;
                    gblTrackRequests.strCaseDesc2 = _selectedCaseType1.Key;
                    IsvalidatedCase = false;
                }
                else
                {
                    IsvalidatedCase = true;
                }
                if (_selectedSubType1 != null)
                {
                    string[] lstrTempData = _selectedSubType1.Value.Split(':');
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
                    gblTrackRequests.strTitle = "Compliant Request";
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
                    if (strFileBody != "")
                    {
                        lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                        //Web Api Timeout
                        if (AppSettings.ErrorExceptionWebApi != "")
                        {
                           App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                        }
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
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message.ToString();
            }
            ComplaintEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To click Choose File button
        /// </summary>
        /// <returns></returns>
        private async Task gotochooseFile()
        {
            ComplaintEn = false;
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
            ComplaintEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To navigate to PickAndShow function
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <returns></returns>
        private async Task PickAndShow(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    LblFilename = true;
                    lblFilename = pickedFile.FileName.ToString();
                    ImgCancel = true;
                    Ischoosefile = false;
                    int lintLastDotPos = strFileName.LastIndexOf('.');
                    string lstrLoadFileType = strFileName.Substring(lintLastDotPos + 1);
                    strFileType = lstrLoadFileType;
                    string temp_inBase64 = Convert.ToBase64String(pickedFile.DataArray);
                    strFileBody = temp_inBase64;// pickedFile.FilePath;
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
        /// <returns></returns>
        private async Task btncancel()
        {
            ComplaintEn = false;
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
            ComplaintEn = true;
            IsBusy = false;
        }
    }
}
