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
    class Inquiry_requestViewModel : INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        //To declare Variables
        public string strCategoryCode = "";
        public string strServerSlowMsg = "";
        string strFileName = "";
        string strFileType = "";
        string strFileBody = "";
        //gotoChooseFile Button 
        public Command gotoChooseFile { get; set; }
        //gotoCancel Button 
        public Command gotoCancel { get; set; }
        //Button_send_Message Button 
        public Command Button_send_Message { get; set; }
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
        //To declare Set property
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
        private List<EnumCombo> _lobjCaseTypes = new List<EnumCombo>();
        public List<EnumCombo> lobjCaseTypes
        {
            get { return _lobjCaseTypes; }
            set
            {
                if (_lobjCaseTypes == value)
                    return;
                _lobjCaseTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjCaseTypes");
            }
        }
        //To declare Combo variable
        private List<EnumCombo> _lobjSubTypes = new List<EnumCombo>();
        public List<EnumCombo> lobjSubTypes
        {
            get { return _lobjSubTypes; }
            set
            {
                if (_lobjSubTypes == value)
                    return;
                _lobjSubTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("lobjSubTypes");
            }
        }        
        //To declare Combo variable
        private EnumCombo _selectedCaseTypes;
        public EnumCombo SelectedCaseTypes
        {
            get { return _selectedCaseTypes; }
            set
            {
                SetProperty(ref _selectedCaseTypes, value);
                if (SelectedCaseTypes != null)
                {
                    SubCaseFilterData(strCategoryCode, SelectedCaseTypes.Value);//SubcaseFilter
                }
            }
        }
        //To declare Combo variable
        private EnumCombo _selectedSubTypes;
        public EnumCombo SelectedSubTypes
        {
            get { return _selectedSubTypes; }
            set
            {
                SetProperty(ref _selectedSubTypes, value);
            }
        }
        //To declare boolean variable
        private bool inquiryEn = true;
        public bool InquiryEn
        {
            get { return inquiryEn; }
            set
            {
                inquiryEn = value;
                OnPropertyChanged();
                RaisePropertyChange("InquiryEn");
            }
        }
        //imginfodark purpose of using image varaiable
        private string imginfodark = "";
        public string ImgInfodark
        {
            get { return imginfodark; }
            set
            {
                imginfodark = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgInfodark");
            }
        }
        //lblreqinfo purpose of using label varaiable
        private string lblreqinfo = "";
        public string lblReqinfo
        {
            get { return lblreqinfo; }
            set
            {
                lblreqinfo = value;
                OnPropertyChanged();
                RaisePropertyChange("lblReqinfo");
            }
        }
        //lbltitles purpose of using label varaiable
        private string lbltitles = "";
        public string lblTitles
        {
            get { return lbltitles; }
            set
            {
                lbltitles = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTitles");
            }
        }
        //txtTitle2 purpose of using text varaiable
        private string txtTitle2 = "";
        public string TxtTitle2
        {
            get { return txtTitle2; }
            set
            {
                txtTitle2 = value;
                OnPropertyChanged();
                RaisePropertyChange("TxtTitle2");
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
        //msgTitle purpose of using data varaiable
        private string placeTitle2 = "";
        public string PlaceTitle2
        {
            get { return placeTitle2; }
            set
            {
                placeTitle2 = value;
                OnPropertyChanged();
                RaisePropertyChange("PlaceTitle2");
            }
        }
        //lbltitles purpose of using label varaiable
        private string lblcaseTypes = "";
        public string lblCaseTypes
        {
            get { return lblcaseTypes; }
            set
            {
                lblcaseTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCaseTypes");
            }
        }
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
        private string lblcaseSubTypes = "";
        public string lblCaseSubTypes
        {
            get { return lblcaseSubTypes; }
            set
            {
                lblcaseSubTypes = value;
                OnPropertyChanged();
                RaisePropertyChange("lblCaseSubTypes");
            }
        }
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
        private string lblmessages = "";
        public string lblMessages
        {
            get { return lblmessages; }
            set
            {
                lblmessages = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessages");
            }
        }
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
        private string lblattachment = "";
        public string lblAttachment
        {
            get { return lblattachment; }
            set
            {
                lblattachment = value;
                OnPropertyChanged();
                RaisePropertyChange("lblAttachment");
            }
        }
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
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
        //lbltitles purpose of using label varaiable
        private string btnsubmits = "";
        public string btnSubmits
        {
            get { return btnsubmits; }
            set
            {
                btnsubmits = value;
                OnPropertyChanged();
                RaisePropertyChange("btnSubmits");
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
        private bool choosefile = true;
        public bool Choosefile
        {
            get { return choosefile; }
            set
            {
                choosefile = value;
                OnPropertyChanged();
                RaisePropertyChange("Choosefile");
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
                gotoCancel.ChangeCanExecute();
                Button_send_Message.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin Inquiry request ViewModel Constructor
        /// </summary>
        public Inquiry_requestViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("Inquiry_requestViewModel");
                //To Call Caption Function 
                Task.Run(() => assignCms()).Wait();
                //Begin-All Command Buttons
                gotoChooseFile = new Command(async () => await gotochooseFile(), () => !IsBusy);
                gotoCancel = new Command(async () => await gotocancel(), () => !IsBusy);
                Button_send_Message = new Command(async () => await button_send_Message(), () => !IsBusy);
                //End-Call Command Button
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End Inquiry request View Model constructor
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
                await Task.Delay(3000);
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
                await Task.Delay(1000);
                
                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;
                    
                //}
              
                dbLayer.objInfoitems = objCMS;
                lobjCategory = dbLayer.getEnum("strcategorylov", objCMS);
                string lstrCategoryCode = lobjCategory[1].Value;
                strCategoryCode = lstrCategoryCode;
                RequestFilterData(lstrCategoryCode);
                ImgInfodark = dbLayer.getCaption("imgrequestInfo", objCMS);
                lblReqinfo = dbLayer.getCaption("strRequestforinformation", objCMS);
                lblTitles = dbLayer.getCaption("strTitle", objCMS);
                lblCaseTypes = dbLayer.getCaption("strCasetype1", objCMS);
                lblCaseSubTypes = dbLayer.getCaption("strSubject", objCMS);
                lblMessages = dbLayer.getCaption("strMessage", objCMS);
                lblAttachment = dbLayer.getCaption("strAttachment", objCMS);
                btnSubmits = dbLayer.getCaption("strSendrequest", objCMS);
                btnChooseFile = dbLayer.getCaption("strChoosefile", objCMS);
                MsgCase = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgTitle = dbLayer.getCaption("strMandatory", objCMSMSG);
                MsgCaseSubType = dbLayer.getCaption("strMandatory", objCMSMSG);
                strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End assignContent function
        /// <summary>
        /// To go RequestFilterData filter option
        /// </summary>
        /// <param name="fstrType"></param>
        private async void RequestFilterData(string fstrType)
        {
            try
            {
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d&fstrcategorycode=
                lobjCaseTypes = objBl.RequestFilterData("getCaseType", fstrType);
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
        /// To go SubCaseFilterData filter option
        /// </summary>
        /// <param name="fstrCategoryType"></param>
        /// <param name="fstrRequestType"></param>
        private async void SubCaseFilterData(string fstrCategoryType, string fstrRequestType)
        {
            try
            {
                //https://localhost:44348/api/DataSource/getCaseType?fstrType=6027a8a7-800d-ed11-b7fb-d566c50e2c51
                // https://localhost:44348/api/DataSource/getSubCaseType?fstrType=d0756a46-7303-e911-8109-005056bcd89d:fdf089d8-7303-e911-8109-005056bcd89d:5827a8a7-800d-ed11-b7fb-d566c50e2c51:57e2683a-9e09-e911-810b-005056bcd89d
                string[] lstrType = fstrRequestType.Split(':');
                fstrRequestType = lstrType[1];
                lobjSubTypes = objBl.RequestSubFilterData("getSubCaseType", fstrCategoryType, fstrRequestType);
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
        /// To click button_send_Message button
        /// </summary>
        /// <returns></returns>
        private async Task button_send_Message()
        {
            InquiryEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                if ((TxtTitle2 == null) || (TxtTitle2 == ""))
                {
                    IsvalidatedTitle = true;
                }
                else
                {
                    gblTrackRequests.strTitle = TxtTitle2;
                    IsvalidatedTitle = false;
                }
                if (_selectedCaseTypes != null)
                {
                    gblTrackRequests.strCaseCode = _selectedCaseTypes.Value;
                    gblTrackRequests.strCaseDesc1 = _selectedCaseTypes.Key;
                    gblTrackRequests.strCaseDesc2 = _selectedCaseTypes.Key;
                    IsvalidatedCase = false;
                }
                else
                {
                    IsvalidatedCase = true;
                }
                if (_selectedSubTypes != null)
                {
                    string[] lstrTempData = _selectedSubTypes.Value.Split(':');
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
                    gblTrackRequests.strTitle = "Inquiry Request";
                    string lstrMsg = TxtMessage.ToString().Trim();
                    await gblRegisteration.getreguser();
                    string lstrDate = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "Z";
                    string lstrResult = objWebApi.postWebApi("NewTruckService", gblTrackRequests.TruckRequest(lstrMsg, lstrDate));
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    gblTrackRequests.strFileName = strFileName;
                    gblTrackRequests.strFileType = strFileType;
                    gblTrackRequests.strFileBody = strFileBody;
                    lstrResult = objWebApi.postWebApi("NewTicketAttachments", gblTrackRequests.TicketAttach());
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    if (lstrResult == "True")
                    {
                        objWebApi.postWebApi("PostSendEmail", gblTrackRequests.TicketMailData(lstrDate, lstrMsg));
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
            InquiryEn = true;
            IsBusy = false;
        }
        /// <summary>
        /// To click gotochooseFile button
        /// </summary>
        /// <returns></returns>
        private async Task gotochooseFile()
        {
            try
            {
                InquiryEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "com.adobe.pdf", "public.rft", "com.microsoft.word.doc", "org.openxmlformats.wordprocessingml.document" }; // same as iOS constant UTType.Image
                }
                await PickAndShow(fileTypes);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            InquiryEn = true;
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
                    lblFilename = pickedFile.FileName;
                    ImgCancel = true;
                    Choosefile = false;
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
        private async Task gotocancel()
        {
            InquiryEn = false;
            IsBusy = true;
            await Task.Delay(1000);
            try
            {
                LblFilename = false;
                lblFilename = "";
                ImgCancel = false;
                Choosefile = true;
                //btnChooseFile.IsVisible = true;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            InquiryEn = true;
            IsBusy = false;
        }
    }
}
